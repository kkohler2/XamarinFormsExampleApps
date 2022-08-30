using FileObserver.Droid.Services;
using System;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileObserverService))]
namespace FileObserver.Droid.Services
{
    public class FileObserverService : IFileObserverService
    {
        private TestFileObserver _testFileObserver;
        private const string _filePath = "/sdcard";

        [Obsolete]
        public FileObserverService()
        {
            _testFileObserver = new TestFileObserver(_filePath);
            _testFileObserver.ScanFile += ReadHIDScanFile;
        }

        private void ReadHIDScanFile(object sender, string file)
        {
            // Do something here with observed file...
        }
    }
}