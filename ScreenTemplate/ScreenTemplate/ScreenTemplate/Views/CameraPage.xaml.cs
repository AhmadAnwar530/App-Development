using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScreenTemplate.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CameraPage : ContentPage
    {
        public CameraPage()
        {
            InitializeComponent();

         
        }

        void OnGetDeviceOrientationButtonClicked(object sender, EventArgs e)
        {
            DeviceOrientation orientation = DependencyService.Resolve<IDeviceOrientationService>().GetOrientation();
            orientationLabel.Text = orientation.ToString();

            //DependencyService is part of the Xamarin platform and allows you to access platform-specific services from your shared code. 
        }

        async void OnPickPhotoButtonClicked(object sender, EventArgs e)
        {
            (sender as Button).IsEnabled = false;

            Stream stream = await DependencyService.Get<IPhotoPickerService>().GetImageStreamAsync();
            //This line uses the DependencyService to get an instance of the IPhotoPickerService implementation. It then calls the GetImageStreamAsync method on that service,
            //which starts the process of selecting an image from the device's gallery or file system.
            //The method returns a Task<Stream>, and the await keyword here makes the code wait until the image selection process is complete before continuing.
            if (stream != null)
            {
                image.Source = ImageSource.FromStream(() => stream);
                //: If a valid image stream is available, this line sets the Source property of an Image control named image to display the selected image.
                //ImageSource.FromStream is a helper method that converts the image stream into an ImageSource, which can be used to display the image in the Image control.
            }

    (sender as Button).IsEnabled = true;
        }
    }
}