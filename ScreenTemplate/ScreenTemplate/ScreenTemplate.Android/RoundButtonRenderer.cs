using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using ScreenTemplate.Droid.Renderers;
using ScreenTemplate.Views;
using ScreenTemplate.ViewModels;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScreenTemplate;
using ScreenTemplate.Droid;

[assembly: ExportRenderer(typeof(RoundButton),typeof(RoundButtonRenderer))]

/* This line is an attribute that tells Xamarin.Forms to use the RoundButtonRenderer 
 * class to render the custom RoundButton control. It establishes the association between the RoundButton control
 * in Xamarin.Forms and its custom renderer RoundButtonRenderer in the Android platform.*/

namespace ScreenTemplate.Droid.Renderers
//specific to the Android platform.
{
    internal class RoundButtonRenderer : ButtonRenderer
        /*  line declares the RoundButtonRenderer class as a subclass of the ButtonRenderer class. 
         *  It means that RoundButtonRenderer inherits functionality from the base ButtonRenderer class, 
         *  which is responsible for rendering Xamarin.Forms' built-in Button control on the Android platform. */
    {
        public RoundButtonRenderer(Context context) : base(context) {

            /* akes a parameter of type Context, which is an Android-specific class that provides access to resources and services. 
             * The : base(context) part means that the constructor of the base class (ButtonRenderer) is called with the same context parameter. 
             * This helps ensure that the base class is properly initialized.*/
        
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);
            //base.OnElementChanged(e);: This line calls the OnElementChanged method of the base class (ButtonRenderer).
            //It's essential to ensure that the default behavior of the base class is executed before adding our custom logic.

            if (Control != null)
            // native Android control (Control) associated with the RoundButton control is not null. The Control represents the native Button widget on the Android platform.
            {
                int buttonColor = Android.Graphics.Color.DarkBlue;
                GradientDrawable shape = new GradientDrawable();
                shape.SetColor(buttonColor);
                shape.SetShape(ShapeType.Oval);

                Control.Background = shape;
            }
        }
    }
}