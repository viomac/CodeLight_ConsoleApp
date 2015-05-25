using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLight_ConsoleApp
{
    public class GetWords:IGetWords
    {
        Dictionary<string, int> wordColumn;

        public GetWords() { 
            this.wordColumn = new Dictionary<string,int>();
        } 
        public Dictionary<string, int> getWords(string line) 
        {            
            int begin = 0, end = 0;
            end = line.IndexOf(' ', begin);
            while (end != -1)
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
