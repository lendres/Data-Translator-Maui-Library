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
	public partial class ValidationSelectionForm : Form
	{
		#region Members

		private List<ValidationCheck>				_validationChecks;
		private DataTranslatorWinRegistry			_registry;

		#endregion

		#region Construction

		/// <summary>
		/// Default constructor.
		/// </summary>
		public ValidationSelectionForm(DataTranslatorWinRegistry registry)
		{
			InitializeComponent();

			_registry											= registry;

			this.checkBoxNumberOfColumnValidation.Checked		= _registry.NumberOfColumnsMustMatchValidation;
			this.checkBoxDateFormatValidation.Checked			= _registry.DateTimeFormattedCorrectlyValidation;
			this.checkBoxHighPassDateValidation.Checked			= _registry.HighPassDateValidation;
			this.dateTimePickerHighPassDateValidation.Value		= _registry.HighPassDateCutOff;
			this.dateTimePickerHighPassTimeValidation.Value		= _registry.HighPassDateCutOff;
			this.checkBoxLowPassDateValidation.Checked			= _registry.LowPassDateValidation;
			this.dateTimePickerLowPassDateValidation.Value		= _registry.LowPassDateCutOff;
			this.dateTimePickerLowPassTimeValidation.Value		= _registry.LowPassDateCutOff;

			SetHighPassDateTimeEnabled();
			SetLowPassDateTimeEnabled();
		}

		#endregion

		#region Properties

		/// <summary>
		/// Get the selected ValidationChecks.
		/// </summary>
		public List<ValidationCheck> ValidationChecks
		{
			get
			{
				return _validationChecks;
			}
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
			// Ensure the data is valid.
			if (!ValidateChildren())
			{
				// Have to set the DialogResult to none to prevent the form from closing.
				this.DialogResult = DialogResult.None;
				return;
			}

			// Create the ValidationChecks (instances of them) using the settings/values specified on the form.
			CreateValidationCheckList();

			// Store values in the registry.
			StoreSettings();

			// This will close the dialog as well.
			this.DialogResult = DialogResult.OK;
		}

		/// <summary>
		/// Create a list of ValidationChecks based on the settings the user set on the form.
		/// </summary>
		private void CreateValidationCheckList()
		{
			_validationChecks = new List<ValidationCheck>();

			// Number of columns in record should match number of column headers.
			if (this.checkBoxNumberOfColumnValidation.Checked)
			{
				_validationChecks.Add(new NotEnoughFieldsValidationCheck());
				_validationChecks.Add(new TooManyFieldsValidationCheck());
			}

			if (this.checkBoxDateFormatValidation.Checked)
			{
				_validationChecks.Add(new DataFormatValidationCheck());
			}

			// Exclude records with a date and time that is before a specified date and time.
			if (this.checkBoxHighPassDateValidation.Checked)
			{
				_validationChecks.Add(new DateHighPassValidationCheck(this.dateTimePickerHighPassDateValidation.Value));
			}

			// Exclude records with a date and time that is after a specified date and time.
			if (this.checkBoxLowPassDateValidation.Checked)
			{
				_validationChecks.Add(new DateLowPassValidationCheck(this.dateTimePickerLowPassDateValidation.Value));
			}
		}

		/// <summary>
		/// Push the settings back to the registry.
		/// </summary>
		private void StoreSettings()
		{
			_registry.NumberOfColumnsMustMatchValidation		= this.checkBoxNumberOfColumnValidation.Checked;
			_registry.DateTimeFormattedCorrectlyValidation		= this.checkBoxDateFormatValidation.Checked;
			_registry.HighPassDateValidation					= this.checkBoxHighPassDateValidation.Checked;
			_registry.HighPassDateCutOff						= this.dateTimePickerHighPassDateValidation.Value.Date + this.dateTimePickerHighPassTimeValidation.Value.TimeOfDay;
			_registry.LowPassDateValidation						= this.checkBoxLowPassDateValidation.Checked;
			_registry.LowPassDateCutOff							= this.dateTimePickerLowPassDateValidation.Value.Date + this.dateTimePickerLowPassTimeValidation.Value.TimeOfDay;
		}

		/// <summary>
		/// High pass date validation check box changed event handler.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">Event arguments.</param>
		private void checkBoxHighPassDateValidation_CheckedChanged(object sender, EventArgs e)
		{
			SetHighPassDateTimeEnabled();
		}

		/// <summary>
		/// Enable/disable the controls based on the checked state of the high pass check box.
		/// </summary>
		private void SetHighPassDateTimeEnabled()
		{
			this.dateTimePickerHighPassDateValidation.Enabled	= this.checkBoxHighPassDateValidation.Checked;
			this.dateTimePickerHighPassTimeValidation.Enabled	= this.checkBoxHighPassDateValidation.Checked;
		}

		/// <summary>
		/// Low pass date validation check box changed event handler.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">Event arguments.</param>
		private void checkBoxLowPassDateValidation_CheckedChanged(object sender, EventArgs e)
		{
			SetLowPassDateTimeEnabled();
		}

		/// <summary>
		/// Enable/disable the controls based on the checked state of the low pass check box.
		/// </summary>
		private void SetLowPassDateTimeEnabled()
		{
			this.dateTimePickerLowPassDateValidation.Enabled	= this.checkBoxLowPassDateValidation.Checked;
			this.dateTimePickerLowPassTimeValidation.Enabled	= this.checkBoxLowPassDateValidation.Checked;
		}

		#endregion

	} // End class.
} // End namespace.