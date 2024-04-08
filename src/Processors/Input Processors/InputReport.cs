namespace DataConverter;

/// <summary>
/// Tallies and contains information and statistics about the input read.
/// </summary>
public class InputReport
{
	#region Members

	private int						_numberOfLines;
	private int						_numberOfRecords;

	#endregion

	#region Construction

	/// <summary>
	/// Default constructor.
	/// </summary>
	public InputReport()
	{
	}

	#endregion

	#region Properties

	/// <summary>
	/// Total number of lines in the input.  This includes all records (corrupted or valid) and any header or footer lines.
	/// </summary>
	public int NumberOfLines
	{
		get
		{
			return _numberOfLines;
		}
	}

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

	
	#endregion

	#region Methods

	/// <summary>
	/// Read a line at the beginning of the file, before the data.
	/// </summary>
	public void ReadPreliminaryLine()
	{
		_numberOfLines++;
	}

	/// <summary>
	/// Read a line at the end of the file, after the data.
	/// </summary>
	public void ReadSubsequentLine()
	{
		_numberOfLines++;
	}

	/// <summary>
	/// Read a record.
	/// </summary>
	public void ReadRecord()
	{
		_numberOfLines++;
		_numberOfRecords++;
	}

	#endregion

} // End class.