//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.ComponentModel;
//using System.Xml.Serialization;
//using System.Windows.Forms;
//using DigitalProduction.Forms;
//using System.Threading;
//using DigitalProduction.Registry;

namespace DataConverter;

/// <summary>
/// Class for interfacing with the Data Translator.
/// </summary>
public class Interface
{
	#region Members

	//		private Form										_ownerForm;
	//		private Controller									_controlller;

	//		// Threading.
	//		private Thread										_processThread;
	//		private ProgressDialog								_progressDialog;
	//		private Configuration								_selectedConfiguration;
	//		private List<ValidationCheck>						_validationChecks;
	//		private DisplayMessageDelegate						_displayMessageDelegate;

	private static TranslatorPreferences            _registry		= new();

	#endregion

	#region Construction

	/// <summary>
	/// Default constructor.
	/// </summary>
	public Interface()
	{
	}

	#endregion

	#region Properties

	//		/// <summary>
	//		/// Delegate for displaying a message.
	//		/// </summary>
	//		public DisplayMessageDelegate DisplayMessageDelegate
	//		{
	//			get
	//			{
	//				return _displayMessageDelegate;
	//			}

	//			set
	//			{
	//				_displayMessageDelegate = value;
	//			}
	//		}

	/// <summary>
	/// Registry access.
	/// </summary>
	public static TranslatorPreferences Registry
	{
		get
		{
			return _registry;
		}

		set
		{
			_registry = value;
		}
	}

	#endregion

	//		#region Methods

	//		#region Import and Translation

	//		/// <summary>
	//		/// Run the UI and work to do a translation.  A turnkey solution.
	//		/// </summary>
	//		public void TranslateData()
	//		{
	//			// Create an instance from the file.
	//			ConfigurationList configurationList	= ConfigurationList.Deserialize(Interface.Registry.ConfigurationListFile);

	//			// For translations, we only want processors that operate on data from the disk.
	//			configurationList = configurationList.FilterBothProcessorsByDataLocation(DataLocation.Disk);

	//			Translate(configurationList, true);
	//		}

	//		/// <summary>
	//		/// Import data.
	//		/// </summary>
	//		/// <typeparam name="T">Type of OutputProcessor used to generate the required internal data structures during the import.</typeparam>
	//		/// <param name="_ownerForm"></param>
	//		/// <param name="configurationListPath"></param>
	//		/// <returns></returns>
	//		public T ImportData<T>() where T : OutputProcessor
	//		{
	//			// Create an instance from the file.
	//			ConfigurationList configurationList	= ConfigurationList.Deserialize(Interface.Registry.ConfigurationListFile);

	//			// For translations, we only want processors that operate on data from the disk.
	//			configurationList = configurationList.FilterByOutputProcessorType(typeof(T));

	//			Controller controller = Translate(configurationList, false);

	//			if (controller == null)
	//			{
	//				return null;
	//			}
	//			else
	//			{
	//				return (T)controller.OutputProcessor;
	//			}
	//		}

	//		/// <summary>
	//		/// The real work of the Translation.  Note that an Import and Translation, for the purposes of this, only differ by whether the output controls are shown.
	//		/// The ConfigurationList must be pre-filtered to include only those that 
	//		/// </summary>
	//		/// <param name="_ownerForm"></param>
	//		/// <param name="configurationList"></param>
	//		/// <param name="showOutputControls"></param>
	//		private Controller Translate(ConfigurationList configurationList, bool showOutputControls)
	//		{
	//			// Translation form.
	//			TranslationInputOutputForm	translationInputOutputForm	= new TranslationInputOutputForm(configurationList, showOutputControls);
	//			translationInputOutputForm.DefaultInputLocation			= System.IO.Path.GetDirectoryName(_registry.LastTranslationInputFile);
	//			translationInputOutputForm.DefaultOutputLocation		= System.IO.Path.GetDirectoryName(_registry.LastTranslationOutputFile);

	//			DialogResult				result						= translationInputOutputForm.ShowDialog();

	//			if (result == DialogResult.OK)
	//			{
	//				// Get ValidationChecks to perform.
	//				ValidationSelectionForm validationSelectionForm = new ValidationSelectionForm(_registry);
	//				result = validationSelectionForm.ShowDialog();

	//				if (result == DialogResult.OK)
	//				{
	//					_validationChecks = validationSelectionForm.ValidationChecks;

	//					_selectedConfiguration = translationInputOutputForm.SelectedConfiguration;
	//					_registry.LastTranslationInputFile = translationInputOutputForm.InputFile;

	//					if (showOutputControls)
	//					{
	//						_registry.LastTranslationOutputFile = translationInputOutputForm.OutputFile;
	//					}

	//					_controlller = new Controller();

	//					CreateTranslateThread();

