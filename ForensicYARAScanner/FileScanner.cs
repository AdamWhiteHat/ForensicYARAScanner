using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Filesystem.Ntfs;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ForensicYARAScanner
{
	public class FileScanner
	{
		public static void LaunchFileScan(ScanParameters parameters)
		{
			var fileEnumerationDelegate
				= new Func<ScanParameters, List<string>>((args) => Worker(args));

			Task<List<string>> enumerationTask = Task.Run(() =>
			{
				List<string> results = new List<string>();
				results.AddRange(fileEnumerationDelegate.Invoke(parameters));
				return results;
			},
			parameters.CancelToken);

			Task reportResultsTask = enumerationTask.ContinueWith((antecedent) => parameters.ReportResultsFunction(antecedent.Result));
		}

		private static List<string> Worker(ScanParameters parameters)
		{
			List<string> resultsAggregate = new List<string>();

			try
			{
				IEnumerable<INode> mftNodes = FileEnumerator.EnumerateFiles(parameters);
				IDataPersistenceLayer dataPersistenceLayer = parameters.DataPersistenceLayer;

				foreach (INode node in mftNodes)
				{
					string message = $"MFT#: {node.MFTRecordNumber.ToString().PadRight(7)} Seq.#: {node.SequenceNumber.ToString().PadRight(4)} Path: {node.FullName}";

					if (parameters.LogOutputFunction != null) parameters.LogOutputFunction.Invoke(message);
					if (parameters.ReportOutputFunction != null) parameters.ReportOutputFunction.Invoke(message);

					ScanResults results = new ScanResults();
					results = PopulateFileProperties(parameters, parameters.SelectedFolder[0], node);

					resultsAggregate.AddRange(results.YaraDetections);

					// Insert scan results into IDataPersistenceLayer
					bool insertResult = dataPersistenceLayer.PersistFileProperties(results);
					if (insertResult)
					{

					}
					else
					{

					}

					parameters.CancelToken.ThrowIfCancellationRequested();
				}

				dataPersistenceLayer.Dispose();
			}
			catch (OperationCanceledException)
			{ }

			return resultsAggregate;
		}

		public static ScanResults PopulateFileProperties(ScanParameters parameters, char driveLetter, INode node)
		{
			CancellationToken cancelToken = parameters.CancelToken;
			cancelToken.ThrowIfCancellationRequested();

			ScanResults results = new ScanResults();

			byte[] fileBytes = new byte[0];
			if (!node.Streams.Any()) //workaround for no file stream such as with hard links
			{
				try
				{
					using (FileStream fsSource = new FileStream(node.FullName,
						FileMode.Open, FileAccess.Read))
					{

						// Read the source file into a byte array.
						fileBytes = new byte[fsSource.Length];
						int numBytesToRead = (int)fsSource.Length;
						int numBytesRead = 0;
						while (numBytesToRead > 0)
						{
							// Read may return anything from 0 to numBytesToRead.
							int n = fsSource.Read(fileBytes, numBytesRead, numBytesToRead);

							// Break when the end of the file is reached.
							if (n == 0)
								break;

							numBytesRead += n;
							numBytesToRead -= n;
						}
						numBytesToRead = fileBytes.Length;

					}
				}
				catch
				{ }
			}
			else
			{
				fileBytes = node.GetBytes().SelectMany(chunk => chunk).ToArray();
				cancelToken.ThrowIfCancellationRequested();
			}

			string yaraIndexFilename = results.PopulateYaraInfo(parameters.YaraParameters);

			if (!string.IsNullOrWhiteSpace(yaraIndexFilename))
			{
				results.YaraDetections = YaraHelper.ScanBytes(fileBytes, yaraIndexFilename);
			}

			throw new NotImplementedException();

			return results;
		}

	}
}
