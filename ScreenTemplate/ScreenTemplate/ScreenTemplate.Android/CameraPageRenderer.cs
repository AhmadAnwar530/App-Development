using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ScreenTemplate.Droid;
using ScreenTemplate.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CameraPage), typeof(CameraPageRenderer))]

namespace ScreenTemplate.Droid
{
    public class CameraPageRenderer : PageRenderer, TextureView.ISurfaceTextureListener
    {
        private global::Android.Hardware.Camera _camera;
        private TextureView _textureView;

        public CameraPageRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || Element == null)
            {
                return;
            }

            try
            {
                _textureView = new TextureView(Context);
                _textureView.SurfaceTextureListener = this;

                AddView(_textureView);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(@"ERROR: ", ex.Message);
            }

            // Rest of the code should not be placed here
        }

        public void OnSurfaceTextureAvailable(SurfaceTexture surface, int width, int height)
        {
            // Implement camera initialization and start preview here
            try
            {
                _camera = global::Android.Hardware.Camera.Open();

                if (_camera != null)
                {
                    _camera.SetPreviewTexture(surface);
                    _camera.StartPreview();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(@"ERROR: ", ex.Message);
                _camera?.Release();
                _camera = null;
            }
        }

        public bool OnSurfaceTextureDestroyed(SurfaceTexture surface)
        {
            // Release camera resources and stop the preview here
            if (_camera != null)
            {
                _camera.StopPreview();
                _camera.Release();
                _camera = null;
            }
            return true;
        }

        public void OnSurfaceTextureSizeChanged(SurfaceTexture surface, int width, int height)
        {
            // Handle surface size changes here if needed
        }

        public void OnSurfaceTextureUpdated(SurfaceTexture surface)
        {
            // Handle surface updates here if needed
        }

        // Implement the rest of the methods here

        // ...
    }
}
