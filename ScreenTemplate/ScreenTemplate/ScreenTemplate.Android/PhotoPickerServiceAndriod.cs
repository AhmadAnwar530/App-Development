using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ScreenTemplate.Droid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.IO;
using Xamarin;
using Xamarin.Forms;
using System.Threading.Tasks;

[assembly: Xamarin.Forms.Dependency(typeof(PhotoPickerServiceAndriod))]

namespace ScreenTemplate.Droid
{
    public class PhotoPickerServiceAndriod : IPhotoPickerService
    {
        public Task<Stream> GetImageStreamAsync()
        {
            // Define the Intent for getting images
            Intent intent = new Intent();
            intent.SetType("image/*");
            intent.SetAction(Intent.ActionGetContent);

            // Start the picture-picker activity (resumes in MainActivity.cs)
            MainActivity.Instance.StartActivityForResult(
                Intent.CreateChooser(intent, "Select Picture"),
                MainActivity.PickImageId);

            // Save the TaskCompletionSource object as a MainActivity property
            MainActivity.Instance.PickImageTaskCompletionSource = new TaskCompletionSource<Stream>();

            // Return Task object
            return MainActivity.Instance.PickImageTaskCompletionSource.Task;
        }
    }

    //This code allows you to pick an image from the device's gallery in an Android app using Xamarin.Forms. The IPhotoPickerService interface acts as a contract to ensure a consistent API
    //    for image picking across different platforms (Android, iOS, etc.). The Android-specific implementation in PhotoPickerServiceAndriod handles the platform-specific logic for image picking
    //    on Android devices.
}