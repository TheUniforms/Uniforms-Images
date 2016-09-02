using System.Diagnostics;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Uniforms.Images;
using Uniforms.Images.Droid;

[assembly: ExportRenderer (typeof (TintedImage), typeof (TintedImageRenderer))]

namespace Uniforms.Images.Droid
{
    public class TintedImageRenderer : ImageRenderer
    {
        /// <summary>
        /// Used for registration with dependency service
        /// </summary>
        public static void Init ()
        {
        }

        /// <summary>
        /// Handles the element changed event.
        /// </summary>
        protected override void OnElementChanged (ElementChangedEventArgs<Image> e)
        {
            base.OnElementChanged (e);

            UpdateTintcolor ();
        }

        /// <summary>
        /// Handles the element property changed event.
        /// </summary>
        protected override void OnElementPropertyChanged (object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged (sender, e);

            if (e.PropertyName == Image.SourceProperty.PropertyName ||
                e.PropertyName == TintedImage.TintColorProperty.PropertyName) {
                UpdateTintcolor ();
            }
        }

        /// <summary>
        /// Updates the tint color.
        /// </summary>
        void UpdateTintcolor ()
        {
            if ((Element == null) || (Control == null)) {
                return;
            }

            var image = Element as TintedImage;

            //Control.ImageTintMode = PorterDuff.Mode.Src;
            Control.SetColorFilter (image.TintColor.ToAndroid ());
        }
    }
}
