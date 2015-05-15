using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLight_ConsoleApp
{
    public interface IFileIndexer
    {
        IDictionary<string, List<WordMatch>> IndexDirectory(string[] directories);
    }
}
