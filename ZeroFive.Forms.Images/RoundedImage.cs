using System;
using Xamarin.Forms;

namespace ZeroFive.Forms.Images
{
    /// <summary>
    /// Rounded image.
    /// </summary>
    public class RoundedImage : Image
    {
        /// <summary>
        /// Thickness property of border
        /// </summary>
        public static readonly BindableProperty BorderThicknessProperty =
            BindableProperty.Create<RoundedImage, int>(
                p => p.BorderThickness, 0);

        /// <summary>
        /// Border thickness of image
        /// </summary>
        public int BorderThickness
        {
            get { return (int)GetValue(BorderThicknessProperty); }
            set { SetValue(BorderThicknessProperty, value); }
        }

        /// <summary>
        /// Color property of border
        /// </summary>
        public static readonly BindableProperty BorderColorProperty =
            BindableProperty.Create<RoundedImage, Color>(
                p => p.BorderColor, Color.White);

        /// <summary>
        /// Border Color of image
        /// </summary>
        public Color BorderColor
        {
            get { return (Color)GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }

        /// <summary>
        /// The border radius property.
        /// </summary>
        public static readonly BindableProperty BorderRadiusProperty =
            BindableProperty.Create<RoundedImage, double>(
                p => p.BorderRadius, -1.0);

        /// <summary>
        /// Border radius of image.
        /// </summary>
        public double BorderRadius
        {
            get { return (double)GetValue(BorderRadiusProperty); }
            set { SetValue(BorderRadiusProperty, value); }
        }
    }
}

