namespace DataConverter;

/// <summary>
/// Attribute for adding processor names to a class.
/// </summary>
[System.AttributeUsage(System.AttributeTargets.Class | System.AttributeTargets.Struct, AllowMultiple = false)]
public class ProcessorMetaData : Attribute
{
	#region Members

	private string				_name					= "";
	private DataLocation		_dataLocation			= DataLocation.Length;
	private string				_filterString			= "";
	private string				_description			= "";

	#endregion

	#region Construction

	/// <summary>
	/// Default constructor.
	/// </summary>
	public ProcessorMetaData()
	{
	}

	#endregion

	#region Properties

	/// <summary>
	/// Name of the processor
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
	/// Location of the data (disk/memory).
	/// </summary>
	public DataLocation DataLocation
	{
		get
		{
			return _dataLocation;
		}
		set
		{
			_dataLocation = value;
		}
	}

	/// <summary>
	/// Filter string.  Used to specified allowed input/output file types.
	/// </summary>
	public string FilterString
	{
		get
		{
			return _filterString;
		}

		set
		{
			_filterString = value;
		}
	}

	/// <summary>
	/// Description of the processor.
	/// </summary>
	public string Description
	{
	  get
	  {
		  return _description;
	  }

	  set
	  {
		  _description = value;
	  }
	}

	#endregion

	#region Methods

	#endregion

} // End class.