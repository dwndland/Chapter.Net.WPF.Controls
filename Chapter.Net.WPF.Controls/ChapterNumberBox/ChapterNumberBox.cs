// -----------------------------------------------------------------------------------------------------------------
// <copyright file="ChapterNumberBox.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Threading;
using Chapter.Net.WPF.Controls.Bases;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls;

/// <summary>
///     Displays a <see cref="TextBox" /> to accept numeric values only, so the text can be bound to a numeric property
///     directly without converting.
/// </summary>
[TemplatePart(Name = "PART_TextBox", Type = typeof(TextBox))]
[TemplatePart(Name = "PART_UpButton", Type = typeof(RepeatButton))]
[TemplatePart(Name = "PART_DownButton", Type = typeof(RepeatButton))]
[TemplatePart(Name = "PART_ResetButton", Type = typeof(Button))]
public class ChapterNumberBox : ControlBase
{
    /// <summary>
    ///     The ChapterNumberBox style key.
    /// </summary>
    public static readonly ComponentResourceKey StyleKey = new(typeof(ChapterNumberBox), "ChapterNumberBox");

    /// <summary>
    ///     Identifies the <see cref="NumberType" /> dependency property.
    /// </summary>
    public static readonly DependencyProperty NumberTypeProperty =
        DependencyProperty.Register(nameof(NumberType), typeof(NumberType), typeof(ChapterNumberBox), new PropertyMetadata(NumberType.Int, OnNumberTypeChanged));

