// -----------------------------------------------------------------------------------------------------------------
// <copyright file="AdvancedTextBox.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls;

/// <summary>
///     Enhances the <see cref="TextBox" /> by the possibilities to show background text, drop files and folders and
///     place additional controls in.
/// </summary>
[TemplatePart(Name = "PART_InfoText", Type = typeof(TextBlock))]
public class AdvancedTextBox : TextBox
{
    /// <summary>
    ///     Identifies the <see cref="InfoAppearance" /> dependency property.
    /// </summary>
    public static readonly DependencyProperty InfoAppearanceProperty =
        DependencyProperty.Register(nameof(InfoAppearance), typeof(InfoAppearance), typeof(AdvancedTextBox), new UIPropertyMetadata(InfoAppearance.OnLostFocus, OnInfoAppearanceChanged));

    /// <summary>
    ///     Identifies the <see cref="InfoText" /> dependency property.
    /// </summary>
    public static readonly DependencyProperty InfoTextProperty =
        DependencyProperty.Register(nameof(InfoText), typeof(string), typeof(AdvancedTextBox), new UIPropertyMetadata(""));

    /// <summary>
    ///     Identifies the <see cref="InfoTextStyle" /> dependency property.
    /// </summary>
    public static readonly DependencyProperty InfoTextStyleProperty =
        DependencyProperty.Register(nameof(InfoTextStyle), typeof(Style), typeof(AdvancedTextBox), new UIPropertyMetadata(null));

    /// <summary>
    ///     Identifies the <see cref="FirstControl" /> dependency property.
    /// </summary>
    public static readonly DependencyProperty FirstControlProperty =
        DependencyProperty.Register(nameof(FirstControl), typeof(object), typeof(AdvancedTextBox), new UIPropertyMetadata(null));

    /// <summary>
    ///     Identifies the <see cref="FirstControlPosition" /> dependency property.
    /// </summary>
    public static readonly DependencyProperty FirstControlPositionProperty =
        DependencyProperty.Register(nameof(FirstControlPosition), typeof(Dock), typeof(AdvancedTextBox), new UIPropertyMetadata(Dock.Left));

    /// <summary>
    ///     Identifies the <see cref="SecondControl" /> dependency property.
    /// </summary>
    public static readonly DependencyProperty SecondControlProperty =
        DependencyProperty.Register(nameof(SecondControl), typeof(object), typeof(AdvancedTextBox), new UIPropertyMetadata(null));

    /// <summary>
    ///     Identifies the <see cref="SecondControlPosition" /> dependency property.
    /// </summary>
    public static readonly DependencyProperty SecondControlPositionProperty =
        DependencyProperty.Register(nameof(SecondControlPosition), typeof(Dock), typeof(AdvancedTextBox), new UIPropertyMetadata(Dock.Right));

    /// <summary>
    ///     Identifies the <see cref="AllowedDropType" /> dependency property.
    /// </summary>
    public static readonly DependencyProperty AllowedDropTypeProperty =
        DependencyProperty.Register(nameof(AllowedDropType), typeof(DroppableTypes), typeof(AdvancedTextBox), new UIPropertyMetadata(DroppableTypes.File));

    /// <summary>
    ///     Identifies the <see cref="Separator" /> dependency property.
    /// </summary>
    public static readonly DependencyProperty SeparatorProperty =
        DependencyProperty.Register(nameof(Separator), typeof(string), typeof(AdvancedTextBox), new UIPropertyMetadata("; "));

    /// <summary>
    ///     Identifies the <see cref="DragDropEffect" /> dependency property.
    /// </summary>
    public static readonly DependencyProperty DragDropEffectProperty =
        DependencyProperty.Register(nameof(DragDropEffect), typeof(DragDropEffects), typeof(AdvancedTextBox), new UIPropertyMetadata(DragDropEffects.Link));

    /// <summary>
    ///     Identifies the <see cref="TextModificator" /> dependency property.
    /// </summary>
    public static readonly DependencyProperty TextModificatorProperty =
        DependencyProperty.Register(nameof(TextModificator), typeof(TextModificator), typeof(AdvancedTextBox), new PropertyMetadata(null));

    /// <summary>
    ///     Identifies the <see cref="InputLimiter" /> dependency property.
    /// </summary>
    public static readonly DependencyProperty InputLimiterProperty =
        DependencyProperty.Register(nameof(InputLimiter), typeof(InputLimiter), typeof(AdvancedTextBox), new PropertyMetadata(null));

