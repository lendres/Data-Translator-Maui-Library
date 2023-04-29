using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Xml.Serialization;
using DigitalProduction.XML.Serialization;
using DigitalProduction.Reflection;

namespace DataConverter
{
	/// <summary>
	/// 
	/// </summary>
	[XmlRoot("configurationlist")]
	public class ConfigurationList
	{
		#region Members

		private List<Configuration>						_configurations				= new List<Configuration>();
		private string									_path						= "";

		#endregion

		#region Construction

		/// <summary>
		/// Default constructor.
		/// </summary>
		public ConfigurationList()
		{
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		public ConfigurationList(List<Configuration> configurations)
		{
			foreach (Configuration configuration in configurations)
			{
				_configurations.Add(new Configuration(configuration));
			}
		}

		#endregion

		#region Properties

		/// <summary>
		/// Configurations.
		/// </summary>
		[XmlArray("configurations"), XmlArrayItem("configuration")]
		public List<Configuration> Configurations
		{
			get
			{
				return _configurations;
			}

			set
			{
				_configurations = value;
			}
		}

		/// <summary>
		/// Number of configurations, provided for convenience.
		/// </summary>
		[XmlIgnore()]
		public int NumberOfConfigurations
		{
			get
			{
				return _configurations.Count;
			}
		}

		/// <summary>
		/// Path the instance was created from.  Used to resave the file later.
		/// </summary>
		[XmlIgnore()]
		public string Path
		{
			get
			{
				return _path;
			}

			set
			{
				_path = value;
			}
		}

		/// <summary>
		/// Bracket operator.
		/// </summary>
		/// <param name="key">Index of required item.</param>
		[XmlIgnore()]
		public Configuration this[int index]
		{
			get
			{
				return _configurations[index];
			}

			set
			{
				_configurations[index] = value;
			}
		}

		#endregion

		#region Methods

		/// <summary>
		/// Gets all the names of the Configurations.
		/// </summary>
		public string[] GetArrayOfNames()
		{
			string[] names = new string[_configurations.Count];

			for (int i = 0; i < _configurations.Count; i++)
			{
				names[i] = _configurations[i].Name;
			}

			return names;
		}

		/// <summary>
		/// Find a Configuration by it's name.
		/// </summary>
		/// <param name="name">Name of the Configuration.</param>
		public Configuration GetConfigurationByName(string name)
		{
			Configuration configuration = _configurations.Find(item => item.Name == name);
			if (configuration == null)
			{
				throw new Exception("The Configuration name provided is not valid or not present.");
			}
			return configuration;
		}

		/// <summary>
		/// Returns a subset of the Configurations based on the filter.
		/// </summary>
		/// <param name="filter">Filter (Predicate).</param>
		private ConfigurationList FilterConfigurations(Func<Configuration, bool> filter)
		{
			return new ConfigurationList(_configurations.Where(filter).ToList());
		}

		/// <summary>
		/// Returns a subset of the Configurations based on a processor type.
		/// </summary>
		/// <param name="outputProcessorType"></param>
		/// <returns></returns>
		public ConfigurationList FilterByOutputProcessorType(Type outputProcessorType)
		{
			ProcessorMetaData processorMetaData = Attributes.GetAttribute<ProcessorMetaData>(outputProcessorType);

			return FilterConfigurations(item => item.OutputProcessorName == processorMetaData.Name);
		}

		/// <summary>
		/// Returns a subset of the Configurations based on the location of the data the read/write.
		/// </summary>
		/// <param name="dataLocation">Data location.</param>
		public ConfigurationList FilterBothProcessorsByDataLocation(DataLocation dataLocation)
		{
			return FilterByInputProcessorDataLocation(dataLocation).FilterByOutputProcessorDataLocation(dataLocation);
		}

		/// <summary>
		/// Returns a subset of the Configurations based on the location of the data the read/write.
		/// </summary>
		/// <param name="dataLocation">Data location.</param>
		public ConfigurationList FilterByInputProcessorDataLocation(DataLocation dataLocation)
		{
			return FilterConfigurations(item => ProcessorObjectFactory.GetProcessorMetaDataFromName(item.InputProcessorName).DataLocation == dataLocation);
		}

		/// <summary>
		/// Returns a subset of the Configurations based on the location of the data the read/write.
		/// </summary>
		/// <param name="dataLocation">Data location.</param>
		public ConfigurationList FilterByOutputProcessorDataLocation(DataLocation dataLocation)
		{
			return FilterConfigurations(item => ProcessorObjectFactory.GetProcessorMetaDataFromName(item.OutputProcessorName).DataLocation == dataLocation);
		}



		#endregion

		#region XML

		/// <summary>
		/// Create an instance from a file.
		/// </summary>
		/// <param name="path">The file to read from.</param>
		/// <returns>The deserialized file types.</returns>
		public static ConfigurationList Deserialize(string path)
		{
			ConfigurationList configurationList	= Serialization.DeserializeObject<ConfigurationList>(path);
			configurationList.Path				= path;
			return configurationList;
		}

		/// <summary>
		/// Write this object to a file.  The Path must be set and represent a valid path or this method will throw an exception.
		/// </summary>
		public void Serialize()
		{
			SerializationSettings settings				= new SerializationSettings(this, _path);
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

		#endregion

	} // End class.
} // End namespace.