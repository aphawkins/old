//-----------------------------------------------------------------------
// <copyright file="Xslt.cs" company="APH Software">
//     Copyright (c) Andrew Hawkins. All rights reserved.
// </copyright>
// <summary>XSL transformation console application entry point.</summary>
//-----------------------------------------------------------------------

namespace Useful.Console
{
	using System;
	using System.Collections.Generic;
	using System.Diagnostics;
	using System.Diagnostics.Contracts;
	using System.Globalization;
	using System.IO;
	using System.Linq;
	using System.Text.RegularExpressions;
	using System.Xml;
	using System.Xml.Linq;
	using System.Xml.Xsl;
	using Useful.Properties;
	using Useful.Xml;

	public class Xslt
    {
		private static readonly ConsoleColor CurrentForegroundColor = Console.ForegroundColor;
		private static readonly ConsoleColor CurrentBackgroundColor = Console.BackgroundColor;
        private static Xslt me = new Xslt();
        private XslOptions xsltOptions = new XslOptions();
		private bool useSourceStdIn;
		private string sourceFile;
		private bool useStylesheetStdIn;
		private string stylesheetFile;
		private bool useOutputfile;
		private string outputfile;
		private bool useTimings;
        private bool useProcessingInstruction;
        private bool validate;

        internal static int Main(string[] args)
        {
			Contract.Ensures(Contract.Result<int>() <= 0);

#if DEBUG
			File.WriteAllText("args.txt", string.Join("\", \"", args));
#endif

			try
			{
                me = new Xslt();

				Tuple<bool, XsltError> argsSuccess = me.ProcessArgs(args);
				if (!argsSuccess.Item1)
                {
                    return (int)argsSuccess.Item2;
                }

				return (int)me.Process();
			}
			catch (Exception ex)
			{
#if DEBUG
				ShowError(false, string.Format(CultureInfo.CurrentCulture, XsltResources.Exception, ex.ToString()), XsltError.SystemError, string.Format(CultureInfo.CurrentCulture, "0x{0:X}".ToLower(CultureInfo.CurrentCulture), (int)XsltError.SystemError));
#else
				ShowError(false, string.Format(CultureInfo.CurrentCulture, XsltResources.Exception, ex.Message), string.Format(CultureInfo.CurrentCulture, "0x{0:X}".ToLower(CultureInfo.CurrentCulture), (int)XsltError.MSXSL_E_SYSTEM_ERROR));
#endif
				return (int)XsltError.SystemError;
			}
			finally
			{
				Console.BackgroundColor = CurrentBackgroundColor;
				Console.ForegroundColor = CurrentForegroundColor;
			}
        }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="filename"></param>
		/// <returns>A streamreader, so we don't get the BOM.</returns>
		private static StreamReader GetInput(bool useStdIn, string filename)
		{
			if (useStdIn)
			{
				return new StreamReader(System.Console.OpenStandardInput(), true);
			}
			else
			{
				return new StreamReader(filename, true);
			}
		}

		private static void DisplayTitle(StreamWriter output)
		{
			SetHighlightColor();
			output.WriteLine(AssemblyInformation.Description());
			SetHighlightColor();
			output.Write("Version:     ");
			SetLowlightColor();
			output.WriteLine(AssemblyInformation.Version());
			SetHighlightColor();
			output.Write("CLR Version: ");
			SetLowlightColor();
			output.WriteLine(Environment.Version.ToString());
		}

