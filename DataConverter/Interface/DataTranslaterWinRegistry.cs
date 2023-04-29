using System;
using System.Collections.Generic;
using System.Text;
using DigitalProduction.Forms;
using Microsoft.Win32;
using DigitalProduction.Registry;

namespace DataConverter
{
	/// <summary>
	/// Registry access and setting storage.
	/// </summary>
	public class DataTranslatorWinRegistry : WinRegistryAccess
	{
		#region Members

		#endregion

		#region Construction and Installation

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="owner">Windows form that owns this registry.</param>
		public DataTranslatorWinRegistry(WinRegistryAccess winRegistryAccess) :
			base(winRegistryAccess)
		{
			winRegistryAccess.Install	+= this.OnInstall;
		}

		/// <summary>
		/// Run the installations of the registry values.
		/// </summary>
		private void OnInstall()
		{
			string baseDirectory;

			// If we are debugging the executing assembly is in the bin\debug directory, so we need to move up a couple levels
			// to get to a location to reference from.  We want to base directory of the project in that case.
#if DEBUG
//#if !DEBUG
			baseDirectory = DigitalProduction.Reflection.Assembly.Path(System.Reflection.Assembly.GetExecutingAssembly());
			baseDirectory = DigitalProduction.IO.Path.ChangeDirectoryDotDot(baseDirectory, 3);
			baseDirectory = System.IO.Path.Combine(baseDirectory, "Data Translator\\");

			this.TranslationMatrixDirectory		= System.IO.Path.Combine(baseDirectory, "ProgramData Files\\");
			this.UnitsFile						= System.IO.Path.Combine(baseDirectory, "ProgramData Files\\Units.xml");

			this.ConfigurationListFile			= System.IO.Path.Combine(baseDirectory, "User Files\\Configuration List.xml");
			this.FieldMetaDataFile				= System.IO.Path.Combine(baseDirectory, "User Files\\Field Meta Data.xml");
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
		protected RegistryKey TranslationKey()
		{
			RegistryKey translationKey;

			try
			{
				RegistryKey appKey = AppKey();

				if (appKey == null)
				{
					return null;
				}

				// Open the Window State key.
				translationKey = appKey.CreateSubKey("Data Translation");
			}
			catch
			{
				return null;
			}

			return translationKey;
		}


		/// <summary>
		/// Return the key that holds the options.
		/// </summary>
		/// <returns>Returns the registry key if it could be accessed, null if an error occurs.</returns>
		protected RegistryKey OptionsKey()
		{
			RegistryKey optionsKey;

			try
			{
				RegistryKey translationKey = TranslationKey();

				if (translationKey == null)
				{
					return null;
				}

				// Open the Window State key.
				optionsKey = translationKey.CreateSubKey("Options");
			}
			catch
			{
				return null;
			}

			return optionsKey;
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
				return GetValue(OptionsKey(), "Translation Matrix Directory", ".\\ProgramData Files");
			}

			set
			{
				SetValue(OptionsKey(), "Translation Matrix Directory", value);
			}
		}

		/// <summary>
		/// Units file location.
		/// </summary>
		public string UnitsFile
		{
			get
			{
				return GetValue(OptionsKey(), "Units File", ".\\User Files\\Units.xml");
			}

			set
			{
				SetValue(OptionsKey(), "Units File", value);
			}
		}

		/// <summary>
		/// Configuration list file location.
		/// </summary>
		public string ConfigurationListFile
		{
			get
			{
				return GetValue(OptionsKey(), "Configuration List File", ".\\User Files\\Configuration List.xml");
			}

			set
			{
				SetValue(OptionsKey(), "Configuration List File", value);
			}
		}

		/// <summary>
		/// Field meta data file location.
		/// </summary>
		public string FieldMetaDataFile
		{
			get
			{
				return GetValue(OptionsKey(), "Field Meta Data File", ".\\ProgramData Files\\Field Meta Data.xml");
			}

			set
			{
				SetValue(OptionsKey(), "Field Meta Data File", value);
			}
		}

		/// <summary>
		/// Last source of input for a translation or import.
		/// </summary>
		public string LastTranslationInputFile
		{
			get
			{
				return GetValue(TranslationKey(), "Last Translation Input File", System.IO.Directory.GetCurrentDirectory());
			}

			set
			{
				SetValue(TranslationKey(), "Last Translation Input File", value);
			}
		}

		/// <summary>
		/// Last source of input for a translation or import.
		/// </summary>
		public string LastTranslationOutputFile
		{
			get
			{
				return GetValue(TranslationKey(), "Last Translation Output File", System.IO.Directory.GetCurrentDirectory());
			}

			set
			{
				SetValue(TranslationKey(), "Last Translation Output File", value);
			}
		}

		public bool NumberOfColumnsMustMatchValidation
		{
			get
			{
				return GetValue(TranslationKey(), "Number Of Columns Must Match Validation", false);
			}

			set
			{
				SetValue(TranslationKey(), "Number Of Columns Must Match Validation", value);
			}
		}

		public bool DateTimeFormattedCorrectlyValidation
		{
			get
			{
				return GetValue(TranslationKey(), "Date Time Formatted Correctly", false);
			}

			set
			{
				SetValue(TranslationKey(), "Date Time Formatted Correctly", value);
			}
		}

		public bool HighPassDateValidation
		{
			get
			{
				return GetValue(TranslationKey(), "High Pass Date", false);
			}

			set
			{
				SetValue(TranslationKey(), "High Pass Date", value);
			}
		}

		public DateTime HighPassDateCutOff
		{
			get
			{
				return GetValue(TranslationKey(), "High Pass Date Cut Off", System.DateTime.Now);
			}

			set
			{
				SetValue(TranslationKey(), "High Pass Date Cut Off", value);
			}
		}

		public bool LowPassDateValidation
		{
			get
			{
				return GetValue(TranslationKey(), "Low Pass Date", false);
			}

			set
			{
				SetValue(TranslationKey(), "Low Pass Date", value);
			}
		}

		public DateTime LowPassDateCutOff
		{
			get
			{
				return GetValue(TranslationKey(), "Low Pass Date Cut Off", System.DateTime.Now);
			}

			set
			{
				SetValue(TranslationKey(), "Low Pass Date Cut Off", value);
			}
		}

		#endregion

	} // End class.
} // End namespace.