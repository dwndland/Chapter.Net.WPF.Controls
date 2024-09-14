// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ChapterPasswordBox.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using Chapter.Net.WPF.Controls.Bases;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls;

/// <summary>
///     Hosts and enhances the <see cref="PasswordBox" /> to be able to bind the password value and
///     show info text in the background.
/// </summary>
[TemplatePart(Name = "PART_InfoText", Type = typeof(TextBlock))]
[TemplatePart(Name = "PART_ChapterPasswordBox", Type = typeof(PasswordBox))]
public class ChapterPasswordBox : ControlBase
{
    /// <summary>
    ///     The ChapterPasswordBox style key.
    /// </summary>
    public static readonly ComponentResourceKey StyleKey = new(typeof(ChapterPasswordBox), "ChapterPasswordBox");

    /// <summary>
    ///     Identifies the <see cref="InfoAppearance" /> dependency property.
    /// </summary>
    public static readonly DependencyProperty InfoAppearanceProperty =
        DependencyProperty.Register(nameof(InfoAppearance), typeof(InfoAppearance), typeof(ChapterPasswordBox), new UIPropertyMetadata(InfoAppearance.OnLostFocus, OnInfoAppearanceChanged));

    /// <summary>
    ///     Identifies the <see cref="InfoText" /> dependency property.
    /// </summary>
    public static readonly DependencyProperty InfoTextProperty =
        DependencyProperty.Register(nameof(InfoText), typeof(string), typeof(ChapterPasswordBox), new UIPropertyMetadata(""));

    /// <summary>
    ///     Identifies the <see cref="InfoTextStyle" /> dependency property.
    /// </summary>
    public static readonly DependencyProperty InfoTextStyleProperty =
        DependencyProperty.Register(nameof(InfoTextStyle), typeof(Style), typeof(ChapterPasswordBox), new UIPropertyMetadata(null));

    /// <summary>
    ///     Identifies the <see cref="Password" /> dependency property.
    /// </summary>
    public static readonly DependencyProperty PasswordProperty =
        DependencyProperty.Register(nameof(Password), typeof(string), typeof(ChapterPasswordBox), new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnPasswordChanged));

    private TextBlock _infoText;
    private PasswordBox _innerChapterPasswordBox;

    private bool _selfChange;

    static ChapterPasswordBox()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(ChapterPasswordBox), new FrameworkPropertyMetadata(typeof(ChapterPasswordBox)));
    }

    /// <summary>
    ///     Gets or sets a value which indicated when the info text in the background is shown.
    /// </summary>
    /// <value>Default: InfoAppearance.OnLostFocus.</value>
    [DefaultValue(InfoAppearance.OnLostFocus)]
    public InfoAppearance InfoAppearance
    {
        get => (InfoAppearance)GetValue(InfoAppearanceProperty);
        set => SetValue(InfoAppearanceProperty, value);
    }

    /// <summary>
    ///     Gets or sets the info text shown in the background.
    /// </summary>
    /// <value>Default: "".</value>
    [DefaultValue("")]
    public string InfoText
    {
        get => (string)GetValue(InfoTextProperty);
        set => SetValue(InfoTextProperty, value);
    }

    /// <summary>
    ///     Gets or sets the style of the info text shown in the background.
    /// </summary>
    /// <value>Default: null.</value>
    [DefaultValue(null)]
    public Style InfoTextStyle
    {
        get => (Style)GetValue(InfoTextStyleProperty);
        set => SetValue(InfoTextStyleProperty, value);
    }

    /// <summary>
    ///     Gets or sets the password typed in the text box.
    /// </summary>
    /// <value>Default: "".</value>
    [DefaultValue("")]
    public string Password
    {
        get => (string)GetValue(PasswordProperty);
        set => SetValue(PasswordProperty, value);
    }

    /// <inheritdoc />
    protected override void OnLoaded(object sender, RoutedEventArgs e)
    {
        RefreshInfoAppearance();
        if (!string.IsNullOrEmpty(Password))
            TakePasswordOver(this, Password);
    }

    /// <summary>
    ///     The template gets added to the control.
    /// </summary>
    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();

        _innerChapterPasswordBox = GetTemplateChild("PART_ChapterPasswordBox") as PasswordBox;
        if (_innerChapterPasswordBox != null)
        {
            _innerChapterPasswordBox.PasswordChanged += ChapterPasswordBox_PasswordChanged;

            _innerChapterPasswordBox.GotFocus += InnerChapterPasswordBox_GotFocus;
            _innerChapterPasswordBox.LostFocus += InnerChapterPasswordBox_LostFocus;
            _innerChapterPasswordBox.PasswordChanged += InnerChapterPasswordBox_PasswordChanged;
        }

        RefreshInfoAppearance();
    }

    private void InnerChapterPasswordBox_GotFocus(object sender, RoutedEventArgs e)
    {
        if (GetInfoTextBlock())
            if (InfoAppearance != InfoAppearance.OnEmpty)
                _infoText.Visibility = Visibility.Collapsed;
    }

    private void InnerChapterPasswordBox_LostFocus(object sender, RoutedEventArgs e)
    {
        if (GetInfoTextBlock())
            if (InfoAppearance != InfoAppearance.None &&
                string.IsNullOrEmpty(Password))
                _infoText.Visibility = Visibility.Visible;
    }

    private void InnerChapterPasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
    {
        if (GetInfoTextBlock())
        {
            var ChapterPasswordBox = (PasswordBox)sender;
            if (string.IsNullOrEmpty(ChapterPasswordBox.Password))
            {
                if (InfoAppearance == InfoAppearance.OnEmpty)
                    _infoText.Visibility = Visibility.Visible;
            }
            else if (_infoText.Visibility == Visibility.Visible)
            {
                _infoText.Visibility = Visibility.Collapsed;
            }
        }
    }

    /// <summary>
    ///     Moves the focus into the inner password box if the control got the focus.
    /// </summary>
    /// <param name="e">The parameter passed by the caller.</param>
    protected override void OnGotFocus(RoutedEventArgs e)
    {
        if (_innerChapterPasswordBox != null)
            _innerChapterPasswordBox.Focus();
        base.OnGotFocus(e);
    }

    private void ChapterPasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
    {
        var box = (PasswordBox)sender;
        _selfChange = true;
        Password = box.Password;
        _selfChange = false;
    }

    private static void OnPasswordChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
    {
        TakePasswordOver(o as ChapterPasswordBox, e.NewValue);
    }

    private static void TakePasswordOver(ChapterPasswordBox control, object password)
    {
        if (!control._selfChange &&
            password != null &&
            control._innerChapterPasswordBox != null)
        {
            control._innerChapterPasswordBox.PasswordChanged -= control.ChapterPasswordBox_PasswordChanged;
            control._innerChapterPasswordBox.Password = password.ToString()!;
            control._innerChapterPasswordBox.PasswordChanged += control.ChapterPasswordBox_PasswordChanged;
        }
    }

    private void RefreshInfoAppearance()
    {
        if (GetInfoTextBlock())
        {
            if (InfoAppearance == InfoAppearance.None)
                _infoText.Visibility = Visibility.Collapsed;
            if (!string.IsNullOrEmpty(Password))
                _infoText.Visibility = Visibility.Collapsed;
        }
    }

    private bool GetInfoTextBlock()
    {
        _infoText ??= GetTemplateChild("PART_InfoText") as TextBlock;
        return _infoText != null;
    }

    private static void OnInfoAppearanceChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
    {
        ((ChapterPasswordBox)sender).RefreshInfoAppearance();
    }
}