using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;

namespace ForensicYARAScanner
{
	public class ScanResults
	{
		public uint MFTNumber { get; private set; }
		public ushort SequenceNumber { get; private set; }
		public string Sha256Hash { get; private set; }

		public ulong Length { get; private set; }
		public char DriveLetter { get; private set; }
		public string FullPath { get; private set; }
		public string FileName { get; private set; }
		public string Extension { get; private set; }
		public string DirectoryLocation { get; private set; }

		public DateTime MftTimeAccessed { get; set; }
		public DateTime MftTimeCreation { get; set; }
		public DateTime MftTimeModified { get; set; }
		public DateTime MftTimeMftModified { get; set; }

		public bool IsPe { get; private set; }
		public string MimeType { get; private set; }

		public List<string> YaraDetections { get; set; }

		public ScanResults()
		{
			YaraDetections = new List<string>();
		}

		public string PopulateYaraInfo(List<YaraFilter> yaraFilters)
		{
			List<string> distinctRulesToRun =
				yaraFilters
				.SelectMany(yf => yf.ProcessRule(this))
				.Distinct()
				.OrderBy(s => s)
				.ToList();

			if (!distinctRulesToRun.Any())
			{
				distinctRulesToRun =
					yaraFilters
						.Where(yf => yf.FilterType == YaraFilterType.ElseNoMatch)
						.SelectMany(yf => yf.OnMatchRules)
						.Distinct()
						.ToList();
			}

			if (!distinctRulesToRun.Any())
			{
				return string.Empty;
			}

			string yaraIndexContents = YaraHelper.MakeYaraIndexFile(distinctRulesToRun);

			string indexFileHash = Sha256Helper.GetSha256Hash_Array(Encoding.UTF8.GetBytes(yaraIndexContents));

			string yaraIndexFilename = Path.Combine(Path.GetTempPath(), $"{indexFileHash}-index.yar");

			if (!File.Exists(yaraIndexFilename))
			{
				File.WriteAllText(yaraIndexFilename, yaraIndexContents);
			}

			return yaraIndexFilename;
		}
	}
}
