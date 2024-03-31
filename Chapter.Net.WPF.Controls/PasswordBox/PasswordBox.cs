// -----------------------------------------------------------------------------------------------------------------
// <copyright file="PasswordBox.cs" company="my-libraries">
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
    ///     Hosts and enhances the <see cref="System.Windows.Controls.PasswordBox" /> to be able to bind the password value and
    ///     show info text in the background.
    /// </summary>
    [TemplatePart(Name = "PART_InfoText", Type = typeof(TextBlock))]
    [TemplatePart(Name = "PART_PasswordBox", Type = typeof(System.Windows.Controls.PasswordBox))]
    public class PasswordBox : Control
    {
        /// <summary>
        ///     Identifies the <see cref="InfoAppearance" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty InfoAppearanceProperty =
            DependencyProperty.Register(nameof(InfoAppearance), typeof(InfoAppearance), typeof(PasswordBox), new UIPropertyMetadata(InfoAppearance.OnLostFocus, OnInfoAppearanceChanged));

        /// <summary>
        ///     Identifies the <see cref="InfoText" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty InfoTextProperty =
            DependencyProperty.Register(nameof(InfoText), typeof(string), typeof(PasswordBox), new UIPropertyMetadata(""));

        /// <summary>
        ///     Identifies the <see cref="InfoTextStyle" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty InfoTextStyleProperty =
            DependencyProperty.Register(nameof(InfoTextStyle), typeof(Style), typeof(PasswordBox), new UIPropertyMetadata(null));

        /// <summary>
        ///     Identifies the <see cref="Password" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.Register(nameof(Password), typeof(string), typeof(PasswordBox), new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnPasswordChanged));

        private TextBlock _infoText;
        private System.Windows.Controls.PasswordBox _innerPasswordBox;

        private bool _selfChange;

        static PasswordBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PasswordBox), new FrameworkPropertyMetadata(typeof(PasswordBox)));
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="PasswordBox" /> class.
        /// </summary>
        public PasswordBox()
        {
            Loaded += InfoTextBox_Loaded;
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

        private void InfoTextBox_Loaded(object sender, RoutedEventArgs e)
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

            _innerPasswordBox = GetTemplateChild("PART_PasswordBox") as System.Windows.Controls.PasswordBox;
            if (_innerPasswordBox != null)
            {
                _innerPasswordBox.PasswordChanged += PasswordBox_PasswordChanged;

                _innerPasswordBox.GotFocus += InnerPasswordBox_GotFocus;
                _innerPasswordBox.LostFocus += InnerPasswordBox_LostFocus;
                _innerPasswordBox.PasswordChanged += InnerPasswordBox_PasswordChanged;
            }

            RefreshInfoAppearance();
        }

        private void InnerPasswordBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (GetInfoTextBlock())
                if (InfoAppearance != InfoAppearance.OnEmpty)
                    _infoText.Visibility = Visibility.Collapsed;
        }

        private void InnerPasswordBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (GetInfoTextBlock())
                if (InfoAppearance != InfoAppearance.None &&
                    string.IsNullOrEmpty(Password))
                    _infoText.Visibility = Visibility.Visible;
        }

        private void InnerPasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (GetInfoTextBlock())
            {
                var passwordBox = (System.Windows.Controls.PasswordBox)sender;
                if (string.IsNullOrEmpty(passwordBox.Password))
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
            if (_innerPasswordBox != null)
                _innerPasswordBox.Focus();
            base.OnGotFocus(e);
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            var box = (System.Windows.Controls.PasswordBox)sender;
            _selfChange = true;
            Password = box.Password;
            _selfChange = false;
        }

        private static void OnPasswordChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            TakePasswordOver(o as PasswordBox, e.NewValue);
        }

        private static void TakePasswordOver(PasswordBox control, object password)
        {
            if (!control._selfChange &&
                password != null &&
                control._innerPasswordBox != null)
            {
                control._innerPasswordBox.PasswordChanged -= control.PasswordBox_PasswordChanged;
                control._innerPasswordBox.Password = password.ToString();
                control._innerPasswordBox.PasswordChanged += control.PasswordBox_PasswordChanged;
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
            if (_infoText == null)
                _infoText = GetTemplateChild("PART_InfoText") as TextBlock;
            return _infoText != null;
        }

        private static void OnInfoAppearanceChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            ((PasswordBox)sender).RefreshInfoAppearance();
        }
    }
}