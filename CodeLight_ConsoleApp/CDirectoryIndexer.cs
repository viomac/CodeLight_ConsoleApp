using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLight_ConsoleApp
{
    public class DirectoryIndexer : IDirectoryIndexer
    {
        public string[] GetFiles(string[] directories)
        {
            var filePaths = new List<string>();
            foreach (string p in directories)
            {
                filePaths.AddRange(Directory.GetFiles(p, "*", SearchOption.AllDirectories));
            }
            return filePaths.ToArray();
        }
    }
}