		private static void DisplayInfo(StreamWriter output)
		{
			SetLowlightColor();
			output.WriteLine("Command line switch compatible with Microsoft's XSLT Processor 'msxsl.exe'");
			output.WriteLine();
			SetHighlightColor();
			output.WriteLine("Differences:");
			SetLowlightColor();
			output.WriteLine("- Return code is the same value as the error code.");
			output.WriteLine("- Some switches aren't supported.");
			output.WriteLine("- Microsoft .NET XSL v1.0 transform is used instead of MSXML.");
			output.WriteLine();
			SetHighlightColor();
			output.WriteLine("Goals:");
			SetLowlightColor();
			output.WriteLine("- Low levels of cyclomatic complexity.");
			output.WriteLine("- High Maintainability index.");
			output.WriteLine("- Globalization support.");
			output.WriteLine("- Code Analysis conformance.");
			output.WriteLine("- Code Contracts conformance.");
			output.WriteLine("- Code Style conformance.");
			output.WriteLine("- Design patterns and guidelines conformance.");
			output.WriteLine("- SOLID Principles.");
			output.WriteLine();
		}

		/// <summary>
		/// Displays the message on the STDOUT.
		/// </summary>
		private static void DisplayHelp()
		{
			using (Stream stdout = Console.OpenStandardOutput())
			{
				using (StreamWriter output = new StreamWriter(stdout))
				{
					output.AutoFlush = true;
					DisplayHelp(output);
				}
			}
		}

		/// <summary>
		/// Displays the message on the specified output.
		/// </summary>
		/// <param name="output">The output to display the message.</param>
		private static void DisplayHelp(StreamWriter output)
		{
			SetLowlightColor();
			DisplayTitle(output);
			DisplayInfo(output);
			SetHighlightColor();
			output.WriteLine("Usage: ");
			SetImportantColor();
			output.Write(AssemblyInformation.Product());
			SetLowlightColor();
			output.WriteLine(" source stylesheet [options] [param=value...] [xmlns:prefix=uri...]");
			output.WriteLine();
			SetHighlightColor();
			output.WriteLine("Options:");
			SetLowlightColor();
			DisplayOption(output, "-?", "Show this message");
			DisplayOption(output, "-o filename", "Write output to named file");
			DisplayOption(output, "-m startMode", "Start the transform in this mode", true);
			DisplayOption(output, "-xw", "Strip non-significant whitespace from source and stylesheet");
			DisplayOption(output, "-xe", "Do not resolve external definitions during parse phase");
			DisplayOption(output, "-v", "Validate documents during parse phase");
			DisplayOption(output, "-t", "Show load and transformation timings");
			DisplayOption(output, "-pi", "Get stylesheet URL from xml-stylesheet PI in source document");
			DisplayOption(output, "-u version", "Use a specific version of MSXML: '2.6', '3.0', '4.0'", true);
			DisplayOption(output, "-", "Dash used as source argument loads XML from stdin");
			DisplayOption(output, "-", "Dash used as stylesheet argument loads XSL from stdin");
			output.WriteLine();
		}

		private static void DisplayOption(StreamWriter output, string optionSwitch, string description, bool isUnsupported)
		{
			SetHighlightColor();
			output.Write("    {0,-14}", optionSwitch);
			if (isUnsupported)
			{
				SetWarningColor();
				output.Write("[Unsupported] ");
			}

			SetLowlightColor();
			output.Write(description);
			output.Write(System.Environment.NewLine);
		}

		private static void DisplayOption(StreamWriter output, string optionSwitch, string description)
		{
			DisplayOption(output, optionSwitch, description, false);
		}

		private static void DisplayTimings(XslTimings timings)
		{
			using (Stream stdout = Console.OpenStandardOutput())
			{
				using (StreamWriter output = new StreamWriter(stdout))
				{
					output.AutoFlush = true;
					output.WriteLine();
					SetHighlightColor();
					output.WriteLine(AssemblyInformation.Description());
					SetHighlightColor();
					output.Write("Version: ");
					SetLowlightColor();
					output.WriteLine(AssemblyInformation.Version());
					SetLowlightColor();
					output.WriteLine("Stylesheet compile time:  {0,8} milliseconds", timings.Compile.TotalMilliseconds.ToString("0.000", CultureInfo.CurrentCulture));
					output.WriteLine("Stylesheet execution time:{0,8} milliseconds", timings.Execute.TotalMilliseconds.ToString("0.000", CultureInfo.CurrentCulture));
					output.WriteLine("Total execution time:     {0,8} milliseconds", timings.Total.TotalMilliseconds.ToString("0.000", CultureInfo.CurrentCulture));
				}
			}
		}

