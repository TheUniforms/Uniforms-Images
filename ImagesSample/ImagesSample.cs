using System;
using Xamarin.Forms;
using Uniforms.Images;

namespace ImagesSample
{
    public class App : Application
    {
        public App ()
        {
            // The root page of your application
            var content = new ContentPage {
                Title = "ImagesSample",
                Content = new StackLayout {
                    VerticalOptions = LayoutOptions.Center,
                    Children = {
                        new Label {
                            HorizontalTextAlignment = TextAlignment.Center,
                            Text = "Tinted image sample:"
                        },
                        new TintedImage {
                            Source="peace_symbol",
                            TintColor=Color.Green
                        },
                        new Label {
                            HorizontalTextAlignment = TextAlignment.Center,
                            Text = "Rounded image sample:"
                        },
                        new RoundedImage {
                            Source = "everest.jpg",
                            Aspect = Aspect.AspectFill,
                            HorizontalOptions = LayoutOptions.Center,
                            BorderRadius = 25
                        }
                    }
                }
            };

            MainPage = new NavigationPage (content);
        }

        protected override void OnStart ()
        {
            // Handle when your app starts
        }

        protected override void OnSleep ()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume ()
        {
            // Handle when your app resumes
        }
    }
}
