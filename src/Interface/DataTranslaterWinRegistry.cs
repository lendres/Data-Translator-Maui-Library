namespace DataConverter;

/// <summary>
/// Registry access and setting storage.
/// </summary>
public class DataTranslatorWinRegistry
{
	#region Members

	#endregion

	#region Construction and Installation

	/// <summary>
	/// Constructor.
	/// </summary>
	/// <param name="owner">Windows form that owns this registry.</param>
	public DataTranslatorWinRegistry()
	{
	}

	/// <summary>
	/// Run the installations of the registry values.
	/// </summary>
	private void OnInstall()
	{
		string? baseDirectory;

		// If we are debugging the executing assembly is in the bin\debug directory, so we need to move up a couple levels
		// to get to a location to reference from.  We want to base directory of the project in that case.
#if DEBUG
		baseDirectory = DigitalProduction.Reflection.Assembly.Path(System.Reflection.Assembly.GetExecutingAssembly());
		if (baseDirectory != null)
		{
			baseDirectory = DigitalProduction.IO.Path.ChangeDirectoryDotDot(baseDirectory, 3);
		}
		baseDirectory = System.IO.Path.Combine(baseDirectory??"", "Data Translator\\");

		DataTranslatorWinRegistry.TranslationMatrixDirectory	= System.IO.Path.Combine(baseDirectory, "ProgramData Files\\");
		DataTranslatorWinRegistry.UnitsFile						= System.IO.Path.Combine(baseDirectory, "ProgramData Files\\Units.xml");
		DataTranslatorWinRegistry.ConfigurationListFile			= System.IO.Path.Combine(baseDirectory, "User Files\\Configuration List.xml");
		DataTranslatorWinRegistry.FieldMetaDataFile				= System.IO.Path.Combine(baseDirectory, "User Files\\Field Meta Data.xml");
#else
		baseDirectory = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
		baseDirectory = System.IO.Path.Combine(baseDirectory, _companyName + "\\");
		baseDirectory = System.IO.Path.Combine(baseDirectory, _softwareName + "\\");
			
		this.TranslationMatrixDirectory		= baseDirectory;
		this.UnitsFile						= System.IO.Path.Combine(baseDirectory, "Units.xml");

		// The folder for the roaming current user.
		baseDirectory						= Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
		baseDirectory						= System.IO.Path.Combine(baseDirectory, _companyName + "\\");
		baseDirectory						= System.IO.Path.Combine(baseDirectory, _softwareName + "\\");
		this.ConfigurationListFile			= System.IO.Path.Combine(baseDirectory, "Configuration List.xml");
		this.FieldMetaDataFile				= System.IO.Path.Combine(baseDirectory, "Field Meta Data.xml");
#endif
	}

	#endregion

	#region Registry Keys

	/// <summary>
	/// Return the key that holds the data translator entries.
	/// </summary>
	/// <returns>Returns the registry key if it could be accessed, null if an error occurs.</returns>
	protected static string TranslationKey()
	{
		return "DataTranslation.";
	}


	/// <summary>
	/// Return the key that holds the options.
	/// </summary>
	/// <returns>Returns the registry key if it could be accessed, null if an error occurs.</returns>
	protected static string OptionsKey()
	{
		return DataTranslatorWinRegistry.TranslationKey() + "Options.";
	}

	#endregion

	#region Properties

	/// <summary>
	/// Translation matrix files default location.
	/// </summary>
	public static string TranslationMatrixDirectory
	{
		get
		{
			return Preferences.Default.Get(DataTranslatorWinRegistry.OptionsKey()+"Translation Matrix Directory", ".\\ProgramData Files");
		}

		set
		{
			Preferences.Default.Set(DataTranslatorWinRegistry.OptionsKey()+"Translation Matrix Directory", value);
		}
	}

	/// <summary>
	/// Units file location.
	/// </summary>
	public static string UnitsFile
	{
		get
		{
			return Preferences.Default.Get(DataTranslatorWinRegistry.OptionsKey()+"Units File", ".\\User Files\\Units.xml");
		}

		set
		{
			Preferences.Default.Set(DataTranslatorWinRegistry.OptionsKey()+"Units File", value);
		}
	}