		private static void SetHighlightColor()
		{
			Console.ForegroundColor = ConsoleColor.Yellow;
		}

		private static void SetLowlightColor()
		{
			Console.ForegroundColor = ConsoleColor.White;
		}

		private static void SetImportantColor()
		{
			Console.ForegroundColor = ConsoleColor.Red;
		}

		private static void SetWarningColor()
		{
			Console.ForegroundColor = ConsoleColor.DarkYellow;
		}

        private static Stream GetOutput(bool useOutputfile, string outputfile)
        {
            if (useOutputfile)
            {
                return new FileStream(outputfile, FileMode.Create);
            }
            else
            {
                return System.Console.OpenStandardOutput();
            }
        }

        private static void ShowError(bool isCommandError, string message, XsltError errorNumber, params string[] args)
        {
            SetHighlightColor();
            using (Stream stderr = Console.OpenStandardError())
            {
                using (StreamWriter output = new StreamWriter(stderr))
                {
                    output.AutoFlush = true;

                    if (isCommandError)
                    {
                        DisplayHelp(output);
                        SetHighlightColor();
                        output.WriteLine(message);
                    }
                    else
                    {
                        SetHighlightColor();
                        output.WriteLine(XsltEmulation.GetErrorCode(errorNumber), args);
                    }

                    SetLowlightColor();
                    output.WriteLine();
                    output.Write("Code:   ");
                    output.Write("0x{0:X}".ToLower(CultureInfo.CurrentCulture), (int)errorNumber);
                    output.WriteLine();
                    SetLowlightColor();
                    if (isCommandError)
                    {
                        output.WriteLine(XsltEmulation.GetErrorCode(errorNumber), args);
                    }
                    else
                    {
                        output.WriteLine(message);
                    }
                }
            }
        }

        private static void DisplayError(string message, XsltError xsltError, params string[] args)
        {
            ShowError(false, message, xsltError, args);
        }

        private static void DisplayCommandError(XsltError xsltError, params string[] args)
        {
            ShowError(true, XsltResources.CommandLineError, xsltError, args);
        }

        private XsltError Process()
		{
			if (this.validate)
			{
                // TODO: This will fail if it's not a file e.g. stdin
                XmlValidation validator = new XmlValidation();
                using (StreamReader xml = new StreamReader(this.sourceFile))
                {
                    if (!validator.IsValid(xml))
                    {
                        DisplayError(string.Empty, XsltError.ParseError, validator.LastException.Message);
                        return XsltError.ParseError;
                    }
                }
			}

			List<string> undefinedPrefixes = this.xsltOptions.GetUndefinedPrefixes();
			if (undefinedPrefixes.Count > 0)
			{
                DisplayCommandError(XsltError.MSXSL_E_PREFIX_UNDEFINED, undefinedPrefixes[0]);
                return XsltError.MSXSL_E_PREFIX_UNDEFINED;
			}

			List<Tuple<string, string>> invalids = this.xsltOptions.GetInvalidArguments();
			if (invalids.Count > 0)
			{
				DisplayError(invalids[0].Item2, XsltError.MSXSL_E_PARAM_CTXT, invalids[0].Item1);
                return XsltError.MSXSL_E_PARAM_CTXT;
			}

            if (string.IsNullOrEmpty(this.stylesheetFile)
                && this.useProcessingInstruction)
            {
                string xml = File.ReadAllText(this.sourceFile);
                this.stylesheetFile = XslTransformation.GetPi(xml);
                this.useStylesheetStdIn = false;

                if (string.IsNullOrEmpty(this.stylesheetFile))
                {
                    DisplayError(string.Empty, XsltError.InvalidPi);
                    return XsltError.InvalidPi;
                }
            }

            if (!string.IsNullOrEmpty(this.xsltOptions.StartMode) && this.xsltOptions.StartMode.Contains(":"))
            {
                DisplayError(string.Format(CultureInfo.CurrentCulture, XsltResources.NameNotContainChar, ":"), XsltError.ModeContext, this.xsltOptions.StartMode);
                return XsltError.ModeContext;
            }

            // TODO: Support Uris?
            // TODO: Support UNC?
            // For input & output
            XsltError fileError = XsltError.None;
            if (!this.useSourceStdIn)
            {
                fileError = this.TestFileExists(this.sourceFile);
                if (fileError != XsltError.None)
                {
                    return fileError;
                }
            }
            
            if (!this.useStylesheetStdIn)
            {
                fileError = this.TestFileExists(this.stylesheetFile);
                if (fileError != XsltError.None)
                {
                    return fileError;
                }
            }

			return this.Transform();
		}

