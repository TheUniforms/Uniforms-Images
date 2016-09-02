using System;
using System.ComponentModel;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using Uniforms.Images;
using Uniforms.Images.iOS;


[assembly: ExportRenderer(typeof(TintedImage), typeof(TintedImageRenderer))]

namespace Uniforms.Images.iOS
{
    /// <summary>
    /// Tinted image renderer for iOS platform.
    /// </summary>
    public class TintedImageRenderer : ImageRenderer
    {
        /// <summary>
        /// Used for reference.
        /// </summary>
        public static new void  Init()
        {
        }

        /// <summary>
        /// Handles the element changed event.
        /// </summary>
        protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
        {
            base.OnElementChanged(e);

            if (Element != null)
            {
                UpdateTintcolor();
            }
        }

        /// <summary>
        /// Handles the element property changed event.
        /// </summary>
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == Image.SourceProperty.PropertyName ||
                e.PropertyName == TintedImage.TintColorProperty.PropertyName)
            {
                UpdateTintcolor();
            }
        }

        /// <summary>
        /// Updates the tint color.
        /// </summary>
        void UpdateTintcolor()
        {
            if ((Control == null) || (Control.Image == null)) {
                return;
            }

            var image = Element as TintedImage;

            if (image.TintColor == Color.Default) {
                if (Control.Image.RenderingMode == UIImageRenderingMode.AlwaysTemplate) {
                    Control.Image = Control.Image.ImageWithRenderingMode (UIImageRenderingMode.Automatic);
                }
            } else {
                Control.Image = Control.Image.ImageWithRenderingMode (UIImageRenderingMode.AlwaysTemplate);
                Control.TintColor = image.TintColor.ToUIColor ();
            }
        }
    }
}

