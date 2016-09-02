using System;
using Foundation;
using UIKit;

namespace ImagesSample.iOS
{
    [Register ("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching (UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init ();
            Uniforms.Images.iOS.TintedImageRenderer.Init ();
            Uniforms.Images.iOS.RoundedImageRenderer.Init ();

            LoadApplication (new App ());

            return base.FinishedLaunching (app, options);
        }
    }
}
