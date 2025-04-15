// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ChapterImagePresenter.cs" company="dwndland">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Chapter.Net.WPF.Controls.Bases;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls;

/// <summary>
///     Displays an image with the possibility to display it in grayscale if disabled.
/// </summary>
public class ChapterImagePresenter : ControlBase
{
    /// <summary>
    ///     The ChapterImagePresenter style key.
    /// </summary>
    public static readonly ComponentResourceKey StyleKey = new(typeof(ChapterImagePresenter), "ChapterImagePresenter");

    /// <summary>
    ///     The Image dependency property.
    /// </summary>
    public static readonly DependencyProperty ImageProperty =
        DependencyProperty.Register(nameof(Image), typeof(Image), typeof(ChapterImagePresenter), new PropertyMetadata(null));

    /// <summary>
    ///     The DisabledImage dependency property.
    /// </summary>
    public static readonly DependencyProperty DisabledImageProperty =
        DependencyProperty.Register(nameof(DisabledImage), typeof(Image), typeof(ChapterImagePresenter), new PropertyMetadata(null, OnDisabledImageChanged));

    private bool _isSetFromOutside;
    private bool _selfSet;

    static ChapterImagePresenter()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(ChapterImagePresenter), new FrameworkPropertyMetadata(typeof(ChapterImagePresenter)));
    }

    /// <summary>
    ///     Gets or sets the image to show.
    /// </summary>
    /// <value>Default: null.</value>
    [DefaultValue(null)]
    public Image Image
    {
        get => (Image)GetValue(ImageProperty);
        set => SetValue(ImageProperty, value);
    }

    /// <summary>
    ///     Gets or sets the image to show when disabled.
    /// </summary>
    /// <value>Default: null.</value>
    [DefaultValue(null)]
    public Image DisabledImage
    {
        get => (Image)GetValue(DisabledImageProperty);
        set => SetValue(DisabledImageProperty, value);
    }

    /// <inheritdoc />
    protected override void OnIsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
        if (_isSetFromOutside)
            return;

        _selfSet = true;

        if (Image?.Source is BitmapSource bitmapSource)
        {
            DisabledImage = new Image
            {
                Source = new FormatConvertedBitmap(bitmapSource, PixelFormats.Gray32Float, null, 0),
                Stretch = Image.Stretch,
                StretchDirection = Image.StretchDirection,
                Height = Image.Height,
                Width = Image.Width
            };
            RenderOptions.SetBitmapScalingMode(DisabledImage, RenderOptions.GetBitmapScalingMode(Image));
        }

        _selfSet = false;
    }

    private static void OnDisabledImageChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var presenter = (ChapterImagePresenter)d;
        if (!presenter._selfSet)
            presenter._isSetFromOutside = true;
    }
}