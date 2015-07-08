ZeroFive.Forms.Images
=====================

Custom images controls and helpers for Xamarin.Forms.

RoundedImage
------------

Extended `RoundedImage` class supports arbitrary border radius as well as border color and thickness.

Usage:

1. Install package ZeroFive.Forms.Images

2. Init renderer in platform specific project like that:

    ```csharp
    Xamarin.Forms.Forms.Init();
    RoundedImageRenderer.Init();
    ```

3. Add `usage` statement and just use `RoundedImage` class:

    ```csharp
    using ZeroFive.Forms.Images;

    // ...

    var image = new RoundedImage {
        Aspect = Aspect.AspectFill,
        BorderRadius = 10,
        WidthRequest = 100,
        HeightRequest = 50,
        Source = "photo.jpg"
    };
    ```

Based on [Xam.Plugins.Forms.ImageCircle](https://github.com/jamesmontemagno/Xamarin.Plugins/tree/master/ImageCircle) plugin.
