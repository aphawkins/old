//-----------------------------------------------------------------------
// <copyright file="ByteCollectionToStringConverter.cs" company="APH Software">
//     Copyright (c) Andrew Hawkins. All rights reserved.
// </copyright>
// <summary>Byte collection to string converter for WPF. Assumes Unicode.</summary>
//-----------------------------------------------------------------------

namespace Useful.Wpf.Converters
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Windows.Data;

    /// <summary>
    /// Converts an ICollection{byte} to a <see cref="string" />.  Assumes the byte list is in Unicode.
    /// </summary>
    public sealed class ByteCollectionToStringConverter : IValueConverter
    {
        /// <summary>
        /// Converts an ICollection{byte} to a <see cref="string" />.  Assumes the byte list is in Unicode.
        /// </summary>
        /// <param name="value">The value produced by the binding source.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>A converted value. If the method returns null, the valid null value is used.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ICollection<byte> bytes = value as ICollection<byte>;
            if (bytes == null || bytes.Count == 0)
            {
                return string.Empty;
            }

            return Encoding.Unicode.GetString(bytes.ToArray());
        }

        /// <summary>
        /// Converts a <see cref="string" /> to an ICollection{byte}.  Assumes the byte list is in Unicode.
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
                return new Collection<byte>();
            }

            return new Collection<byte>(Encoding.Unicode.GetBytes(str));
        }
    }
}