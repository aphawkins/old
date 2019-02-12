//-----------------------------------------------------------------------
// <copyright file="Arg.cs" company="APH Software">
//     Copyright (c) Andrew Hawkins. All rights reserved.
// </copyright>
// <summary>A command line argument.</summary>
//-----------------------------------------------------------------------

namespace Useful.Console
{
    /// <summary>
	/// A command line argument.
	/// </summary>
	internal class Arg
	{
		/// <summary>
		/// Gets or sets the command.
		/// </summary>
		internal string Command
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the command's options.
		/// </summary>
		internal string[] Options
		{
			get;
			set;
		}
	}
}
