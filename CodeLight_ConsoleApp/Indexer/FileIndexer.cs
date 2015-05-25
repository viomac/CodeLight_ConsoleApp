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
        IWordFilter wordFilter;

        public FileIndexer(IWordFilter wordFilter)
        {
            this.wordFilter = wordFilter;
        }
        
        public IDictionary<string, List<WordMatch>> IndexDirectories(string[] directories)
        {
            var dictionary = new Dictionary<string, List<WordMatch>>();           
            foreach (string path in FileSystemUtilities.GetAllFiles(directories))
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
            int lineNumber = 1;
            foreach (string line in lines)
            {
                IndexLine(line, lineNumber, Path, ref dictionary);
                lineNumber++;
            }
        }

        internal void IndexLine(string line, int LineNumber, string path, ref Dictionary<string, List<WordMatch>> dictionary)
        {
            Dictionary<string,int> words = FileIndexerUtilities.GetWords(line);            
            foreach(var word in words){
                if (wordFilter.ShouldKeep(word.Key))
                {
                    dictionary.AddItem(word.Key, new WordMatch(path, LineNumber, word.Value));
                }
                
            }
        }      

    }
}
