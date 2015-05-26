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
        void AddOccurrence(string word, string path, Match match);
        void RemoveMatchesInPath(string path);
        Dictionary<string,List<Match>> Lookfor(string word);
    }
}
