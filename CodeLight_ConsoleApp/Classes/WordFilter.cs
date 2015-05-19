using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLight_ConsoleApp
{
    public class KeywordsFilter : IWordFilter
    {
        static List<string> filter = new List<string> { "while", "for", "var", "int", "class", "case", "if" };
        public bool ShouldKeep(string word) {
            return !filter.Contains(word);
        }
    }
}
