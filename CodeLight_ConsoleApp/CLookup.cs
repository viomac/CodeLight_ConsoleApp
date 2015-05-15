using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLight_ConsoleApp
{
    class Lookup : ILookup
    {
        public IList<WordMatch> SearchWord(string word) { 
            var occurrences = new List<WordMatch>();
            return occurrences;
        }
    }
}
