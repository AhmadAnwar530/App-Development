using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ScreenTemplate;
using ScreenTemplate.Droid;
using System;
using System.Collections.Generic;
using ScreenTemplate.Droid.Renderers;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly:ExportRenderer(typeof(MyEntry),typeof(MyEntryRenderer))]
namespace ScreenTemplate.Droid.Renderers
{
     class MyEntryRenderer : EntryRenderer
    {
        public MyEntryRenderer(Context context) :base(context) {
        
        
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if(Control != null && e.NewElement is MyEntry myEntry)
            {
                //Control.SetBackgroundColor(global::Android.Graphics.Color.DarkBlue);   
              
                    GradientDrawable shape = new GradientDrawable();
                    shape.SetCornerRadius((int)myEntry.CornerRadius);
                    shape.SetColor(Android.Graphics.Color.LightBlue);

                    Control.Background = shape;
                
            }
        }
    }
}