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
	public partial class EditTranslationMatrixForm : DPMForm
	{
		#region Members

		private TranslationMatrix					_translationMatrix;
		private List<TranslationMap>				_translationMaps			= new List<TranslationMap>();
		private string								_defaultDirectory;

		#endregion

		#region Construction

		/// <summary>
		/// Constructor.
		/// </summary>
		public EditTranslationMatrixForm(DPMForm parentForm, TranslationMatrix translationMatrix, string defaultDirectory = "") : 
			base(parentForm, "Edit Translation Matrix Form")
		{
			_translationMatrix	= translationMatrix;
			_defaultDirectory	= defaultDirectory;
			Initialize();
		}

		/// <summary>
		/// Initialize form.
		/// </summary>
		private void Initialize()
		{
			InitializeComponent();
			_translationMatrix.CloneTranslationMaps(_translationMaps);
			BindingList<TranslationMap> bindingList				= new BindingList<TranslationMap>(_translationMaps);
			this.bindingSourceTranslationMap.DataSource			= bindingList;
			this.dataGridViewColumnOutputName.Items.AddRange(Enumerations.GetAllDescriptionAttributesForType<Field>().ToArray());
			this.dataGridViewColumnDataType.Items.AddRange(Enumerations.GetAllDescriptionAttributesForType<DataType>().ToArray());
			this.dataGridViewColumnCatagoryOfUnits.Items.AddRange(UnitsConverter.GetListOfUnitCatagories());
		}

		#endregion

		#region Form Event Handlers

		/// <summary>
		/// Shown event handler.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">Event argument.</param>
		private void EditTranslationMatrixForm_Shown(object sender, EventArgs e)
		{
			PopulateFromAndToUnits();
		}

		/// <summary>
		/// Initial population of From and To Units comboboxes based on the unit's category read from the file.
		/// </summary>
		private void PopulateFromAndToUnits()
		{
			foreach (DataGridViewRow dataGridViewRow in this.dataGridViewTranslationMatrix.Rows)
			{
				object value = dataGridViewRow.Cells[this.dataGridViewColumnCatagoryOfUnits.Index].Value;
				if (value != null)
				{
					string selectedValue = value.ToString();

					// If a unit category has not been selected, we cannot populate the control.
					if (selectedValue != "")
					{
						string[] names							= UnitsConverter.GetListOfUnitsInGroup(selectedValue);

						DataGridViewComboBoxCell comboBoxCell	= (DataGridViewComboBoxCell)dataGridViewRow.Cells[this.dataGridViewColumnFromUnits.Index];
						comboBoxCell.Items.Clear();
						comboBoxCell.Items.AddRange(names);

						comboBoxCell							= (DataGridViewComboBoxCell)dataGridViewRow.Cells[this.dataGridViewColumnToUnits.Index];
						comboBoxCell.Items.Clear();
						comboBoxCell.Items.AddRange(names);
					}
				}
			}
		}

		#endregion

		#region Event Handlers

		/// <summary>
		/// Import the names from an external source.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">Event arguments.</param>
		private void buttonImportNames_Click(object sender, EventArgs e)
		{
			// Get the input file name and InputProcessor to use.
			ExtractInputNamesForm extractInputNamesForm = new ExtractInputNamesForm();
			DialogResult result = extractInputNamesForm.ShowDialog(this);

			if (result == DialogResult.OK)
			{
				// The form will process the file if OK is pressed and have a list of names ready for us.
				List<string> inputNames = extractInputNamesForm.InputNames;

				// We have to generate TranslationMaps from the list of name.
				foreach (string inputName in inputNames)
				{
					// Make sure the item/name doesn't already exist.  We are merging the names and we cannot have duplicates.
					TranslationMap translationMap = _translationMaps.Find(item => item.InputName == inputName);
					if (translationMap == null)
					{
						// The name wasn't found in the existing list, so create a new TranslationMap and add it.
						this.bindingSourceTranslationMap.Add(new TranslationMap(inputName));
					}
				}
			}
		}

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
			if (_translationMatrix.IsSaveable)
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
			_translationMatrix.SetTranslationMaps(_translationMaps);
			_translationMatrix.Serialize();
		}

		/// <summary>
		/// Does the actual work of the Save As.
		/// </summary>
		private void SaveAs()
		{
			string path = FileSelect.BrowseForANewFileLocation(this, Translator.TranslationMatrixFileFilterString, "Save As", _defaultDirectory);

			if (path != "")
			{
				_translationMatrix.SetTranslationMaps(_translationMaps);
				_translationMatrix.Serialize(path);
			}
		}

		/// <summary>
		/// DataGridView cell value changed.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">Event arguments.</param>
		private void dataGridViewTranslationMatrix_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex > -1)
			{
				// Check if it is the Units Category column.
				if (e.ColumnIndex == this.dataGridViewColumnCatagoryOfUnits.Index)
				{
					string selectedValue = this.dataGridViewTranslationMatrix.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

					// If a unit category has not been selected, we cannot populate the control.
					if (selectedValue != "")
					{
						string[] names = UnitsConverter.GetListOfUnitsInGroup(selectedValue);

						ResetComboBoxItems(e.RowIndex, this.dataGridViewColumnFromUnits.Index, names);
						ResetComboBoxItems(e.RowIndex, this.dataGridViewColumnToUnits.Index, names);
					}
				}
			}
		}

		/// <summary>
		/// Update a Combobox's items to the supplied array of strings.
		/// </summary>
		/// <param name="rowIndex">Row the combobox is in.</param>
		/// <param name="columnIndex">Column the combobox is in.</param>
		/// <param name="names">Items to add to the combobox.</param>
		private void ResetComboBoxItems(int rowIndex, int columnIndex, string[] names)
		{
			// Get the combobox.
			DataGridViewComboBoxCell comboBoxCell = (DataGridViewComboBoxCell)this.dataGridViewTranslationMatrix.Rows[rowIndex].Cells[columnIndex];

			// Clear the existing values and add the new ones.
			comboBoxCell.Items.Clear();
			comboBoxCell.Items.AddRange(names);

			// Have to reset the value so the combobox doesn't try to grab it (and it doesn't exist).
			comboBoxCell.Value = "";
		}

		/// <summary>
		/// DataGridView cell dirty state changed.  Need this to force other cells to update if they rely on another cell changing value.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">Event arguments.</param>
		private void dataGridViewTranslationMatrix_CurrentCellDirtyStateChanged(object sender, EventArgs e)
		{
			if (this.dataGridViewTranslationMatrix.IsCurrentCellDirty)
			{
				this.dataGridViewTranslationMatrix.CommitEdit(DataGridViewDataErrorContexts.Commit);
			}
		}

		/// <summary>
		/// Open comboboxes when the cell is clicked.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">Event arguments.</param>
		private void dataGridViewTranslationMatrix_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			// Make sure the clicked row isn't the header.
			if (e.RowIndex < 0)
			{
				return;
			}

			DataGridView dataGridView = sender as DataGridView;

			// Check to make sure the cell clicked is the cell containing the combobox.
			if (dataGridView.Columns[e.ColumnIndex] is DataGridViewComboBoxColumn)
			{
				dataGridView.BeginEdit(true);
				((ComboBox)dataGridView.EditingControl).DroppedDown = true;
			}
		}

		/// <summary>
		/// Data error handler.  Mainly left here to debug future errors.
		/// </summary>
		/// <remarks>
		/// An error will occur if the Units.xml file has errors in it (typos, et cetera) or does not match the Translation Matrix File.
		/// </remarks>
		/// <param name="sender">Sender.</param>
		/// <param name="e">Event arguments.</param>
		private void dataGridViewTranslationMatrix_DataError(object sender, DataGridViewDataErrorEventArgs e)
		{
			//DataGridViewComboBoxCell comboBoxCell = (DataGridViewComboBoxCell)this.dataGridViewTranslationMatrix.Rows[e.RowIndex].Cells[e.ColumnIndex];
			throw new Exception("Translation Matrix Configuration Error", e.Exception);
		}

		#endregion

	} // End class.
} // End namespace.