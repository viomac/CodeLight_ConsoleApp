
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLight_ConsoleApp
{
    [TestFixture]
    public class TestAddToDictionary
    {
        [Test]
        public void AddToDictionary()
        {
            var dictionary = new Dictionary<string, List<WordMatch>>();
            var filter = new keyWordsFilter();
            FileIndexerUtilities.AddMatch("hola", new WordMatch(@"\..\..\Dir1", 12, 3), ref dictionary);
            FileIndexerUtilities.AddMatch("hola", new WordMatch(@"\..\..\Dir1", 6, 1), ref dictionary);
            FileIndexerUtilities.AddMatch("prueba", new WordMatch(@"\..\..\Dir2", 34, 51), ref dictionary);
            Assert.That(dictionary.Count, Is.EqualTo(3));
            Assert.That(dictionary["hola"].Count, Is.EqualTo(2));     
        }
    }
}
