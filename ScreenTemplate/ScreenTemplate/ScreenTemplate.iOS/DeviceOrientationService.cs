using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using ScreenTemplate;
using Xamarin.Forms;
using ScreenTemplate.iOS;

[assembly: Dependency(typeof(DeviceOrientationService))]

namespace ScreenTemplate.iOS
{
    internal class DeviceOrientationService : IDeviceOrientationService
    {
        public DeviceOrientation GetOrientation()
        {
            UIInterfaceOrientation orientation = UIApplication.SharedApplication.StatusBarOrientation;

            bool isPotrait = orientation == UIInterfaceOrientation.Portrait ||
                orientation == UIInterfaceOrientation.PortraitUpsideDown;

            return isPotrait ? DeviceOrientation.Portrait : DeviceOrientation.Landscape;
        }
    }
}