    /// <summary>
    ///     Identifies the <see cref="WhitespaceHandling" /> dependency property.
    /// </summary>
    public static readonly DependencyProperty WhitespaceHandlingProperty =
        DependencyProperty.Register(nameof(WhitespaceHandling), typeof(WhitespaceHandling), typeof(AdvancedTextBox), new PropertyMetadata(WhitespaceHandling.None));

    private TextBlock _infoText;

    static AdvancedTextBox()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(AdvancedTextBox), new FrameworkPropertyMetadata(typeof(AdvancedTextBox)));
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="AdvancedTextBox" /> class.
    /// </summary>
    public AdvancedTextBox()
    {
        Loaded += InfoTextBox_Loaded;
        PreviewDragOver += DroppableTextBox_PreviewDragOver;
        PreviewDrop += DroppableTextBox_PreviewDrop;
        CommandBindings.Add(new CommandBinding(ApplicationCommands.Paste, null, CanPasteCommand));
    }

    /// <summary>
    ///     Gets or sets a value which indicates when the info text in the background is shown.
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
    ///     Gets or sets an additional control placed inside the text box.
    /// </summary>
    /// <value>Default: null.</value>
    [DefaultValue(null)]
    public object FirstControl
    {
        get => GetValue(FirstControlProperty);
        set => SetValue(FirstControlProperty, value);
    }

    /// <summary>
    ///     Gets or sets a value which indicates where the additional <see cref="FirstControl" /> has to be placed in the text
    ///     box.
    /// </summary>
    /// <value>Default: Dock.Left.</value>
    [DefaultValue(Dock.Left)]
    public Dock FirstControlPosition
    {
        get => (Dock)GetValue(FirstControlPositionProperty);
        set => SetValue(FirstControlPositionProperty, value);
    }

    /// <summary>
    ///     Gets or sets an second additional control placed inside the text box.
    /// </summary>
    /// <value>Default: null.</value>
    [DefaultValue(null)]
    public object SecondControl
    {
        get => GetValue(SecondControlProperty);
        set => SetValue(SecondControlProperty, value);
    }

    /// <summary>
    ///     Gets or sets a value which indicates where the additional <see cref="SecondControl" /> has to be placed in the text
    ///     box.
    /// </summary>
    /// <value>Default: Dock.Right.</value>
    [DefaultValue(Dock.Right)]
    public Dock SecondControlPosition
    {
        get => (Dock)GetValue(SecondControlPositionProperty);
        set => SetValue(SecondControlPositionProperty, value);
    }

    /// <summary>
    ///     Gets or sets a value which indicates what the text box allows to drop in.
    /// </summary>
    /// <value>Default: DroppableTypes.File.</value>
    [DefaultValue(DroppableTypes.File)]
    public DroppableTypes AllowedDropType
    {
        get => (DroppableTypes)GetValue(AllowedDropTypeProperty);
        set => SetValue(AllowedDropTypeProperty, value);
    }

    /// <summary>
    ///     Gets or sets a value which will be used as a separator if multiple elements can be dropped to the textbox. See
    ///     <see cref="AllowedDropType" />.
    /// </summary>
    /// <value>Default: "; ".</value>
    [DefaultValue("; ")]
    public string Separator
    {
        get => (string)GetValue(SeparatorProperty);
        set => SetValue(SeparatorProperty, value);
    }

    /// <summary>
    ///     Gets or sets the mouse icon when files or folders (See <see cref="AllowedDropType" />) will be dropped into the
    ///     text box.
    /// </summary>
    /// <value>Default: DragDropEffects.Link.</value>
    [DefaultValue(DragDropEffects.Link)]
    public DragDropEffects DragDropEffect
    {
        get => (DragDropEffects)GetValue(DragDropEffectProperty);
        set => SetValue(DragDropEffectProperty, value);
    }

    /// <summary>
    ///     Gets or sets the the modificator how to change the text the user inputs.
    /// </summary>
    /// <value>Default: null.</value>
    [DefaultValue(null)]
    public TextModificator TextModificator
    {
        get => (TextModificator)GetValue(TextModificatorProperty);
        set => SetValue(TextModificatorProperty, value);
    }

    /// <summary>
    ///     Gets or sets the limiter checking if a key or string is allowed to be entered.
    /// </summary>
    /// <value>Default: null.</value>
    [DefaultValue(null)]
    public InputLimiter InputLimiter
    {
        get => (InputLimiter)GetValue(InputLimiterProperty);
        set => SetValue(InputLimiterProperty, value);
    }

    /// <summary>
    ///     Gets or sets a value which indicates how to handle whitespace.
    /// </summary>
    /// <value>Default: WhitespaceHandling.None.</value>
    [DefaultValue(WhitespaceHandling.None)]
    public WhitespaceHandling WhitespaceHandling
    {
        get => (WhitespaceHandling)GetValue(WhitespaceHandlingProperty);
        set => SetValue(WhitespaceHandlingProperty, value);
    }

    private void InfoTextBox_Loaded(object sender, RoutedEventArgs e)
    {
        RefreshInfoAppearance();
    }

    /// <summary>
    ///     The template gets added to the control.
    /// </summary>
    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();

        RefreshInfoAppearance();
    }

    /// <summary>
    ///     Takes care about hiding the info text in the background depending on the <see cref="InfoAppearance" /> property.
    /// </summary>
    /// <param name="e">The parameter passed by the caller.</param>
    protected override void OnGotFocus(RoutedEventArgs e)
    {
        base.OnGotFocus(e);

        if (!GetInfoTextBlock())
            return;

        if (InfoAppearance != InfoAppearance.OnEmpty)
            _infoText.Visibility = Visibility.Collapsed;
    }

    /// <summary>
    ///     Takes care about display the info text in the background depending on the <see cref="InfoAppearance" /> property.
    /// </summary>
    /// <param name="e">The parameter passed by the caller.</param>
    protected override void OnLostFocus(RoutedEventArgs e)
    {
        base.OnLostFocus(e);

        if (GetInfoTextBlock())
            if (InfoAppearance != InfoAppearance.None && string.IsNullOrEmpty(Text))
                _infoText.Visibility = Visibility.Visible;

        if (TextModificator is { ModificationTime: ModificationTime.OnLostFocus })
            Text = TextModificator.Modify(Text);

        switch (WhitespaceHandling)
        {
            case WhitespaceHandling.DisallowLeadingAndTrim:
            case WhitespaceHandling.Trim:
                Text = Text.Trim();
                break;
        }
    }

    /// <summary>
    ///     Predicts the text to be input and checks if its allowed depending on the <see cref="InfoAppearance" />.
    /// </summary>
    /// <param name="e">The parameter passed by the caller.</param>
    protected override void OnPreviewTextInput(TextCompositionEventArgs e)
    {
        if (InputLimiter == null)
            return;

        var prediction = Text;
        prediction = prediction.Remove(SelectionStart, SelectionLength);
        prediction = prediction.Insert(SelectionStart, e.Text);

        e.Handled = !InputLimiter.AcceptText(prediction);
    }

    private void CanPasteCommand(object sender, CanExecuteRoutedEventArgs e)
    {
        if (!Clipboard.ContainsText() || InputLimiter == null)
            return;

        var textToPaste = Clipboard.GetText();

        var prediction = Text;
        prediction = prediction.Remove(SelectionStart, SelectionLength);
        prediction = prediction.Insert(SelectionStart, textToPaste);

        e.CanExecute = InputLimiter.AcceptText(prediction);
        e.Handled = true;
    }

    /// <summary>
    ///     Takes care about display or hide the info text in the background depending on the <see cref="InfoAppearance" />.
    ///     property.
    /// </summary>
    /// <param name="e">The parameter passed by the caller.</param>
    protected override void OnTextChanged(TextChangedEventArgs e)
    {
        base.OnTextChanged(e);

        if (GetInfoTextBlock())
        {
            if (string.IsNullOrEmpty(Text))
            {
                if (InfoAppearance == InfoAppearance.OnEmpty)
                    _infoText.Visibility = Visibility.Visible;
            }
            else if (_infoText.Visibility == Visibility.Visible)
            {
                _infoText.Visibility = Visibility.Collapsed;
            }
        }

        if (TextModificator is { ModificationTime: ModificationTime.OnType })
        {
            var caretPos = SelectionStart;
            var oldTextLength = Text.Length;
            Text = TextModificator.Modify(Text);
            SelectionStart = caretPos + (Text.Length - oldTextLength);
        }

        if (WhitespaceHandling == WhitespaceHandling.DisallowLeadingAndTrim)
            if (Text.StartsWith(' ') || Text.StartsWith('\t'))
                Text = Text.TrimStart(' ', '\t');
    }

    /// <summary>
    ///     Takes care if a key is allowed or not by the <see cref="InputLimiter" />.
    /// </summary>
    /// <param name="e">The parameter passed by the caller.</param>
    protected override void OnPreviewKeyDown(KeyEventArgs e)
    {
        if (WhitespaceHandling == WhitespaceHandling.DisallowLeadingAndTrim && e.Key == Key.Space)
            e.Handled = CaretIndex == 0;

        if (InputLimiter != null)
            e.Handled = !InputLimiter.AcceptKey(e.Key);
    }

    /// <summary>
    ///     Calls the text modificator in the case the user typed whitespace.
    /// </summary>
    /// <param name="e">The parameter passed by the caller.</param>
    protected override void OnKeyUp(KeyEventArgs e)
    {
        if (e.Key == Key.Space)
            if (TextModificator is { ModificationTime: ModificationTime.OnType })
            {
                var caretPos = SelectionStart;
                Text = TextModificator.Modify(Text);
                SelectionStart = caretPos;
            }

        base.OnKeyUp(e);
    }

    private void RefreshInfoAppearance()
    {
        if (!GetInfoTextBlock())
            return;

        if (InfoAppearance == InfoAppearance.None || !string.IsNullOrEmpty(Text))
            _infoText.Visibility = Visibility.Collapsed;
    }

    private bool GetInfoTextBlock()
    {
        _infoText ??= GetTemplateChild("PART_InfoText") as TextBlock;
        return _infoText != null;
    }

    private void DroppableTextBox_PreviewDragOver(object sender, DragEventArgs e)
    {
        // Text drag and drop are handled by the base class

        if (AllowedDropType == DroppableTypes.Text && e.Data.GetDataPresent(DataFormats.Text))
        {
            if (InputLimiter == null)
            {
                e.Effects = DragDropEffect;
                return;
            }

            var textToDrop = e.Data.GetData(DataFormats.Text)?.ToString();
            var prediction = Text;
            prediction = prediction.Remove(SelectionStart, SelectionLength);
            prediction = prediction.Insert(SelectionStart, textToDrop);

            e.Effects = InputLimiter.AcceptText(prediction) ? DragDropEffect : DragDropEffects.None;
            return;
        }

        e.Effects = !string.IsNullOrEmpty(GetContent(e)) ? DragDropEffect : DragDropEffects.None;
        e.Handled = true;
    }

    private void DroppableTextBox_PreviewDrop(object sender, DragEventArgs e)
    {
        // Text drag and drop are handled by the base class

        if (AllowedDropType == DroppableTypes.Text && e.Data.GetDataPresent(DataFormats.Text))
            return;

        e.Handled = true;
        var contentText = GetContent(e);
        if (string.IsNullOrEmpty(contentText))
            return;
        ((AdvancedTextBox)sender).Text = contentText;
        Focus();
    }

    private string GetContent(DragEventArgs e)
    {
        if (!e.Data.GetDataPresent(DataFormats.FileDrop, true))
            return null;

        if (!(e.Data.GetData(DataFormats.FileDrop, true) is string[] content))
            return null;

        switch (AllowedDropType)
        {
            case DroppableTypes.File:
                if (content.Length == 1 &&
                    File.Exists(content[0]))
                    return content[0];
                break;
            case DroppableTypes.Files:
                return content.Any(value => !File.Exists(value)) ? null : string.Join(Separator, content);
            case DroppableTypes.FilesFolders:
                return content.Any(value => !File.Exists(value) && !Directory.Exists(value)) ? null : string.Join(Separator, content);
            case DroppableTypes.Folder:
                if (content.Length == 1 && Directory.Exists(content[0]))
                    return content[0];
                break;
            case DroppableTypes.Folders:
                return content.Any(value => !Directory.Exists(value)) ? null : string.Join(Separator, content);
        }

        return null;
    }

    private static void OnInfoAppearanceChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
    {
        ((AdvancedTextBox)sender).RefreshInfoAppearance();
    }
}