using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLight_ConsoleApp
{
    public class keyWordsFilter : IWordFilter
    {
        static List<string> filter = new List<string> { "while", "for", "var", "int", "class", "case" };
        public bool ShouldKeep(string word) {
            return !filter.Contains(word);
        }
    }
}
