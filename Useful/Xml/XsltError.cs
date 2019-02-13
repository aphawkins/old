//-----------------------------------------------------------------------
// <copyright file="XsltError.cs" company="APH Software">
//     Copyright (c) Andrew Hawkins. All rights reserved.
// </copyright>
// <summary>Errors returned from the XSLT console application.</summary>
//-----------------------------------------------------------------------

namespace Useful.Console
{
	public enum XsltError
    {
        None = 0,

        // Standard commandline errors
        MSXSL_E_UNKNOWN_OPTION = unchecked((int)0xc0000067),	// OK
        ParamMissingName = unchecked((int)0xc000006e),		// OK
        // end
		MissingSource = unchecked((int)0xc0000068),	// OK
		MissingStyleSheet = unchecked((int)0xc0000069),	// OK
		MissingOutput = unchecked((int)0xc000006a),	// OK
		MSXSL_E_MISSING_MODE = unchecked((int)0xc000006b),		// OK
		MSXSL_E_MISSING_PARAM_EQUALS = unchecked((int)0xc000006c),	// OK
		MSXSL_E_MISSING_NS_EQUALS = unchecked((int)0xc000006d),	// OK
		MSXSL_E_MISSING_PARAM_VALUE = unchecked((int)0xc000006f),
		MSXSL_E_MISSING_URI_VALUE = unchecked((int)0xc0000070),
		MSXSL_E_PREFIX_UNDEFINED = unchecked((int)0xc0000071),
		MSXSL_E_MULTIPLE_STDIN = unchecked((int)0xc0000072),
		////MSXSL_E_BAD_MSXML = unchecked((int)0xc0000074),
		////MSXSL_E_CMDLINE_CTXT = unchecked((int)0x800c0005),		// Ok
		////MSXSL_E_CREATE_CTXT = unchecked((int)0xc0000073),		// Ok
		MSXSL_E_LOAD_CTXT = unchecked((int)0x800c0006),			// Ok
		////MSXSL_E_PARSE_CTXT = unchecked((int)0xc00ce552),		// Ok	// Also 0xc00ce552
		CompileContext = unchecked((int)0x80004005),		// Ok
		MSXSL_E_CREATE_FILE_CTXT = unchecked((int)0x80070003),	// Ok
		ModeContext = unchecked((int)0x80004006),			// Bad	// Should be 0x80004005
		MSXSL_E_PARAM_CTXT = unchecked((int)0x80004007),		// Bad	// Should be 0x80004005
		////MSXSL_E_EXECUTE_CTXT = unchecked((int)0x80004008),		// Bad  // Should be 0x80004005
		////MSXSL_E_CMDLINE_ERROR = unchecked((int)0xc000007d),
		ParseError = unchecked((int)0xc00ce015),		// OK
		////MSXSL_E_FROM_STDIN = unchecked((int)0xc000007f),
		SystemError = -1,
        ////MSXSL_E_OBJECT_NOT_FOUND = unchecked((int)0xc0000081),
		////MSXSL_E_NO_MSXML = unchecked((int)0xc0000082),
		InvalidPi = unchecked((int)0xc0000083),		// Ok
		////MSXSL_E_UNKNOWN_VERSION = unchecked((int)0xc0000084),
		ProcessingInstructionConflict = unchecked((int)0xc0000085),
        ////XSLT_E_DUPLICATE_SWITCH = unchecked((int)0xc0100067),
    }
}
