using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLight_ConsoleApp
{
    public class WordSplitter :IWordSplitter
    {
        Dictionary<string, int> wordColumn;
        Dictionary<string, List<Match>> wordMatch;
            
        public WordSplitter() { 
            this.wordColumn = new Dictionary<string,int>();
            this.wordMatch = new Dictionary<string, List<Match>>();
        } 

        public Dictionary<string, int> SplitIntoWords(string line) 
        {            
            int begin = 0, end = 0;
            end = line.IndexOf(' ', begin);
            while (end != -1 )
            {
                wordColumn.Add(line.Substring(begin, end - begin), begin + 1);
                begin = end + 1;
                end = line.IndexOf(' ', begin);
            }
            end = line.Length;
            wordColumn.Add(line.Substring(begin, end - begin), begin + 1);
            return wordColumn;
        }
        
    }
}
