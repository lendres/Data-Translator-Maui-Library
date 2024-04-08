using System;

namespace DataConverter;

/// <summary>
/// Controller to convert from one data format to another.
/// </summary>
public partial class Translator
{
	#region Members

	private TranslationMatrix?				_translationMatrix;

	private bool							_processingRecord;
	private bool							_processingTable;

	private OutputProcessor?				_outputProcessor;

	#endregion

	#region Construction

	/// <summary>
	/// Default constructor.
	/// </summary>
	private Translator()
	{
	}

	/// <summary>
	/// Default constructor.
	/// </summary>
	public Translator(string translationMatrixFile)
	{
		_translationMatrix  = TranslationMatrix.Deserialize(translationMatrixFile);
	}

	#endregion

	#region Properties

	/// <summary>
	/// OutputProcessor.
	/// </summary>
	public OutputProcessor? OutputProcessor
	{
		get
		{
			return _outputProcessor;
		}

		set
		{
			_outputProcessor = value;
		}
	}

	#endregion

	#region Static Properties

	/// <summary>
	/// Specifies the file extension for a Translation Matrix File.
	/// </summary>
	public static string TranslationMatrixFileExtension
	{
		get
		{
			return "transmtx";
		}
	}

	/// <summary>
	/// Provides the filter string (used for dialog boxes) for a Translation Matrix File.
	/// </summary>
	public static string TranslationMatrixFileFilterString
	{
		get
		{
			return "Translation Map Files (*.transmtx)|*.transmtx|XML files (*.xml)|*.xml|Text files (*.txt)|*.txt|All files (*.*)|*.*";
		}
	}

	#endregion

	#region Methods

	/// <summary>
	/// Translates the meta data for an entry (does not convert the value).
	/// </summary>
	/// <param name="metaData">Meta data to translate.</param>
	public void TranslateMetaData(EntryTranslationMetaData metaData)
	{
		TranslationMap translationMap	= _translationMatrix[metaData.InputName];

		// We use the ResovledName instead of the OutputName for the meta data.  The difference is that the OutputName is the mapped
		// name if it is set, otherwise it is "Unknown."  The "ResovledName" reverts to the input name in the case where the OutputName
		// is Unknown.
		//metaData.OutputName				= translationMap.OutputName;
		metaData.OutputName				= translationMap.ResolvedName;
		metaData.Field					= translationMap.OutputField;
		metaData.DataType				= translationMap.DataType;
	}

	/// <summary>
	/// Pass a data read from the input to the Translator for processing.
	/// </summary>
	/// <param name="data">Value read from the input.</param>
	/// <param name="metaData">MetaData describing the field.</param>
	public void Entry(string data, EntryTranslationMetaData metaData)
	{
		TranslationMap translationMap = _translationMatrix[metaData.InputName];

		switch (translationMap.DataType)
		{
			case DataType.Double:
			{
				double convertedData	= System.Convert.ToDouble(data);
				convertedData			= translationMap.UnitsConverter.Convert(convertedData);
				_outputProcessor?.Entry(convertedData, metaData);
				break;
			}

			case DataType.DateTime:
			{
				DateTime convertedData;
				Validation.TryParseDate(data, out convertedData);
				_outputProcessor?.Entry(convertedData, metaData);
				break;
			}

			case DataType.String:
			{
				_outputProcessor?.Entry(data, metaData);
				break;
			}
		}
	}

	/// <summary>
	/// A new record (or line of data) was found.
	/// </summary>
	/// <param name="metaData">MetaData describing the record.</param>
	public void NewRecord(RecordTranslationMetaData metaData)
	{
		System.Diagnostics.Debug.Assert(!_processingRecord, "The previous Record must be closed before a new one can be opened.", "\"EndRecord\" must be called be another call to \"NewRecord\".");
		_processingRecord = true;
		_outputProcessor?.NewRecord(metaData);
	}

	/// <summary>
	/// The end of a record (or line of data) was found.
	/// </summary>
	/// <param name="metaData">MetaData describing the record.</param>
	public virtual void EndRecord()
	{
		_processingRecord = false;
		_outputProcessor?.EndRecord();
	}

	/// <summary>
	/// A new table (or block of data) was found.
	/// </summary>
	/// <param name="metaData">MetaData describing the table.</param>
	public void NewTable(TableTranslationMetaData metaData)
	{
		// Ensure the previous table was properly closed.  No cheating by the InputProcessors.
		System.Diagnostics.Debug.Assert(!_processingTable, "The previous Table must be closed before a new one can be opened.", "\"EndTable\" must be called be another call to \"NewTable\".");
		_processingTable = true;

		// Number of headers.
		int headerCount = metaData.ColumnHeaders.Count;

		// Convert the header names from the input names to the output names, if there is a TranslationMap available
		// for the header name.
		for (int i = 0; i < headerCount; i++)
		{
			TranslationMap translationMap = _translationMatrix[metaData.ColumnHeaders[i]];

			// We use the ResovledName instead of the OutputName for the meta data.  The difference is that the OutputName is the mapped
			// name if it is set, otherwise it is "Unknown."  The "ResovledName" reverts to the input name in the case where the OutputName
			// is Unknown.
			//metaData.ColumnHeaders[i]	= translationMap.OutputName;
			metaData.ColumnHeaders[i]	= translationMap.ResolvedName;
			metaData.Units.Add(translationMap.ToUnits);
			metaData.Fields.Add(translationMap.OutputField);
			metaData.DataTypes.Add(translationMap.DataType);
		}

		// Pass the information along to the OutputProcessor.
		_outputProcessor?.NewTable(metaData);
	}

	/// <summary>
	/// The end of a table (or block of data) was found.
	/// </summary>
	public virtual void EndTable()
	{
		_processingTable = false;
		_outputProcessor?.EndTable();
	}

	#endregion

	#region Static Methods

	/// <summary>
	/// Helper function to create a file containing positions for meta data for all the fields.
	/// </summary>
	/// <param name="path">Path to write the file to.</param>
	public static void WriteInitialFieldMetaDataFile(string path)
	{
		FieldMetaDataContainer container = new(true);
		container.Serialize(path);
	}

	#endregion

} // End class.