using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CodeLight_ConsoleApp
{
    public static class FileSystemUtilities
    {
        public static List<string> GetFiles(string[] directories) {
            var filePaths = new List<string>();

            foreach (string p in directories)
            {
                filePaths.AddRange(Directory.GetFiles(p, "*", SearchOption.AllDirectories));
            }

            return filePaths;
        }
    }
}
