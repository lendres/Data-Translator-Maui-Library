using System;
using System.Xml.Serialization;

namespace DataConverter
{
	/// <summary>
	/// Information used to change the units from internal to external values.
	/// </summary>
	public class UnitsConverter
	{
		#region Members

		private string										_category			= "Unknown";
		private string										_from				= "Unknown";
		private string										_to					= "Unknown";
		private bool										_negate				= false;

		// Static variables.
		private static Thor.Units.UnitConverter				_converter			= null;

		#endregion

		#region Construction

		/// <summary>
		/// Static constructor.  Initializes static variables/members.
		/// </summary>
		static UnitsConverter()
		{
		}

		/// <summary>
		/// Default constructor.
		/// </summary>
		public UnitsConverter()
		{
			InitializeConverter();
		}

		/// <summary>
		/// Copy constructor.
		/// </summary>
		/// <remarks>
		/// Don't need to initialize the converter for a copy constructor, if another instance already exists the converter was created.
		/// </remarks>
		public UnitsConverter(UnitsConverter source)
		{
			_category	= source._category;
			_from		= source._from;
			_to			= source._to;
			_negate		= source._negate;
		}

		/// <summary>
		/// Initializes the UnitConverter.
		/// </summary>
		/// <remarks>
		/// Since we only need one UnitConverter we make it static.  However, since we must get the location of the Units File from the registry, and
		/// the registry needs to be initialized from the calling application (the registry entries will be a subkey of the main application key) we
		/// cannot initialize the UnitConverter from the static constructor.
		/// </remarks>
		private void InitializeConverter()
		{
			if (_converter == null)
			{
				_converter			= (Thor.Units.UnitConverter)Thor.Units.InterfaceFactory.CreateUnitConverter();
				_converter.OnError	+= new Thor.Units.UnitEventHandler(Converter_OnError);
				_converter.LoadUnitsFile(Interface.Registry.UnitsFile);
			}
		}

		#endregion

		#region Properties

		/// <summary>
		/// Category of units.
		/// </summary>
		[XmlAttribute("category")]
		public string Category
		{
			get
			{
				return _category;
			}

			set
			{
				_category = value;
			}
		}

		/// <summary>
		/// Units to convert from.
		/// </summary>
		[XmlAttribute("from")]
		public string From
		{
			get
			{
				return _from;
			}

			set
			{
				_from = value;
			}
		}

		/// <summary>
		/// Units to convert to.
		/// </summary>
		[XmlAttribute("to")]
		public string To
		{
			get
			{
				return _to;
			}

			set
			{
				_to = value;
			}
		}

		/// <summary>
		/// Specifies if the sign should be changed.  For example, 18.2 => -18.2.
		/// </summary>
		[XmlAttribute("negate")]
		public bool Negate
		{
			get
			{
				return _negate;
			}

			set
			{
				_negate = value;
			}
		}

		/// <summary>
		/// Returns the sign as specified by "Negate".
		/// </summary>
		[XmlIgnore()]
		public int Sign
		{
			get
			{
				return _negate ? -1 : 1;
			}
		}

		#endregion

		#region Methods

		/// <summary>
		/// Convert a value based on the values of the instance.
		/// 
		/// If no conversion have been specified (or incorrect settings specified) the input is return unmodified.
		/// </summary>
		/// <param name="input">Input value to convert.</param>
		public double Convert(double input)
		{
			// Make sure we have valid data.
			if (_category != null && _from != null && _to != null)
			{
				double output;
				_converter.ConvertUnits(input, _from, _to, out output);
				return output * this.Sign;
			}
			else
			{
				return input;
			}
		}

		#endregion

		#region Static Methods

		/// <summary>
		/// Error handler for converter.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">Event arguments.</param>
		private static void Converter_OnError(object sender, Thor.Units.UnitEventArgs e)
		{
			throw new NotImplementedException();
		}

		public static string[] GetListOfUnitCatagories()
		{
			return _converter.Groups.GetAllGroupNames();
		}

		public static string[] GetListOfUnitsInGroup(string groupName)
		{
			return _converter.Groups[groupName].Units.GetAllUnitNames();
		}


		#endregion

	} // End class.
} // End namespace.