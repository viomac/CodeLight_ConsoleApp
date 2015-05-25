using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLight_ConsoleApp
{
    public interface IWordDictionary
    {
        Dictionary<string, Dictionary<string, List<Match>>> dictionary { get; }
        void addItem(string word, string path, Match match);
        void removePath(string path);
        Dictionary<string,List<Match>> lookfor(string word);
    }
}
