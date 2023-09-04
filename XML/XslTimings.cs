//-----------------------------------------------------------------------
// <copyright file="XslTimings.cs" company="APH Software">
//     Copyright (c) Andrew Hawkins. All rights reserved.
// </copyright>
// <summary>Stores the various timings of an XSL transform.</summary>
//-----------------------------------------------------------------------

namespace Useful.Xml
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;

	public class XslTimings
	{
		public TimeSpan Compile { get; set; }

		public TimeSpan Execute { get; set; }

		public TimeSpan Total { get; set; }
	}
}