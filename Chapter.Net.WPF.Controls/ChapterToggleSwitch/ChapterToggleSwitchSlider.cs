// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ChapterToggleSwitchSlider.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls
{
    /// <summary>
    ///     The slider shown in the <see cref="ChapterToggleSwitch" />.
    /// </summary>
    public class ChapterToggleSwitchSlider : Control
    {
        /// <summary>
        ///     The DependencyProperty for the Shape property.
        /// </summary>
        public static readonly DependencyProperty ShapeProperty =
            DependencyProperty.Register(nameof(Shape), typeof(ChapterToggleSwitchShape), typeof(ChapterToggleSwitchSlider), new PropertyMetadata(ChapterToggleSwitchShape.Round));

        static ChapterToggleSwitchSlider()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ChapterToggleSwitchSlider), new FrameworkPropertyMetadata(typeof(ChapterToggleSwitchSlider)));
        }

        /// <summary>
        ///     Gets or sets the shape of the slider.
        /// </summary>
        /// <value>Default: ChapterToggleSwitchShape.Round.</value>
        [DefaultValue(ChapterToggleSwitchShape.Round)]
        public ChapterToggleSwitchShape Shape
        {
            get => (ChapterToggleSwitchShape)GetValue(ShapeProperty);
            set => SetValue(ShapeProperty, value);
        }
    }
}