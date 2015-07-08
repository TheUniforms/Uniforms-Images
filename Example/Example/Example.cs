using System;
using Xamarin.Forms;
using ZeroFive.Forms.Images;

namespace Example
{
    public class App : Application
    {
        public App()
        {
            // The root page of your application
            MainPage = new ContentPage
            {
                Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center,
                    Children =
                    {
                        new Label
                        {
                            XAlign = TextAlignment.Center,
                            Text = "Rounded Image Example:"
                        },
                        new RoundedImage
                        {
                            Source = "icon.png",
                            BorderThickness = 0,
                            BorderRadius = 10,
                            HorizontalOptions = LayoutOptions.Center,
                            WidthRequest = 50,
                            HeightRequest = 40,
                            Aspect = Aspect.AspectFill,
                        }
                    }
                }
            };
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

