namespace DataConverter;

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