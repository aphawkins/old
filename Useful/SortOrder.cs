//-----------------------------------------------------------------------
// <copyright file="SortOrder.cs" company="APH Software">
//     Copyright (c) Andrew Hawkins. All rights reserved.
// </copyright>
// <summary>Specifies how items in a list are sorted.</summary>
//-----------------------------------------------------------------------

namespace Useful
{
    /// <summary>
    /// Specifies how items in a list are sorted.
    /// </summary>
    public enum SortOrder
    {
        /// <summary>
        /// The items are not sorted.
        /// </summary>
        None = 0,

        /// <summary>
        /// The items are sorted in ascending order.
        /// </summary>
        Ascending = 1,

        /// <summary>
        /// The items are sorted in descending order.
        /// </summary>
        Descending = 2,
    }
}