        private XsltError Transform()
        {
			Stopwatch timer = Stopwatch.StartNew();
			XslTimings timings;
			
			//// Contract.Assert((this.useSourceStdIn && string.IsNullOrEmpty(this.sourceFile)) || (!this.useSourceStdIn && !string.IsNullOrEmpty(this.sourceFile)));
			//// Contract.Assert((this.useStylesheetStdIn && string.IsNullOrEmpty(this.stylesheetFile)) || (!this.useStylesheetStdIn && !string.IsNullOrEmpty(this.stylesheetFile)));

			using (TextReader xml = GetInput(this.useSourceStdIn, this.sourceFile))
			{
				using (TextReader xsl = GetInput(this.useStylesheetStdIn, this.stylesheetFile))
				{
					try
					{
						using (Stream output = GetOutput(this.useOutputfile, this.outputfile))
						{
							try
							{
								timings = XslTransformation.Transform(xsl, xml, output, this.xsltOptions);
							}
							catch (XsltException ex)
							{
								DisplayError(ex.Message, XsltError.CompileContext, this.stylesheetFile);
                                return XsltError.CompileContext;
							}
							catch (XmlException ex)
							{
								DisplayError(ex.Message, XsltError.CompileContext, this.stylesheetFile);
                                return XsltError.CompileContext;
							}
						}
					}
					catch (IOException ex)
					{
						DisplayError(ex.Message, XsltError.MSXSL_E_CREATE_FILE_CTXT, this.outputfile);
                        return XsltError.MSXSL_E_CREATE_FILE_CTXT;
					}
				}
			}

			timer.Stop();
			timings.Total = timer.Elapsed;

			if (this.useTimings)
			{
				DisplayTimings(timings);
			}

            return XsltError.None;
        }

		private XsltError TestFileExists(string filename)
		{
			if (File.Exists(filename))
			{
				return XsltError.None;
			}

			Uri uriResult;
			if (Uri.TryCreate(filename, UriKind.Absolute, out uriResult))
			{
				// This is a valid URL, but we don't support them!
				DisplayError(XsltResources.MissingResource, XsltError.MSXSL_E_LOAD_CTXT, filename);
                return XsltError.MSXSL_E_LOAD_CTXT;
			}

			DisplayError(XsltResources.MissingObject, XsltError.MSXSL_E_LOAD_CTXT, filename);
            return XsltError.MSXSL_E_LOAD_CTXT;
		}

