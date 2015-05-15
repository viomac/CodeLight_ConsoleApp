using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLight_ConsoleApp
{
    static class FileIndexerUtilities
    {
        public static void AddMatch(string word, WordMatch match, ref Dictionary<string, List<WordMatch>> dictionary)
        {
            if (!dictionary.ContainsKey(word))
            {
                var listOfMatch = new List<WordMatch>();
                listOfMatch.Add(match);
                dictionary.Add(word, listOfMatch);
            }
            else
            {
                dictionary[word].Add(match);
            }
        }
    }
}
