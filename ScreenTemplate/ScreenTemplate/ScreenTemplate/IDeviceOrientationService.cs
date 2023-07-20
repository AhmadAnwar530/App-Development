using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin;
using Xamarin.Essentials;
using ScreenTemplate;

namespace ScreenTemplate
{

    public enum DeviceOrientation
    { 
        Unknown,
        Portrait,
        Landscape,
        PortraitUpsideDown,
        LandscapeLeft,
        LandscapeRight,
        PortraitFlipped,
        LandscapeFlipped
    
    }

    public interface IDeviceOrientationService
    {
        DeviceOrientation GetOrientation();
    }
}
