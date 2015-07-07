using System;
using System.ComponentModel;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Foundation;
using ZeroFive.Forms.Images;
using ZeroFive.Forms.Images.iOS;


[assembly: ExportRenderer(typeof(RoundedImage), typeof(RoundedImageRenderer))]

namespace ZeroFive.Forms.Images.iOS
{
    /// <summary>
    /// ImageCircle Implementation
    /// </summary>
    [Preserve]
    public class RoundedImageRenderer : ImageRenderer
    {
        /// <summary>
        /// Used for registration with dependency service
        /// </summary>
        public static void Init()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
        {
            base.OnElementChanged(e);

            if (Element != null)
            {
                UpdateBorder();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == VisualElement.HeightProperty.PropertyName ||
                e.PropertyName == VisualElement.WidthProperty.PropertyName ||
                e.PropertyName == RoundedImage.BorderRadiusProperty.PropertyName ||
                e.PropertyName == RoundedImage.BorderColorProperty.PropertyName ||
                e.PropertyName == RoundedImage.BorderThicknessProperty.PropertyName)
            {
                UpdateBorder();
            }
        }

        private void UpdateBorder()
        {
            try
            {
                var radius = (Element as RoundedImage).BorderRadius;

                if (radius < 0)
                {
                    radius = Math.Min(Element.Width, Element.Height) / 2.0;
                }

                Control.Layer.CornerRadius = (float)radius;
                Control.Layer.MasksToBounds = false;
                Control.Layer.BorderColor = ((RoundedImage)Element).BorderColor.ToCGColor();
                Control.Layer.BorderWidth = ((RoundedImage)Element).BorderThickness;
                Control.ClipsToBounds = true;
            }
            catch(Exception ex)
            {
                Debug.WriteLine("Unable to create circle image: " + ex);
            }
        }
    }
}
