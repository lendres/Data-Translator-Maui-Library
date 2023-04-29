using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Xml.Serialization;

namespace DataConverter
{
	/// <summary>
	/// Meta data associated with a field (entry).  Has descriptors that can be used to populate forms and controls.
	/// </summary>
	public class FieldMetaData
	{
		#region Members

		private string				_enumName				= " ";
		private string				_shortName				= " ";
		private string				_longName				= " ";
		private string				_catagory				= " ";
		private string				_description			= " ";

		#endregion

		#region Construction

		/// <summary>
		/// Default constructor.
		/// </summary>
		private FieldMetaData()
		{
		}

		/// <summary>
		/// Blank constructor.
		/// </summary>
		public FieldMetaData(string enumName)
		{
			_enumName = enumName;
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		public FieldMetaData(FieldMetaData source)
		{
			_enumName				= source._enumName;
			_shortName				= source._shortName;
			_longName				= source._longName;
			_catagory				= source._catagory;
			_description			= source._description;
		}

		#endregion

		#region Properties

		/// <summary>
		/// Name of internal enumeration value.  Used for cross checking, clarification, et cetera.
		/// </summary>
		[XmlElement("enumname")]
		public string EnumName
		{
			get
			{
				return _enumName;
			}

			set
			{
				_enumName = value;
			}
		}

		/// <summary>
		/// Short name to be used in chart legends, et cetera.
		/// </summary>
		[XmlElement("shortname")]
		public string ShortName
		{
			get
			{
				return _shortName;
			}

			set
			{
				_shortName = value;
			}
		}

		/// <summary>
		/// Long name to be used in chart titles, et cetera.
		/// </summary>
		[XmlElement("longname")]
		public string LongName
		{
			get
			{
				return _longName;
			}

			set
			{
				_longName = value;
			}
		}

		/// <summary>
		/// Catagory.
		/// </summary>
		[XmlElement("catagory")]
		public string Catagory
		{
			get
			{
				return _catagory;
			}

			set
			{
				_catagory = value;
			}
		}

		/// <summary>
		/// Description.
		/// </summary>
		[XmlElement("description")]
		public string Description
		{
			get
			{
				return _description;
			}

			set
			{
				_description = value;
			}
		}

		#endregion

		#region Methods

		#endregion

	} // End class.
} // End namespace.