using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLight_ConsoleApp
{
    public interface IIndexer
    {
        void IndexDirectories(List<string> directories);
        IDictionary<string, List<Match>> LookUp(string word);        
    }
}
