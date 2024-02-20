using System;
using System.Collections.Generic;

namespace DataConverter
{
	/// <summary>
	/// A validation check for too many fields in the record.
	/// </summary>
	public class DateHighPassValidationCheck : ValidationCheck
	{
		#region Members

		private DateTime				_cutOffDate;

		#endregion

		#region Construction

		/// <summary>
		/// Default constructor.
		/// </summary>
		public DateHighPassValidationCheck(DateTime cutOffDate) :
			base("Before Specified Date")
		{
			_cutOffDate = cutOffDate;
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
			for (int i = 0; i < entries.Count; i++)
			{
				if (entryMetaData[i].Field == Field.DateTime)
				{
					DateTime dateTime;
					if (Validation.TryParseDate(entries[i], out dateTime))
					{
						if (dateTime > _cutOffDate)
						{
							return true;
						}
						else
						{
							return false;
						}
					}
					else
					{
						return false;
					}
				}
			}

			// We didn't find a DateTime Field, so we return true;
			return true;
		}

		#endregion

	} // End class.
} // End namespace.