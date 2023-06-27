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
	/// 
	/// </summary>
	public class ValidationReport
	{
		#region Enumerations

		#endregion

		#region Delegates

		#endregion

		#region Data Structures

		private struct ErrorCount
		{
			public string	Name;
			public int		Count;
		}

		#endregion

		#region Members

		private int						_numberOfRecords;
		private List<ErrorCount>		_errorCounts;

		private string					_corruptionReport					= "";

		#endregion

		#region Construction

		/// <summary>
		/// Default constructor.
		/// </summary>
		public ValidationReport()
		{
		}

		#endregion

		#region Properties

		/// <summary>
		/// Total number of records found in the input (corrupted and valid records).
		/// </summary>
		public int NumberOfRecords
		{
			get
			{
				return _numberOfRecords;
			}
		}

		/// <summary>
		/// Number of records that were valid.
		/// </summary>
		public int NumberOfValidRecords
		{
			get
			{
				return _numberOfRecords - this.NumberOfCorruptedRecords;
			}
		}

		/// <summary>
		/// Number of corrupted records.  These are records that could not be parsed correctly for any reason, missing fields, too many fields, invalid values.
		/// </summary>
		public int NumberOfCorruptedRecords
		{
			get
			{
				int count = 0;

				for (int i = 0; i < _errorCounts.Count; i++)
				{
					count += _errorCounts[i].Count;
				}

				return count;
			}
		}

		/// <summary>
		/// Corruption report.
		/// </summary>
		public string CorruptionReport
		{
			get
			{
				return _corruptionReport;
			}
		}

		#endregion

		#region Methods

		/// <summary>
		/// Read a record.
		/// </summary>
		/// <param name="validRecordResult">Type of record found.</param>
		public void ReadRecord()
		{
			_numberOfRecords++;
		}

		public void GenerateCorruptionReport(List<ValidationCheck> validationChecks)
		{
			_errorCounts = new List<ErrorCount>();

			for (int i = 0; i < validationChecks.Count; i++)
			{
				_errorCounts.Add(new ErrorCount()
				{
					Name = validationChecks[i].Name,
					Count = validationChecks[i].NumberOfValidationFailures
				});
				_corruptionReport += String.Format("{0,-30}\t{1,6}\r\n", validationChecks[i].Name, validationChecks[i].NumberOfValidationFailures);
			}
		}

		#endregion

	} // End class.
} // End namespace.