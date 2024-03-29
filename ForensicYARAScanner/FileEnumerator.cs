﻿using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO.Filesystem.Ntfs;

namespace ForensicYARAScanner
{
	using NtfsNodeAttributes = System.IO.Filesystem.Ntfs.Attributes;

	public class FileEnumerator
	{
		private static string[] IgnoreTheseRootFiles = Properties.Settings.Default.IgnoreTheseRootFiles.Cast<string>().ToArray();

		private static string[] IgnoreTheseRootDirectories = Properties.Settings.Default.IgnoreTheseRootDirectories.Cast<string>().ToArray();

		private static char[] DirectorySeperatorChars = new char[]
		{
			Path.DirectorySeparatorChar,
			Path.AltDirectorySeparatorChar
		};

		public static IEnumerable<INode> EnumerateFiles(ScanParameters parameters)
		{
			parameters.CancelToken.ThrowIfCancellationRequested();

			StringBuilder currentPath = new StringBuilder(parameters.SelectedFolder);
			string lastParent = currentPath.ToString();

			string temp = currentPath.ToString();
			if (temp.Contains(':') && (temp.Length == 2 || temp.Length == 3)) // Is a root directory, i.e. "C:" or "C:\"
			{
				lastParent = ".";
			}

			string drive = parameters.SelectedFolder[0].ToString().ToUpper();

			List<DriveInfo> ntfsDrives = DriveInfo.GetDrives().Where(d => d.IsReady && d.DriveFormat == "NTFS").ToList();

			DriveInfo driveToAnalyze = ntfsDrives.Where(dr => dr.Name.ToUpper().Contains(drive)).Single();

			NtfsReader ntfsReader = new NtfsReader(driveToAnalyze, RetrieveMode.All);

			IEnumerable<INode> mftNodes =
				ntfsReader.GetNodes(driveToAnalyze.Name)
					.Where(node =>
							(node.Attributes &
							 (NtfsNodeAttributes.Device
							  | NtfsNodeAttributes.Directory
							  | NtfsNodeAttributes.ReparsePoint
							  | NtfsNodeAttributes.SparseFile
							 )
							) == 0) // This means that we DONT want any matches of the above NtfsNodeAttributes type
					.Where(node => FileMatchesPattern(node.FullName));

			if (parameters.SelectedFolder.ToCharArray().Length > 3)
			{
				string selectedFolderUppercase = parameters.SelectedFolder.ToUpperInvariant().TrimEnd(new char[] { '\\' });
				mftNodes = mftNodes.Where(node => node.FullName.ToUpperInvariant().Contains(selectedFolderUppercase));
			}

			return mftNodes;
		}

		private static bool FileMatchesPattern(string fullName)
		{
			string filename = Path.GetFileName(fullName);
			string rootDirectory = Path.GetDirectoryName(fullName).Substring(3);

			int seperatorIndex = rootDirectory.IndexOfAny(DirectorySeperatorChars);
			if (seperatorIndex != -1)
			{
				rootDirectory = rootDirectory.Substring(0, seperatorIndex);
			}

			/* if (filename.FirstOrDefault() == '$') { return false; } */

			if (string.IsNullOrWhiteSpace(rootDirectory))
			{
				if (IgnoreTheseRootFiles.Contains(filename))
				{
					return false;
				}
			}
			else
			{
				if (IgnoreTheseRootDirectories.Any(dir => rootDirectory.Equals(dir)))
				{
					return false;
				}
			}

			return true;
		}
	}
}
