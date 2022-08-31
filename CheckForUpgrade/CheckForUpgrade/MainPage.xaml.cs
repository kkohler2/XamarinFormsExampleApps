using CheckForUpgrade.Interfaces;
using System;
using Xamarin.Forms;

namespace CheckForUpgrade
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var upgradeService = DependencyService.Get<IUpgradeService>();
            upgradeService.Upgrade();
        }
    }
}
