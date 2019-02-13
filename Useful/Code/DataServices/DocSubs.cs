using System;
using System.Collections.Generic;
using System.Text;

namespace Useful.DataServices
{
	internal struct DocSubs
	{
		internal int Cid;
		internal string SchemaName;
		internal string DocumentId;
		internal string FromSystem;
		internal string ToSystem;
		internal string Xml;
		internal bool Successful;
		internal string[] Errors;
	}
}
