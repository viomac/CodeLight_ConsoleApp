
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLight_ConsoleApp
{


    [TestFixture]
    public class AddToDictionary
    {
        IDictionary<string, List<WordMatch>> dictionary;
        IWordFilter filter;

        [SetUp]
        public void SetUp(){
            dictionary = new Dictionary<string, List<WordMatch>>();
            filter = new KeywordsFilter();

            dictionary.AddItem("hola", new WordMatch(@"\..\..\Dir1", 12, 3));
            dictionary.AddItem("hola", new WordMatch(@"\..\..\Dir1", 6, 1));
            dictionary.AddItem("prueba", new WordMatch(@"\..\..\Dir2", 34, 51));
        }

        [Test]
        public void AddMatch()
        {
            Assert.That(dictionary.Count, Is.EqualTo(2));
            Assert.That(dictionary["hola"].Count, Is.EqualTo(2));     
        }        
    }
}
