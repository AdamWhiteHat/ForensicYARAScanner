using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ForensicYARAScanner
{
	public class ScanParameters
	{
		public CancellationToken CancelToken { get; set; }
		public string SelectedFolder { get; set; }
		public string[] SearchPatterns { get; set; }
		public List<YaraFilter> YaraParameters { get; set; }
		public Action<string> ReportOutputFunction { get; set; }
		public Action<string> LogOutputFunction { get; set; }
		public Action<List<string>> ReportResultsFunction { get; set; }
		public Action<string, string, Exception> ReportExceptionFunction { get; set; }
		public IDataPersistenceLayer DataPersistenceLayer { get; set; }

		public ScanParameters(CancellationToken cancelToken,
								string selectedFolder,
								string searchPatterns,
								List<YaraFilter> yaraParameters,
								IDataPersistenceLayer dataPersistenceLayerClass,
								Action<string> reportOutputFunction,
								Action<string> logOutputFunction,
								Action<List<string>> reportResultsFunction,
								Action<string, string, Exception> reportExceptionFunction)
		{
			this.CancelToken = cancelToken;
			this.SelectedFolder = selectedFolder;
			this.YaraParameters = yaraParameters;
			this.DataPersistenceLayer = dataPersistenceLayerClass;
			this.ReportOutputFunction = reportOutputFunction;
			this.LogOutputFunction = logOutputFunction;
			this.ReportResultsFunction = reportResultsFunction;
			this.ReportExceptionFunction = reportExceptionFunction;
			this.SearchPatterns = ParseSearchPatterns(searchPatterns);
		}

		private string[] ParseSearchPatterns(string searchPattern)
		{
			string[] patterns = new string[] { ".exe", ".dll", ".sys", ".drv", ".ocx", ".com", ".scr" };

			if (!string.IsNullOrWhiteSpace(searchPattern))
			{
				patterns = searchPattern.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
				patterns = patterns.Select(s => s.Contains(".") ? s.Replace("*", "") : s).ToArray();
			}

			return patterns;

		}

		public void ThrowIfAnyParametersInvalid()
		{
			if (DataPersistenceLayer == null) { throw new ArgumentException(nameof(DataPersistenceLayer)); }
			if (SearchPatterns == null) { throw new ArgumentNullException(nameof(SearchPatterns)); }
			if (ReportExceptionFunction == null) { throw new ArgumentNullException(nameof(ReportExceptionFunction)); }
			if (ReportOutputFunction == null) { throw new ArgumentNullException(nameof(ReportOutputFunction)); }
			if (LogOutputFunction == null) { throw new ArgumentNullException(nameof(LogOutputFunction)); }
			if (ReportResultsFunction == null) { throw new ArgumentNullException(nameof(ReportResultsFunction)); }
			if (string.IsNullOrWhiteSpace(SelectedFolder)) { throw new ArgumentNullException(nameof(SelectedFolder)); }
			if (!Directory.Exists(SelectedFolder)) { throw new DirectoryNotFoundException(SelectedFolder); }

			char suppliedDriveLetter = char.ToUpper(SelectedFolder[0]);

			List<char> foundDriveLetters = DriveInfo.GetDrives()
													.Where(d => d.IsReady && d.DriveFormat == "NTFS")
													.Select(di => di.Name.ToUpper()[0])
													.ToList();

			if (!foundDriveLetters.Any() || !foundDriveLetters.Contains(suppliedDriveLetter))
			{
				throw new DriveNotFoundException($"The drive {suppliedDriveLetter}:\\ was not found, the drive was not mounted or ready, or the drive had a file system other than NTFS.");
			}

			if (CancelToken == null) { throw new ArgumentNullException(nameof(CancelToken), "If you do not want to pass a CancellationToken, then pass 'CancellationToken.None'"); }
			CancelToken.ThrowIfCancellationRequested();
		}
	}
}
