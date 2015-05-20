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
    public class NestedDictionary
    {
        Dictionary<string, Dictionary<string, List<Match>>> dictionary;

        [SetUp]
        public void SetUp_Dictionary()
        {
            dictionary = new Dictionary<string, Dictionary<string, List<Match>>>();

            var matches = new List<Match>();
            matches.Add(new Match(6, 7));
            matches.Add(new Match(56, 23));
            matches.Add(new Match(34, 98));

            var wordMatch = new Dictionary<string, List<Match>>();
            wordMatch.AddItem("Path", new Match(6, 8));
            wordMatch.AddItem("Path2", new Match(6, 7));
            wordMatch.AddItem("Path2", new Match(56, 23));
            wordMatch.AddItem("Path2", new Match(34, 98));

            dictionary.Add("word", wordMatch);
            dictionary.Add("word2", new Dictionary<string, List<Match>>() { { "Path2", matches } });
        }


        [Test]
        public void nestedDictionary() {

            Assert.AreEqual(dictionary.Count,2); 
            Assert.AreEqual(dictionary["word"].Count, 2);  
            Assert.AreEqual(dictionary["word2"].Count, 1);
            Assert.AreEqual(dictionary["word"]["Path"].Count, 1);
            Assert.AreEqual(dictionary["word"]["Path2"].Count, 3);
 
            Assert.That(dictionary["word2"]["Path2"].Count, Is.EqualTo(3));
            Assert.AreEqual(dictionary["word"]["Path2"][2].Column, 98);
            Assert.AreEqual(dictionary["word"]["Path2"][2].Line, 34);
            Assert.That(dictionary["word"]["Path"][0].Equals(new Match(6,8)));
            Assert.That(dictionary["word"]["Path2"][2].Equals(new Match(34, 98)));
            Assert.That(dictionary["word"]["Path"][0].Equals(new Match(6, 8)));
        }

        [Test]
        public void AddNestedDictionary() {
            var wordMatch = new Dictionary<string, List<Match>>();
            wordMatch.AddItem("Path", new Match(12, 24));
            dictionary.Add("word3", wordMatch);

            Assert.AreEqual(dictionary.Count, 3);
            Assert.AreEqual(dictionary["word3"].Count, 1);
        }

        [Test]
        public void DeleteByWord_NestedDictionary() {
            Assert.AreEqual(dictionary["word"].Count, 2);
            Assert.That(dictionary["word"].Remove("Path2"));
            Assert.AreEqual(dictionary["word"].Count, 1);
        }

        [Test]
        public void DeletebyPath_NestedDictionary()
        {
            Assert.AreEqual(dictionary.Count, 2);
            FileIndexerUtilities.DeletePath("Path2", ref dictionary);
            Assert.AreEqual(dictionary["word"].Count, 1);
            Assert.AreEqual(dictionary.Count, 1);
            Assert.That(dictionary.ContainsKey("word2"), Is.EqualTo(false));

            FileIndexerUtilities.DeletePath("Path", ref dictionary);
            Assert.AreEqual(dictionary.Count,0);
        }
    }
}
