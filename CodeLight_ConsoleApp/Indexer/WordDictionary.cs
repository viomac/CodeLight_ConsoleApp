using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLight_ConsoleApp
{
    public class WordDictionary : IWordDictionary
    {
		public Dictionary<string, Dictionary<string, Dictionary<int,List<int>>>> dictionary { get; private set; }

		public WordDictionary (){
			dictionary = new Dictionary<string, Dictionary<string, Dictionary<int, List<int>>>> ();
		}

		public void AddOccurrence (string word, string path, int line, List<int> column)
		{
			if (!dictionary.ContainsKey (word))
				dictionary.Add (word, new Dictionary<string, Dictionary<int, List<int>>> ());
			if (!dictionary [word].ContainsKey (path))
				dictionary [word].Add (path, new Dictionary<int, List<int>> ());

				dictionary [word] [path].Add (line, column);
		}

		public void RemoveMatchesInPath (string path)
		{
			var removeWords = new List<string>();
			foreach (KeyValuePair<string, Dictionary<string, Dictionary<int,List<int>>>> wordEntry in dictionary)
			{
				wordEntry.Value.Remove(path);
				if (wordEntry.Value.Count == 0)					
					removeWords.Add(wordEntry.Key);
			}
			foreach (var word in removeWords)
			{
				dictionary.Remove(word);
			}
		}

		public Dictionary<string, Dictionary<int, List<int>>> Lookfor(string word){
			return dictionary[word];
		}
    }
}
