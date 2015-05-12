using CodeLight_ConsoleApp;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Test_CodeLight
{
	[TestFixture ()]
	public class Test
	{
        [Test ()]
        public void Test_ClassDirectoryIndexer() {

            string[] paths = {@"..\..\..\TestFiles\Extra2",
                              @"..\..\..\TestFiles\Extra5"};
            string[] files = {@"..\..\..\TestFiles\Extra2\Test4.txt",
                              @"..\..\..\TestFiles\Extra2\Test5.txt",
                              @"..\..\..\TestFiles\Extra5\Test7.txt",
                              @"..\..\..\TestFiles\Extra5\Test8.txt",
                              @"..\..\..\TestFiles\Extra5\Test9.txt",
                              };

            var directories = new CodeLight_ConsoleApp.ConcreteDirectoryIndexer();
            string[] filesResult = directories.GetFiles(paths);
            Assert.AreEqual(files, filesResult);
        }

        [Test()]
        public void Test_ListOfWordMatch() {

            var dicionary = new Dictionary<string,List<WordMatch>>;

            var item1 = new WordMatch("path1",3,4);
            var item2 = new WordMatch("path2",5,24);
            var item3 = new WordMatch("path3",18,56);
            var listOfMatch = new List<WordMatch>();

            listOfMatch.Add(item1);
            listOfMatch.Add(item2);
            listOfMatch.Add(item3);

            string word = "hola";
            
            var AddMatchs = new CAddMatchToDictionary();

            AddMatchs.AddMatch(word,listOfMatch);
 
        }
	}
}

