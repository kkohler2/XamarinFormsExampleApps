using ReadLogcat.Interfaces;
using System;
using System.IO;
using Xamarin.Forms;

namespace ReadLogcat
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            string logFile = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), "log.txt");
            if (File.Exists(logFile))
            {
                File.Delete(logFile);
            }
            var logService = DependencyService.Get<ILogService>();
            logService.LogCat();
        }
    }
}
