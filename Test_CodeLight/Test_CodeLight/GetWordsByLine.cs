using CodeLight_ConsoleApp;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_CodeLight
{
    [TestFixture]
    public class GetWordsByLine
    {
		IWordSplitter splitter;

        [SetUp]
        public void Setup()
        {
            splitter = new WordSplitter();
        }
                
        [Test]
        public void EmptyLine() {
			Dictionary<string, List<int>> wordList = splitter.SplitIntoWords("");
			Assert.AreEqual(wordList.Count,0);
			Assert.That(wordList.ContainsKey(""),Is.False);
        } 

		[Test]
		public void wordsByLine(){
			string line = "This is a simple... function() , (   ) {  } array[] example, simple;,,   SimpleExample  ,  ";
			Dictionary<string, List<int>> wordList = splitter.SplitIntoWords(line);
			Assert.AreEqual (wordList.Count,8);
			Assert.That (wordList.ContainsKey ("function"));
			Assert.That (wordList.ContainsKey ("array"));
			Assert.That (wordList.ContainsKey (""), Is.False);
			Assert.AreEqual (wordList["simple"].Count, 2);
			Assert.AreEqual (wordList["simple"], new List<int>{11,62});
			Assert.AreEqual (wordList["This"], new List<int>{1});

		}
        
    }
}
