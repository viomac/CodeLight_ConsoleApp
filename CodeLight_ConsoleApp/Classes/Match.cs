using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLight_ConsoleApp
{
    public class Match
    {
        public int Line { get; private set; }
        public int Column { get; set; }

        public Match(int line)
        {
            Line = line;
            Column = -1;
        }
        public Match(int line, int column)
        {
            Line = line;
            Column = column;
        }

    }
}


        /*public string FilePath { get; private set; }
        public WordMatch()
        {
            FilePath = null;
            Line = -1;
            Column = -1;
        }
        */