    /// <summary>
    ///     Identifies the <see cref="Number{T}" /> dependency property.
    /// </summary>
    public static readonly DependencyProperty NumberProperty =
        DependencyProperty.Register(nameof(Number), typeof(object), typeof(ChapterNumberBox), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnNumberChanged));

    /// <summary>
    ///     Identifies the <see cref="Minimum" /> dependency property.
    /// </summary>
    public static readonly DependencyProperty MinimumProperty =
        DependencyProperty.Register(nameof(Minimum), typeof(object), typeof(ChapterNumberBox), new PropertyMetadata(OnMinimumChanged));

    /// <summary>
    ///     Identifies the <see cref="Maximum" /> dependency property.
    /// </summary>
    public static readonly DependencyProperty MaximumProperty =
        DependencyProperty.Register(nameof(Maximum), typeof(object), typeof(ChapterNumberBox), new PropertyMetadata(OnMaximumChanged));

    /// <summary>
    ///     Identifies the <see cref="Unit" /> dependency property.
    /// </summary>
    public static readonly DependencyProperty UnitProperty =
        DependencyProperty.Register(nameof(Unit), typeof(object), typeof(ChapterNumberBox), new PropertyMetadata(null));

    /// <summary>
    ///     Identifies the <see cref="UnitPosition" /> dependency property.
    /// </summary>
    public static readonly DependencyProperty UnitPositionProperty =
        DependencyProperty.Register(nameof(UnitPosition), typeof(Dock), typeof(ChapterNumberBox), new PropertyMetadata(Dock.Right));

    /// <summary>
    ///     Identifies the <see cref="HasCheckBox" /> dependency property.
    /// </summary>
    public static readonly DependencyProperty HasCheckBoxProperty =
        DependencyProperty.Register(nameof(HasCheckBox), typeof(bool), typeof(ChapterNumberBox), new PropertyMetadata(false));

    /// <summary>
    ///     Identifies the <see cref="IsChecked" /> dependency property.
    /// </summary>
    public static readonly DependencyProperty IsCheckedProperty =
        DependencyProperty.Register(nameof(IsChecked), typeof(bool), typeof(ChapterNumberBox), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

    /// <summary>
    ///     Identifies the <see cref="CheckBoxBehavior" /> dependency property.
    /// </summary>
    public static readonly DependencyProperty CheckBoxBehaviorProperty =
        DependencyProperty.Register(nameof(CheckBoxBehavior), typeof(ChapterNumberBoxCheckBoxBehavior), typeof(ChapterNumberBox), new PropertyMetadata(ChapterNumberBoxCheckBoxBehavior.None));

    /// <summary>
    ///     Identifies the <see cref="CheckBoxPosition" /> dependency property.
    /// </summary>
    public static readonly DependencyProperty CheckBoxPositionProperty =
        DependencyProperty.Register(nameof(CheckBoxPosition), typeof(Dock), typeof(ChapterNumberBox), new PropertyMetadata(Dock.Left));

    /// <summary>
    ///     Identifies the <see cref="UpDownBehavior" /> dependency property.
    /// </summary>
    public static readonly DependencyProperty UpDownBehaviorProperty =
        DependencyProperty.Register(nameof(UpDownBehavior), typeof(UpDownBehavior), typeof(ChapterNumberBox), new PropertyMetadata(UpDownBehavior.None));

    /// <summary>
    ///     Identifies the <see cref="Step" /> dependency property.
    /// </summary>
    public static readonly DependencyProperty StepProperty =
        DependencyProperty.Register(nameof(Step), typeof(object), typeof(ChapterNumberBox), new PropertyMetadata(null, OnStepChanged));

    /// <summary>
    ///     Identifies the <see cref="UpDownButtonsPosition" /> dependency property.
    /// </summary>
    public static readonly DependencyProperty UpDownButtonsPositionProperty =
        DependencyProperty.Register(nameof(UpDownButtonsPosition), typeof(Dock), typeof(ChapterNumberBox), new PropertyMetadata(Dock.Right));

    /// <summary>
    ///     Identifies the <see cref="CanStepUp" /> dependency property.
    /// </summary>
    public static readonly DependencyProperty CanStepUpProperty =
        DependencyProperty.Register(nameof(CanStepUp), typeof(bool), typeof(ChapterNumberBox), new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

    /// <summary>
    ///     Identifies the <see cref="CanStepDown" /> dependency property.
    /// </summary>
    public static readonly DependencyProperty CanStepDownProperty =
        DependencyProperty.Register(nameof(CanStepDown), typeof(bool), typeof(ChapterNumberBox), new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

    /// <summary>
    ///     Identifies the <see cref="HasResetButton" /> dependency property.
    /// </summary>
    public static readonly DependencyProperty HasResetButtonProperty =
        DependencyProperty.Register(nameof(HasResetButton), typeof(bool), typeof(ChapterNumberBox), new PropertyMetadata(false));

    /// <summary>
    ///     Identifies the <see cref="DefaultNumber" /> dependency property.
    /// </summary>
    public static readonly DependencyProperty DefaultNumberProperty =
        DependencyProperty.Register(nameof(DefaultNumber), typeof(object), typeof(ChapterNumberBox), new PropertyMetadata(null, OnDefaultNumberChanged));

    /// <summary>
    ///     Identifies the <see cref="ResetButtonPosition" /> dependency property.
    /// </summary>
    public static readonly DependencyProperty ResetButtonPositionProperty =
        DependencyProperty.Register(nameof(ResetButtonPosition), typeof(Dock), typeof(ChapterNumberBox), new PropertyMetadata(Dock.Right));

    /// <summary>
    ///     Identifies the <see cref="CanReset" /> dependency property.
    /// </summary>
    public static readonly DependencyProperty CanResetProperty =
        DependencyProperty.Register(nameof(CanReset), typeof(bool), typeof(ChapterNumberBox), new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

    /// <summary>
    ///     Identifies the <see cref="NumberSelectionBehavior" /> dependency property.
    /// </summary>
    public static readonly DependencyProperty NumberSelectionBehaviorProperty =
        DependencyProperty.Register(nameof(NumberSelectionBehavior), typeof(ChapterNumberBoxSelection), typeof(ChapterNumberBox), new PropertyMetadata(ChapterNumberBoxSelection.None));

    /// <summary>
    ///     Identifies the <see cref="LostFocusBehavior" /> dependency property.
    /// </summary>
    public static readonly DependencyProperty LostFocusBehaviorProperty =
        DependencyProperty.Register(nameof(LostFocusBehavior), typeof(LostFocusBehavior), typeof(ChapterNumberBox), new PropertyMetadata(null));

    /// <summary>
    ///     Identifies the <see cref="InputCulture" /> dependency property.
    /// </summary>
    public static readonly DependencyProperty InputCultureProperty =
        DependencyProperty.Register(nameof(InputCulture), typeof(CultureInfo), typeof(ChapterNumberBox), new PropertyMetadata(null, OnInputCultureChanged));

    /// <summary>
    ///     Identifies the <see cref="PredefinesCulture" /> dependency property.
    /// </summary>
    public static readonly DependencyProperty PredefinesCultureProperty =
        DependencyProperty.Register(nameof(PredefinesCulture), typeof(CultureInfo), typeof(ChapterNumberBox), new PropertyMetadata(null));

    /// <summary>
    ///     Identifies the <see cref="NumberChanged" /> routed event.
    /// </summary>
    public static readonly RoutedEvent NumberChangedEvent =
        EventManager.RegisterRoutedEvent(nameof(NumberChanged), RoutingStrategy.Bubble, typeof(NumberChangedEventHandler), typeof(ChapterNumberBox));

    /// <summary>
    ///     Identifies the <see cref="IsReadOnly" /> dependency property.
    /// </summary>
    public static readonly DependencyProperty IsReadOnlyProperty =
        DependencyProperty.Register(nameof(IsReadOnly), typeof(bool), typeof(ChapterNumberBox), new PropertyMetadata(false));

    /// <summary>
    ///     Identifies the <see cref="AcceptUpDownOnNull" /> dependency property.
    /// </summary>
    public static readonly DependencyProperty AcceptUpDownOnNullProperty =
        DependencyProperty.Register(nameof(AcceptUpDownOnNull), typeof(bool), typeof(ChapterNumberBox), new PropertyMetadata(false));

    /// <summary>
    ///     Identifies the <see cref="DecimalPlaces" /> dependency property.
    /// </summary>
    public static readonly DependencyProperty DecimalPlacesProperty =
        DependencyProperty.Register(nameof(DecimalPlaces), typeof(int), typeof(ChapterNumberBox), new PropertyMetadata(-1, OnDecimalPlacesChanged));

    private RepeatButton _downButton;
    private INumber _number;
    private Button _resetButton;
    private bool _selfChange;
    private TextBox _textBox;
    private RepeatButton _upButton;

    static ChapterNumberBox()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(ChapterNumberBox), new FrameworkPropertyMetadata(typeof(ChapterNumberBox)));
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ChapterNumberBox" /> class.
    /// </summary>
    public ChapterNumberBox()
    {
        _number = NumberFactory.Create(NumberType);
    }

    /// <summary>
    ///     Gets or sets the type of number to be supported in the ChapterNumberBox.
    /// </summary>
    /// <value>Default: NumberType.Int.</value>
    [DefaultValue(NumberType.Int)]
    public NumberType NumberType
    {
        get => (NumberType)GetValue(NumberTypeProperty);
        set => SetValue(NumberTypeProperty, value);
    }

    /// <summary>
    ///     Gets or sets the number value. It can be any of the <see cref="NumberType" />.
    /// </summary>
    /// <value>Default: null.</value>
    [DefaultValue(null)]
    public object Number
    {
        get => GetValue(NumberProperty);
        set => SetValue(NumberProperty, value);
    }

    /// <summary>
    ///     Gets or sets the minimum value to be written into the ChapterNumberBox.
    /// </summary>
    /// <value>Default: null.</value>
    [DefaultValue(null)]
    public object Minimum
    {
        get => GetValue(MinimumProperty);
        set => SetValue(MinimumProperty, value);
    }

    /// <summary>
    ///     Gets or sets the maximum value to be written into the ChapterNumberBox.
    /// </summary>
    /// <value>Default: null.</value>
    [DefaultValue(null)]
    public object Maximum
    {
        get => GetValue(MaximumProperty);
        set => SetValue(MaximumProperty, value);
    }

    /// <summary>
    ///     Gets or sets the unit.
    /// </summary>
    /// <value>Default: null.</value>
    [DefaultValue(null)]
    public object Unit
    {
        get => GetValue(UnitProperty);
        set => SetValue(UnitProperty, value);
    }

    /// <summary>
    ///     Gets or sets the position of the unit within the ChapterNumberBox.
    /// </summary>
    /// <value>Default: Dock.Right.</value>
    [DefaultValue(Dock.Right)]
    public Dock UnitPosition
    {
        get => (Dock)GetValue(UnitPositionProperty);
        set => SetValue(UnitPositionProperty, value);
    }

    /// <summary>
    ///     Gets or sets the value which indicates if a checkbox is shown in the ChapterNumberBox.
    /// </summary>
    /// <value>Default: false.</value>
    [DefaultValue(false)]
    public bool HasCheckBox
    {
        get => (bool)GetValue(HasCheckBoxProperty);
        set => SetValue(HasCheckBoxProperty, value);
    }

    /// <summary>
    ///     Gets or sets the value which indicates of the checkbox is checked.
    /// </summary>
    /// <value>Default: false.</value>
    [DefaultValue(false)]
    public bool IsChecked
    {
        get => (bool)GetValue(IsCheckedProperty);
        set => SetValue(IsCheckedProperty, value);
    }

    /// <summary>
    ///     Gets or sets the behavior of the checkbox.
    /// </summary>
    /// <value>Default: ChapterNumberBoxCheckBoxBehavior.None.</value>
    [DefaultValue(ChapterNumberBoxCheckBoxBehavior.None)]
    public ChapterNumberBoxCheckBoxBehavior CheckBoxBehavior
    {
        get => (ChapterNumberBoxCheckBoxBehavior)GetValue(CheckBoxBehaviorProperty);
        set => SetValue(CheckBoxBehaviorProperty, value);
    }

    /// <summary>
    ///     Gets or sets the position of the checkbox.
    /// </summary>
    /// <value>Default: Dock.Left.</value>
    [DefaultValue(Dock.Left)]
    public Dock CheckBoxPosition
    {
        get => (Dock)GetValue(CheckBoxPositionProperty);
        set => SetValue(CheckBoxPositionProperty, value);
    }

    /// <summary>
    ///     Gets or sets the possibilities how the values can be incremented or decremented.
    /// </summary>
    /// <value>Default: UpDownBehavior.None.</value>
    [DefaultValue(UpDownBehavior.None)]
    public UpDownBehavior UpDownBehavior
    {
        get => (UpDownBehavior)GetValue(UpDownBehaviorProperty);
        set => SetValue(UpDownBehaviorProperty, value);
    }

    /// <summary>
    ///     Gets or sets the step width to be used when increment the value by the buttons or arrow keys.
    /// </summary>
    /// <value>Default: null.</value>
    [DefaultValue(null)]
    public object Step
    {
        get => GetValue(StepProperty);
        set => SetValue(StepProperty, value);
    }

    /// <summary>
    ///     Gets or sets the position of the up/down buttons.
    /// </summary>
    /// <value>Default: Dock.Left.</value>
    [DefaultValue(Dock.Left)]
    public Dock UpDownButtonsPosition
    {
        get => (Dock)GetValue(UpDownButtonsPositionProperty);
        set => SetValue(UpDownButtonsPositionProperty, value);
    }

    /// <summary>
    ///     Gets or sets a value which indicates if the current number can step up.
    /// </summary>
    /// <value>Default: true.</value>
    [DefaultValue(true)]
    public bool CanStepUp
    {
        get => (bool)GetValue(CanStepUpProperty);
        set => SetValue(CanStepUpProperty, value);
    }

    /// <summary>
    ///     Gets or sets a value which indicates if the current number can step down.
    /// </summary>
    /// <value>Default: true.</value>
    [DefaultValue(true)]
    public bool CanStepDown
    {
        get => (bool)GetValue(CanStepDownProperty);
        set => SetValue(CanStepDownProperty, value);
    }

    /// <summary>
    ///     Gets or sets a value which indicates if the ChapterNumberBox has a cancel 'X' button.
    /// </summary>
    /// <value>Default: false.</value>
    [DefaultValue(false)]
    public bool HasResetButton
    {
        get => (bool)GetValue(HasResetButtonProperty);
        set => SetValue(HasResetButtonProperty, value);
    }

    /// <summary>
    ///     Gets or sets the default value to place in when the "ResetButton" (See <see cref="HasResetButton" />) is clicked.
    /// </summary>
    /// <value>Default: null.</value>
    [DefaultValue(null)]
    public object DefaultNumber
    {
        get => GetValue(DefaultNumberProperty);
        set => SetValue(DefaultNumberProperty, value);
    }

    /// <summary>
    ///     Gets or sets the position of the reset button within the ChapterNumberBox.
    /// </summary>
    /// <value>Default: Dock.Right.</value>
    [DefaultValue(Dock.Right)]
    public Dock ResetButtonPosition
    {
        get => (Dock)GetValue(ResetButtonPositionProperty);
        set => SetValue(ResetButtonPositionProperty, value);
    }

    /// <summary>
    ///     Gets or sets a value which indicates if the reset button can be clicked.
    /// </summary>
    /// <value>Default: true.</value>
    [DefaultValue(true)]
    public bool CanReset
    {
        get => (bool)GetValue(CanResetProperty);
        set => SetValue(CanResetProperty, value);
    }

    /// <summary>
    ///     Gets or sets a value that defines when the number should be selected automatically.
    /// </summary>
    /// <value>Default: ChapterNumberBoxSelection.None.</value>
    [DefaultValue(ChapterNumberBoxSelection.None)]
    public ChapterNumberBoxSelection NumberSelectionBehavior
    {
        get => (ChapterNumberBoxSelection)GetValue(NumberSelectionBehaviorProperty);
        set => SetValue(NumberSelectionBehaviorProperty, value);
    }

    /// <summary>
    ///     Gets or sets the behavior to be applied to the number and/or text when the ChapterNumberBox lost its focus.
    /// </summary>
    /// <value>Default: null.</value>
    [DefaultValue(null)]
    public LostFocusBehavior LostFocusBehavior
    {
        get => (LostFocusBehavior)GetValue(LostFocusBehaviorProperty);
        set => SetValue(LostFocusBehaviorProperty, value);
    }

    /// <summary>
    ///     Gets or sets the culture to be used to parse the user input.
    /// </summary>
    /// <value>Default: CultureInfo.CurrentUICulture.</value>
    public CultureInfo InputCulture
    {
        get => (CultureInfo)GetValue(InputCultureProperty);
        set => SetValue(InputCultureProperty, value);
    }

    /// <summary>
    ///     Gets or sets the culture to be used to parse the value defined in the xaml file like
    ///     <see cref="Minimum" />, <see cref="Maximum" /> and <see cref="DefaultNumber" />.
    /// </summary>
    /// <value>Default: CultureInfo.CurrentUICulture.</value>
    public CultureInfo PredefinesCulture
    {
        get => (CultureInfo)GetValue(PredefinesCultureProperty);
        set => SetValue(PredefinesCultureProperty, value);
    }

    /// <summary>
    ///     Gets or sets a value if the ChapterNumberBox is shown read only.
    /// </summary>
    /// <value>Default: false.</value>
    [DefaultValue(false)]
    public bool IsReadOnly
    {
        get => (bool)GetValue(IsReadOnlyProperty);
        set => SetValue(IsReadOnlyProperty, value);
    }

    /// <summary>
    ///     Gets or sets a value which indicates if increment and decrement is possible even if the value is null. Minimum or
    ///     maximum then will be placed in.
    /// </summary>
    /// <value>Default: false.</value>
    [DefaultValue(false)]
    public bool AcceptUpDownOnNull
    {
        get => (bool)GetValue(AcceptUpDownOnNullProperty);
        set => SetValue(AcceptUpDownOnNullProperty, value);
    }

    /// <summary>
    ///     Gets or sets the allowed maximum of decimal places.
    /// </summary>
    /// <value>Default: -1 (off).</value>
    [DefaultValue(-1)]
    public int DecimalPlaces
    {
        get => (int)GetValue(DecimalPlacesProperty);
        set => SetValue(DecimalPlacesProperty, value);
    }

    internal int SelectionStart => _textBox.SelectionStart;

    internal string Text => _textBox.Text;

    private static void OnNumberTypeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var control = (ChapterNumberBox)d;
        control.OnNumberTypeChanged(e);
    }

    private static void OnNumberChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var control = (ChapterNumberBox)d;
        control.OnNumberChanged(e);
    }

    private static void OnMinimumChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var control = (ChapterNumberBox)d;
        control.OnMinimumChanged(e);
    }

    private static void OnMaximumChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var control = (ChapterNumberBox)d;
        control.OnMaximumChanged(e);
    }

    private static void OnStepChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var control = (ChapterNumberBox)d;
        control.OnStepChanged(e);
    }

    private static void OnDefaultNumberChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var control = (ChapterNumberBox)d;
        control.OnDefaultNumberChanged(e);
    }

    private static void OnInputCultureChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var control = (ChapterNumberBox)d;
        control.OnInputCultureChanged(e);
    }

    private static void OnDecimalPlacesChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var control = (ChapterNumberBox)d;
        control.OnDecimalPlacesChanged(e);
    }

    /// <summary>
    ///     Occurs when the Number value has been changed.
    /// </summary>
    public event NumberChangedEventHandler NumberChanged
    {
        add => AddHandler(NumberChangedEvent, value);
        remove => RemoveHandler(NumberChangedEvent, value);
    }

    /// <summary>
    ///     The template gets added to the control.
    /// </summary>
    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();

        _textBox = GetTemplateChild("PART_TextBox") as TextBox;
        if (_textBox == null)
            return;

        _upButton = GetTemplateChild("PART_UpButton") as RepeatButton;
        if (_upButton != null)
            _upButton.Click += HandleUpClick;

        _downButton = GetTemplateChild("PART_DownButton") as RepeatButton;
        if (_downButton != null)
            _downButton.Click += HandleDownClick;

        _resetButton = GetTemplateChild("PART_ResetButton") as Button;
        if (_resetButton != null)
            _resetButton.Click += HandleResetClick;

        _number.Initialize(Number, Minimum, Maximum, DecimalPlaces, Step, DefaultNumber, InputCulture, PredefinesCulture);
        _textBox.Text = _number!.ToString();

        _textBox.PreviewDragOver += HandlePreviewDragOver;
        _textBox.PreviewDrop += HandlePreviewDrop;
        _textBox.PreviewKeyDown += HandleTextBoxPreviewKeyDown;
        _textBox.PreviewTextInput += HandlePreviewTextInput;
        _textBox.CommandBindings.Add(new CommandBinding(ApplicationCommands.Paste, null, CanPasteCommand));
        _textBox.GotFocus += HandleTextBoxGotFocus;
        _textBox.LostFocus += HandleTextBoxLostFocus;

        EnableDisableUpDownButtons();
    }

    private void HandlePreviewDragOver(object sender, DragEventArgs e)
    {
        if (!IsReadOnly && _textBox.IsEnabled && e.Data.GetDataPresent(DataFormats.Text))
        {
            var droppedText = e.Data.GetData(DataFormats.Text)!.ToString();
            var prediction = _textBox.Text;
            prediction = prediction.Remove(_textBox.SelectionStart, _textBox.SelectionLength);
            prediction = prediction.Insert(_textBox.SelectionStart, droppedText!);
            e.Effects = _number.CanTakeNumber(prediction) ? DragDropEffects.Copy : DragDropEffects.None;
            e.Handled = e.Effects == DragDropEffects.None;
        }
        else
        {
            e.Effects = DragDropEffects.None;
            e.Handled = true;
        }
    }

    private void HandlePreviewDrop(object sender, DragEventArgs e)
    {
        if (!e.Data.GetDataPresent(DataFormats.Text))
            return;

        e.Handled = true;
        var droppedText = e.Data.GetData(DataFormats.Text)!.ToString();
        var prediction = _textBox.Text;
        prediction = prediction.Remove(_textBox.SelectionStart, _textBox.SelectionLength);
        prediction = prediction.Insert(_textBox.SelectionStart, droppedText!);

        if (_number.TakeNumber(prediction))
        {
            TakeNumber();
            _textBox.Text = _number!.ToString();
        }
    }

    private void HandleTextBoxPreviewKeyDown(object sender, KeyEventArgs e)
    {
        if (IsReadOnly)
        {
            e.Handled = true;
            return;
        }

        switch (e.Key)
        {
            case Key.Space:
            {
                e.Handled = true;
                break;
            }
            case Key.Delete:
            {
                var newText = _textBox.SelectionLength > 0 ? TextWithRemovedSelection() : TextWithRemovedAfter();
                _number.TakeNumber(newText);
                TakeNumber();
                break;
            }
            case Key.Back:
            {
                var newText = _textBox.SelectionLength > 0 ? TextWithRemovedSelection() : TextWithRemovedBefore();
                _number.TakeNumber(newText);
                TakeNumber();
                break;
            }
            case Key.Up:
            {
                if ((UpDownBehavior == UpDownBehavior.Arrows || UpDownBehavior == UpDownBehavior.ArrowsAndButtons) && !IsReadOnly)
                    HandleUpClick(this, null);
                break;
            }
            case Key.Down:
            {
                if ((UpDownBehavior == UpDownBehavior.Arrows || UpDownBehavior == UpDownBehavior.ArrowsAndButtons) && !IsReadOnly)
                    HandleDownClick(this, null);
                break;
            }
        }
    }

    private void CanPasteCommand(object sender, CanExecuteRoutedEventArgs e)
    {
        if (IsReadOnly)
            return;

        if (!Clipboard.ContainsText())
            return;

        var textToPaste = Clipboard.GetText();

        var currentText = _textBox.Text;
        currentText = currentText.Remove(_textBox.SelectionStart, _textBox.SelectionLength);
        currentText = currentText.Insert(_textBox.SelectionStart, textToPaste);

        e.CanExecute = false;
        if (_number.TakeNumber(currentText))
        {
            e.CanExecute = true;
            TakeNumber();
        }

        e.Handled = true;
    }

    private void HandleUpClick(object sender, RoutedEventArgs routedEventArgs)
    {
        if (AcceptUpDownOnNull && Number == null)
            _number.ToMinimum();
        else
            _number.Increase();
        TakeNumber();
        _textBox.Text = _number.ToString()!;
        if (NumberSelectionBehavior == ChapterNumberBoxSelection.OnFocusAndUpDown || NumberSelectionBehavior == ChapterNumberBoxSelection.OnUpDown)
            SelectAll();
    }

    private void HandleDownClick(object sender, RoutedEventArgs routedEventArgs)
    {
        if (AcceptUpDownOnNull && Number == null)
            _number.ToMaximum();
        else
            _number.Decrease();
        TakeNumber();
        _textBox.Text = _number.ToString()!;
        if (NumberSelectionBehavior == ChapterNumberBoxSelection.OnFocusAndUpDown || NumberSelectionBehavior == ChapterNumberBoxSelection.OnUpDown)
            SelectAll();
    }

    private void HandleResetClick(object sender, RoutedEventArgs e)
    {
        _number.Reset();
        TakeNumber();
        _textBox.Text = _number.ToString()!;
    }

    private void EnableDisableUpDownButtons()
    {
        if (AcceptUpDownOnNull && Number == null)
        {
            CanStepUp = true;
            CanStepDown = true;
            return;
        }

        CanStepUp = _number.CanIncrease;
        CanStepDown = _number.CanDecrease;
    }

    private void HandlePreviewTextInput(object sender, TextCompositionEventArgs e)
    {
        if (e.Text == "-" && _number.AcceptNegative && (string.IsNullOrEmpty(_textBox.Text) || _textBox.SelectionLength == _textBox.Text.Length))
            return;

        var currentText = _textBox.Text;
        currentText = currentText.Remove(_textBox.SelectionStart, _textBox.SelectionLength);
        currentText = currentText.Insert(_textBox.SelectionStart, e.Text);

        if (_number.TakeNumber(currentText))
        {
            TakeNumber();
            return;
        }

        e.Handled = true;
    }

    private void TakeNumber()
    {
        _selfChange = true;
        Number = _number.CurrentNumber;
        _selfChange = false;
    }

    private string TextWithRemovedSelection()
    {
        return _textBox.Text.Remove(_textBox.SelectionStart, _textBox.SelectionLength);
    }

    private string TextWithRemovedBefore()
    {
        if (_textBox.SelectionStart == -1)
            return _textBox.Text;
        if (_textBox.SelectionStart == 0)
            return _textBox.Text;

        return _textBox.Text.Remove(_textBox.SelectionStart - 1, 1);
    }

    private string TextWithRemovedAfter()
    {
        if (_textBox.SelectionStart == -1)
            return _textBox.Text;

        if (_textBox.SelectionStart == _textBox.Text.Length)
            return _textBox.Text;

        return _textBox.Text.Remove(_textBox.SelectionStart, 1);
    }

    private void OnNumberTypeChanged(DependencyPropertyChangedEventArgs e)
    {
        _number = NumberFactory.Create((NumberType)e.NewValue);
        _number.Initialize(Number, Minimum, Maximum, DecimalPlaces, Step, DefaultNumber, InputCulture, PredefinesCulture);
    }

    private void OnNumberChanged(DependencyPropertyChangedEventArgs e)
    {
        EnableDisableUpDownButtons();

        if (e.OldValue != e.NewValue)
            OnNumberChanged(e.OldValue, e.NewValue);

        if (_selfChange)
            return;

        _number.TakeNumber(e.NewValue);

        if (_textBox != null)
            _textBox.Text = _number.ToString()!;

        EnableDisableUpDownButtons();
    }

    private void OnMinimumChanged(DependencyPropertyChangedEventArgs e)
    {
        _number.TakeMinimum(e.NewValue);
    }

    private void OnMaximumChanged(DependencyPropertyChangedEventArgs e)
    {
        _number.TakeMaximum(e.NewValue);
    }

    private void OnStepChanged(DependencyPropertyChangedEventArgs e)
    {
        _number.TakeStep(e.NewValue);
    }

    private void OnDefaultNumberChanged(DependencyPropertyChangedEventArgs e)
    {
        _number.TakeDefaultNumber(e.NewValue);
    }

    private void OnInputCultureChanged(DependencyPropertyChangedEventArgs e)
    {
        _number.TakeCulture(e.NewValue);
    }

    private void OnDecimalPlacesChanged(DependencyPropertyChangedEventArgs e)
    {
        _number.TakeDecimalPlaces((int)e.NewValue);
    }

    private void OnNumberChanged(object oldNumber, object newNumber)
    {
        RaiseEvent(new NumberChangedEventArgs(oldNumber, newNumber));
    }

    private void HandleTextBoxGotFocus(object sender, RoutedEventArgs e)
    {
        if (NumberSelectionBehavior == ChapterNumberBoxSelection.OnFocusAndUpDown || NumberSelectionBehavior == ChapterNumberBoxSelection.OnFocus)
            SelectAll();
    }

    private void HandleTextBoxLostFocus(object sender, RoutedEventArgs e)
    {
        HandleMinimumValue();

        var behavior = LostFocusBehavior;
        if (behavior == null)
            return;

        HandleNullValue(behavior);
        HandleTrimming(behavior);
        HandleFormatting(behavior);
    }

    private void HandleMinimumValue()
    {
        if (_number.NumberIsBelowMinimum)
        {
            _number.ToMinimum();
            TakeNumber();
            _textBox.Text = _number.ToString()!;
        }
    }

    private void HandleNullValue(LostFocusBehavior behavior)
    {
        if (_number.CurrentNumber != null)
            return;
        switch (behavior.Value)
        {
            case ValueBehavior.PlaceDefaultNumber:
                _number.Reset();
                break;
            case ValueBehavior.PlaceMaximumNumber:
                _number.ToMaximum();
                break;
            case ValueBehavior.PlaceMinimumNumber:
                _number.ToMinimum();
                break;
        }

        TakeNumber();
        _textBox.Text = _number.ToString()!;
    }

    private void HandleTrimming(LostFocusBehavior behavior)
    {
        if (!behavior.TrimLeadingZero)
            return;

        _textBox.Text = $"{_number.CurrentNumber}";
    }

    private void HandleFormatting(LostFocusBehavior behavior)
    {
        if (string.IsNullOrWhiteSpace(behavior.FormatText))
            return;

        _textBox.Text = string.Format(behavior.FormatText, _number.CurrentNumber);
    }

    private void SelectAll()
    {
        _textBox.Dispatcher.BeginInvoke(new Action(() => { _textBox.SelectAll(); }), DispatcherPriority.Render);
    }

    internal void Tab(FocusNavigationDirection direction)
    {
        _textBox.MoveFocus(new TraversalRequest(direction));
    }
}