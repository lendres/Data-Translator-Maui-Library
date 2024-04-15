using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DataConverter;

/// <summary>
/// Registry access and setting storage.
/// </summary>
public class TranslatorPreferences : INotifyPropertyChanged
{
	#region Members

	private static readonly		TranslatorPreferences			_instance = new TranslatorPreferences();

	public event				PropertyChangedEventHandler?	PropertyChanged;

	#endregion

	#region Construction and Installation

	/// <summary>
	/// Constructor.
	/// </summary>
	/// <param name="owner">Windows form that owns this registry.</param>
	public TranslatorPreferences()
	{
	}

	#endregion

	#region Properties

	public static TranslatorPreferences Instance => _instance;

	#endregion

	#region Keys

	/// <summary>
	/// Return the key that holds the data translator entries.
	/// </summary>
	/// <returns>Returns the registry key if it could be accessed, null if an error occurs.</returns>
	protected string TranslationKey()
	{
		return "DataTranslation.";
	}


	/// <summary>
	/// Return the key that holds the options.
	/// </summary>
	/// <returns>Returns the registry key if it could be accessed, null if an error occurs.</returns>
	protected string OptionsKey()
	{
		return TranslationKey() + "Options.";
	}

	#endregion

	#region Properties

	/// <summary>
	/// Translation matrix files default location.
	/// </summary>
	public string TranslationMatrixDirectory
	{
		get
		{
			return Preferences.Default.Get(OptionsKey()+"Translation Matrix Directory", ".\\ProgramData Files");
		}

		set
		{
			Preferences.Default.Set(OptionsKey()+"Translation Matrix Directory", value);
		}
	}

	/// <summary>
	/// Units file location.
	/// </summary>
	public string UnitsFile
	{
		get
		{
			return Preferences.Default.Get(OptionsKey()+"Units File", ".\\User Files\\Units.xml");
		}

		set
		{
			Preferences.Default.Set(OptionsKey()+"Units File", value);
		}
	}

	/// <summary>
	/// Configuration list file location.
	/// </summary>
	public string ConfigurationListFile
	{
		get
		{
			return Preferences.Default.Get(OptionsKey()+"Configuration List File", ".\\User Files\\Configuration List.xml");
		}

		set
		{
			Preferences.Default.Set(OptionsKey()+"Configuration List File", value);
		}
	}

	/// <summary>
	/// Field meta data file location.
	/// </summary>
	public string FieldMetaDataFile
	{
		get
		{
			return Preferences.Default.Get(OptionsKey()+"Field Meta Data File", ".\\ProgramData Files\\Field Meta Data.xml");
		}

		set
		{
			Preferences.Default.Set(OptionsKey()+"Field Meta Data File", value);
		}
	}

	/// <summary>
	/// Last source of input for a translation or import.
	/// </summary>
	public string LastTranslationInputFile
	{
		get
		{
			return Preferences.Default.Get(TranslationKey()+"Last Translation Input File", System.IO.Directory.GetCurrentDirectory());
		}

		set
		{
			Preferences.Default.Set(TranslationKey()+"Last Translation Input File", value);
		}
	}

	/// <summary>
	/// Last source of input for a translation or import.
	/// </summary>
	public string LastTranslationOutputFile
	{
		get
		{
			return Preferences.Default.Get(TranslationKey()+"Last Translation Output File", System.IO.Directory.GetCurrentDirectory());
		}

		set
		{
			Preferences.Default.Set(TranslationKey()+"Last Translation Output File", value);
		}
	}

	public bool NumberOfColumnsMustMatchValidation
	{
		get
		{
			return Preferences.Default.Get(TranslationKey()+"Number Of Columns Must Match Validation", false);
		}

		set
		{
			Preferences.Default.Set(TranslationKey()+"Number Of Columns Must Match Validation", value);
		}
	}

	public bool DateTimeFormattedCorrectlyValidation
	{
		get
		{
			return Preferences.Default.Get(TranslationKey()+"Date Time Formatted Correctly", false);
		}

		set
		{
			Preferences.Default.Set(TranslationKey()+"Date Time Formatted Correctly", value);
		}
	}

	public bool HighPassDateValidation
	{
		get
		{
			return Preferences.Default.Get(TranslationKey()+"High Pass Date", false);
		}

		set
		{
			Preferences.Default.Set(TranslationKey()+"High Pass Date", value);
		}
	}

	public DateTime HighPassDateCutOff
	{
		get
		{
			return Preferences.Default.Get(TranslationKey()+"High Pass Date Cut Off", System.DateTime.Now);
		}

		set
		{
			Preferences.Default.Set(TranslationKey()+"High Pass Date Cut Off", value);
		}
	}

	public bool LowPassDateValidation
	{
		get
		{
			return Preferences.Default.Get(TranslationKey()+"Low Pass Date", false);
		}

		set
		{
			Preferences.Default.Set(TranslationKey()+"Low Pass Date", value);
		}
	}

	public DateTime LowPassDateCutOff
	{
		get => GetValue<DateTime>(TranslationKey()+"Low Pass Date Cut Off", System.DateTime.Now);

		set
		{
			Preferences.Default.Set(TranslationKey()+"Low Pass Date Cut Off", value);
		}
	}

	#endregion

	#region Setting and Getting Properties


	protected bool SetValue<T>(string propertyName, T value) where T : IComparable
	{
		T? existing = Preferences.Default.Get(propertyName, default(T));

		if (existing != null && EqualityComparer<T>.Default.Equals(existing, value))
		{
			Preferences.Default.Set(propertyName, value);
			OnPropertyChanged(propertyName);
			return true;
		}

		return false;
	}

	protected T? GetValue<T>(string propertyName, T defaultValue)
	{
		return Preferences.Default.Get(propertyName, defaultValue);
	}

	protected void OnPropertyChanged([CallerMemberName] string propertyName = null!)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}

	#endregion

} // End class.