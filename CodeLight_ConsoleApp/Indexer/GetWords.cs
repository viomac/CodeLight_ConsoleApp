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
        Dictionary<string, List<Match>> wordMatch;
            
        public GetWords() { 
            this.wordColumn = new Dictionary<string,int>();
            this.wordMatch = new Dictionary<string, List<Match>>();
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

        public Dictionary<string, List<Match>> getWords(string[] lines)
        {
            int lineNumber = 1;
            foreach (string line in lines)
            {
                this.getWords(line);// IndexLine(line, lineNumber, Path, ref dictionary);
                lineNumber++;
            }
            return wordMatch;
        }


    }
}
