using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeLight_ConsoleApp
{
    public interface IFileWatcher
    {
        void Watch(string dirPath);
        void StopWatch();
    }
}
