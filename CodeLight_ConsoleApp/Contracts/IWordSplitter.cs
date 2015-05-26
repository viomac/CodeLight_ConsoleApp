using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLight_ConsoleApp
{
    public interface IWordSplitter
    {
       Dictionary<string, int> SplitIntoWords(string line);
    }
}
