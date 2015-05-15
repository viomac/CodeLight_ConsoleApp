using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CodeLight_ConsoleApp
{
    public class FileIndexer : IFileIndexer
    {
        IWordFilter filter;

        public FileIndexer(IWordFilter wordFilter)
        {
            this.filter = wordFilter;
        }
        
        public IDictionary<string, List<WordMatch>> IndexDirectory(string[] directories)
        {
            var dictionary = new Dictionary<string, List<WordMatch>>();           
            foreach (string path in FileSystemUtilities.GetFiles(directories))
            {
                IndexFile(path, ref dictionary);
            }
            return dictionary;
        }

        void IndexFile(string path, ref Dictionary<string, List<WordMatch>> dictionary)
        {
            string[] lines = System.IO.File.ReadAllLines(path);
            IndexLines(lines, path, ref dictionary);
        }

        void IndexLines(string[] lines, string Path, ref Dictionary<string, List<WordMatch>> dictionary)
        {
            int numberOfLine = 1;
            foreach (string line in lines)
            {
                IndexWords(line, numberOfLine, Path, ref dictionary);
                numberOfLine++;
            }
        }

        internal void IndexWords(string line, int numberOfLine, string path, ref Dictionary<string, List<WordMatch>> dictionary)
        {
            string word;
            int lenghtWord, begin = 0, end = 0, column;
            WordMatch wordMatch;
            end = line.IndexOf(' ', begin);
            while (end != -1)
            {
                lenghtWord = end - begin;
                word = line.Substring(begin, end - begin);
                column = begin+1;
                wordMatch = new WordMatch(path, numberOfLine, column);
                if (this.filter.ShouldKeep(word))
                {
                    FileIndexerUtilities.AddMatch(word, wordMatch, ref dictionary);
                }
                begin = end + 1;
                end = line.IndexOf(' ', begin);
            }
            lenghtWord = line.Length - begin;
            word = line.Substring(begin, lenghtWord);
            column = begin + 1;
            wordMatch = new WordMatch(path, numberOfLine, column);
            if (this.filter.ShouldKeep(word))
            {
                FileIndexerUtilities.AddMatch(word, wordMatch, ref dictionary);
            }
        }      

    }
}
