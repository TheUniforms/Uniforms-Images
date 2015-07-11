using System;
using Xamarin.Forms;

namespace ZeroFive.Forms.Images
{
    public class TintedImage : Image
    {
        /// <summary>
        /// The tint color property.
        /// </summary>
        public static readonly BindableProperty TintColorProperty =
            BindableProperty.Create<TintedImage, Color>(
                p => p.TintColor, Color.Default);

        /// <summary>
        /// Gets or sets the color of the tint.
        /// </summary>
        public Color TintColor
        {
            get { return (Color)GetValue(TintColorProperty); }
            set { SetValue(TintColorProperty, value); }
        }
    }
}

