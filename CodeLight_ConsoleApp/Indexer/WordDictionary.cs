using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLight_ConsoleApp
{
    public class WordDictionary : IWordDictionary
    {
        public Dictionary<string, Dictionary<string, List<Match>>> dictionary { get; private set; }

        public WordDictionary()
        {
            dictionary = new Dictionary<string, Dictionary<string, List<Match>>>();
        }

        public void AddOccurrence(string word, string path, Match match)
        {
            if (!dictionary.ContainsKey(word))
                dictionary.Add(word, new Dictionary<string, List<Match>>());
            dictionary[word].AddItem(path, match);

        }

        public void RemoveMatchesInPath(string path)
        {
            var removeWords = new List<string>();
            foreach (var wordEntry in dictionary)
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

        public Dictionary<string, List<Match>> Lookfor(string word)
        {
            return dictionary[word];
        }
    }
}
