using Android.Content;
using CheckForUpgrade.Droid.Services;
using CheckForUpgrade.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(UpgradeService))]
namespace CheckForUpgrade.Droid.Services
{
    public class UpgradeService : IUpgradeService
    {
        public void Upgrade()
        {
            try
            {
                var intent = new Intent();
                intent.SetFlags(ActivityFlags.NewTask);
                intent.SetComponent(new ComponentName("com.fsl.android.ota", "com.fsl.android.ota.OtaAppActivity"));
                Android.App.Application.Context.StartActivity(intent);
            }
            catch (System.Exception)
            {
            }
        }
    }
}