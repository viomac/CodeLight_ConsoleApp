using System;
using NUnit.Framework;
using CodeLight_ConsoleApp;
using System.Collections.Generic;

namespace Test_CodeLight
{
	[TestFixture]
	public class DictionaryMethods{

		IWordDictionary dict;

		[SetUp]
		public void SetUp(){
			dict = new WordDictionary ();
			dict.AddOccurrence ("word1","path1",1 ,new List<int>(){5,6});
			dict.AddOccurrence ("word1","path1",6 ,new List<int>(){4});
			dict.AddOccurrence ("word1","path1",58,new List<int>(){15,22,71});
			dict.AddOccurrence ("word2","path1",1 ,new List<int>(){25,32});
			dict.AddOccurrence ("word2","path1",23,new List<int>(){6});

			dict.AddOccurrence ("word1","path2",24,new List<int>(){11});
			dict.AddOccurrence ("word3","path2",1 ,new List<int>(){13,24});

			dict.AddOccurrence ("word1","path3",3,new List<int>(){1,23});
		}

		[Test]
		public void AddItems(){
			dict.AddOccurrence ("word4", "path1", 13, new List<int> (){ 7 });
			dict.AddOccurrence ("word5","path1",12,new List<int>(){67});

			Assert.AreEqual (dict.dictionary.Count,5);
			Assert.AreEqual (dict.dictionary ["word1"].Count, 3);
			Assert.AreEqual (dict.dictionary ["word1"]["path1"].Count, 3);
			Assert.AreEqual (dict.dictionary ["word1"]["path1"][58].Count, 3);
			Assert.AreEqual (dict.dictionary ["word1"]["path1"][58], new List<int>(){15,22,71});
		} 

		[Test]
		public void RemovePath(){
			Assert.AreEqual (dict.dictionary.Count,3);
			dict.RemoveMatchesInPath ("path1");
			Assert.AreEqual (dict.dictionary.Count,2);
			Assert.That (dict.dictionary.ContainsKey("word4"),Is.False);
		}

		[Test]
		public void lookforWord(){
			Dictionary<string, Dictionary<int, List<int>>> occurrences = dict.Lookfor ("word1");
			Assert.AreEqual (occurrences.Count,3);
			Assert.AreEqual (occurrences["path1"].Count,3);
			Assert.AreEqual (occurrences["path2"].Count,1);
			Assert.AreEqual (occurrences["path1"][58].Count,3);
			Assert.That (occurrences["path1"][6][0], Is.EqualTo(4));
			Assert.AreEqual (occurrences["path1"][58][2], 71);
			Assert.AreEqual (occurrences["path1"][58],new List<int>(){15,22,71});
			Assert.That (occurrences["path1"][58].Contains(22));
		}
	}
}

