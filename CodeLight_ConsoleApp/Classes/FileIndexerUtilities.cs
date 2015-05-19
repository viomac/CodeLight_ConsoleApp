using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLight_ConsoleApp
{
    public static class FileIndexerUtilities
    {

        public static Dictionary<string, int> GetWords(string line) {
            var words = new Dictionary<string, int>();
            int begin = 0, end = 0;
            end = line.IndexOf(' ', begin);
            while (end != -1)
            {
                words.Add(line.Substring(begin, end - begin), begin + 1);
                begin = end + 1;
                end = line.IndexOf(' ', begin);
            }
            end = line.Length;
            words.Add(line.Substring(begin, end - begin), begin + 1);
            return words;
        }
    }
}
