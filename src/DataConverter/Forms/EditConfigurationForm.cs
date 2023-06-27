using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using DigitalProduction.Forms;

namespace DataConverter
{
	/// <summary>
	/// Edit a configuration.
	/// 
	/// Currently allows 
	/// </summary>
	public partial class EditConfigurationForm : Form
	{
		#region Members

		private Configuration					_configuration;
		private bool							_hideOutputProcessorSettings;

		private string							_defaultTransformationMatrixDirectory;

		#endregion

		#region Constructors

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="configuration">Configuration to edit.</param>
		/// <param name="hideOutputProcessorSettings">If true, the OutputProcessor controls are hidden.</param>
		public EditConfigurationForm(Configuration configuration, string transformationMatrixDirectory, bool hideOutputProcessorSettings = false)
		{
			_configuration								= configuration;
			_defaultTransformationMatrixDirectory		= transformationMatrixDirectory;
			_hideOutputProcessorSettings				= hideOutputProcessorSettings;

			InitializeComponent();

			InitializeControls(transformationMatrixDirectory, hideOutputProcessorSettings);
		}

		/// <summary>
		/// Initial control settings.
		/// </summary>
		/// <param name="hideOutputProcessorSettings">
		/// If true, the OutputProcessor controls are not shown.  Useful if the output always goes to one location, but input can vary.
		/// </param>
		private void InitializeControls(string transformationMatrixDirectory, bool hideOutputProcessorSettings)
		{
			// Populate combo boxes.
			this.comboBoxInputProcessor.Items.AddRange(ProcessorObjectFactory.InputProcessorNames);
			this.comboBoxOutputProcessor.Items.AddRange(ProcessorObjectFactory.OutputProcessorNames);

			string[] files = Directory.GetFiles(transformationMatrixDirectory, "*." + Translator.TranslationMatrixFileExtension, SearchOption.AllDirectories);

			// Make sure that there are appropriate Output Templates located in the directory.
			if (files.Length == 0)
			{
				throw new Exception("No Translation Matrix Files are located in the Translation Matrix directory.");
			}

			// Trim the path off and leave just the file names.
			for (int i = 0; i < files.Length; i++)
			{
				// Remove directory.
				string file = System.IO.Path.GetFileNameWithoutExtension(files[i]);

				// Add the file to the drop down list.
				this.comboBoxTranslationMatrix.Items.Add(file);
			}

			this.textBoxName.Text							= _configuration.Name;
			this.comboBoxTranslationMatrix.SelectedItem		= System.IO.Path.GetFileNameWithoutExtension(_configuration.TranslationMatrixFile);

			this.comboBoxInputProcessor.SelectedItem		= _configuration.InputProcessorName;
			this.comboBoxOutputProcessor.SelectedItem		= _configuration.OutputProcessorName;

			if (hideOutputProcessorSettings)
			{
				this.labelOutputProcesssor.Visible		= false;
				this.comboBoxOutputProcessor.Visible	= false;
			}
		}

		#endregion

		#region Properties

		/// <summary>
		/// Configuration that is being edited.
		/// </summary>
		public Configuration Configuration
		{
			get
			{
				return _configuration;
			}
		}

		/// <summary>
		/// Default directory for the transformation matrix files.
		/// </summary>
		public string DefaultTransformationMatrixDirectory
		{
			get
			{
				return _defaultTransformationMatrixDirectory;
			}

			set
			{
				_defaultTransformationMatrixDirectory = value;
			}
		}

		#endregion

		#region Event Handlers

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

			_configuration.Name						= this.textBoxName.Text;
			_configuration.TranslationMatrixFile	= this.comboBoxTranslationMatrix.SelectedItem.ToString() + "." + Translator.TranslationMatrixFileExtension;
			_configuration.InputProcessorName		= this.comboBoxInputProcessor.SelectedItem.ToString();
			_configuration.OutputProcessorName		= this.comboBoxOutputProcessor.SelectedItem.ToString();
		}

		/// <summary>
		/// Simple control validation done before we exit.
		/// </summary>
		private bool ValidateAllControls()
		{
			// Check the name.
			if (this.textBoxName.Text.Trim() == "")
			{
				MessageBox.Show(this, "A valid name must be specified.", "Invalid Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}

			// Translation matrix file check.
			if (this.comboBoxTranslationMatrix.SelectedIndex < 0)
			{
				MessageBox.Show(this, "A valid Translation Matrix File must be selected.", "Invalid File", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}

			// Input processor check.
			if (this.comboBoxInputProcessor.SelectedIndex < 0)
			{
				MessageBox.Show(this, "An Input Processor must be selected.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}

			// Output processor check.
			if (!_hideOutputProcessorSettings)
			{
				if (this.comboBoxOutputProcessor.SelectedIndex < 0)
				{
					MessageBox.Show(this, "An Output Processor must be selected.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return false;
				}
			}

			return true;
		}

		#endregion

	} // End class.
} // End namespace.