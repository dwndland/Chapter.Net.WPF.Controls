// -----------------------------------------------------------------------------------------------------------------
// <copyright file="TimeBox.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls
{
    /// <summary>
    ///     Shows textboxes to let the user input a time.
    /// </summary>
    [TemplatePart(Name = "PART_HourBox", Type = typeof(ChapterNumberBox))]
    [TemplatePart(Name = "PART_MinuteBox", Type = typeof(ChapterNumberBox))]
    [TemplatePart(Name = "PART_SecondBox", Type = typeof(ChapterNumberBox))]
    [TemplatePart(Name = "PART_UpButton", Type = typeof(UpDownButton))]
    [TemplatePart(Name = "PART_DownButton", Type = typeof(UpDownButton))]
    public class TimeBox : Control
    {
        /// <summary>
        ///     Identifies the <see cref="Time" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty TimeProperty =
            DependencyProperty.Register(nameof(Time), typeof(TimeSpan), typeof(TimeBox), new FrameworkPropertyMetadata(TimeSpan.Zero, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnTimeChanged));

        /// <summary>
        ///     Identifies the <see cref="TimeFormat" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty TimeFormatProperty =
            DependencyProperty.Register(nameof(TimeFormat), typeof(TimeFormat), typeof(TimeBox), new UIPropertyMetadata(TimeFormat.Short));

        /// <summary>
        ///     Identifies the <see cref="HasUpDownButtons" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty HasUpDownButtonsProperty =
            DependencyProperty.Register(nameof(HasUpDownButtons), typeof(bool), typeof(TimeBox), new UIPropertyMetadata(true));

        private ChapterNumberBox _focusedBox;
        private ChapterNumberBox _hourBox;
        private ChapterNumberBox _minuteBox;
        private ChapterNumberBox _secondBox;
        private bool _selfChange;

        static TimeBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TimeBox), new FrameworkPropertyMetadata(typeof(TimeBox)));
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="TimeBox" /> class.
        /// </summary>
        public TimeBox()
        {
            AddHandler(ChapterNumberBox.NumberChangedEvent, new NumberChangedEventHandler(HandleChapterNumberBoxNumberChanged));
        }

        /// <summary>
        ///     Gets or sets the time shown in the text box.
        /// </summary>
        /// <value>Default: TimeSpan.Zero.</value>
        public TimeSpan Time
        {
            get => (TimeSpan)GetValue(TimeProperty);
            set => SetValue(TimeProperty, value);
        }

        /// <summary>
        ///     Gets or sets the format of the time the user can edit.
        /// </summary>
        /// <value>Default: TimeFormat.Short.</value>
        [DefaultValue(TimeFormat.Short)]
        public TimeFormat TimeFormat
        {
            get => (TimeFormat)GetValue(TimeFormatProperty);
            set => SetValue(TimeFormatProperty, value);
        }

        /// <summary>
        ///     Gets or sets a value that indicates if the time box has up down buttons or not.
        /// </summary>
        /// <value>Default: true.</value>
        [DefaultValue(true)]
        public bool HasUpDownButtons
        {
            get => (bool)GetValue(HasUpDownButtonsProperty);
            set => SetValue(HasUpDownButtonsProperty, value);
        }

        private static void OnTimeChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var control = (TimeBox)sender;
            control.OnTimeChanged();
        }

        /// <summary>
        ///     The template gets added to the control.
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _hourBox = CatchBox("PART_HourBox");
            _minuteBox = CatchBox("PART_MinuteBox");
            _secondBox = CatchBox("PART_SecondBox");
            CatchButton("PART_UpButton", Up_Click);
            CatchButton("PART_DownButton", Down_Click);

            TakeTime();
        }

        private void OnTimeChanged()
        {
            if (!_selfChange && IsLoaded)
                TakeTime();
        }

        private void TakeTime()
        {
            _selfChange = true;
            _hourBox.Number = Time.Hours;
            _minuteBox.Number = Time.Minutes;
            _secondBox.Number = Time.Seconds;
            _selfChange = false;
        }

        private ChapterNumberBox CatchBox(string name)
        {
            var ChapterNumberBox = GetTemplateChild(name) as ChapterNumberBox;
            if (ChapterNumberBox != null)
            {
                ChapterNumberBox.GotFocus += ChapterNumberBoxOnGotFocus;
                ChapterNumberBox.PreviewKeyDown += ChapterNumberBoxOnPreviewKeyDown;
                ChapterNumberBox.PreviewKeyUp += ChapterNumberBoxOnPreviewKeyUp;
            }

            return ChapterNumberBox;
        }

        private void CatchButton(string name, RoutedEventHandler handler)
        {
            if (GetTemplateChild(name) is UpDownButton ChapterNumberBox)
                ChapterNumberBox.Click += handler;
        }

        private void HandleChapterNumberBoxNumberChanged(object sender, NumberChangedEventArgs e)
        {
            if (_selfChange)
                return;

            _selfChange = true;
            Time = new TimeSpan(GetNumber(_hourBox),
                GetNumber(_minuteBox),
                TimeFormat == TimeFormat.Long ? GetNumber(_secondBox) : 0);
            _selfChange = false;
        }

        private int GetNumber(ChapterNumberBox box)
        {
            if (box.Number == null)
                return (int)box.DefaultNumber;
            return (int)box.Number;
        }

        private void ChapterNumberBoxOnGotFocus(object sender, RoutedEventArgs routedEventArgs)
        {
            _focusedBox = (ChapterNumberBox)sender;
        }

        private void ChapterNumberBoxOnPreviewKeyDown(object sender, KeyEventArgs keyEventArgs)
        {
            var box = (ChapterNumberBox)sender;
            switch (keyEventArgs.Key)
            {
                case Key.Left:
                    MoveCaretLeft(box);
                    break;
                case Key.Right:
                    MoveCaretRight(box);
                    break;
            }
        }

        private void ChapterNumberBoxOnPreviewKeyUp(object sender, KeyEventArgs keyEventArgs)
        {
            var box = (ChapterNumberBox)sender;
            if (box.SelectionStart == 2)
                MoveCaretRight(box);
        }

        private void MoveCaretLeft(ChapterNumberBox ChapterNumberBox)
        {
            if (Equals(ChapterNumberBox, _hourBox))
                return;

            if (ChapterNumberBox.SelectionStart == 0)
                ChapterNumberBox.Tab(FocusNavigationDirection.Left);
        }

        private void MoveCaretRight(ChapterNumberBox ChapterNumberBox)
        {
            if (TimeFormat == TimeFormat.Long && Equals(ChapterNumberBox, _secondBox))
                return;

            if (TimeFormat == TimeFormat.Short && Equals(ChapterNumberBox, _minuteBox))
                return;

            if (ChapterNumberBox.Text.Length == ChapterNumberBox.SelectionStart)
                ChapterNumberBox.Tab(FocusNavigationDirection.Right);
        }

        private void Up_Click(object sender, RoutedEventArgs e)
        {
            if (_focusedBox != null)
                ChangeValue(_focusedBox, 1);
        }

        private void Down_Click(object sender, RoutedEventArgs e)
        {
            if (_focusedBox != null)
                ChangeValue(_focusedBox, -1);
        }

        private void ChangeValue(ChapterNumberBox box, int step)
        {
            var value = GetNumber(box) + step;
            if (value >= 60)
                value -= 60;
            else if (value <= -1)
                value += 60;
            box.Number = value;
        }
    }
}