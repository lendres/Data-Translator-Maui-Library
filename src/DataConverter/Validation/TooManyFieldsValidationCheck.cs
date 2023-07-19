using System.Collections.Generic;

namespace DataConverter
{
	/// <summary>
	/// A validation check for too many fields in the record.
	/// </summary>
	public class TooManyFieldsValidationCheck : ValidationCheck
	{
		#region Members

		#endregion

		#region Construction

		/// <summary>
		/// Default constructor.
		/// </summary>
		public TooManyFieldsValidationCheck() :
			base("Too Many Fields")
		{
		}

		#endregion

		#region Properties

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
		protected override bool ValidityCheck(List<string> entries, List<EntryTranslationMetaData> entryMetaData, RecordTranslationMetaData recordMetaData, TableTranslationMetaData tableMetaData)
		{
			// Determine if the number of fields is the expected number.  If not, the line is considered invalid.
			if (entries.Count > tableMetaData.NumberOfColumns)
			{
				return false;
			}
			else
			{
				return true;
			}
		}

		#endregion

	} // End class.
} // End namespace.