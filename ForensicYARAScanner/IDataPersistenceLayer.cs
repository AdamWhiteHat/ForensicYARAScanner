using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForensicYARAScanner
{
	public interface IDataPersistenceLayer : IDisposable
	{
		bool PersistFileProperties(ScanResults fileProperties);
	}
}
