using Android.App;
using Android.Content;
using ForegroundService.Interfaces;
using Plugin.CurrentActivity;
using Xamarin.Forms;
using static Android.App.ActivityManager;
using static Android.App.PendingIntent;

[assembly: Dependency(typeof(ForegroundService.Droid.Services.ForegroundService))]
namespace ForegroundService.Droid.Services
{
    public class ForegroundService : IForegroundService
    {
        // https://stackoverflow.com/questions/12074980/bring-application-to-front-after-user-clicks-on-home-button
        // https://forums.xamarin.com/discussion/134696/how-to-tell-if-android-app-is-in-the-background-or-foreground

        // Note: This does NOT APPEAR TO WORK!!!

        public void BringToForeground()
        {
            RunningAppProcessInfo myProcess = new RunningAppProcessInfo();
            GetMyMemoryState(myProcess);
            if (myProcess.Importance != Importance.Foreground)
            {
                Intent notificationIntent = new Intent(CrossCurrentActivity.Current.AppContext, typeof(MainActivity));
                //notificationIntent.SetFlags(ActivityFlags.ClearTop | ActivityFlags.SingleTop);
                notificationIntent.SetFlags(ActivityFlags.NewTask | ActivityFlags.ResetTaskIfNeeded);
                PendingIntent pendingIntent = PendingIntent.GetActivity(CrossCurrentActivity.Current.AppContext, 0, notificationIntent, 0);
                try
                {
                    pendingIntent.Send();
                }
                catch (CanceledException e)
                {
                    //e.PrintStackTrace();
                }
            }
        }
    }
}