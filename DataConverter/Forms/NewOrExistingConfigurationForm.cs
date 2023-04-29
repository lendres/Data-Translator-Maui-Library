using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataConverter
{
	/// <summary>
	/// Dialog for selecting an existing configuration to edit, or creating a new one.
	/// </summary>
	public partial class NewOrExistingConfigurationForm : Form
	{
		#region Members

		private ConfigurationList				_configurationList;
		private Configuration					_selectedConfiguration;
		private InstanceSelect					_instanceSelect;

		#endregion

		#region Construction

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="configurationList">Configuration list.</param>
		public NewOrExistingConfigurationForm(ConfigurationList configurationList)
		{
			_configurationList					= configurationList;

			InitializeComponent();
		}

		#endregion

		#region Properties

		/// <summary>
		/// Configuration user selected.
		/// </summary>
		public Configuration SelectedConfiguration
		{
			get
			{
				return _selectedConfiguration;
			}

			set
			{
				_selectedConfiguration = value;
			}
		}

		/// <summary>
		/// Specifies if a new or existing Configuration was selected.
		/// </summary>
		public InstanceSelect InstanceSelect
		{
			get
			{
				return _instanceSelect;
			}
		}

		#endregion

		#region Event Handlers and Helpers

		/// <summary>
		/// Handle the form opening/loading event.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">Event arguments.</param>
		private void NewOrExistingConfigurationForm_Load(object sender, EventArgs e)
		{
			this.radioButtonNewConfiguration.Checked	= true;
			_instanceSelect								= InstanceSelect.New;

			this.comboBoxEditExistingFile.Items.Clear();
			this.comboBoxEditExistingFile.Items.AddRange(_configurationList.GetArrayOfNames());
			this.comboBoxEditExistingFile.SelectedIndex = 0;

			SetControls();
		}

		/// <summary>
		/// Handles event for radio button check changing.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">Event arguments.</param>
		private void radioButtonExistingConfiguration_CheckedChanged(object sender, EventArgs e)
		{
			SetControls();
			_instanceSelect	= InstanceSelect.Existing;
		}

		/// <summary>
		/// Handles event for radio button check changing.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">Event arguments.</param>
		private void radioButtonNewConfiguration_CheckedChanged(object sender, EventArgs e)
		{
			SetControls();
			_instanceSelect	= InstanceSelect.New;
		}

		/// <summary>
		/// Sets the state of the controls.
		/// </summary>
		private void SetControls()
		{
			this.comboBoxEditExistingFile.Enabled	= this.radioButtonEditConfiguration.Checked;
			bool enabled							= this.radioButtonNewConfiguration.Checked;
		}

		/// <summary>
		/// Validate and establish results before closing.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">Event arguments.</param>
		private void buttonOK_Click(object sender, EventArgs e)
		{
			// Ensure the data is valid.
			if (!ValidateChildren())
			{
				// Have to set the DialogResult to none to prevent the form from closing.
				this.DialogResult = DialogResult.None;
				return;
			}

			if (this.radioButtonEditConfiguration.Checked)
			{
				_selectedConfiguration = _configurationList[this.comboBoxEditExistingFile.SelectedIndex];
			}
			else
			{
				_selectedConfiguration = new Configuration();
			}

			// This will close the dialog as well.
			this.DialogResult = DialogResult.OK;
		}

		/// <summary>
		/// Cancel.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">Event arguments.</param>
		private void buttonCancel_Click(object sender, EventArgs e)
		{
			// Ensure nothing is selected.
			_selectedConfiguration = null;
			this.DialogResult = DialogResult.Cancel;
		}

		#endregion

	} // End class.
} // End namespace.