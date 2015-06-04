using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLight_ConsoleApp
{
    public interface IFileIndexer
    {
        void IndexFile(string path, ref IWordDictionary dictionary);
		//void RemoveFile(string path, ref IWordDictionary dictionary);
		//void updateFile(string path, ref IWordDictionary dictionary);
    }
}
