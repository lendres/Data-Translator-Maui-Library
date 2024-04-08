namespace DataConverter;

/// <summary>
/// Base class for output processors.
/// </summary>
public abstract class OutputProcessor : Processor
{
	#region Members

	private RecordTranslationMetaData?				_currentRecordMetaData;
	private TableTranslationMetaData?				_currentTableMetaData;

	#endregion

	#region Construction

	/// <summary>
	/// Default constructor.
	/// </summary>
	public OutputProcessor()
	{
	}

	#endregion

	#region Properties

	/// <summary>
	/// Meta data for the current record being written.
	/// </summary>
	public RecordTranslationMetaData? CurrentRecordMetaData
	{
		get
		{
			return _currentRecordMetaData;
		}

		set
		{
			_currentRecordMetaData = value;
		}
	}

	/// <summary>
	/// Meta data for the current table being written.
	/// </summary>
	public TableTranslationMetaData? CurrentTableMetaData
	{
		get
		{
			return _currentTableMetaData;
		}

		set
		{
			_currentTableMetaData = value;
		}
	}

	#endregion

	#region Methods

	/// <summary>
	/// Pass a data read from the input to the Translator for processing.
	/// </summary>
	/// <param name="data">Value read from the input.</param>
	/// <param name="metaData">MetaData describing the field.</param>
	public abstract void Entry(double data, EntryTranslationMetaData metaData);

	/// <summary>
	/// Pass a data read from the input to the Translator for processing.
	/// </summary>
	/// <param name="data">Value read from the input.</param>
	/// <param name="metaData">MetaData describing the field.</param>
	public abstract void Entry(DateTime data, EntryTranslationMetaData metaData);

	/// <summary>
	/// Pass a data read from the input to the Translator for processing.
	/// </summary>
	/// <param name="data">Value read from the input.</param>
	/// <param name="metaData">MetaData describing the field.</param>
	public abstract void Entry(string data, EntryTranslationMetaData metaData);

	/// <summary>
	/// A new record (or line of data) was found.
	/// </summary>
	/// <param name="metaData">MetaData describing the record.</param>
	public virtual void NewRecord(RecordTranslationMetaData metaData)
	{
		_currentRecordMetaData = metaData;
	}

	/// <summary>
	/// The end of a record (or line of data) was found.
	/// </summary>
	public virtual void EndRecord()
	{
	}

	/// <summary>
	/// A new table (or block of data) was found.
	/// </summary>
	/// <param name="metaData">MetaData describing the table.</param>
	public virtual void NewTable(TableTranslationMetaData metaData)
	{
		_currentTableMetaData = metaData;
	}

	/// <summary>
	/// The end of a table (or block of data) was found.
	/// </summary>
	public virtual void EndTable()
	{
	}

	#endregion

} // End class.