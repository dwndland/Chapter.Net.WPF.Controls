// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ChapterResizer.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls;

/// <summary>
///     Brings the possibility to resize every UI control manually by hold and drag the corners or sides.
/// </summary>
[TemplatePart(Name = "PART_LeftThumb", Type = typeof(Thumb))]
[TemplatePart(Name = "PART_LeftTopThumb", Type = typeof(Thumb))]
[TemplatePart(Name = "PART_TopThumb", Type = typeof(Thumb))]
[TemplatePart(Name = "PART_RightTopThumb", Type = typeof(Thumb))]
[TemplatePart(Name = "PART_RightThumb", Type = typeof(Thumb))]
[TemplatePart(Name = "PART_RightBottomThumb", Type = typeof(Thumb))]
[TemplatePart(Name = "PART_BottomThumb", Type = typeof(Thumb))]
[TemplatePart(Name = "PART_LeftBottomThumb", Type = typeof(Thumb))]
public class ChapterResizer : ContentControl
{
    private static readonly DependencyPropertyKey LeftWidthPropertyKey =
        DependencyProperty.RegisterReadOnly(nameof(LeftWidth), typeof(double), typeof(ChapterResizer), new PropertyMetadata(6d));

    private static readonly DependencyPropertyKey TopHeightPropertyKey =
        DependencyProperty.RegisterReadOnly(nameof(TopHeight), typeof(double), typeof(ChapterResizer), new PropertyMetadata(6d));

    private static readonly DependencyPropertyKey RightWidthPropertyKey =
        DependencyProperty.RegisterReadOnly(nameof(RightWidth), typeof(double), typeof(ChapterResizer), new PropertyMetadata(6d));

    private static readonly DependencyPropertyKey BottomHeightPropertyKey =
        DependencyProperty.RegisterReadOnly(nameof(BottomHeight), typeof(double), typeof(ChapterResizer), new PropertyMetadata(6d));

    /// <summary>
    ///     Identifies the <see cref="FrameSizes" /> dependency property.
    /// </summary>
    public static readonly DependencyProperty FrameSizesProperty =
        DependencyProperty.Register(nameof(FrameSizes), typeof(Thickness), typeof(ChapterResizer), new UIPropertyMetadata(new Thickness(6), OnFrameSizesChanged));

    /// <summary>
    ///     Identifies the <see cref="CornerSize" /> dependency property.
    /// </summary>
    public static readonly DependencyProperty CornerSizeProperty =
        DependencyProperty.Register(nameof(CornerSize), typeof(double), typeof(ChapterResizer), new UIPropertyMetadata(12d));

    /// <summary>
    ///     Identifies the <see cref="CornerSize" /> dependency property.
    /// </summary>
    public static readonly DependencyProperty LeftWidthProperty = LeftWidthPropertyKey.DependencyProperty;

    /// <summary>
    ///     Identifies the <see cref="TopHeight" /> dependency property.
    /// </summary>
    public static readonly DependencyProperty TopHeightProperty = TopHeightPropertyKey.DependencyProperty;

    /// <summary>
    ///     Identifies the <see cref="RightWidth" /> dependency property.
    /// </summary>
    public static readonly DependencyProperty RightWidthProperty = RightWidthPropertyKey.DependencyProperty;

    /// <summary>
    ///     Identifies the <see cref="BottomHeight" /> dependency property.
    /// </summary>
    public static readonly DependencyProperty BottomHeightProperty = BottomHeightPropertyKey.DependencyProperty;

