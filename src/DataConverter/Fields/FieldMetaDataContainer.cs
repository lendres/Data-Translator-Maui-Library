using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Xml.Serialization;
using DigitalProduction.Generic;
using DigitalProduction;
using DigitalProduction.XML.Serialization;
using DigitalProduction.IO;

namespace DataConverter
{
	/// <summary>
	/// 
	/// </summary>
	[XmlRoot("fieldmetadatacontainer")]
	public class FieldMetaDataContainer
	{
		#region Enumerations

		#endregion

		#region Delegates

		#endregion
		
		#region Events

		#endregion

		#region Members

		private List<FieldMetaData>								_fieldMetaData;
		private string											_path						= "";

		#endregion

		#region Construction

		/// <summary>
		/// Default constructor.  Used for serialization.
		/// </summary>
		private FieldMetaDataContainer()
		{
		}

		/// <summary>
		/// Constructor.  Used for initializing a blank container.  Can use this to take a new enum type and write an empty configuration file
		/// which the FieldMetaData can be added to.
		/// </summary>
		public FieldMetaDataContainer(bool initialize)
		{
			if (initialize)
			{
				Array values		= Enum.GetValues(typeof(Field));
				int length			= values.Length;
				_fieldMetaData		= new List<FieldMetaData>(length);

				for (int i = 0; i < length; i++)
				{
					_fieldMetaData.Add(new FieldMetaData(values.GetValue(i).ToString()));
				}
			}
		}

		#endregion

		#region Properties

		/// <summary>
		/// FieldMetaData entries.
		/// </summary>
		[XmlArray("fieldmetadatalist"), XmlArrayItem("fieldmetadata")]
		public List<FieldMetaData> FieldMetaData
		{
			get
			{
				return _fieldMetaData;
			}

			set
			{
				_fieldMetaData = value;
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

		#endregion

		#region Methods

		/// <summary>
		/// Sets the provided list as the FieldMetaData.
		/// </summary>
		/// <param name="fieldMetaData"></param>
		public void SetFieldMetaData(List<FieldMetaData> fieldMetaData)
		{
			int length			= fieldMetaData.Count;
			_fieldMetaData		= new List<FieldMetaData>(length);

			for (int i = 0; i < length; i++)
			{
				_fieldMetaData.Add(new FieldMetaData(fieldMetaData[i]));
			}
		}

		/// <summary>
		/// Clones all the FieldMetaData and returns them in a new list.
		/// </summary>
		public List<FieldMetaData> CloneFieldMetaData()
		{
			int numberOfEntries					= _fieldMetaData.Count;
			List<FieldMetaData> fieldMetaData	= new List<FieldMetaData>(numberOfEntries);
			
			for (int i = 0; i < numberOfEntries; i++)
			{
				fieldMetaData.Add(new FieldMetaData(_fieldMetaData[i]));
			}

			return fieldMetaData;
		}

		#endregion

		#region XML

		/// <summary>
		/// Create an instance from a file.
		/// </summary>
		/// <param name="path">The file to read from.</param>
		/// <returns>The deserialized file types.</returns>
		public static FieldMetaDataContainer Deserialize(string path)
		{
			FieldMetaDataContainer fieldMetaDataContainer	= Serialization.DeserializeObject<FieldMetaDataContainer>(path);
			fieldMetaDataContainer._path					= path;
			return fieldMetaDataContainer;
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