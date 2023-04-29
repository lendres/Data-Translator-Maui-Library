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
	/// A validation check the validates the format of the data.  Checks to make sure the data can be converted to the type of data it is
	/// supposed to be (for example a double or a date/time).
	/// </summary>
	public class DataFormatValidationCheck : ValidationCheck
	{
		#region Members

		#endregion

		#region Construction

		/// <summary>
		/// Default constructor.
		/// </summary>
		public DataFormatValidationCheck() :
			base("Data Format Invalid")
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
			for (int i = 0; i < entries.Count; i++)
			{
				switch (entryMetaData[i].DataType)
				{
					case DataType.DateTime:
					{
						DateTime dateTime;
						if (!Validation.TryParseDate(entries[i], out dateTime))
						{
							return false;
						}
						break;
					}

					case DataType.Double:
					{
						double output;
						if (!double.TryParse(entries[i], out output))
						{
							return false;
						}
						break;
					}
				}
			}

			// We didn't find bad data so return true.
			return true;
		}

		#endregion

	} // End class.
} // End namespace.