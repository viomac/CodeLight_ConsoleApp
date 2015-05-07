using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLight_ConsoleApp
{
    class Program
    {
  
        //static Dictionary<string,object> FileIndexer (string path);
        static void FileIndexer(string path) {
            string line;
            //foreach (string fl in filePaths) {
            using (StreamReader sr = new StreamReader(path)){
                string[] words;
                while ((line = sr.ReadLine()) != null){
                    words = line.Split(' ');
                    foreach (string w in words){
                        Console.WriteLine(w);
                    }
                }
            }
            //}
        }

        static string[] GetFiles(string[] directories) {
            var filePaths = new List<string>();
            foreach (string p in directories)            {
                filePaths.AddRange(Directory.GetFiles(p, "*", SearchOption.AllDirectories));
            }
            return filePaths.ToArray();
        }

        static void Main(string[] args)
        {
            //Create keywords set
            var words = new string[]{"while","for","var","int","class","case"};
            string[] words_array = { "while", "for", "var", "int", "class", "case" };
            var keywords = new HashSet<string>(words_array);

            //Get files from directories
            string path = @"TestFiles\Test1.txt";
            string[] paths = {@"TestFiles\Extra2",
                              @"TestFiles\Extra5"};

            foreach (string fl in paths) { Console.WriteLine(fl); }
            string[] filePaths = GetFiles(paths);
            
            Console.WriteLine("File names from selected directories:");
            foreach (string fl in filePaths) { Console.WriteLine(fl); }

            FileIndexer(path);
            
            /*string[] dirs = Directory.GetDirectories(path,"*");
            Console.WriteLine("The number of directories is {0}.", dirs.Length);
            foreach (string dir in dirs) {
                Console.WriteLine(dir);
            } */
            
            //var res = FileIndexer(path);
            Console.ReadLine();

        }
    }
}
