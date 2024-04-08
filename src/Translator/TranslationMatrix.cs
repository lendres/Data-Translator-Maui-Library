using DigitalProduction.IO;
using DigitalProduction.XML.Serialization;
using System.Xml.Serialization;

namespace DataConverter;

/// <summary>
/// Contains the data used to convert the metadata in files to known internal data types.
/// </summary>
[XmlRoot("translationmatrix")]
public partial class TranslationMatrix
{
	#region Enumerations

	#endregion

	#region Delegates

	#endregion

	#region Events

	#endregion

	#region Members

	private SerializableSortedList<string, TranslationMap>			_translationMaps		= new();
	private string													_path					= "";

	#endregion

	#region Construction

	/// <summary>
	/// Default constructor.
	/// </summary>
	public TranslationMatrix()
	{
	}

	#endregion

	#region Properties

	/// <summary>
	/// The entries that make up the matrix.
	/// </summary>
	[XmlElement("entries")]
	public SerializableSortedList<string, TranslationMap> Entries
	{
		get
		{
			return _translationMaps;
		}

		set
		{
			_translationMaps = value;
		}
	}

	/// <summary>
	/// Path the TranslationMatrix was deserialized from.  Stored to make it easier to save (re-serialize) later.
	/// </summary>
	[XmlIgnore()]
	public string Path
	{
		get
		{
			return _path;
		}

		private set
		{
			_path = value;
		}
	}

	/// <summary>
	/// Returns true if the instance can be serialized.
	/// </summary>
	[XmlIgnore()]
	public bool IsSaveable
	{
		get
		{
			return _path != null && _path != "" && DigitalProduction.IO.Path.IsValidFileName(_path) == ValidFileNameResult.Valid;
		}
	}

	/// <summary>
	/// Provide brackets operator for accessing TranslationMaps.
	/// </summary>
	/// <param name="key">Lookup key to find the associated TranslationMap.</param>
	[XmlIgnore()]
	public TranslationMap this[string key]
	{
		get
		{
			if (_translationMaps.TryGetValue(key, out TranslationMap? value))
			{
				return value;
			}
			else
			{
				return new TranslationMap();
			}
		}

		set
		{
			_translationMaps[key] = value;
		}
	}

	#endregion

	#region Methods

	/// <summary>
	/// Clones all the TranslationMaps and puts them into the provided list.
	/// </summary>
	public void CloneTranslationMaps(List<TranslationMap> translationMaps)
	{
		int numberOfEntries						= _translationMaps.Count;
		IList<TranslationMap> values			=  _translationMaps.Values;
		
		for (int i = 0; i < numberOfEntries; i++)
		{
			translationMaps.Add(new TranslationMap(values[i]));
		}
	}

	/// <summary>
	/// Clears all the existing TranslationMaps and uses the values passed to establish the new matrix.
	/// </summary>
	/// <param name="translationMaps">TranslationMaps this TranslationMatrix will use.</param>
	public void SetTranslationMaps(List<TranslationMap> translationMaps)
	{
		_translationMaps.Clear();

		int numberOfEntries = translationMaps.Count;

		for (int i = 0; i < numberOfEntries; i++)
		{
			TranslationMap map = translationMaps[i];
			_translationMaps.Add(map.InputName, map);
		}
	}

	#endregion

	#region XML

	/// <summary>
	/// Write this object to a file.  The Path must be set and represent a valid path or this method will throw an exception.
	/// </summary>
	public void Serialize()
	{
		SerializationSettings settings				= new(this, _path);
		settings.XmlSettings.NewLineOnAttributes	= false;
		Serialization.SerializeObject(settings);
	}

	/// <summary>
	/// Write this object to a file.  The Path must be set and represent a valid path or this method will throw an exception.
	/// </summary>
	public void Serialize(string path)
	{
		_path = path;
		Serialize();
	}

	/// <summary>
	/// Create an instance from a file.
	/// </summary>
	/// <param name="path">The file to read from.</param>
	public static TranslationMatrix Deserialize(string path)
	{
		TranslationMatrix? translationMatrix = Serialization.DeserializeObject<TranslationMatrix>(path) ??
			throw new Exception("Unable to deserialize the translation matrix.");

		translationMatrix.Path              = path;
		return translationMatrix;
	}

	#endregion

} // End class.