	//					if (_progressDialog.DialogResult == DialogResult.OK)
	//					{
	//						InputReportForm inputReportForm = new InputReportForm(_controlller.InputProcessor.InputReport, _controlller.Validator.ValidationReport);
	//						inputReportForm.ShowDialog(_ownerForm);
	//						return _controlller;
	//					}
	//					else
	//					{
	//						return null;
	//					}
	//				}
	//				else
	//				{
	//					return null;
	//				}
	//			}
	//			else
	//			{
	//				return null;
	//			}
	//		}

	//		/// <summary>
	//		/// Create the ProgressDialog and Thread to run the processing on.
	//		/// </summary>
	//		private void CreateTranslateThread()
	//		{
	//			_progressDialog = new ProgressDialog(ProgressBarStyle.Marquee);
	//			_progressDialog.ResetProgress();
	//			_progressDialog.StartTimer();

	//			_processThread = new Thread(new ThreadStart(this.RunTranslateThread));
	//			_processThread.IsBackground = true;
	//			_processThread.Start();

	//			if (_progressDialog.ShowDialog(_ownerForm) == DialogResult.Cancel)
	//			{
	//				_processThread.Abort();
	//				try
	//				{
	//					_controlller.InputProcessor.Close();
	//					_controlller.OutputProcessor.Close();
	//				}
	//				catch (Exception exception)
	//				{
	//					DisplayMessage("Error closing input and output files.\n\n" + exception.Message, "Error", MessageBoxIcon.Error);
	//				}
	//			}
	//		}

	//		/// <summary>
	//		/// Run the translation on a separate thread.
	//		/// </summary>
	//		private void RunTranslateThread()
	//		{
	//			// Wait for the dialog to open.
	//			while (!_progressDialog.Visible)
	//			{
	//				System.Threading.Thread.Sleep(100);
	//			}

	//			try
	//			{
	//				_controlller.TranslateData(_selectedConfiguration, _registry.LastTranslationInputFile, _registry.LastTranslationOutputFile, _validationChecks);
	//				// Close the dialog and allow the other thread to continue.
	//				_progressDialog.Invoke(new ProgressDialog.CallBack(_progressDialog.CloseOK));
	//			}
	//			catch (Exception exception)
	//			{
	//				// Close the dialog and allow the other thread to continue.
	//				_progressDialog.Invoke(new ProgressDialog.CallBack(_progressDialog.Close));
	//				DisplayMessage(exception.Message, "Error", MessageBoxIcon.Error);
	//			}
	//		}

	//		/// <summary>
	//		/// Invoke a message on the calling form.
	//		/// </summary>
	//		/// <param name="message">Message/text.</param>
	//		/// <param name="caption">Caption.</param>
	//		/// <param name="icon">MessageBoxIcon to show.</param>
	//		private void DisplayMessage(string message, string caption, MessageBoxIcon icon)
	//		{
	//			if (_ownerForm.InvokeRequired)
	//			{
	//				// We need to use a callback.
	//				_ownerForm.Invoke(_displayMessageDelegate, new object[] { message, caption, icon });
	//			}
	//			else
	//			{
	//				// Callback not required, just display the MessageBox.
	//				InvokeMessage(message, caption, icon);
	//			}
	//		}

	//		private void InvokeMessage(string message, string caption, MessageBoxIcon icon)
	//		{
	//			MessageBox.Show(_ownerForm, message, caption, MessageBoxButtons.OK, icon);
	//		}

	//		#endregion

	//		#region Configurations and ConfigurationList

	//		/// <summary>
	//		/// Edit a configuration.  Presents dialogs to user to select and edit a Configuration.
	//		/// </summary>
	//		/// <param name="configurationListPath">Path to deserialize the ConfigurationList From.</param>
	//		public DialogResult ConfigurationEdit()
	//		{
	//			string configurationListPath = Interface.Registry.ConfigurationListFile;

	//			// Ensure the file exists.  Error handling/checking.
	//			if (!System.IO.File.Exists(configurationListPath))
	//			{
	//				throw new Exception("The Translation Configuration List does not exist at the supplied location:\n\nFile: " + configurationListPath);
	//			}

	//			// Create an instance from the file.
	//			ConfigurationList configurationList	= ConfigurationList.Deserialize(configurationListPath);

	//			DialogResult result = ConfigurationEdit(configurationList);
	//			if (result == DialogResult.OK)
	//			{
	//				configurationList.Serialize();
	//			}

	//			return result;
	//		}

	//		/// <summary>
	//		/// Edit a configuration.  Presents dialogs to user to select and edit a Configuration.
	//		/// </summary>
	//		/// <param name="configurationList">ConfigurationList to add or edit from.</param>
	//		private DialogResult ConfigurationEdit(ConfigurationList configurationList)
	//		{
	//			// STEP 1.
	//			// Present the user with the option to edit an existing Configuration or create a new one.
	//			NewOrExistingConfigurationForm selectConfigurationDialog	= new NewOrExistingConfigurationForm(configurationList);
	//			DialogResult result											= selectConfigurationDialog.ShowDialog();

