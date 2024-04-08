namespace DataConverter;

/// <summary>
/// Meta data used for translations.
/// </summary>
public class EntryTranslationMetaData : TranslationMetaData
{
	#region Members

	private string					_inputName			= "";
	private string					_outputName			= "";
	private Field					_field				= Field.Unknown;
	private DataType				_dataType			= DataType.String;

	#endregion

	#region Construction

	/// <summary>
	/// Default constructor.
	/// </summary>
	private EntryTranslationMetaData()
	{
	}

	/// <summary>
	/// Constructor.
	/// </summary>
	public EntryTranslationMetaData(string inputName, int number) :
		base(number)
	{
		_inputName	= inputName;
	}

	#endregion

	#region Properties

	/// <summary>
	/// Name of the data used in the input or source data file/location.
	/// </summary>
	public string InputName
	{
		get
		{
			return _inputName;
		}

		set
		{
			_inputName = value;
		}
	}

	/// <summary>
	/// Name of the data used in the output or destination data file/location.
	/// </summary>
	public string OutputName
	{
		get
		{
			return _outputName;
		}
		set
		{
			_outputName = value;
		}
	}

	/// <summary>
	/// Field for the entry.
	/// </summary>
	public Field Field
	{
		get
		{
			return _field;
		}

		set
		{
			_field = value;
		}
	}

	/// <summary>
	/// Data type the entry should be converted to.
	/// </summary>
	public DataType DataType
	{
		get
		{
			return _dataType;
		}

		set
		{
			_dataType = value;
		}
	}

	#endregion

	#region Methods

	#endregion

} // End class.