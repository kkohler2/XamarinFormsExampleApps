using Java.Lang;
using ReadLogcat.Droid.Services;
using ReadLogcat.Interfaces;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(LogService))]
namespace ReadLogcat.Droid.Services
{
    public class LogService : ILogService
    {
        public void LogCat()
        {
            try
            {
                string logFile = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), "log.txt");
                Android.Util.Log.Debug("ReadLogcat", $"LogFile: {logFile}");
                Runtime.GetRuntime().Exec($"logcat -d -f {logFile}");

                using(StreamReader reader = new StreamReader(logFile))
                {
                    string line;
                    while((line = reader.ReadLine()) != null)
                    {
                        // Filter data as needed and send to server here.
                        System.Diagnostics.Debug.WriteLine($"Log: {line}");
                    }
                }
            }
            catch (System.Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
    }
}