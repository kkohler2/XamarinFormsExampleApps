using Android.OS;
using Android.Util;
using System;

namespace FileObserver.Droid.Services
{
    public class TestFileObserver : Android.OS.FileObserver
    {
        static FileObserverEvents _Events = (FileObserverEvents.CloseWrite);
        public event EventHandler<string> ScanFile;

        [Obsolete]
        public TestFileObserver(string rootPath) : base(rootPath, _Events)
        {
            Log.Debug("FileObserver",$"Watching folder for HID badge swipes: {rootPath}");
            StartWatching();
        }

        public override void OnEvent(FileObserverEvents e, string path)
        {
            //if (path.EndsWith(".txt"))
            {
                ScanFile?.Invoke(this, path);
            }
        }
    }
}