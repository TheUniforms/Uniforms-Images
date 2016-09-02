using System;
using System.ComponentModel;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Foundation;
using Uniforms.Images;
using Uniforms.Images.iOS;

[assembly: ExportRenderer(typeof(RoundedImage), typeof(RoundedImageRenderer))]

namespace Uniforms.Images.iOS
{
    /// <summary>
    /// Rounded image renderer for iOS platform.
    /// </summary>
    public class RoundedImageRenderer : TintedImageRenderer
    {
        /// <summary>
        /// Used for reference.
        /// </summary>
        public static new void Init()
        {
        }

        /// <summary>
        /// Handles the element changed event.
        /// </summary>
        protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
        {
            base.OnElementChanged(e);

            if (Element != null) {
                UpdateBorder ();
            }
        }

        /// <summary>
        /// Handles the element property changed event.
        /// </summary>
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == VisualElement.HeightProperty.PropertyName ||
                e.PropertyName == VisualElement.WidthProperty.PropertyName ||
                e.PropertyName == RoundedImage.BorderRadiusProperty.PropertyName ||
                e.PropertyName == RoundedImage.BorderColorProperty.PropertyName ||
                e.PropertyName == RoundedImage.BorderThicknessProperty.PropertyName) {
                UpdateBorder();
            }
        }

        private void UpdateBorder()
        {
            if (Control == null) {
                return;
            }

            try {
                var image = Element as RoundedImage;
                var radius = image.BorderRadius;

                if (radius < 0) {
                    radius = Math.Min (Element.Width, Element.Height) / 2.0;
                }

                Control.Layer.MasksToBounds = true;
                Control.Layer.CornerRadius = (nfloat)radius;
                Control.Layer.BorderColor = image.BorderColor.ToCGColor();
                Control.Layer.BorderWidth = image.BorderThickness;
            } catch (Exception ex) {
                Debug.WriteLine ("RoundedImageRenderer: unable to create circle image: " + ex);
            }
        }
    }
}
