namespace DataConverter;

/// <summary>
/// Does the validation of the data in the input file.
/// </summary>
public class Validator
{
	#region Members

	// Instances that this Validator will interact with.
	private readonly List<ValidationCheck>				_validationChecks						= new();
	private Translator?									_translator;
	private ValidationReport?							_validationReport;

	// Members for storing entry data until the entire record can be validated.
	private TableTranslationMetaData?					_tableMetaData;
	private RecordTranslationMetaData?					_recordMetaData;
	private readonly List<EntryTranslationMetaData>		_entryMetaData							= new();
	private readonly List<string>						_entries								= new();

	#endregion

	#region Construction

	/// <summary>
	/// Default constructor.
	/// </summary>
	public Validator()
	{
	}

	#endregion

	#region Properties

	/// <summary>
	/// Statics and information about the data read from the input.
	/// </summary>
	public ValidationReport? ValidationReport
	{
		get
		{
			return _validationReport;
		}

		set
		{
			_validationReport = value;
		}
	}

	/// <summary>
	/// The Translator that validated data will be passed to.
	/// </summary>
	public Translator? Translator
	{
		get
		{
			return _translator;
		}

		set
		{
			_translator = value;
		}
	}

	#endregion

	#region Methods

	/// <summary>
	/// Add a validation check.
	/// </summary>
	/// <param name="validationChecks">List of ValidationChecks to add.</param>
	public void AddValidationChecks(List<ValidationCheck> validationChecks)
	{
		for (int i = 0; i < validationChecks.Count; i++)
		{
			_validationChecks.Add(validationChecks[i]);
		}
	}

	/// <summary>
	/// Add a validation check.
	/// </summary>
	/// <param name="validationCheck">A ValidationCheck.</param>
	public void AddValidationCheck(ValidationCheck validationCheck)
	{
		_validationChecks.Add(validationCheck);
	}

	/// <summary>
	/// Pass data read from the input to the Translator for processing.
	/// </summary>
	/// <param name="data">Value read from the input.</param>
	/// <param name="metaData">MetaData describing the field.</param>
	public void Entry(string data, EntryTranslationMetaData metaData)
	{
		if (_translator  == null)
		{
			throw new NullReferenceException("The translator is null.");
		}

		// Make sure we have the type Field type available for validation purposes.
		_translator.TranslateMetaData(metaData);

		_entryMetaData.Add(metaData);
		_entries.Add(data);
	}

	/// <summary>
	/// A new record (or line of data) was found.
	/// </summary>
	/// <param name="metaData">MetaData describing the record.</param>
	public void NewRecord(RecordTranslationMetaData metaData)
	{
		_recordMetaData		= metaData;

		_entries.Clear();
		_entryMetaData.Clear();
	}

	/// <summary>
	/// The end of a record (or line of data) was found.
	/// </summary>
	/// <param name="metaData">MetaData describing the record.</param>
	public virtual void EndRecord()
	{
		if (_translator  == null)
		{
			throw new NullReferenceException("The translator is null.");
		}
		if (_recordMetaData  == null)
		{
			throw new NullReferenceException("The record meta data is null.");
		}

		bool valid = Validate();

		if (valid)
		{
			_translator.NewRecord(_recordMetaData);

			for (int i = 0; i < _entries.Count; i++)
			{
				_translator.Entry(_entries[i], _entryMetaData[i]);
			}

			_translator.EndRecord();
		}
	}

	/// <summary>
	/// A new table (or block of data) was found.
	/// </summary>
	/// <param name="metaData">MetaData describing the table.</param>
	public void NewTable(TableTranslationMetaData metaData)
	{
		if (_translator  == null)
		{
			throw new NullReferenceException("The translator is null.");
		}
		_tableMetaData = metaData;
		_translator.NewTable(metaData);

		_validationReport = new ValidationReport();
	}

	/// <summary>
	/// The end of a table (or block of data) was found.
	/// </summary>
	public virtual void EndTable()
	{
		if (_translator  == null)
		{
			throw new NullReferenceException("The translator is null.");
		}
		if (_validationReport  == null)
		{
			throw new NullReferenceException("The validation report is null.");
		}

		_translator.EndTable();
		_validationReport.GenerateCorruptionReport(_validationChecks);
	}

	/// <summary>
	/// Validate all the entries of the record.
	/// </summary>
	/// <returns></returns>
	private bool Validate()
	{
		if (_recordMetaData  == null)
		{
			throw new NullReferenceException("The record meta data report is null.");
		}
		if (_tableMetaData  == null)
		{
			throw new NullReferenceException("The table meta data report is null.");
		}

		int validationCheckCount = _validationChecks.Count;

		for (int i = 0; i < validationCheckCount; i++)
		{
			if (!_validationChecks[i].Validate(_entries, _entryMetaData, _recordMetaData, _tableMetaData))
			{
				return false;
			}
		}

		return true;
	}

	#endregion

} // End class.