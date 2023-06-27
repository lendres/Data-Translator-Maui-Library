using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DigitalProduction.Forms;

namespace DataConverter
{
	/// <summary>
	/// 
	/// </summary>
	public partial class InputReportForm : Form
	{
		#region Members

		#endregion

		#region Construction

		/// <summary>
		/// Default constructor.
		/// </summary>
		public InputReportForm(InputReport inputReport, ValidationReport validationReport)
		{
			InitializeComponent();

			this.textBoxNumberOfLines.Text								= inputReport.NumberOfLines.ToString();
			this.textBoxNumberOfRecords.Text							= inputReport.NumberOfRecords.ToString();
			this.textBoxNumberOfCorruptedRecords.Text					= validationReport.NumberOfCorruptedRecords.ToString();
			this.textBoxCorruptionReport.Text							= validationReport.CorruptionReport;
		}

		#endregion

		#region Event Handlers

		/// <summary>
		/// Ok click handler.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">Event arguments.</param>
		private void bntOK_Click(object sender, EventArgs e)
		{
			// This will close the dialog as well.
			this.DialogResult = DialogResult.OK;
		}

		#endregion

	} // End class.
} // End namespace.