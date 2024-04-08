namespace DataConverter;

/// <summary>
/// Flat file output processors.  Base class for writing flat files (files with data separated by a delimiter, but otherwise unformated).
/// </summary>
[ProcessorMetaData(Name = "Flat File Output Processor",
				   DataLocation = DataLocation.Disk,
				   FilterString = "Text files (*.txt)|*.txt|All files (*.*)|*.*",
				   Description = ""
				  )
]
public class FlatFileOutputProcessor : OutputProcessor
{
	#region Members

	/// <summary> Input stream for reading file. </summary>
	protected StreamWriter?											_outputStream;

	private readonly string											_delimiter;

	#endregion

	#region Construction

	/// <summary>
	/// Default constructor.
	/// </summary>
	public FlatFileOutputProcessor()
	{
		_delimiter = "\t";
	}

	/// <summary>
	/// Default constructor.
	/// </summary>
	public FlatFileOutputProcessor(string delimiter)
	{
		_delimiter = delimiter;
	}

	#endregion

	#region Properties

	#endregion

	#region Methods

	/// <summary>
	/// Open the output file.
	/// </summary>
	/// <param name="location">Path to the location to write the file to.</param>
	public override void Open(string location)
	{
		base.Open(location);
		_outputStream = File.CreateText(location);
	}

	/// <summary>
	/// Pass a data read from the input to the Translator for processing.
	/// </summary>
	/// <param name="data">Value read from the input.</param>
	/// <param name="metaData">MetaData describing the field.</param>
	public override void Entry(double data, EntryTranslationMetaData metaData)
	{
		if (_outputStream == null)
		{
			throw new NullReferenceException("The output stream has not been initialized.");
		}
		_outputStream.Write(data.ToString() + _delimiter);
	}

	/// <summary>
	/// Pass a data read from the input to the Translator for processing.
	/// </summary>
	/// <param name="data">Value read from the input.</param>
	/// <param name="metaData">MetaData describing the field.</param>
	public override void Entry(DateTime data, EntryTranslationMetaData metaData)
	{
		if (_outputStream == null)
		{
			throw new NullReferenceException("The output stream has not been initialized.");
		}
		_outputStream.Write(data.ToString() + _delimiter);
	}

	/// <summary>
	/// Pass a data read from the input to the Translator for processing.
	/// </summary>
	/// <param name="data">Value read from the input.</param>
	/// <param name="metaData">MetaData describing the field.</param>
	public override void Entry(string data, EntryTranslationMetaData metaData)
	{
		if (_outputStream == null)
		{
			throw new NullReferenceException("The output stream has not been initialized.");
		}
		_outputStream.Write(data + _delimiter);
	}

	/// <summary>
	/// A new record (or line of data) was found.
	/// </summary>
	/// <param name="metaData">MetaData describing the record.</param>
	public override void NewRecord(RecordTranslationMetaData metaData)
	{
		if (_outputStream == null)
		{
			throw new NullReferenceException("The output stream has not been initialized.");
		}

		base.NewRecord(metaData);

		_outputStream.Write(_outputStream.NewLine);
	}

	/// <summary>
	/// A new table (or block of data) was found.
	/// </summary>
	/// <param name="metaData">MetaData describing the table.</param>
	public override void NewTable(TableTranslationMetaData metaData)
	{
		if (_outputStream == null)
		{
			throw new NullReferenceException("The output stream has not been initialized.");
		}

		base.NewTable(metaData);

		List<string> headers = metaData.ColumnHeaders;

		for (int i = 0; i < headers.Count; i++)
		{
			_outputStream.Write(headers[i] + _delimiter);
		}
	}

	/// <summary>
	/// Close the output file.
	/// </summary>
	public override void Close()
	{
		if (_outputStream == null)
		{
			throw new NullReferenceException("The output stream has not been initialized.");
		}
		_outputStream.Close();
	}

	#endregion

} // End class.