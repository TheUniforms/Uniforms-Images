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
        /// 
        /// </summary>
        /// <param name="canvas"></param>
        /// <param name="child"></param>
        /// <param name="drawingTime"></param>
        /// <returns></returns>
        protected override bool DrawChild(Canvas canvas, global::Android.Views.View child, long drawingTime)
        {
            try
            {
                var radius = Math.Min(Width, Height) / 2;
                var strokeWidth = ((RoundedImage)Element).BorderThickness;

                radius -= strokeWidth / 2;

                var path = new Path();
                path.AddCircle(Width / 2, Height / 2, radius, Path.Direction.Ccw);
                canvas.Save();
                canvas.ClipPath(path);

                var result = base.DrawChild(canvas, child, drawingTime);

                canvas.Restore();

                path = new Path();
                path.AddCircle(Width / 2, Height / 2, radius, Path.Direction.Ccw);

                var paint = new Paint();
                paint.AntiAlias = true;
                paint.StrokeWidth = strokeWidth;
                paint.SetStyle(Paint.Style.Stroke);
                paint.Color = ((RoundedImage)Element).BorderColor.ToAndroid();

                canvas.DrawPath(path, paint);

                paint.Dispose();
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
