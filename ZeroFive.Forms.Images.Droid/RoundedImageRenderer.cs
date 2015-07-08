using System;
using System.ComponentModel;
//using Android.Content;
//using Android.OS;
using Android.Runtime;
using Android.Views;
//using Android.Widget;
using Android.Graphics;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using ZeroFive.Forms.Images;
using ZeroFive.Forms.Images.Droid;


[assembly: ExportRenderer(typeof(RoundedImage), typeof(RoundedImageRenderer))]

namespace ZeroFive.Forms.Images.Droid
{
    /// <summary>
    /// Rounded image renderer.
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
        /// Handles the element changed event.
        /// </summary>
        protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                //Only enable hardware accelleration on lollipop
                if ((int)Android.OS.Build.VERSION.SdkInt < 21)
                {
                    SetLayerType(LayerType.Software, null);
                }
            }
        }

        /// <summary>
        /// Handles the element property changed event.
        /// </summary>
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == RoundedImage.BorderRadiusProperty.PropertyName ||
                e.PropertyName == RoundedImage.BorderColorProperty.PropertyName ||
                e.PropertyName == RoundedImage.BorderThicknessProperty.PropertyName)
            {
                Invalidate();
            }
        }

        /// <summary>
        /// Redraws the child.
        /// </summary>
        protected override bool DrawChild(Canvas canvas, global::Android.Views.View child, long drawingTime)
        {
            try
            {
                var radius = (float)((RoundedImage)Element).BorderRadius;
                var stroke = (float)((RoundedImage)Element).BorderThickness;
                var delta = (float)stroke / 2.0f;

                if (radius < 0)
                {
                    radius = Math.Min(Width, Height) / 2.0f;
                }

                radius -= delta;

                // Clip with rounded rect
                var path = new Path();
                path.AddRoundRect(new RectF(delta, delta, Width - stroke, Height - stroke),
                    radius, radius, Path.Direction.Ccw);
                canvas.Save();
                canvas.ClipPath(path);
                path.Dispose();

                var result = base.DrawChild(canvas, child, drawingTime);

                canvas.Restore();

                // Add stroke for smoother border
                path = new Path();
                path.AddRoundRect(new RectF(delta, delta, Width - stroke, Height - stroke),
                    radius, radius, Path.Direction.Ccw);
                var paint = new Paint();
                paint.AntiAlias = true;
                paint.StrokeWidth = stroke;
                paint.SetStyle(Paint.Style.Stroke);
                paint.Color = ((RoundedImage)Element).BorderColor.ToAndroid();
                canvas.DrawPath(path, paint);
                paint.Dispose();

                // Clean up
                path.Dispose();

                return result;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Unable to create circle image: " + ex);
            }

            return base.DrawChild(canvas, child, drawingTime);
        }
    }
}
