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
	/// Form used to gather data to run a translation where both the input and output are on the disk.
	/// </summary>
	public partial class TranslationInputOutputForm : Form
	{
		#region Members

		private ConfigurationList				_configurationList;
		private Configuration					_selectedConfiguration;
		private bool							_showOutputFileControls;

		private string							_defaultInputLocation;
		private string							_defaultOutputLocation;

		#endregion

		#region Construction

		/// <summary>
		/// Default constructor.
		/// </summary>
		private TranslationInputOutputForm()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		public TranslationInputOutputForm(ConfigurationList configurationList, bool showOutputFileControls = true)
		{
			InitializeComponent();

			_configurationList			= configurationList;
			_showOutputFileControls		= showOutputFileControls;

			if (!_showOutputFileControls)
			{
				this.labelOutputFile.Visible		= false;
				this.textBoxOutputFile.Visible		= false;
				this.buttonBrowseOutput.Visible		= false;

				this.MinimumSize			= new Size(this.MinimumSize.Width, 207);
				this.Size					= new Size(this.Size.Width, 207);
				this.MaximumSize			= new Size(this.MaximumSize.Width, 207);

				this.Text					= "Import";
			}
		}

		#endregion

		#region Properties

		/// <summary>
		/// Get the Configuration that was selected.
		/// </summary>
		public Configuration SelectedConfiguration
		{
			get
			{
				return _selectedConfiguration;
			}
		}

		/// <summary>
		/// Input file.
		/// </summary>
		public string InputFile
		{
			get
			{
				return this.textBoxInputFile.Text.Trim();
			}
		}

		/// <summary>
		/// Output file.
		/// </summary>
		public string OutputFile
		{
			get
			{
				return this.textBoxOutputFile.Text.Trim();
			}
		}

		/// <summary>
		/// Default input file location.
		/// </summary>
		public string DefaultInputLocation
		{
			get
			{
				return _defaultInputLocation;
			}

			set
			{
				_defaultInputLocation = value;
			}
		}

		/// <summary>
		/// Default output file location.
		/// </summary>
		public string DefaultOutputLocation
		{
			get
			{
				return _defaultOutputLocation;
			}

			set
			{
				_defaultOutputLocation = value;
			}
		}

		#endregion

		#region Event Handlers

		/// <summary>
		/// Form opening event handler.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">Event arguments.</param>
		private void TranslationInputOutputForm_Load(object sender, EventArgs e)
		{
			_selectedConfiguration						= null;
			this.comboBoxConfiguration.SelectedIndex	= -1;

			this.comboBoxConfiguration.Items.Clear();
			this.comboBoxConfiguration.Items.AddRange(_configurationList.GetArrayOfNames());
			SetEnabledForControls(false);
		}

		/// <summary>
		/// Selected Configuration changed event handler.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">Event arguments.</param>
		private void comboBoxConfiguration_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.comboBoxConfiguration.SelectedIndex > -1)
			{
				_selectedConfiguration = _configurationList[this.comboBoxConfiguration.SelectedIndex];
				SetEnabledForControls(true);
			}
		}

		/// <summary>
		/// Sets the Enabled status of the controls.
		/// </summary>
		/// <param name="enabled">Specifies if the controls should be enabled or disabled.</param>
		private void SetEnabledForControls(bool enabled)
		{
			this.labelInputFile.Enabled			= enabled;
			this.textBoxInputFile.Enabled		= enabled;
			this.buttonBrowseInput.Enabled		= enabled;
			this.labelOutputFile.Enabled		= enabled;
			this.textBoxOutputFile.Enabled		= enabled;
			this.buttonBrowseOutput.Enabled		= enabled;
		}

		/// <summary>
		/// Get an input file.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">Event arguments.</param>
		private void buttonBrowseInput_Click(object sender, EventArgs e)
		{
			ProcessorMetaData processorMetaData		= ProcessorObjectFactory.GetProcessorMetaDataFromName(_selectedConfiguration.InputProcessorName);
			string path								= FileSelect.BrowseForAFile(this, processorMetaData.FilterString, "Input File", _defaultInputLocation);

			if (path != "")
			{
				this.textBoxInputFile.Text = path;
				_defaultInputLocation = System.IO.Path.GetDirectoryName(path);
			}
		}

		/// <summary>
		/// Get an output file.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">Event arguments.</param>
		private void buttonBrowseOutput_Click(object sender, EventArgs e)
		{
			ProcessorMetaData processorMetaData	= ProcessorObjectFactory.GetProcessorMetaDataFromName(_selectedConfiguration.OutputProcessorName);
			string path							= FileSelect.BrowseForANewFileLocation(this, processorMetaData.FilterString, "Output File", _defaultOutputLocation);

			if (path != "")
			{
				this.textBoxOutputFile.Text = path;
				_defaultOutputLocation = System.IO.Path.GetDirectoryName(path);
			}
		}

		/// <summary>
		/// Ok click handler.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">Event arguments.</param>
		private void bntOK_Click(object sender, EventArgs e)
		{
			if (this.comboBoxConfiguration.SelectedIndex < 0)
			{
				MessageBox.Show(this, "A Configuration is not selected.", "Error", MessageBoxButtons.OK);

				// Have to set the DialogResult to none to prevent the form from closing.
				this.DialogResult = DialogResult.None;
				return;
			}

			string path = this.textBoxInputFile.Text.Trim();
			if (!System.IO.File.Exists(path))
			{
				MessageBox.Show(this, "The input file specified does not exist.", "Error", MessageBoxButtons.OK);

				// Have to set the DialogResult to none to prevent the form from closing.
				this.DialogResult = DialogResult.None;
				return;
			}

			if (_showOutputFileControls)
			{
				path = this.textBoxOutputFile.Text.Trim();
				DigitalProduction.IO.ValidFileNameResult validFileNameResult = DigitalProduction.IO.Path.IsValidFileName(path);
				if (validFileNameResult != DigitalProduction.IO.ValidFileNameResult.Valid)
				{
					MessageBox.Show(this, "The output file specified is not a valid path.", "Error", MessageBoxButtons.OK);

					// Have to set the DialogResult to none to prevent the form from closing.
					this.DialogResult = DialogResult.None;
					return;
				}
			}

			// This will close the dialog as well.
			this.DialogResult = DialogResult.OK;
		}

		#endregion

	} // End class.
} // End namespace.