    static ChapterResizer()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(ChapterResizer), new FrameworkPropertyMetadata(typeof(ChapterResizer)));
    }

    /// <summary>
    ///     Gets or sets all frame ChapterResizer widths and heights. Left,Top,Right,Bottom.
    /// </summary>
    /// <value>Default: 6.</value>
    [DefaultValue(6)]
    public Thickness FrameSizes
    {
        get => (Thickness)GetValue(FrameSizesProperty);
        set => SetValue(FrameSizesProperty, value);
    }

    /// <summary>
    ///     Gets or sets the width and height of all corner ChapterResizers.
    /// </summary>
    /// <value>Default: 12.</value>
    [DefaultValue(12)]
    public double CornerSize
    {
        get => (double)GetValue(CornerSizeProperty);
        set => SetValue(CornerSizeProperty, value);
    }

    /// <summary>
    ///     Gets or sets the width of the left frame ChapterResizer.
    /// </summary>
    /// <value>Default: 6.</value>
    [DefaultValue(6)]
    public double LeftWidth
    {
        get => (double)GetValue(LeftWidthProperty);
        private set => SetValue(LeftWidthPropertyKey, value);
    }

    /// <summary>
    ///     Gets or sets the height of the top frame ChapterResizer.
    /// </summary>
    /// <value>Default: 6.</value>
    [DefaultValue(6)]
    internal double TopHeight
    {
        get => (double)GetValue(TopHeightProperty);
        private set => SetValue(TopHeightPropertyKey, value);
    }

    /// <summary>
    ///     Gets or sets the width of the right frame ChapterResizer.
    /// </summary>
    /// <value>Default: 6.</value>
    [DefaultValue(6)]
    internal double RightWidth
    {
        get => (double)GetValue(RightWidthProperty);
        private set => SetValue(RightWidthPropertyKey, value);
    }

    /// <summary>
    ///     Gets or sets the height of the bottom frame ChapterResizer.
    /// </summary>
    /// <value>Default: 6.</value>
    [DefaultValue(6)]
    internal double BottomHeight
    {
        get => (double)GetValue(BottomHeightProperty);
        private set => SetValue(BottomHeightPropertyKey, value);
    }

    /// <summary>
    ///     The template gets added to the control.
    /// </summary>
    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();

        if (GetTemplateChild("PART_LeftThumb") is Thumb leftThumb)
            leftThumb.DragDelta += LeftThumb_DragDelta;

        if (GetTemplateChild("PART_LeftTopThumb") is Thumb leftTopThumb)
            leftTopThumb.DragDelta += LeftTopThumb_DragDelta;

        if (GetTemplateChild("PART_TopThumb") is Thumb topThumb)
            topThumb.DragDelta += TopThumb_DragDelta;

        if (GetTemplateChild("PART_RightTopThumb") is Thumb rightTopThumb)
            rightTopThumb.DragDelta += RightTopThumb_DragDelta;

        if (GetTemplateChild("PART_RightThumb") is Thumb rightThumb)
            rightThumb.DragDelta += RightThumb_DragDelta;

        if (GetTemplateChild("PART_RightBottomThumb") is Thumb rightBottomThumb)
            rightBottomThumb.DragDelta += RightBottomThumb_DragDelta;

        if (GetTemplateChild("PART_BottomThumb") is Thumb bottomThumb)
            bottomThumb.DragDelta += BottomThumb_DragDelta;

        if (GetTemplateChild("PART_LeftBottomThumb") is Thumb leftBottomThumb)
            leftBottomThumb.DragDelta += LeftBottomThumb_DragDelta;

        RefreshCornerVisibilities();
    }

    private double GetFinalWidth(double additionalValue)
    {
        if (double.IsNaN(Width))
            Width = ActualWidth;
        var newWidth = Width + additionalValue;
        return PrepareWidthByRange(newWidth < 0 ? 0 : newWidth);
    }

    private double PrepareWidthByRange(double p)
    {
        if (double.IsNaN(MinWidth) || p >= MinWidth)
        {
            if (double.IsNaN(MaxWidth) || p <= MaxWidth)
                return p;
            return MaxWidth;
        }

        return MinWidth;
    }

    private double GetFinalHeight(double additionalValue)
    {
        if (double.IsNaN(Height))
            Height = ActualHeight;
        var newHeight = Height + additionalValue;
        return PrepareHeightByRange(newHeight < 0 ? 0 : newHeight);
    }

    private double PrepareHeightByRange(double p)
    {
        if (double.IsNaN(MinHeight) || p >= MinHeight)
        {
            if (double.IsNaN(MaxHeight) || p <= MaxHeight)
                return p;
            return MaxHeight;
        }

        return MinHeight;
    }

    private void LeftThumb_DragDelta(object sender, DragDeltaEventArgs e)
    {
        Width = GetFinalWidth(e.HorizontalChange * -1);
    }

    private void LeftTopThumb_DragDelta(object sender, DragDeltaEventArgs e)
    {
        Width = GetFinalWidth(e.HorizontalChange * -1);
        Height = GetFinalHeight(e.VerticalChange * -1);
    }

    private void TopThumb_DragDelta(object sender, DragDeltaEventArgs e)
    {
        Height = GetFinalHeight(e.VerticalChange * -1);
    }

    private void RightTopThumb_DragDelta(object sender, DragDeltaEventArgs e)
    {
        Width = GetFinalWidth(e.HorizontalChange);
        Height = GetFinalHeight(e.VerticalChange * -1);
    }

    private void RightThumb_DragDelta(object sender, DragDeltaEventArgs e)
    {
        Width = GetFinalWidth(e.HorizontalChange);
    }

    private void RightBottomThumb_DragDelta(object sender, DragDeltaEventArgs e)
    {
        Width = GetFinalWidth(e.HorizontalChange);
        Height = GetFinalHeight(e.VerticalChange);
    }

    private void BottomThumb_DragDelta(object sender, DragDeltaEventArgs e)
    {
        Height = GetFinalHeight(e.VerticalChange);
    }

    private void LeftBottomThumb_DragDelta(object sender, DragDeltaEventArgs e)
    {
        Width = GetFinalWidth(e.HorizontalChange * -1);
        Height = GetFinalHeight(e.VerticalChange);
    }

    private static void OnFrameSizesChanged(DependencyObject owner, DependencyPropertyChangedEventArgs e)
    {
        var control = (ChapterResizer)owner;
        var thickness = (Thickness)e.NewValue;
        control.LeftWidth = thickness.Left;
        control.TopHeight = thickness.Top;
        control.RightWidth = thickness.Right;
        control.BottomHeight = thickness.Bottom;
        control.RefreshCornerVisibilities();
    }

    private void RefreshCornerVisibilities()
    {
        if (GetTemplateChild("PART_LeftTopThumb") is Thumb leftTopThumb)
            leftTopThumb.Visibility = LeftWidth > 0 && TopHeight > 0 ? Visibility.Visible : Visibility.Collapsed;

        if (GetTemplateChild("PART_RightTopThumb") is Thumb rightTopThumb)
            rightTopThumb.Visibility = TopHeight > 0 && RightWidth > 0 ? Visibility.Visible : Visibility.Collapsed;

        if (GetTemplateChild("PART_RightBottomThumb") is Thumb rightBottomThumb)
            rightBottomThumb.Visibility = RightWidth > 0 && BottomHeight > 0 ? Visibility.Visible : Visibility.Collapsed;

        if (GetTemplateChild("PART_LeftBottomThumb") is Thumb leftBottomThumb)
            leftBottomThumb.Visibility = BottomHeight > 0 && LeftWidth > 0 ? Visibility.Visible : Visibility.Collapsed;
    }
}