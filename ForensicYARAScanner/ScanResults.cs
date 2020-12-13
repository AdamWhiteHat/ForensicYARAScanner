using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ForensicYARAScanner
{
	public class ScanResults
	{
		public List<string> DetectedRules { get; private set; }

		public ScanResults()
		{
			DetectedRules = new List<string>();
		}
	}
}