	//			// STEP 2.
	//			// Edit the Configuration selected or created.
	//			if (result == DialogResult.OK)
	//			{
	//				EditConfigurationForm editConfigurationDialog	= new EditConfigurationForm(selectConfigurationDialog.SelectedConfiguration, _registry.TranslationMatrixDirectory);
	//				result											= editConfigurationDialog.ShowDialog();

	//				// If ok was pressed, write the file back to the disk.
	//				if (result == DialogResult.OK)
	//				{
	//					if (selectConfigurationDialog.InstanceSelect == InstanceSelect.New)
	//					{
	//						configurationList.Configurations.Add(selectConfigurationDialog.SelectedConfiguration);
	//					}
	//				}
	//			}

	//			return result;
	//		}

	//		#endregion

	//		#region Field Names and Properties

	//		/// <summary>
	//		/// Edit the Field names and properties.
	//		/// </summary>
	//		public void EditFieldNames()
	//		{
	//			//string path = FileSelect.BrowseForAFile(owner, _fieldMetaDataFilterString);

	//			FieldMetaDataContainer fieldMetaDataContainer = FieldMetaDataContainer.Deserialize(Interface.Registry.FieldMetaDataFile);

	//			EditFieldMetaDataForm editFieldMetaDataForm = new EditFieldMetaDataForm(fieldMetaDataContainer);
	//			editFieldMetaDataForm.ShowDialog(_ownerForm);
	//		}

	//		#endregion

	//		#region TranslationMatrixs and TranslationMaps

	//		/// <summary>
	//		/// Create a new blank TranslationMatrix and edit it.
	//		/// </summary>
	//		/// <param name="initialDirectory">Directory to start the browsing from.</param>
	//		public void CreateNewTranslationMatrix(DPMForm parentForm, string initialDirectory = "")
	//		{
	//			if (initialDirectory == "")
	//			{
	//				initialDirectory = _registry.TranslationMatrixDirectory;
	//			}

	//			TranslationMatrix translationMatrix					= new TranslationMatrix();
	//			EditTranslationMatrixForm editTranslationMatrixForm	= new EditTranslationMatrixForm(parentForm, translationMatrix, initialDirectory);
	//			editTranslationMatrixForm.ShowDialog(_ownerForm);
	//		}

	//		/// <summary>
	//		/// Edit an existing TranslationMatrix.
	//		/// </summary>
	//		/// <param name="initialDirectory">Directory to start the browsing from.</param>
	//		public void EditExistingTranslationMatrix(DPMForm parentForm, string initialDirectory = "")
	//		{
	//			if (initialDirectory == "")
	//			{
	//				initialDirectory = _registry.TranslationMatrixDirectory;
	//			}

	//			string path = FileSelect.BrowseForAFile(_ownerForm, Translator.TranslationMatrixFileFilterString, "Select a Translation Matrix File", initialDirectory);

	//			if (path != "")
	//			{
	//				TranslationMatrix translationMatrix					= TranslationMatrix.Deserialize(path);
	//				EditTranslationMatrixForm editTranslationMatrixForm = new EditTranslationMatrixForm(parentForm, translationMatrix);
	//				editTranslationMatrixForm.ShowDialog(_ownerForm);
	//			}
	//		}

	//		/// <summary>
	//		/// Create a new TranslationMatrix by copying from an existing one and then edit it.
	//		/// </summary>
	//		/// <param name="owner">Owner form.</param>
	//		/// <param name="initialDirectory">Directory to start the browsing from.</param>
	//		public void CreateNewTranslationMatrixFromExisting(DPMForm parentForm, string initialDirectory = "")
	//		{
	//			if (initialDirectory == "")
	//			{
	//				initialDirectory = Interface.Registry.TranslationMatrixDirectory;
	//			}

	//			string path = FileSelect.BrowseForAFile(_ownerForm, Translator.TranslationMatrixFileFilterString, "Select a Translation Matrix File", initialDirectory);

	//			if (path != "")
	//			{
	//				// Deserialize the TranslationMatrix, then clear the path.  Clearing path will prevent the TranslationMatrix from automatically
	//				// overwriting the existing file and force a new file dialog to be shown.
	//				TranslationMatrix translationMatrix					= TranslationMatrix.Deserialize(path, false);
	//				EditTranslationMatrixForm editTranslationMatrixForm = new EditTranslationMatrixForm(parentForm, translationMatrix);
	//				editTranslationMatrixForm.ShowDialog(_ownerForm);
	//			}
	//		}

	//		#endregion

	//		#endregion

} // End class.