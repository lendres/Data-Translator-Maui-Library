using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DigitalProduction.Registry;
using DigitalProduction.Forms;

namespace DataConverter
{
	/// <summary>
	/// Control used to change settings for the Data Translator library.  To use, add the control to a form.  In the constructor
	/// of the form, call "SetRegistryAccess."  In the "Ok" button event handler, call "Save."
	/// </summary>
	public partial class DataTranslatorOptionsControl : UserControl
	{
		#region Members

		private DataTranslatorWinRegistry			_registry;

		#endregion

		#region Construction

		/// <summary>
		/// Default constructor.  Needed for visual designer.
		/// </summary>
		public DataTranslatorOptionsControl()
		{
			InitializeComponent();
		}

		#endregion

		#region Properties

		#endregion

		#region Event Handlers

		/// <summary>
		/// Click handler for browsing for the translation matrices directory.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">Event Argument.</param>
		private void buttonTranslationMatrixLocation_Click(object sender, EventArgs e)
		{
			DirectorySelect.SelectDirectory("Select the default directory for Translation Matrix files.", false, this.textBoxTranslationMatrixLocation);
		}

		/// <summary>
		/// Click handler for browsing for the units file.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">Event Argument.</param>
		private void buttonUnitsFile_Click(object sender, EventArgs e)
		{
			string file = FileSelect.BrowseForAnXMLFile(this, "Select the Units Definition File", System.IO.Path.GetDirectoryName(this.textBoxUnitsFile.Text));
			if (file != "")
			{
				this.textBoxUnitsFile.Text = file;
			}
		}

		/// <summary>
		/// Click handler for browsing for the configurations file.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">Event Argument.</param>
		private void buttonConfigurationFile_Click(object sender, EventArgs e)
		{
			string file = FileSelect.BrowseForAnXMLFile(this, "Select the Units Definition File", System.IO.Path.GetDirectoryName(this.textBoxConfigurationFile.Text));
			if (file != "")
			{
				this.textBoxConfigurationFile.Text = file;
			}
		}

		/// <summary>
		/// Click handler for browsing for the field meta data file.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">Event Argument.</param>
		private void buttonFieldMetaDataFile_Click(object sender, EventArgs e)
		{
			string file = FileSelect.BrowseForAnXMLFile(this, "Select the Units Definition File", System.IO.Path.GetDirectoryName(this.textBoxFieldMetaDataFile.Text));
			if (file != "")
			{
				this.textBoxFieldMetaDataFile.Text = file;
			}
		}

		#endregion

		#region Methods

		/// <summary>
		/// Sets the registry accessed of the main application.  Settings are saved as a subkey of the AppKey of this registry access.
		/// </summary>
		/// <param name="winRegistryAccess"></param>
		public void SetRegistryAccess(WinRegistryAccess winRegistryAccess)
		{
			_registry												= new DataTranslatorWinRegistry(winRegistryAccess);
			this.textBoxTranslationMatrixLocation.Text				= _registry.TranslationMatrixDirectory;
			this.textBoxUnitsFile.Text								= _registry.UnitsFile;
			this.textBoxConfigurationFile.Text						= _registry.ConfigurationListFile;
			this.textBoxFieldMetaDataFile.Text						= _registry.FieldMetaDataFile;
		}

		/// <summary>
		/// Saves the data in the form back to the registry.
		/// </summary>
		public void Save()
		{
			_registry.TranslationMatrixDirectory				= this.textBoxTranslationMatrixLocation.Text;
			_registry.UnitsFile									= this.textBoxUnitsFile.Text;
			_registry.ConfigurationListFile						= this.textBoxConfigurationFile.Text;
			_registry.FieldMetaDataFile							= this.textBoxFieldMetaDataFile.Text;
		}

		#endregion

	} // End class.
} // End namespace.
