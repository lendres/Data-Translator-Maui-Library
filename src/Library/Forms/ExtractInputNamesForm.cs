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
	/// Edit a configuration.
	/// 
	/// Currently allows 
	/// </summary>
	public partial class ExtractInputNamesForm : Form
	{
		#region Members

		private List<string>					_inputNames;

		#endregion

		#region Constructors

		/// <summary>
		/// Constructor.
		/// </summary>
		public ExtractInputNamesForm()
		{
			InitializeComponent();

			// Populate combo boxes.
			this.comboBoxInputProcessor.Items.AddRange(ProcessorObjectFactory.InputProcessorNames);

			SetEnabled(false);
		}

		#endregion

		#region Properties

		public List<string> InputNames
		{
			get
			{
				return _inputNames;
			}
		}

		#endregion

		#region Event Handlers

		/// <summary>
		/// InputProcessor combo box selected index changed event handler.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">Event arguments.</param>
		private void comboBoxInputProcessor_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.comboBoxInputProcessor.SelectedIndex > -1)
			{
				SetEnabled(true);
			}
			else
			{
				SetEnabled(false);
			}
		}

		/// <summary>
		/// Sets the enabled status of the controls
		/// </summary>
		/// <param name="enabled">Specifies if the controls are enabled.</param>
		private void SetEnabled(bool enabled)
		{
			this.textBoxInputSource.Enabled			= enabled;
			this.buttonBrowseInputSource.Enabled	= enabled;
		}

		/// <summary>
		/// Browse for a Translation Matrix File.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">Event arguments.</param>
		private void buttonBrowseInputSource_Click(object sender, EventArgs e)
		{
			string fileterString = "All files (*.*)|*.*";
			if (this.comboBoxInputProcessor.SelectedIndex > -1)
			{
				ProcessorMetaData processorMetaData = ProcessorObjectFactory.GetProcessorMetaDataFromName(this.comboBoxInputProcessor.Text);
			}
			string path = FileSelect.BrowseForAFile(this, fileterString);

			if (path != "")
			{
				this.textBoxInputSource.Text = path;
			}
		}

		/// <summary>
		/// Ok button handler.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">Event arguments.</param>
		private void buttonOK_Click(object sender, EventArgs e)
		{
			// Ensure the data is valid.
			if (!ValidateAllControls())
			{
				// Have to set the DialogResult to none to prevent the form from closing.
				this.DialogResult = DialogResult.None;
				return;
			}

			InputProcessor inputProcessor = ProcessorObjectFactory.CreateInputProcessor(this.comboBoxInputProcessor.Text);
			inputProcessor.Open(this.textBoxInputSource.Text.Trim());
			_inputNames = inputProcessor.ExtractInputNames();
			inputProcessor.Close();
		}

		/// <summary>
		/// Simple control validation done before we exit.
		/// </summary>
		private bool ValidateAllControls()
		{
			// Translation matrix file check.
			if (!System.IO.File.Exists(this.textBoxInputSource.Text))
			{
				MessageBox.Show(this, "A valid Input Source must be selected.", "Invalid File", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}

			// Input processor check.
			if (this.comboBoxInputProcessor.SelectedIndex < 0)
			{
				MessageBox.Show(this, "An Input Processor must be selected.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}

			return true;
		}
		
		#endregion

	} // End class.
} // End namespace.