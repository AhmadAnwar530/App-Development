using System;

using Android.App;
using Android;
using Android.Content;
using Android.Net;
using Android.Provider;
using Uri = Android.Net.Uri;
using Android.Support.V4.Content;
using Android.Support.V4.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using ZXing.Mobile;
using Acr.UserDialogs;
using Plugin.LocalNotification;
using Acr.UserDialogs.Extended;
using Android.Graphics.Drawables;
using System.Drawing;
namespace NoWaste.Droid
{
    [Activity(Label = "Nil Waste", Icon = "@mipmap/icon", Theme = "@style/MainTheme",  ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {



        protected override void OnCreate(Bundle savedInstanceState)
        {
            UserDialogs.Init(this);

            MobileBarcodeScanner.Initialize(Application);

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            LocalNotificationCenter.MainActivity = this;
            LocalNotificationCenter.CreateNotificationChannel();
            base.OnCreate(savedInstanceState);
            //if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.ScheduleExactAlarm) != Permission.Granted)
            //{
            //    // Show a dialog/toast/message to instruct the user to manually grant the permission
            //    UserDialogs.Instance.Alert("Please grant the 'Schedule Exact Alarms' permission in the app settings for proper notifications.");

            //    // Create an Intent that will open the system settings for your app
            //    Intent intent = new Intent(Settings.ActionApplicationDetailsSettings);
            //    Uri uri = Uri.FromParts("package", Application.Context.PackageName, null);
            //    intent.SetData(uri);
            //    StartActivity(intent);
            //}
            Application.Context.Resources.GetIdentifier("icon", "drawable", Application.Context.PackageName);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            Rg.Plugins.Popup.Popup.Init(this);
            LoadApplication(new App());
            LocalNotificationCenter.NotifyNotificationTapped(Intent);
        }
        protected override void OnNewIntent(Intent intent)
        {
            LocalNotificationCenter.NotifyNotificationTapped(intent);
            base.OnNewIntent(intent);
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}