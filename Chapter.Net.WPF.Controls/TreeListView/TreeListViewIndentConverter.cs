// -----------------------------------------------------------------------------------------------------------------
// <copyright file="TreeListViewIndentConverter.cs" company="my-libraries">
//     Copyright (c) David Wendland. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------------------------------------------

using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

// ReSharper disable once CheckNamespace

namespace Chapter.Net.WPF.Controls
{
    /// <summary>
    ///     Adds an intending level of the items shown in the tree of the <see cref="TreeListView" />.
    /// </summary>
    public class TreeListViewIndentConverter : IValueConverter
    {
        /// <summary>
        ///     Checks if the tree view item is a child item and can be collapsed and calculates the intending by the level.
        /// </summary>
        /// <param name="value">The tree view item container.</param>
        /// <param name="targetType">This parameter is not used.</param>
        /// <param name="parameter">This parameter is not used.</param>
        /// <param name="culture">This parameter is not used.</param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                var container = FindParent<TreeListViewItem>(value as DependencyObject);
                if (container != null)
                    return container.Level * 10;
            }

            return null;
        }

        /// <summary>
        ///     Not implemented.
        /// </summary>
        /// <param name="value">This parameter is not used.</param>
        /// <param name="targetType">This parameter is not used.</param>
        /// <param name="parameter">This parameter is not used.</param>
        /// <param name="culture">This parameter is not used.</param>
        /// <returns>nothing</returns>
        /// <exception cref="System.NotImplementedException">The convert back is not intended to be used.</exception>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private static TParentType FindParent<TParentType>(DependencyObject item) where TParentType : DependencyObject
        {
            if (item == null)
                return default;

            var parent = VisualTreeHelper.GetParent(item);
            while (parent != null && !(parent is TParentType))
                parent = VisualTreeHelper.GetParent(parent);

            return (TParentType)parent;
        }
    }
}