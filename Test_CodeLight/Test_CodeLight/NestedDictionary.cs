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
        [Test]
        public void nestedDictionary() {
            var dictionary = new Dictionary<string, Dictionary<string, List<Match>>>();
            var matches = new List<Match>();
            matches.Add(new Match(6, 7));
            matches.Add(new Match(56,23));
            matches.Add(new Match(34,98));

            dictionary.Add("word", new Dictionary<string, List<Match>>() { {"path", matches} });
            dictionary.Add("word2", new Dictionary<string, List<Match>>() { { "path2", matches } });

            Assert.AreEqual(dictionary.Count,2); 
            Assert.AreEqual(dictionary["word"].Count, 1);  
            Assert.AreEqual(dictionary["word2"].Count, 1);
            Assert.That(dictionary["word"]["path"].Count, Is.EqualTo(3)); 
            Assert.That(dictionary["word2"]["path2"].Count, Is.EqualTo(3)); 

            Assert.AreEqual(dictionary["word"]["path"][2],matches[2]);
        }

        [Test]
        public void AddNestedDictionary() {
            var wordMatch = new Dictionary<string, List<Match>>();
            wordMatch.AddItem("Path",new Match(6, 8));

            wordMatch.AddItem("Path2", new Match(6, 7));
            wordMatch.AddItem("Path2", new Match(56, 23));
            wordMatch.AddItem("Path2", new Match(34,98));
            
            var dictionary = new Dictionary<string, Dictionary<string, List<Match>>>();
            dictionary.Add("word",wordMatch);
            
            var match = new List<Match>();
            match.Add(new Match(6,7));

            Assert.AreEqual(dictionary.Count, 1); 
            Assert.AreEqual(dictionary["word"].Count,2); 
            Assert.AreEqual(dictionary["word"]["Path"].Count, 1); 
            Assert.AreEqual(dictionary["word"]["Path2"].Count, 3);
            Assert.AreEqual(dictionary["word"]["Path2"][2].Column, 98);
            Assert.AreEqual(dictionary["word"]["Path2"][2].Line, 34);

            //Assert.AreEqual(dictionary["word"]["Path2"][0], new Match(6,8));

            

            
        }
    }
}
