//-----------------------------------------------------------------------
// <copyright file="XsltEmulation.cs" company="APH Software">
//     Copyright (c) Andrew Hawkins. All rights reserved.
// </copyright>
// <summary>placeholder.</summary>
//-----------------------------------------------------------------------

namespace Useful.Console
{
	using System.Collections.Generic;

	internal class XsltEmulation
    {
        private static Dictionary<XsltError, string> errorCodes = GetErrorMessages();
        
        internal static string GetErrorCode(XsltError errorCode)
        {
            if (!errorCodes.ContainsKey(errorCode))
            {
                return "Unknown error!";
            }

            return errorCodes[errorCode];
        }

        private static Dictionary<XsltError, string> GetErrorMessages()
		{
            Dictionary<XsltError, string> errorCodes = new Dictionary<XsltError, string>();
			errorCodes.Add(XsltError.MSXSL_E_UNKNOWN_OPTION, "Unrecognized option : '-{0}'.");
			errorCodes.Add(XsltError.MissingSource, "Missing source filename.");
            errorCodes.Add(XsltError.MissingStyleSheet, "Missing stylesheet filename.");
            errorCodes.Add(XsltError.MissingOutput, "Missing output filename after '-o' option.");
            errorCodes.Add(XsltError.MSXSL_E_MISSING_MODE, "Missing start mode name after '-m' option.");
            errorCodes.Add(XsltError.MSXSL_E_MISSING_PARAM_EQUALS, "Parameter name '{0}' must be followed by an '=' character.");
            errorCodes.Add(XsltError.MSXSL_E_MISSING_NS_EQUALS, "Namespace declaration '{0}' must be followed by an '=' character.");
            errorCodes.Add(XsltError.ParamMissingName, "The '=' character must be preceded by the name of a parameter or a namespace declaration.");
            errorCodes.Add(XsltError.MSXSL_E_MISSING_PARAM_VALUE, "Parameter '{0}' is missing a value following the '=' character.");
            errorCodes.Add(XsltError.MSXSL_E_MISSING_URI_VALUE, "Namespace declaration '{0}' is missing a URI following the '=' character.");
            errorCodes.Add(XsltError.MSXSL_E_PREFIX_UNDEFINED, "Prefix '{0}' cannot be resolved.  Use xmlns:{0}='...' to bind '{0}' to a URI.");
            errorCodes.Add(XsltError.MSXSL_E_MULTIPLE_STDIN, "The input and the stylesheet document cannot both be read from stdin.  At least one of them must be loaded from a URL.");
            ////errorCodes.Add(XsltError.MSXSL_E_BAD_MSXML, "Could not create the '{0}' object.  Make sure that MSXML version {1} is correctly installed on the machine.");
            ////errorCodes.Add(XsltError.MSXSL_E_CMDLINE_CTXT, "Error occurred while parsing command line.");
            ////errorCodes.Add(XsltError.MSXSL_E_CREATE_CTXT, "Error occurred while creating MSXML COM objects.");
            errorCodes.Add(XsltError.MSXSL_E_LOAD_CTXT, "Error occurred while loading document '{0}'.");
            ////errorCodes.Add(XsltError.MSXSL_E_PARSE_CTXT, "Error occurred while parsing document.");
            errorCodes.Add(XsltError.CompileContext, "Error occurred while compiling stylesheet '{0}'.");
            errorCodes.Add(XsltError.MSXSL_E_CREATE_FILE_CTXT, "Error occurred while creating file '{0}'.");
            errorCodes.Add(XsltError.ModeContext, "Error occurred while setting the stylesheet's starting mode to '{0}'.");
            errorCodes.Add(XsltError.MSXSL_E_PARAM_CTXT, "Error occurred while passing parameter '{0}' to the stylesheet.");
            ////errorCodes.Add(XsltError.MSXSL_E_EXECUTE_CTXT, "Error occurred while executing stylesheet '{0}'.");
            ////errorCodes.Add(XsltError.MSXSL_E_CMDLINE_ERROR, "{0}\r\nCode:   0x{1}\r\n{2}%0");
            errorCodes.Add(XsltError.ParseError, "{0}");
            ////errorCodes.Add(XsltError.MSXSL_E_FROM_STDIN, "<from stdin>%0");
            errorCodes.Add(XsltError.SystemError, "The system cannot provide error text for error number {0}.");
            ////errorCodes.Add(XsltError.MSXSL_E_OBJECT_NOT_FOUND, "The system cannot locate the object specified.");
            ////errorCodes.Add(XsltError.MSXSL_E_NO_MSXML, "Could not locate a recognized version of MSXML on the machine.  Please re-install MSXML version 2.6 or later.");
            errorCodes.Add(XsltError.InvalidPi, "The source document does not contain an 'xml-stylesheet' processing instruction of this form: <?xml-stylesheet type='text/xsl' href='stylesheet-url'?>");
            ////errorCodes.Add(XsltError.MSXSL_E_UNKNOWN_VERSION, "The '-u' option must have a value of '2.6', '3.0', or '4.0'.");
            errorCodes.Add(XsltError.ProcessingInstructionConflict, "The '-pi' option cannot be used when the stylesheet argument is specified.");
            ////errorCodes.Add(XsltError.XSLT_E_DUPLICATE_SWITCH, "Duplicate switch.");
            return errorCodes;
		}
    }
}
