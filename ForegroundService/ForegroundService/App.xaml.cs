using ForegroundService.Interfaces;
using Xamarin.Forms;

namespace ForegroundService
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
            var service = DependencyService.Get<IForegroundService>();
            service.BringToForeground();
        }

        protected override void OnResume()
        {
        }
    }
}
