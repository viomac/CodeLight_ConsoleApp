using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLight_ConsoleApp
{
    interface ILookup
    {
        IList<WordMatch> SearchWord(string word);
    }
}
