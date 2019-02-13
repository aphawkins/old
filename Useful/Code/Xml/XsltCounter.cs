namespace Useful.Xml
{
	internal class XsltCounter
	{
		public XsltCounter()
		{
			ResetCount();
		}

		public int Count
		{
			get;
			set;
		}

		public string GetHashCount()
		{
			if (this.Count == 1)
			{
				return string.Empty;
			}
			else
			{
				return string.Format("#{0:000}", this.Count - 1);
			}
		}

		public void ResetCount()
		{
			this.Count = 0;
		}

		public void IncrementCounter()
		{
			this.Count++;
		}
	}
}
