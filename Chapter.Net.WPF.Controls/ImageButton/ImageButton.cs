// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ImageButton.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls;

/// <summary>
///     Enhances the <see cref="Button" /> to show an disabled image. The bound image will be shown monochrome if the
///     button is disabled.
/// </summary>
public class ImageButton : Button
{
    /// <summary>
    ///     Identifies the ImageSource dependency property.
    /// </summary>
    public static readonly DependencyProperty ImageSourceProperty =
        DependencyProperty.Register(nameof(ImageSource), typeof(BitmapSource), typeof(ImageButton), new UIPropertyMetadata(null, OnImageSourceChanged));

    /// <summary>
    ///     Identifies the ImageWidth dependency property.
    /// </summary>
    public static readonly DependencyProperty ImageWidthProperty =
        DependencyProperty.Register(nameof(ImageWidth), typeof(double), typeof(ImageButton), new UIPropertyMetadata(16.0, OnSizeChanged));

    /// <summary>
    ///     Identifies the ImageHeight dependency property.
    /// </summary>
    public static readonly DependencyProperty ImageHeightProperty =
        DependencyProperty.Register(nameof(ImageHeight), typeof(double), typeof(ImageButton), new UIPropertyMetadata(16.0, OnSizeChanged));

    /// <summary>
    ///     Identifies the ImageMargin dependency property.
    /// </summary>
    public static readonly DependencyProperty ImageMarginProperty =
        DependencyProperty.Register(nameof(ImageMargin), typeof(Thickness), typeof(ImageButton), new UIPropertyMetadata(new Thickness(0, 0, 2, 0)));

    /// <summary>
    ///     Identifies the ImagePosition dependency property.
    /// </summary>
    public static readonly DependencyProperty ImagePositionProperty =
        DependencyProperty.Register(nameof(ImagePosition), typeof(Dock), typeof(ImageButton), new UIPropertyMetadata(Dock.Left));

    /// <summary>
    ///     Identifies the HorizontalImageAlignment dependency property.
    /// </summary>
    public static readonly DependencyProperty HorizontalImageAlignmentProperty =
        DependencyProperty.Register(nameof(HorizontalImageAlignment), typeof(HorizontalAlignment), typeof(ImageButton), new UIPropertyMetadata(HorizontalAlignment.Center));

    /// <summary>
    ///     Identifies the VerticalImageAlignment dependency property.
    /// </summary>
    public static readonly DependencyProperty VerticalImageAlignmentProperty =
        DependencyProperty.Register(nameof(VerticalImageAlignment), typeof(VerticalAlignment), typeof(ImageButton), new UIPropertyMetadata(VerticalAlignment.Center));

    /// <summary>
    ///     Identifies the VerticalImageAlignment dependency property.
    /// </summary>
    public static readonly DependencyProperty ImageStretchProperty =
        DependencyProperty.Register(nameof(ImageStretch), typeof(Stretch), typeof(ImageButton), new UIPropertyMetadata(Stretch.Uniform));

    internal static readonly DependencyProperty DisabledImageSourceProperty =
        DependencyProperty.Register(nameof(DisabledImageSource), typeof(BitmapSource), typeof(ImageButton), new UIPropertyMetadata(null));

    private bool _sizeIsSet;

    static ImageButton()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(ImageButton), new FrameworkPropertyMetadata(typeof(ImageButton)));
    }

    /// <summary>
    ///     Gets or sets the source if the button image.
    /// </summary>
    /// <value>Default: null.</value>
    [DefaultValue(null)]
    public BitmapSource ImageSource
    {
        get => (BitmapSource)GetValue(ImageSourceProperty);
        set => SetValue(ImageSourceProperty, value);
    }

    /// <summary>
    ///     Gets or sets the width of the image shown in the button.
    /// </summary>
    /// <value>Default: 16d.</value>
    [DefaultValue(16d)]
    public double ImageWidth
    {
        get => (double)GetValue(ImageWidthProperty);
        set => SetValue(ImageWidthProperty, value);
    }

    /// <summary>
    ///     Gets or sets the height of the image shown in the button.
    /// </summary>
    /// <value>Default: 16d.</value>
    [DefaultValue(16d)]
    public double ImageHeight
    {
        get => (double)GetValue(ImageHeightProperty);
        set => SetValue(ImageHeightProperty, value);
    }

    /// <summary>
    ///     Gets or sets the margin of the image shown in the button.
    /// </summary>
    /// <value>Default: 0,0,2,0.</value>
    public Thickness ImageMargin
    {
        get => (Thickness)GetValue(ImageMarginProperty);
        set => SetValue(ImageMarginProperty, value);
    }

    /// <summary>
    ///     Gets or sets a value that indicates where the image have to be placed in the button.
    /// </summary>
    /// <value>Default: Dock.Left.</value>
    [DefaultValue(Dock.Left)]
    public Dock ImagePosition
    {
        get => (Dock)GetValue(ImagePositionProperty);
        set => SetValue(ImagePositionProperty, value);
    }

    /// <summary>
    ///     Gets or sets the horizontal alignment of the image shown in the button.
    /// </summary>
    /// <value>Default: HorizontalAlignment.Center.</value>
    [DefaultValue(HorizontalAlignment.Center)]
    public HorizontalAlignment HorizontalImageAlignment
    {
        get => (HorizontalAlignment)GetValue(HorizontalImageAlignmentProperty);
        set => SetValue(HorizontalImageAlignmentProperty, value);
    }

    /// <summary>
    ///     Gets or sets the vertical alignment of the image shown in the button.
    /// </summary>
    /// <value>Default: VerticalAlignment.Center.</value>
    [DefaultValue(VerticalAlignment.Center)]
    public VerticalAlignment VerticalImageAlignment
    {
        get => (VerticalAlignment)GetValue(VerticalImageAlignmentProperty);
        set => SetValue(VerticalImageAlignmentProperty, value);
    }

    /// <summary>
    ///     Gets or sets a value that indicated how the image have to be stretched in the button.
    /// </summary>
    /// <value>Default: Stretch.Uniform.</value>
    [DefaultValue(Stretch.Uniform)]
    public Stretch ImageStretch
    {
        get => (Stretch)GetValue(ImageStretchProperty);
        set => SetValue(ImageStretchProperty, value);
    }

    internal BitmapSource DisabledImageSource
    {
        get => (BitmapSource)GetValue(DisabledImageSourceProperty);
        set => SetValue(DisabledImageSourceProperty, value);
    }

    private static void OnImageSourceChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
    {
        var control = (ImageButton)o;
        if (e.NewValue != null && !control._sizeIsSet)
        {
            var bitmapSource = e.NewValue as BitmapSource;
            control.DisabledImageSource = new FormatConvertedBitmap(bitmapSource, PixelFormats.Gray32Float, null, 0);
            control.ImageHeight = bitmapSource.Height;
            control.ImageWidth = bitmapSource.Width;
        }
    }

    private static void OnSizeChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
    {
        var control = (ImageButton)o;
        control._sizeIsSet = true;
    }
}