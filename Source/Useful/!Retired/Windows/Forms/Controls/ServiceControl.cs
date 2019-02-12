using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Useful.Windows.Forms.Controls
{
	/// <summary>
	/// A Windows control that is a base for other service controls.
	/// </summary>
	public partial class ServiceControl : UserControl
	{
		// This delegate enables asynchronous calls for setting
		// the text property on a TextBox control.
		private delegate void SetTextCallback(bool isChecked);

		/// <summary>
		/// Initializes a new instance of this class.
		/// </summary>
		public ServiceControl()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Is the service available?
		/// </summary>
		public bool Availability
		{
			get
			{
				return this.checkAvailable.Checked;
			}
			set
			{
				this.checkAvailable.Checked = value;
			}
		}

		// This method demonstrates a pattern for making thread-safe
		// calls on a Windows Forms control. 
		//
		// If the calling thread is different from the thread that
		// created the TextBox control, this method creates a
		// SetTextCallback and calls itself asynchronously using the
		// Invoke method.
		//
		// If the calling thread is the same as the thread that created
		// the TextBox control, the Text property is set directly. 

		internal void SetChecked(bool isChecked)
		{
			// InvokeRequired required compares the thread ID of the
			// calling thread to the thread ID of the creating thread.
			// If these threads are different, it returns true.
			if (this.checkAvailable.InvokeRequired)
			{
				SetTextCallback d = new SetTextCallback(SetChecked);
				this.Invoke(d, new object[] { isChecked });
			}
			else
			{
				this.checkAvailable.Checked = isChecked;
			}
		}
	}
}