	/// <summary>
	/// Configuration list file location.
	/// </summary>
	public static string ConfigurationListFile
	{
		get
		{
			return Preferences.Default.Get(DataTranslatorWinRegistry.OptionsKey()+"Configuration List File", ".\\User Files\\Configuration List.xml");
		}

		set
		{
			Preferences.Default.Set(DataTranslatorWinRegistry.OptionsKey()+"Configuration List File", value);
		}
	}

	/// <summary>
	/// Field meta data file location.
	/// </summary>
	public static string FieldMetaDataFile
	{
		get
		{
			return Preferences.Default.Get(DataTranslatorWinRegistry.OptionsKey()+"Field Meta Data File", ".\\ProgramData Files\\Field Meta Data.xml");
		}

		set
		{
			Preferences.Default.Set(DataTranslatorWinRegistry.OptionsKey()+"Field Meta Data File", value);
		}
	}

	/// <summary>
	/// Last source of input for a translation or import.
	/// </summary>
	public static string LastTranslationInputFile
	{
		get
		{
			return Preferences.Default.Get(DataTranslatorWinRegistry.TranslationKey()+"Last Translation Input File", System.IO.Directory.GetCurrentDirectory());
		}

		set
		{
			Preferences.Default.Set(DataTranslatorWinRegistry.TranslationKey()+"Last Translation Input File", value);
		}
	}

	/// <summary>
	/// Last source of input for a translation or import.
	/// </summary>
	public static string LastTranslationOutputFile
	{
		get
		{
			return Preferences.Default.Get(DataTranslatorWinRegistry.TranslationKey()+"Last Translation Output File", System.IO.Directory.GetCurrentDirectory());
		}

		set
		{
			Preferences.Default.Set(DataTranslatorWinRegistry.TranslationKey()+"Last Translation Output File", value);
		}
	}

	public static bool NumberOfColumnsMustMatchValidation
	{
		get
		{
			return Preferences.Default.Get(DataTranslatorWinRegistry.TranslationKey()+"Number Of Columns Must Match Validation", false);
		}

		set
		{
			Preferences.Default.Set(DataTranslatorWinRegistry.TranslationKey()+"Number Of Columns Must Match Validation", value);
		}
	}

	public static bool DateTimeFormattedCorrectlyValidation
	{
		get
		{
			return Preferences.Default.Get(DataTranslatorWinRegistry.TranslationKey()+"Date Time Formatted Correctly", false);
		}

		set
		{
			Preferences.Default.Set(DataTranslatorWinRegistry.TranslationKey()+"Date Time Formatted Correctly", value);
		}
	}

	public static bool HighPassDateValidation
	{
		get
		{
			return Preferences.Default.Get(DataTranslatorWinRegistry.TranslationKey()+"High Pass Date", false);
		}

		set
		{
			Preferences.Default.Set(DataTranslatorWinRegistry.TranslationKey()+"High Pass Date", value);
		}
	}

	public static DateTime HighPassDateCutOff
	{
		get
		{
			return Preferences.Default.Get(DataTranslatorWinRegistry.TranslationKey()+"High Pass Date Cut Off", System.DateTime.Now);
		}

		set
		{
			Preferences.Default.Set(DataTranslatorWinRegistry.TranslationKey()+"High Pass Date Cut Off", value);
		}
	}

	public static bool LowPassDateValidation
	{
		get
		{
			return Preferences.Default.Get(DataTranslatorWinRegistry.TranslationKey()+"Low Pass Date", false);
		}

		set
		{
			Preferences.Default.Set(DataTranslatorWinRegistry.TranslationKey()+"Low Pass Date", value);
		}
	}

	public static DateTime LowPassDateCutOff
	{
		get
		{
			return Preferences.Default.Get(DataTranslatorWinRegistry.TranslationKey()+"Low Pass Date Cut Off", System.DateTime.Now);
		}

		set
		{
			Preferences.Default.Set(DataTranslatorWinRegistry.TranslationKey()+"Low Pass Date Cut Off", value);
		}
	}

	#endregion

} // End class.