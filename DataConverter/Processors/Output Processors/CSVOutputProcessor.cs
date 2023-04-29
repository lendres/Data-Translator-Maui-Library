using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Xml.Serialization;
using System.IO;

namespace DataConverter
{
	/// <summary>
	/// Excel output processors.
	/// </summary>
	[ProcessorMetaData(Name = "CSV Output Processor",
					   DataLocation = DataLocation.Disk,
					   FilterString = "Comma Separated Values files (*.csv)|*.csv|Text files (*.txt)|*.txt|All files (*.*)|*.*",
					   Description = ""
					  )
	]
	public class CSVOutputProcessor : FlatFileOutputProcessor
	{
		#region Construction

		/// <summary>
		/// Default constructor.
		/// </summary>
		public CSVOutputProcessor() : base(",")
		{
		}

		#endregion

	} // End class.
} // End namespace.