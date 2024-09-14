// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ChapterToggleSwitch.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.ComponentModel;
using System.Windows;
using Chapter.Net.WPF.Controls.Bases;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls;

/// <summary>
///     A custom checkbox where a slider shows the checked and unchecked state.
/// </summary>
public class ChapterToggleSwitch : CheckBoxBase
{
    /// <summary>
    ///     The ChapterToggleSwitch style key.
    /// </summary>
    public static readonly ComponentResourceKey StyleKey = new(typeof(ChapterToggleSwitch), "ChapterToggleSwitch");

    /// <summary>
    ///     The DependencyProperty for the SliderShape property.
    /// </summary>
    public static readonly DependencyProperty SliderShapeProperty =
        DependencyProperty.Register(nameof(SliderShape), typeof(ChapterToggleSwitchShape), typeof(ChapterToggleSwitch), new PropertyMetadata(ChapterToggleSwitchShape.Round));

    /// <summary>
    ///     The DependencyProperty for the SliderHeight property.
    /// </summary>
    public static readonly DependencyProperty SliderHeightProperty =
        DependencyProperty.Register(nameof(SliderHeight), typeof(double), typeof(ChapterToggleSwitch), new PropertyMetadata(22.0));

    /// <summary>
    ///     The DependencyProperty for the SliderWidth property.
    /// </summary>
    public static readonly DependencyProperty SliderWidthProperty =
        DependencyProperty.Register(nameof(SliderWidth), typeof(double), typeof(ChapterToggleSwitch), new PropertyMetadata(22.0));

    /// <summary>
    ///     The DependencyProperty for the BackShape property.
    /// </summary>
    public static readonly DependencyProperty BackShapeProperty =
        DependencyProperty.Register(nameof(BackShape), typeof(ChapterToggleSwitchShape), typeof(ChapterToggleSwitch), new PropertyMetadata(ChapterToggleSwitchShape.Round));

    /// <summary>
    ///     The DependencyProperty for the BackMargin property.
    /// </summary>
    public static readonly DependencyProperty BackMarginProperty =
        DependencyProperty.Register(nameof(BackMargin), typeof(Thickness), typeof(ChapterToggleSwitch), new PropertyMetadata(new Thickness(0)));

    /// <summary>
    ///     The DependencyProperty for the SliderMargin property.
    /// </summary>
    public static readonly DependencyProperty SliderMarginProperty =
        DependencyProperty.Register(nameof(SliderMargin), typeof(Thickness), typeof(ChapterToggleSwitch), new PropertyMetadata(new Thickness(2)));

    /// <summary>
    ///     The DependencyProperty for the OnText property.
    /// </summary>
    public static readonly DependencyProperty OnTextProperty =
        DependencyProperty.Register(nameof(OnText), typeof(string), typeof(ChapterToggleSwitch), new PropertyMetadata("ON"));

    /// <summary>
    ///     The DependencyProperty for the OffText property.
    /// </summary>
    public static readonly DependencyProperty OffTextProperty =
        DependencyProperty.Register(nameof(OffText), typeof(string), typeof(ChapterToggleSwitch), new PropertyMetadata("OFF"));

    /// <summary>
    ///     The DependencyProperty for the HasText property.
    /// </summary>
    public static readonly DependencyProperty HasTextProperty =
        DependencyProperty.Register(nameof(HasText), typeof(bool), typeof(ChapterToggleSwitch), new PropertyMetadata(true));

    static ChapterToggleSwitch()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(ChapterToggleSwitch), new FrameworkPropertyMetadata(typeof(ChapterToggleSwitch)));
    }

    /// <summary>
    ///     Gets or sets the shape of the slider.
    /// </summary>
    /// <value>Default: ChapterToggleSwitchShape.Round.</value>
    [DefaultValue(ChapterToggleSwitchShape.Round)]
    public ChapterToggleSwitchShape SliderShape
    {
        get => (ChapterToggleSwitchShape)GetValue(SliderShapeProperty);
        set => SetValue(SliderShapeProperty, value);
    }

    /// <summary>
    ///     Gets or sets the height of the slider.
    /// </summary>
    /// <value>Default: 22d.</value>
    [DefaultValue(22d)]
    public double SliderHeight
    {
        get => (double)GetValue(SliderHeightProperty);
        set => SetValue(SliderHeightProperty, value);
    }

    /// <summary>
    ///     Gets or sets the width of the slider.
    /// </summary>
    /// <value>Default: 22d.</value>
    [DefaultValue(22d)]
    public double SliderWidth
    {
        get => (double)GetValue(SliderWidthProperty);
        set => SetValue(SliderWidthProperty, value);
    }

    /// <summary>
    ///     Gets or sets the shape of the background element.
    /// </summary>
    /// <value>Default: ChapterToggleSwitchShape.Round.</value>
    [DefaultValue(ChapterToggleSwitchShape.Round)]
    public ChapterToggleSwitchShape BackShape
    {
        get => (ChapterToggleSwitchShape)GetValue(BackShapeProperty);
        set => SetValue(BackShapeProperty, value);
    }

    /// <summary>
    ///     Gets or sets the margin of the background element.
    /// </summary>
    /// <value>Default: 0.</value>
    public Thickness BackMargin
    {
        get => (Thickness)GetValue(BackMarginProperty);
        set => SetValue(BackMarginProperty, value);
    }

    /// <summary>
    ///     Gets or sets the margin of the slider.
    /// </summary>
    /// <value>Default: 2.</value>
    public Thickness SliderMargin
    {
        get => (Thickness)GetValue(SliderMarginProperty);
        set => SetValue(SliderMarginProperty, value);
    }

    /// <summary>
    ///     Gets or sets the on text for the background element.
    /// </summary>
    /// <value>Default: "ON".</value>
    [DefaultValue("ON")]
    public string OnText
    {
        get => (string)GetValue(OnTextProperty);
        set => SetValue(OnTextProperty, value);
    }

    /// <summary>
    ///     Gets or sets the off text for the background element.
    /// </summary>
    /// <value>Default: "OFF".</value>
    [DefaultValue("OFF")]
    public string OffText
    {
        get => (string)GetValue(OffTextProperty);
        set => SetValue(OffTextProperty, value);
    }

    /// <summary>
    ///     Gets or sets the indicator of the back element has text display for on and off.
    /// </summary>
    /// <value>Default: true.</value>
    [DefaultValue(true)]
    public bool HasText
    {
        get => (bool)GetValue(HasTextProperty);
        set => SetValue(HasTextProperty, value);
    }
}