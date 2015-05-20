using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Test_CodeLight
{
    [TestFixture]
    public class FileWatcher
    {
        [Test]
        public void Creating_Dirs() {
            string mainDir = @"..\..\..\WatcherTest";
            var dir = new DirectoryInfo(mainDir);
            dir.Create();
            dir.CreateSubdirectory(@"dir1\dir11\dir111");
            dir.CreateSubdirectory(@"dir2\dir22");
            string filePath = Path.Combine(mainDir, "text1.txt");
            var file = File.Create(filePath);
            file.Close();
            dir.Delete(true);
        }

    }
}
