//-----------------------------------------------------------------------
// <copyright file="ArgsProcessor.cs" company="APH Software">
//     Copyright (c) Andrew Hawkins. All rights reserved.
// </copyright>
// <summary>A command line argument processor.</summary>
//-----------------------------------------------------------------------

namespace Useful.Console
{
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Diagnostics.Contracts;

	/// <summary>
	/// A command line argument processor.
	/// </summary>
	internal class ArgsProcessor : IEnumerable<Arg>
	{
        /// <summary>
        /// This stores the arguments.
        /// </summary>
		private List<Arg> newArgs = new List<Arg>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
		internal ArgsProcessor(string[] args)
		{
			Contract.Requires(args != null);

			Arg newArg = new Arg();
			List<string> options = new List<string>();

			foreach (string arg in args)
			{
				if (arg.StartsWith(@"-", StringComparison.OrdinalIgnoreCase)
					|| arg.StartsWith(@"/", StringComparison.OrdinalIgnoreCase))
				{
					// New Arg command

					// Put all options with previous command
					if (!string.IsNullOrEmpty(newArg.Command) || options.Count > 0)
					{
						newArg.Options = options.ToArray();
						this.AddArg(newArg);
						options.Clear();
					}

					newArg = new Arg();

					if (arg.Length == 1)
					{
						// the arg is just the starting char
						newArg.Command = arg;
					}
					else
					{
						newArg.Command = arg.TrimStart('-', '/').ToUpperInvariant();
					}
				}
				else
				{
					if (newArg.Command == null)
					{
						newArg.Command = string.Empty;
					}

					if (arg.Contains("\'\'"))
					{
						string[] ss = arg.Split(new string[] { "\'\'" }, StringSplitOptions.None);
						foreach (string s in ss)
						{
							string newOption = s;
							if (!s.StartsWith("\'", StringComparison.OrdinalIgnoreCase))
							{
								newOption = "\'" + s;
							}

							if (!s.EndsWith("\'", StringComparison.OrdinalIgnoreCase))
							{
								newOption += "\'";
							}

							options.Add(newOption);
						}
					}
					else
					{
						options.Add(arg); // .TrimStart('\'', '\"').TrimEnd('\'', '\"'));
					}
				}
			}

			if (!string.IsNullOrEmpty(newArg.Command) || options.Count > 0)
			{
				newArg.Options = options.ToArray();
				this.AddArg(newArg);
			}
		}

        /// <summary>
        /// The total number of arguments.
        /// </summary>
		public int Count
		{
			get
			{
				Contract.Ensures(Contract.Result<int>() >= 0);
				return this.newArgs.Count;
			}
		}

        /// <summary>
        /// 
        /// </summary>
		public bool DuplicateCommands
		{
			get;
			private set;
		}

		public Arg this[int i]
		{
			get
			{
				Contract.Requires(i >= 0);
				return this.newArgs[i];
			}

			set
			{
				Contract.Requires(i >= 0);
				this.newArgs[i] = value;
			}
		}
		
		public IEnumerator<Arg> GetEnumerator()
		{
			Contract.Ensures(this.newArgs != null);

			return this.newArgs.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			throw new NotImplementedException();
		}

		private void AddArg(Arg arg)
		{
			Contract.Ensures(this.newArgs != null);
			Contract.Ensures(Contract.OldValue(this.newArgs.Count) - this.newArgs.Count == -1);
			Contract.Ensures(this.newArgs.Count >= 1);

			if (!this.DuplicateCommands)
			{
				foreach (Arg newArg in this.newArgs)
				{
					if (string.Equals(newArg.Command, arg.Command, StringComparison.OrdinalIgnoreCase)
						&& !string.Equals(arg.Command, "-", StringComparison.OrdinalIgnoreCase))
					{
						this.DuplicateCommands = true;
						break;
					}
				}
			}

			this.newArgs.Add(arg);
		}
	}
}
