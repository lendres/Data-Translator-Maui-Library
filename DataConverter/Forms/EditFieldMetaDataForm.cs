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
using DigitalProduction.Reflection;

namespace DataConverter
{
	/// <summary>
	/// 
	/// </summary>
	public partial class EditFieldMetaDataForm : Form
	{
		#region Members

		private FieldMetaDataContainer					_fieldMetaDataContainer;
		private List<FieldMetaData>						_fieldMetaData						= new List<FieldMetaData>();

		#endregion

		#region Construction

		/// <summary>
		/// Constructor.
		/// </summary>
		public EditFieldMetaDataForm(FieldMetaDataContainer fieldMetaDataContainer)
		{
			_fieldMetaDataContainer = fieldMetaDataContainer;
			Initialize();
		}

		private void Initialize()
		{
			InitializeComponent();
			_fieldMetaData										= _fieldMetaDataContainer.CloneFieldMetaData();
			BindingList<FieldMetaData> bindingList				= new BindingList<FieldMetaData>(_fieldMetaData);
			this.bindingSourceTranslationMap.DataSource			= bindingList;
		}

		#endregion

		#region Form Event Handlers

		#endregion

		#region Event Handlers

		/// <summary>
		/// Save click handler.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">Event arguments.</param>
		private void buttonSave_Click(object sender, EventArgs e)
		{
			SaveOrSaveAs();
		}

		/// <summary>
		/// Save As click handler.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">Event arguments.</param>
		// If we never end up doing additional validation, we do not need this function.  Redirect the "Save & Close" button to use the
		// same event handler as the "Save" button.
		private void buttonSaveAndClose_Click(object sender, EventArgs e)
		{
			SaveOrSaveAs();
		}

		/// <summary>
		/// Check to see if we need to do a Save or Save As.
		/// </summary>
		private void SaveOrSaveAs()
		{
			if (_fieldMetaDataContainer.IsSaveable)
			{
				Save();
			}
			else
			{
				SaveAs();
			}
		}

		/// <summary>
		/// Perform a save of the TranslationMatrix.
		/// </summary>
		private void Save()
		{
			_fieldMetaDataContainer.SetFieldMetaData(_fieldMetaData);
			_fieldMetaDataContainer.Serialize();
		}

		/// <summary>
		/// Does the actual work of the Save As.
		/// </summary>
		private void SaveAs()
		{
			string path = FileSelect.BrowseForANewFileLocation(this, Translator.TranslationMatrixFileFilterString);

			if (path != "")
			{
				_fieldMetaDataContainer.SetFieldMetaData(_fieldMetaData);
				_fieldMetaDataContainer.Serialize(path);
			}
		}

		#endregion

	} // End class.
} // End namespace.