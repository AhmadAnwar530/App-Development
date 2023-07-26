using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using NoWaste.Droid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

[assembly: Dependency(typeof(AppInfoAndroid))]

namespace NoWaste.Droid
{
  public class AppInfoAndroid : IAppInfo
  {
    public AppInfoAndroid() { }

    public string GetAppVersion()
    {

      var versionName = global::Android.App.Application.Context.PackageManager.GetPackageInfo(global::Android.App.Application.Context.PackageName, 0).VersionName.ToString();
#if DEBUG
      versionName += "D";
#endif
      /*Context context = Forms.ApplicationContext;
      var versionName = context.PackageManager.GetPackageInfo(context.PackageName, 0).VersionName;*/
      return versionName;
    }

    public string GetSystemInfo()
    {
      var manuf = Android.OS.Build.Manufacturer;
      var model = Android.OS.Build.Model;
      var sdkVersion = Android.OS.Build.VERSION.SdkInt;
      var device = Android.OS.Build.Device;
      return string.Format("{0}/{1}/{2}/Api:{3}", manuf, model, device, sdkVersion);

    }

  }
}