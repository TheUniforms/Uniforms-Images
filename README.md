ZeroFive.Forms.Images
=====================

Custom images controls and helpers for Xamarin.Forms

Install
-------

Install via NuGet:

```
PM> Install-Package ZeroFive.Forms.Images
```

You may also clone repository and add projects directly to your solution. Just don't forget to add references.

Tinted Image
------------

`RoundedImage` extends `Image` and adds `TintColor` property. Available only for **iOS** at the moment.

Rounded Image
-------------

`RoundedImage` extends `Image` class and supports arbitrary border radius as well as border color and thickness.

Available for **iOS** and **Android** at the moment.

Usage:

1. Init renderer in platform specific project like that:

    ```csharp
    Xamarin.Forms.Forms.Init();
    RoundedImageRenderer.Init();
    ```

2. Add `usage` statement and just use `RoundedImage` class:

    ```csharp
    using ZeroFive.Forms.Images;

    // ...

    var image = new RoundedImage {
        Aspect = Aspect.AspectFill,
        HorizontalOptions = LayoutOptions.Center,
        BorderRadius = 10,
        WidthRequest = 100,
        HeightRequest = 50,
        Source = "photo.jpg"
    };
    ```

If you need circle image, you may also specify `BorderRadius = -1.0` and it will be automatically set to half of the image size.

Note the `Aspect` and `HorizontalOptions` parameters values, they could prevent unwanted stretching in layout.

Based on [Xam.Plugins.Forms.ImageCircle](https://github.com/jamesmontemagno/Xamarin.Plugins/tree/master/ImageCircle) plugin and provides the same basic interface.
