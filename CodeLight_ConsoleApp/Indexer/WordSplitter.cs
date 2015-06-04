using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace CodeLight_ConsoleApp
{
    public class WordSplitter :IWordSplitter
    {
        public Dictionary<string, List<int>> SplitIntoWords(string line) 
        {            
			var wordColumn = new Dictionary<string, List<int>>();
			string[] words = SplitWords (line);
			int column=0, begin=0;

			if( words.Length != 0){
				for (int i = 0; i < words.Length; i++) 
				{
					column = line.IndexOf (words[i], begin);
					wordColumn.AddItem(words[i],column+1);
					begin = column + words [i].Length;
				}
			}
            return wordColumn;
        }

		string[] SplitWords(string s)
		{
			string[] words = Regex.Split(s, @"\W+");
			List<string> wordsWithoutNulls = words.ToList();
			wordsWithoutNulls.Remove ("");
			return wordsWithoutNulls.ToArray();
		}
        
    }
}
