using System;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using ScreenTemplate.iOS.Renderers;
using ScreenTemplate.Views;
using ScreenTemplate;

[assembly: ExportRenderer(typeof(RoundButton), typeof(RoundButtonRenderer))]

namespace ScreenTemplate.iOS.Renderers
{
    internal class RoundButtonRenderer : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.Layer.CornerRadius = Control.Bounds.Height / 2;
                Control.ClipsToBounds = true;
                Control.BackgroundColor = UIColor.Black;
            }
        }
    }
}