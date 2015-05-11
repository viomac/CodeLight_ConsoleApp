using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLight_ConsoleApp
{
    public class WordMatch
    {
        public string FilePath { get; private set; }
        public int Line { get; set; }
        public int Column { get; set; }

        public WordMatch()
        {
            FilePath = null;
            Line = -1;
            Column = -1;
        }
        public WordMatch(string filePath)
        {
            FilePath = filePath;
            Line = -1;
            Column = -1;
        }
        public WordMatch(string filePath, int line, int column)
        {
            FilePath = filePath;
            Line = line;
            Column = column;
        }
    }


    class Program
    {
        //static Dictionary<string,object> FileIndexer (string path);
        static void FileIndexer(string path)
        {
            string[] words_array = { "while", "for", "var", "int", "class", "case" };
            var keywords = new HashSet<string>(words_array);
            string[] lines = System.IO.File.ReadAllLines(path);
			var dictionary = new Dictionary<string, WordMatch>();
            int numberOfLine = 1;

            foreach (string line in lines)
            {
                string word;
                int lenghtWord;
                int begin = 0, end = 0;
                if (line.Length != 0)
                {
                    end = line.IndexOf(' ', begin);
                    while (end != -1)
                    {
                        lenghtWord = end - begin;
                        word = line.Substring(begin, end - begin);
                        if (!words_array.Contains(word))
                        {                           
                            var wordMatch = new WordMatch(path);
                            wordMatch.Line = numberOfLine;
                            wordMatch.Column = begin+1;
                            //dictionary.Add(word, wordMatch);
							Console.WriteLine("Word: {0}, line: {1}, column: {2}", word, wordMatch.Line, wordMatch.Column);
                        }
                        begin = end + 1;
                        end = line.IndexOf(' ', begin);
                    }
					lenghtWord = line.Length - begin;
					word = line.Substring (begin, lenghtWord);
					if (!words_array.Contains (word)) {
						var wordMatch2 = new WordMatch (path);
						wordMatch2.Line = numberOfLine;
						wordMatch2.Column = begin + 1;
						//dictionary.Add (word, wordMatch2);
						Console.WriteLine ("Word: {0}, line: {1}, column: {2}", word, wordMatch2.Line, wordMatch2.Column);
					}
                }
                numberOfLine++;
            }
        }

        static string[] GetFiles(string[] directories)
        {
            var filePaths = new List<string>();
            foreach (string p in directories)
            {
                filePaths.AddRange(Directory.GetFiles(p, "*", SearchOption.AllDirectories));
            }
            return filePaths.ToArray();
        }


        static void Main(string[] args)
        {
			

            string path = @"..\..\..\TestFiles\Test1.txt";
            FileIndexer(path);

            Console.ReadLine();

        }
    }
}