        private Tuple<bool, XsltError> ProcessArgs(string[] args)
        {
            if (args == null || args.Length == 0)
            {
				DisplayCommandError(XsltError.MissingSource);
                return Tuple.Create(false, XsltError.MissingSource);
            }

            ArgsProcessor pro = new ArgsProcessor(args);
            Tuple<XsltError, string> paramsError = Tuple.Create(XsltError.None, string.Empty);
			
            // Process the switches first
            foreach (Arg arg in pro)
            {
                string command = arg.Command.ToLower(CultureInfo.CurrentCulture);

                switch (command)
                {
                    case "":
                        {
                            paramsError = this.ProcessParams(arg.Options, 0);
                            break;
                        }

					case "?":
						{
							DisplayHelp();
                            return Tuple.Create(false, XsltError.None);
						}

                    case "-":
					case "/":
                        {
							if (!this.useSourceStdIn && string.IsNullOrEmpty(this.sourceFile))
                            {
								this.useSourceStdIn = true;
                            }
							else if (!this.useStylesheetStdIn && string.IsNullOrEmpty(this.stylesheetFile))
                            {
								this.useStylesheetStdIn = true;
                            }
                            else
                            {
								DisplayCommandError(XsltError.MSXSL_E_UNKNOWN_OPTION, string.Empty);
                                return Tuple.Create(false, XsltError.MSXSL_E_UNKNOWN_OPTION);
                            }

                            paramsError = this.ProcessParams(arg.Options, 0);

                            break;
                        }

					case "o":
                        {
                            paramsError = this.ProcessParams(arg.Options, 1);

                            if (arg.Options.Length == 0 
								|| string.IsNullOrEmpty(arg.Options[0]))
                            {
								DisplayCommandError(XsltError.MissingOutput);
                                return Tuple.Create(false, XsltError.MissingOutput);
                            }                            
                            else
                            {
	                            this.useOutputfile = true;
								this.outputfile = arg.Options[0];
                            }

                            break;
                        }

                    case "t":
                        {
                            paramsError = this.ProcessParams(arg.Options, 0);

                            this.useTimings = true;
                            break;
                        }

                    case "m":
                        {
                            paramsError = this.ProcessParams(arg.Options, 1);

                            if (arg.Options.Length == 0)
                            {
								DisplayCommandError(XsltError.MSXSL_E_MISSING_MODE);
                                return Tuple.Create(false, XsltError.MSXSL_E_MISSING_MODE);
                            }
                            else
                            {
                                this.xsltOptions.StartMode = arg.Options[0];
                            }

                            break;
                        }

                    case "u":
                        {
                            paramsError = this.ProcessParams(arg.Options, 1);
                            break;
                        }

                    case "pi":
                        {
                            paramsError = this.ProcessParams(arg.Options, 0);

                            if (this.useStylesheetStdIn
								|| !string.IsNullOrEmpty(this.stylesheetFile))
                            {
								DisplayCommandError(XsltError.ProcessingInstructionConflict);
                                return Tuple.Create(false, XsltError.ProcessingInstructionConflict);
                            }

                            this.useProcessingInstruction = true;
                            break;
                        }

                    case "xw":
                        {
                            paramsError = this.ProcessParams(arg.Options, 0);

                            this.xsltOptions.RemoveWhitespace = true;
                            break;
                        }

                    case "v":
                        {
                            paramsError = this.ProcessParams(arg.Options, 0);

                            this.validate = true;
                            break;
                        }

					case "xe":
						{
                            paramsError = this.ProcessParams(arg.Options, 0);

							this.xsltOptions.ExternalDefinitions = false;
							break;
						}

                    default:
                        {
							DisplayCommandError(XsltError.MSXSL_E_UNKNOWN_OPTION, command);
                            return Tuple.Create(false, XsltError.MSXSL_E_UNKNOWN_OPTION);
                        }
                }

                if (paramsError.Item1 != XsltError.None)
                {
                    DisplayCommandError(paramsError.Item1, paramsError.Item2);
                    return Tuple.Create(false, paramsError.Item1);
                }
            }

            if (!this.useSourceStdIn && string.IsNullOrEmpty(this.sourceFile))
            {
				DisplayCommandError(XsltError.MissingSource);
                return Tuple.Create(false, XsltError.MissingSource);
            }

			if (!this.useStylesheetStdIn && string.IsNullOrEmpty(this.stylesheetFile) && !this.useProcessingInstruction)
            {
				DisplayCommandError(XsltError.MissingStyleSheet);
                return Tuple.Create(false, XsltError.MissingStyleSheet);
            }

            if (this.useSourceStdIn && this.useStylesheetStdIn)
            {
				DisplayCommandError(XsltError.MSXSL_E_MULTIPLE_STDIN);
                return Tuple.Create(false, XsltError.MSXSL_E_MULTIPLE_STDIN);
            }

			return Tuple.Create(true, XsltError.None);
        }

