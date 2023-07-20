using Foundation;
using ScreenTemplate;
using ScreenTemplate.iOS.Renderers;
using System;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(MyEntry), typeof(MyEntryRenderer))]
namespace ScreenTemplate.iOS.Renderers
{
    public class MyEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null && e.NewElement is MyEntry myEntry)
            {
                Control.Layer.CornerRadius = (nfloat)myEntry.CornerRadius;
                Control.Layer.BackgroundColor = UIColor.Blue.CGColor;
            }
        }
    }
}
