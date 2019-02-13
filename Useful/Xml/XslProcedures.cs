//-----------------------------------------------------------------------
// <copyright file="XslProcedures.cs" company="APH Software">
//     Copyright (c) Andrew Hawkins. All rights reserved.
// </copyright>
// <summary>Methods that are to be used during an XSL transformation.</summary>
//-----------------------------------------------------------------------

namespace Useful.Xml
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;

	internal class XslProcedures
	{
		public XslProcedures()
		{
			this.Reset();
		}

		public int Count
		{
			get;
			set;
		}

		public void Reset()
		{
			this.Count = 0;
		}

		public void IncrementCounter()
		{
			this.Count++;
		}
	}
}
