using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLight_ConsoleApp
{
    public interface IWordDictionary
    {
		Dictionary<string, Dictionary<string, Dictionary<int,List<int>>>> dictionary { get; }
		void AddOccurrence(string word, string path, int line, List<int> column);
		void RemoveMatchesInPath(string path);
		Dictionary<string, Dictionary<int, List<int>>> Lookfor(string word);
    }
}
