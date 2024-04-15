using System.ComponentModel;
using DigitalProduction.Delegates;

namespace DataConverter;

/// <summary>
/// Registry access and setting storage.
/// </summary>
public class TranslatorPreferences
{
	#region Members

	public static event		NoArgumentsEventHandler?		TranslationMatrixDirectoryChanged;
	public static event		NoArgumentsEventHandler?        UnitsFileChanged;
	public static event		NoArgumentsEventHandler?        ConfigurationListFileChanged;
	public static event		NoArgumentsEventHandler?        FieldMetaDataFileChanged;

	#endregion

	#region Construction and Installation

	/// <summary>
	/// Constructor.
	/// </summary>
	/// <param name="owner">Windows form that owns this registry.</param>
	public TranslatorPreferences()
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

		TranslatorPreferences.TranslationMatrixDirectory	= System.IO.Path.Combine(baseDirectory, "ProgramData Files\\");
		TranslatorPreferences.UnitsFile						= System.IO.Path.Combine(baseDirectory, "ProgramData Files\\Units.xml");
		TranslatorPreferences.ConfigurationListFile			= System.IO.Path.Combine(baseDirectory, "User Files\\Configuration List.xml");
		TranslatorPreferences.FieldMetaDataFile				= System.IO.Path.Combine(baseDirectory, "User Files\\Field Meta Data.xml");
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
		return TranslationKey() + "Options.";
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
			return Preferences.Default.Get(OptionsKey()+"Translation Matrix Directory", ".\\ProgramData Files");
		}

		set
		{
			Preferences.Default.Set(OptionsKey()+"Translation Matrix Directory", value);
			TranslationMatrixDirectoryChanged?.Invoke();
		}
	}

	/// <summary>
	/// Units file location.
	/// </summary>
	public static string UnitsFile
	{
		get
		{
			return Preferences.Default.Get(OptionsKey()+"Units File", ".\\User Files\\Units.xml");
		}

		set
		{
			Preferences.Default.Set(OptionsKey()+"Units File", value);
			UnitsFileChanged?.Invoke();
		}
	}

	/// <summary>
	/// Configuration list file location.
	/// </summary>
	public static string ConfigurationListFile
	{
		get
		{
			return Preferences.Default.Get(OptionsKey()+"Configuration List File", ".\\User Files\\Configuration List.xml");
		}

		set
		{
			Preferences.Default.Set(OptionsKey()+"Configuration List File", value);
			ConfigurationListFileChanged?.Invoke();
		}
	}

	/// <summary>
	/// Field meta data file location.
	/// </summary>
	public static string FieldMetaDataFile
	{
		get
		{
			return Preferences.Default.Get(OptionsKey()+"Field Meta Data File", ".\\ProgramData Files\\Field Meta Data.xml");
		}

		set
		{
			Preferences.Default.Set(OptionsKey()+"Field Meta Data File", value);
			FieldMetaDataFileChanged?.Invoke();
		}
	}

	/// <summary>
	/// Last source of input for a translation or import.
	/// </summary>
	public static string LastTranslationInputFile
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
	public static string LastTranslationOutputFile
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

	public static bool NumberOfColumnsMustMatchValidation
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

	public static bool DateTimeFormattedCorrectlyValidation
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

	public static bool HighPassDateValidation
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

	public static DateTime HighPassDateCutOff
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

	public static bool LowPassDateValidation
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

	public static DateTime LowPassDateCutOff
	{
		get
		{
			return Preferences.Default.Get(TranslationKey()+"Low Pass Date Cut Off", System.DateTime.Now);
		}

		set
		{
			Preferences.Default.Set(TranslationKey()+"Low Pass Date Cut Off", value);
		}
	}

	#endregion

} // End class.