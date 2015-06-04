using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CodeLight_ConsoleApp
{
	public class FileIndexer : IFileIndexer{
		IWordFilter wordFilter;
		IWordSplitter getWords;

		public FileIndexer (IWordFilter wordFilter, IWordSplitter getWords){
			this.wordFilter = wordFilter;
			this.getWords = getWords;
		}

		public void IndexFile (string path, ref IWordDictionary dictionary){
			string[] lines = System.IO.File.ReadAllLines (path);
			int lineNumber = 1;
			foreach (string line in lines){
				IndexLine (line, lineNumber, path, ref dictionary);
				lineNumber++;
			}
		}

		internal void IndexLine (string line, int LineNumber, string path, ref IWordDictionary dictionary){
			Dictionary<string,List<int>> words = getWords.SplitIntoWords (line); 
			foreach (KeyValuePair<string,List<int>> word in words){
				if (wordFilter.ShouldKeep(word.Key)){
					dictionary.AddOccurrence (word.Key, path, LineNumber,word.Value);
				}
			}
		}

	}
}
