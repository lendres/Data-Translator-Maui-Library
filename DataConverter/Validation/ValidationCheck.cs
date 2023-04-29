using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Xml.Serialization;

namespace DataConverter
{
	/// <summary>
	/// Base class for the ValidationChecks.
	/// </summary>
	public abstract class ValidationCheck
	{
		#region Members

		private string					_name;
		private int						_numberOfValidationFailures;

		#endregion

		#region Construction

		/// <summary>
		/// Default constructor.
		/// </summary>
		private ValidationCheck()
		{
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		public ValidationCheck(string name)
		{
			_name = name;
		}

		#endregion

		#region Properties

		/// <summary>
		/// Name of validation check.
		/// </summary>
		public string Name
		{
			get
			{
				return _name;
			}

			set
			{
				_name = value;
			}
		}

		/// <summary>
		/// Number of times the validation has failed.
		/// </summary>
		public int NumberOfValidationFailures
		{
			get
			{
				return _numberOfValidationFailures;
			}
		}

		#endregion

		#region Methods

		/// <summary>
		/// Checks the entries to see if they meet the criteria specified by this ValidationCheck for them to be considered valid.
		/// 
		/// If a single entry is invalid, the entire record is considered invalid.
		/// </summary>
		/// <param name="entries">Entries from a single Record of data.</param>
		/// <param name="entryMetaData">Meta data for all the entries in the record.</param>
		/// <param name="recordMetaData">Meta data for the record.</param>
		/// <param name="tableMetaData">Meta data for the table.</param>
		public bool Validate(List<string> entries, List<EntryTranslationMetaData> entryMetaData, RecordTranslationMetaData recordMetaData, TableTranslationMetaData tableMetaData)
		{
			bool validated = ValidityCheck(entries, entryMetaData, recordMetaData, tableMetaData);

			if (!validated)
			{
				_numberOfValidationFailures++;
			}

			return validated;
		}

		/// <summary>
		/// Checks the entries to see if they meet the criteria specified by this ValidationCheck for them to be considered valid.
		/// 
		/// If a single entry is invalid, the entire record is considered invalid.
		/// </summary>
		/// <param name="entries">Entries from a single Record of data.</param>
		/// <param name="entryMetaData">Meta data for all the entries in the record.</param>
		/// <param name="recordMetaData">Meta data for the record.</param>
		/// <param name="tableMetaData">Meta data for the table.</param>
		protected abstract bool ValidityCheck(List<string> entries, List<EntryTranslationMetaData> entryMetaData, RecordTranslationMetaData recordMetaData, TableTranslationMetaData tableMetaData);

		#endregion

	} // End class.
} // End namespace.