        private Tuple<XsltError, string> ProcessParams(string[] options, int start)
        {
            if (options == null || options.Length == 0 || options.Length < start)
            {
                return Tuple.Create(XsltError.None, string.Empty);
            }

            string param = null;

            for (int i = start; i < options.Length; i++)
            {
                string option = options[i].Replace("\"", string.Empty).Replace("\'", string.Empty);

                if (option == "=")
                {
                    param += "=";
                }
                else if (option.StartsWith("=", StringComparison.OrdinalIgnoreCase))
                {
                    if (param == null)
                    {
                        return Tuple.Create(XsltError.ParamMissingName, string.Empty);
                    }
                    else
                    {
						this.xsltOptions.AddParameter(param, option.TrimStart('='));
                        param = null;
                    }
                }
                else if (option.EndsWith("=", StringComparison.OrdinalIgnoreCase))
                {
                    if (param == null)
                    {
                        param = option;
                    }
                    else
                    {
						this.xsltOptions.AddParameter(param, option.TrimEnd('='));
                        param = null;
                    }
                }
                else if (option.Contains("="))
                {
                    if (options[i].StartsWith("'", StringComparison.OrdinalIgnoreCase) && options[i].EndsWith("'", StringComparison.OrdinalIgnoreCase))
                    {
                        if (param == null)
                        {
                            param = option;
                        }
                        else
                        {
							this.xsltOptions.AddParameter(param.TrimEnd('='), options[i]);
                            param = null;
                        }
                    }
                    else
                    {
						int firstEquals = options[i].IndexOf('=');

						string paramName = options[i].Substring(0, firstEquals);
						string paramValue = options[i].Substring(firstEquals + 1);

						this.xsltOptions.AddParameter(paramName, paramValue.Trim('\''));
                    }
                }
                else if (param != null && param.EndsWith("=", StringComparison.OrdinalIgnoreCase))
                {
					this.xsltOptions.AddParameter(param.TrimEnd('='), option);
                    param = null;
                }
                else if (param != null && i != start)
                {
                    return Tuple.Create(XsltError.MSXSL_E_MISSING_PARAM_EQUALS, options[i - 1]);
                }
                else if (!this.useSourceStdIn && string.IsNullOrEmpty(this.sourceFile))
                {
                    this.sourceFile = option.Trim();
                }
                else if (string.IsNullOrEmpty(this.stylesheetFile))
                {
                    this.stylesheetFile = option.Trim();
                }
                else
                {
                    param = option;
                }
            }

            if (param != null)
            {
                if (param.EndsWith("=", StringComparison.OrdinalIgnoreCase))
                {
					if (param.Contains(':'))
					{
                        return Tuple.Create(XsltError.MSXSL_E_MISSING_URI_VALUE, param.TrimEnd('='));
					}

                    return Tuple.Create(XsltError.MSXSL_E_MISSING_PARAM_VALUE, param.TrimEnd('='));
                }

				if (param.Contains(':'))
				{
                    return Tuple.Create(XsltError.MSXSL_E_MISSING_NS_EQUALS, param);
				}

                return Tuple.Create(XsltError.MSXSL_E_MISSING_PARAM_EQUALS, param);
            }

            return Tuple.Create(XsltError.None, string.Empty);
        }
    }
}
