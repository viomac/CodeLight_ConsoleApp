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
    public class Dictionary
    {
        IWordDictionary dict;

        [SetUp]
        public void SetUp() {
            dict = new WordDictionary();
            dict.addItem("word", "path", new Match(6, 8));
            dict.addItem("word", "path2", new Match(6, 7));
            dict.addItem("word", "path2", new Match(56, 23));
            dict.addItem("word", "path2", new Match(34, 98));

            dict.addItem("word2", "path2", new Match(6, 7));
            dict.addItem("word2", "path2", new Match(56, 23));
            dict.addItem("word2", "path2", new Match(34, 98));
        }

        [Test]
        public void addItems() {
            Assert.AreEqual(dict.dictionary.Count,2);
            Assert.AreEqual(dict.dictionary["word"].Count, 2);
            Assert.AreEqual(dict.dictionary["word2"].Count,1);
            Assert.AreEqual(dict.dictionary["word2"]["path2"].Count, 3);

            dict.addItem("word3","path", new Match(1,2));
            dict.addItem("word3", "path", new Match(12, 24));
            dict.addItem("word3","path2", new Match(3,94));
            dict.addItem("word3","path3", new Match(73,35));

            Assert.AreEqual(dict.dictionary.Count,3);
            Assert.AreEqual(dict.dictionary["word3"].Count,3);
            Assert.AreEqual(dict.dictionary["word3"]["path"].Count,2); 
        } 

        [Test]
        public void removeItems() {
            dict.removePath("path2");
            Assert.AreEqual(dict.dictionary.Count, 1);
            Assert.That(dict.dictionary.ContainsKey("word2"), Is.False);
        } 

        [Test]
        public void lookforWord() {
            Dictionary<string, List<Match>> ocurrences = dict.lookfor("word");
            Assert.AreEqual(ocurrences.Count,2);
            Assert.AreEqual(ocurrences["path2"].Count,3); 
        }

    }
}
