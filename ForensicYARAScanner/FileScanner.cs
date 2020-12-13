using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Filesystem.Ntfs;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForensicYARAScanner
{
	public class FileScanner
	{
		public static void LaunchFileEnumerator(ScanParameters parameters)
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

			return new List<string> { };
		}

		public static ScanResults PopulateFileProperties(ScanParameters parameters, char driveLetter, INode node)
		{
			throw new NotImplementedException();
		}
	}
}
