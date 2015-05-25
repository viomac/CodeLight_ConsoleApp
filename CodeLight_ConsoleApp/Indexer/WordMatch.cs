using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLight_ConsoleApp
{
    public class WordMatch
    {
        public string FilePath { get; private set; }
        public int Line { get; private set; }
        public int Column { get; set; }

        public WordMatch()
        {
            FilePath = null;
            Line = -1;
            Column = -1;
        }
        public WordMatch(string filePath, int line)
        {
            FilePath = filePath;
            Line = line;
            Column = -1;
        }
        public WordMatch(string filePath, int line, int column)
        {
            FilePath = filePath;
            Line = line;
            Column = column;
        }
    }
}
