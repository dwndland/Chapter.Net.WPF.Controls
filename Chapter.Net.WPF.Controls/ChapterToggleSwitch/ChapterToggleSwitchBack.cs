// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ChapterToggleSwitchBack.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls;

/// <summary>
///     The background control shown in the <see cref="ChapterToggleSwitch" />.
/// </summary>
public class ChapterToggleSwitchBack : Control
{
    /// <summary>
    ///     The ChapterToggleSwitchBack style key.
    /// </summary>
    public static readonly ComponentResourceKey StyleKey = new(typeof(ChapterToggleSwitchBack), "ChapterToggleSwitchBack");

    /// <summary>
    ///     The DependencyProperty for the Shape property.
    /// </summary>
    public static readonly DependencyProperty ShapeProperty =
        DependencyProperty.Register(nameof(Shape), typeof(ChapterToggleSwitchShape), typeof(ChapterToggleSwitchBack), new PropertyMetadata(ChapterToggleSwitchShape.Round, OnShapeChanged));

    /// <summary>
    ///     The DependencyProperty for the CornerRadius property.
    /// </summary>
    public static readonly DependencyProperty CornerRadiusProperty =
        DependencyProperty.Register(nameof(CornerRadius), typeof(double), typeof(ChapterToggleSwitchBack), new PropertyMetadata(0.0));

    /// <summary>
    ///     The DependencyProperty for the IsChecked property.
    /// </summary>
    public static readonly DependencyProperty IsCheckedProperty =
        DependencyProperty.Register(nameof(IsChecked), typeof(bool), typeof(ChapterToggleSwitchBack), new PropertyMetadata(false));

    /// <summary>
    ///     The DependencyProperty for the HasText property.
    /// </summary>
    public static readonly DependencyProperty HasTextProperty =
        DependencyProperty.Register(nameof(HasText), typeof(bool), typeof(ChapterToggleSwitchBack), new PropertyMetadata(true));

    /// <summary>
    ///     The DependencyProperty for the OnText property.
    /// </summary>
    public static readonly DependencyProperty OnTextProperty =
        DependencyProperty.Register(nameof(OnText), typeof(string), typeof(ChapterToggleSwitchBack), new PropertyMetadata("ON"));

    /// <summary>
    ///     The DependencyProperty for the OffText property.
    /// </summary>
    public static readonly DependencyProperty OffTextProperty =
        DependencyProperty.Register(nameof(OffText), typeof(string), typeof(ChapterToggleSwitchBack), new PropertyMetadata("OFF"));

    static ChapterToggleSwitchBack()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(ChapterToggleSwitchBack), new FrameworkPropertyMetadata(typeof(ChapterToggleSwitchBack)));
    }

    /// <summary>
    ///     Gets or sets the indicator of the on and off texts are shown.
    /// </summary>
    /// <value>Default: true.</value>
    [DefaultValue(true)]
    public bool HasText
    {
        get => (bool)GetValue(HasTextProperty);
        set => SetValue(HasTextProperty, value);
    }

    /// <summary>
    ///     Gets or sets the on text.
    /// </summary>
    /// <value>Default: "ON".</value>
    [DefaultValue("ON")]
    public string OnText
    {
        get => (string)GetValue(OnTextProperty);
        set => SetValue(OnTextProperty, value);
    }

    /// <summary>
    ///     Gets or sets the off text.
    /// </summary>
    /// <value>Default: "OFF".</value>
    [DefaultValue("OFF")]
    public string OffText
    {
        get => (string)GetValue(OffTextProperty);
        set => SetValue(OffTextProperty, value);
    }

    /// <summary>
    ///     Gets or sets the shape of that control.
    /// </summary>
    /// <value>Default: ChapterToggleSwitchShape.Round.</value>
    [DefaultValue(ChapterToggleSwitchShape.Round)]
    public ChapterToggleSwitchShape Shape
    {
        get => (ChapterToggleSwitchShape)GetValue(ShapeProperty);
        set => SetValue(ShapeProperty, value);
    }

    /// <summary>
    ///     Gets or sets the corner radius of this control.
    /// </summary>
    /// <value>Default: 0d.</value>
    [DefaultValue(0d)]
    public double CornerRadius
    {
        get => (double)GetValue(CornerRadiusProperty);
        set => SetValue(CornerRadiusProperty, value);
    }

    /// <summary>
    ///     Gets or sets the indicator if this control is checked or not.
    /// </summary>
    /// <value>Default: false.</value>
    [DefaultValue(false)]
    public bool IsChecked
    {
        get => (bool)GetValue(IsCheckedProperty);
        set => SetValue(IsCheckedProperty, value);
    }

    private static void OnShapeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var control = (ChapterToggleSwitchBack)d;
        control.UpdateCornerRadius();
    }

    /// <summary>
    ///     Triggered if the render size of the control is changed.
    /// </summary>
    /// <param name="sizeInfo">The size changed information data.</param>
    protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
    {
        base.OnRenderSizeChanged(sizeInfo);

        UpdateCornerRadius();
    }

    private void UpdateCornerRadius()
    {
        switch (Shape)
        {
            case ChapterToggleSwitchShape.Round:
                CornerRadius = ActualHeight / 2;
                break;
            case ChapterToggleSwitchShape.Square:
                CornerRadius = 0;
                break;
        }
    }
}