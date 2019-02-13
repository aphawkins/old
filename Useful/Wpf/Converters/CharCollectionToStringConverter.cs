//-----------------------------------------------------------------------
// <copyright file="CharCollectionToStringConverter.cs" company="APH Software">
//     Copyright (c) Andrew Hawkins. All rights reserved.
// </copyright>
// <summary>Char collection to string converter for WPF. Assumes Unicode.</summary>
//-----------------------------------------------------------------------

namespace Useful.Wpf.Converters
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Globalization;
    using System.Windows.Data;

    /// <summary>
    /// Converts an ICollection{char} to a <see cref="string" />.
    /// </summary>
    public sealed class CharCollectionToStringConverter : IValueConverter
    {
        /// <summary>
        /// Converts an ICollection{char} to a <see cref="string" />.
        /// </summary>
        /// <param name="value">The value produced by the binding source.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>A converted value. If the method returns null, the valid null value is used.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ICollection<char> chars = value as ICollection<char>;
            if (chars == null || chars.Count == 0)
            {
                return string.Empty;
            }

            return string.Concat(chars);
        }

        /// <summary>
        /// Converts a <see cref="string" /> to a ICollection{char}.
        /// </summary>
        /// <param name="value">The value that is produced by the binding target.</param>
        /// <param name="targetType">The type to convert to.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>A converted value. If the method returns null, the valid null value is used.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string str = parameter as string;

            if (string.IsNullOrEmpty(str))
            {
                return new Collection<char>();
            }

            return new Collection<char>(str.ToCharArray());
        }
    }
}