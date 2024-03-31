// -----------------------------------------------------------------------------------------------------------------
// <copyright file="EnumerationComboBox.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls
{
    /// <summary>
    ///     Represents a ComboBox which takes an enumeration value and shows all possible states inside the dropdown menu for
    ///     let choosing a value.
    /// </summary>
    public class EnumerationComboBox : ComboBox
    {
        /// <summary>
        ///     Identifies the EnumType dependency property.
        /// </summary>
        public static readonly DependencyProperty EnumTypeProperty =
            DependencyProperty.Register(nameof(EnumType), typeof(Type), typeof(EnumerationComboBox), new PropertyMetadata(OnEnumTypeChanged));

        /// <summary>
        ///     Identifies the DisplayKind dependency property.
        /// </summary>
        public static readonly DependencyProperty DisplayKindProperty =
            DependencyProperty.Register(nameof(DisplayKind), typeof(EnumDisplayKind), typeof(EnumerationComboBox), new PropertyMetadata(EnumDisplayKind.Custom, OnItemConverterChanged));

        /// <summary>
        ///     Identifies the ItemConverter dependency property.
        /// </summary>
        public static readonly DependencyProperty ItemConverterProperty =
            DependencyProperty.Register(nameof(ItemConverter), typeof(IValueConverter), typeof(EnumerationComboBox), new PropertyMetadata(OnItemConverterChanged));

        static EnumerationComboBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(EnumerationComboBox), new FrameworkPropertyMetadata(typeof(EnumerationComboBox)));
            SelectedItemProperty.OverrideMetadata(typeof(EnumerationComboBox), new FrameworkPropertyMetadata(OnSelectedItemChanged, OnSelectedItemChanging));
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="EnumerationComboBox" /> class.
        /// </summary>
        public EnumerationComboBox()
        {
            Loaded += HandleLoaded;
        }

        /// <summary>
        ///     Gets or sets the type of the enum which named can be selected from.
        /// </summary>
        /// <value>Default: null.</value>
        [DefaultValue(null)]
        public Type EnumType
        {
            get => (Type)GetValue(EnumTypeProperty);
            set => SetValue(EnumTypeProperty, value);
        }

        /// <summary>
        ///     Gets or sets the way hot to display the items in the drop down or in the selection box itself.
        /// </summary>
        /// <remarks>
        ///     The default is <see cref="EnumDisplayKind.Custom" /> which means you have to define the
        ///     EnumerationComboBox.ItemTemplate by yourself.
        /// </remarks>
        /// <remarks>
        ///     Note: If <see cref="EnumDisplayKind.Custom" /> is set you need to set the <see cref="ItemConverter" /> as well;
        ///     otherwise <see cref="EnumDisplayKind.ToString" /> will be used instead.
        /// </remarks>
        /// <value>Default: EnumDisplayKind.Custom.</value>
        [DefaultValue(EnumDisplayKind.Custom)]
        public EnumDisplayKind DisplayKind
        {
            get => (EnumDisplayKind)GetValue(DisplayKindProperty);
            set => SetValue(DisplayKindProperty, value);
        }

        /// <summary>
        ///     Gets or sets the converter to use when <see cref="EnumDisplayKind.Custom" /> is set as the
        ///     <see cref="DisplayKind" />.
        /// </summary>
        /// <value>Default: null.</value>
        [DefaultValue(null)]
        public IValueConverter ItemConverter
        {
            get => (IValueConverter)GetValue(ItemConverterProperty);
            set => SetValue(ItemConverterProperty, value);
        }

        private void HandleLoaded(object sender, RoutedEventArgs e)
        {
            if (EnumType != null)
                return;

            var enumTypeBinding = GetBindingExpression(EnumTypeProperty);
            if (enumTypeBinding != null)
                return;

            var selectedItemBinding = GetBindingExpression(SelectedItemProperty);
            if (selectedItemBinding != null)
            {
                var type = GetBoundType(selectedItemBinding);
                if (type != null)
                    EnumType = type;
            }
            else if (SelectedItem != null)
            {
                EnumType = SelectedItem.GetType();
            }
        }

        private static void OnSelectedItemChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
        }

        private static object OnSelectedItemChanging(DependencyObject sender, object basevalue)
        {
            if (basevalue == null)
                return null;

            var control = (EnumerationComboBox)sender;
            if (control.EnumType != null)
                return basevalue;

            control.EnumType = basevalue.GetType();
            return basevalue;
        }

        /// <summary>
        ///     Checks if the item is already the correct item container. If not the <see cref="GetContainerForItemOverride" />
        ///     will be used to generate the right container.
        /// </summary>
        /// <param name="item">The item to shown in the <see cref="EnumerationComboBox" />.</param>
        /// <returns>True if the item is the correct item container already.</returns>
        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return item is EnumerationComboBoxItem;
        }

        /// <summary>
        ///     Generates a new child item container to hold in the <see cref="EnumerationComboBox" />.
        /// </summary>
        /// <returns>The generated child item container.</returns>
        protected override DependencyObject GetContainerForItemOverride()
        {
            return new EnumerationComboBoxItem();
        }

        private static void OnItemConverterChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var control = (EnumerationComboBox)sender;
            if (control.DisplayKind != EnumDisplayKind.Converter || control.ItemConverter == null)
                return;

            var textBinding = new Binding { Converter = control.ItemConverter };
            var template = new DataTemplate();

            var textBlockControl = new FrameworkElementFactory(typeof(TextBlock));
            textBlockControl.SetBinding(TextBlock.TextProperty, textBinding);
            template.VisualTree = textBlockControl;

            control.ItemTemplate = template;
        }

        private static void OnEnumTypeChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var control = (EnumerationComboBox)sender;

            if (control.ItemsSource != null)
                return;

            TakeValues(control);
        }

        private static void TakeValues(EnumerationComboBox control)
        {
            control.Items.Clear();
            foreach (var value in Enum.GetValues(control.EnumType))
                control.Items.Add(value);
        }

        private static Type GetBoundType(BindingExpression bindingExpression)
        {
            var split = bindingExpression.ParentBinding.Path.Path.Split('.').LastOrDefault();
            if (split == null)
                return null;
            var dataItem = bindingExpression.DataItem;
            if (dataItem == null)
                return null;
            var type = dataItem.GetType();
            var propertyInfo = type.GetProperty(split);
            if (propertyInfo == null)
                return null;
            return propertyInfo.PropertyType;
        }
    }
}