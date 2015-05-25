using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLight_ConsoleApp
{
    public class WordDictionary: IWordDictionary
    {
        public Dictionary<string, Dictionary<string, List<Match>>> dictionary { get; private set; }

        public WordDictionary() 
        {
            dictionary = new Dictionary<string, Dictionary<string, List<Match>>>();
        }

        public void addItem(string word, string path, Match match) 
        {
            if(!dictionary.ContainsKey(word))
                dictionary.Add(word, new Dictionary<string, List<Match>>());
            dictionary[word].AddItem(path,match);

        }

        public void removePath(string path)
        {
            var removeWords = new List<string>();            
            foreach (var wordMatch in dictionary)
            {
                wordMatch.Value.Remove(path);
                if (wordMatch.Value.Count == 0)
                    removeWords.Add(wordMatch.Key);
            }
            foreach (var word in removeWords)
            {
                dictionary.Remove(word);
            }
        }

        public Dictionary<string, List<Match>> lookfor(string word) 
        {
            return dictionary[word];
        }
    }
}
