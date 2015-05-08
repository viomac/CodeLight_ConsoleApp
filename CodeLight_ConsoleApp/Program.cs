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
        public string FilePath;
        public int Line;
        public int Column;

        public WordMatch() { 
            FilePath = null; 
            Line = -1; 
            Column = -1; 
        }
        public WordMatch(string filePath, int line, int column) { 
            FilePath = filePath; 
            Line = line; 
            Column = column; }
    }

    class Program
    {
        //static Dictionary<string,object> FileIndexer (string path);
        static void FileIndexer(string path)
        {
            var dictionary = new Dictionary<string, WordMatch>();
            string[] lines = System.IO.File.ReadAllLines(path);
            string word;
            int col = 0, separatorIndex;

            foreach (string line in lines)
            {
                for (int i = 0; i < line.Length; i++)
                {
                    separatorIndex = line.IndexOf(' ');

                }
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
            string line = "Hola mundo mundo";
            string word;
            int begin = 0, end = 0;

            end = line.IndexOf(' ',begin);
            Console.WriteLine(end);

            while( begin <= line.Length){
                end = line.IndexOf(' ',begin);
                word = line.Substring(begin,end-1);
                Console.WriteLine(word);
                begin = end + 1;
            }





            var datos = new WordMatch("Path", 5, 67);
            var datos2 = new WordMatch();
            datos2.FilePath = "Ruta2";
            datos2.Line = 27;
            datos2.Column = 56;
            var dictionary = new Dictionary<string, WordMatch>();

            dictionary.Add("word1", datos);
            dictionary.Add("word2", datos2);

            foreach (KeyValuePair<string, WordMatch> pair in dictionary)
            {
                Console.WriteLine("Palabra:{0}, Ruta:{1}, renglon: {2}, columna: {3}", pair.Key, pair.Value.FilePath, pair.Value.Line, pair.Value.Column);
            }

            string path = @"..\..\..\TestFiles\Test1.txt";
            string[] words_array = { "while", "for", "var", "int", "class", "case" };
            var keywords = new HashSet<string>(words_array);

            FileIndexer(path);

            Console.ReadLine();

        }
    }
}
