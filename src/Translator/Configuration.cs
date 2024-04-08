using System.Xml.Serialization;

namespace DataConverter;

/// <summary>
/// A translation Configuration.  Holds all the data required for the Translator to setup and run a translation.
/// </summary>
public class Configuration
{
	#region Members

	private string					_name							= "";
	private string					_inputProcessorName				= "";
	private string					_outputProcessorName			= "";
	private string					_translationMapFile				= "";

	#endregion

	#region Construction

	/// <summary>
	/// Default constructor.
	/// </summary>
	public Configuration()
	{
	}

	/// <summary>
	/// Constructor.
	/// </summary>
	public Configuration(string name)
	{
		_name = name;
	}

	/// <summary>
	/// Copy constructor.
	/// </summary>
	/// <param name="source">Configuration to copy from.</param>
	public Configuration(Configuration source)
	{
		_name						= source._name;
		_inputProcessorName			= source._inputProcessorName;
		_outputProcessorName		= source._outputProcessorName;
		_translationMapFile			= source._translationMapFile;
	}

	#endregion

	#region Properties

	/// <summary>
	/// Configuration name.
	/// </summary>
	[XmlAttribute("name")]
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
	/// Name of the input processor.  Must match the ProcessorMetaData.Name.
	/// </summary>
	[XmlElement("inputprocessor")]
	public string InputProcessorName
	{
		get
		{
			return _inputProcessorName;
		}
		set
		{
			_inputProcessorName = value;
		}
	}

	/// <summary>
	/// Name of the output processor.  Must match the ProcessorMetaData.Name.
	/// </summary>
	[XmlElement("outputprocessor")]
	public string OutputProcessorName
	{
		get
		{
			return _outputProcessorName;
		}

		set
		{
			_outputProcessorName = value;
		}
	}

	/// <summary>
	/// Path of the file containing the translation maps to use in the translation.
	/// </summary>
	[XmlElement("translationmapfile")]
	public string TranslationMatrixFile
	{
		get
		{
			return _translationMapFile;
		}

		set
		{
			_translationMapFile = value;
		}
	}

	#endregion

	#region Methods

	#endregion

} // End class.