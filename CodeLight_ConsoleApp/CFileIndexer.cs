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

        public FileIndexer(IWordFilter wordFilter) {
            this.filter = wordFilter;
        }        

        public IDictionary<string, List<WordMatch>> Index(string[] paths)
        {
            var dictionary = new Dictionary<string,List<WordMatch>>();
            foreach (string path in paths) {    
                IndexFile(ref dictionary, path);
            }
            return dictionary;
        }

        void IndexFile(ref Dictionary<string,List<WordMatch>> dictionary, string path) {
            string[] lines = this.getLines(path); 
            IndexLines(ref dictionary, lines, path);
        }

        string[] getLines(string path)
        {
            string[] lines = System.IO.File.ReadAllLines(path);
            return lines;
        }

        void IndexLines(ref Dictionary<string, List<WordMatch>> dictionary, string[] lines, string Path)
        {
            int numberOfLine = 1;
            foreach( string line in lines ){
                IndexWords(ref dictionary, line, numberOfLine, Path);
                numberOfLine++;
            }
        }

        void IndexWords(ref Dictionary<string,List<WordMatch>> dictionary, string line,int numberOfLine, string path) {
            string word;
            int lenghtWord, begin = 0, end = 0;
            end = line.IndexOf(' ', begin);
            while (end != -1)
            {
                lenghtWord = end - begin;
                word = line.Substring(begin, end - begin);
                if (!this.filter.ContainsWord(word))
                {
                    var wordMatch = new WordMatch(path, numberOfLine);
                    wordMatch.Column = begin + 1;
                    this.AddMatchToDictionary(ref dictionary,word, wordMatch);
                }
                begin = end + 1;
                end = line.IndexOf(' ', begin);
            }
            lenghtWord = line.Length - begin;
            word = line.Substring(begin, lenghtWord);
            if (!this.filter.ContainsWord(word))
            {
                var wordMatch2 = new WordMatch(path, numberOfLine);
                wordMatch2.Column = begin + 1;
                this.AddMatchToDictionary(ref dictionary, word, wordMatch2);
            }
        }

        void AddMatchToDictionary(ref Dictionary<string,List<WordMatch>> dictionary, string word, WordMatch match)
        {            
            if (!dictionary.ContainsKey(word)){
                var listOfMatch = new List<WordMatch>();
                listOfMatch.Add(match);
                dictionary.Add(word, listOfMatch);
            }
            else{
                dictionary[word].Add(match);
            }            
        }

    }
}
