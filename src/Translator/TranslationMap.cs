using DigitalProduction.Reflection;
using System.ComponentModel;
using System.Xml.Serialization;

namespace DataConverter;

/// <summary>
/// Contains the information required to map input data to a known data type.
/// </summary>
public class TranslationMap : INotifyPropertyChanged
{
	#region Events

	public event PropertyChangedEventHandler?		PropertyChanged;

	#endregion

	#region Members

	private string						_inputName					= "Unknown";
	private Field						_outputField				= Field.Unknown;
	private DataType					_dataType					= DataType.String;
	private UnitsConverter				_unitsConverter				= new();

	#endregion

	#region Construction

	/// <summary>
	/// Default constructor.
	/// </summary>
	public TranslationMap()
	{
	}

	/// <summary>
	/// Constructor.
	/// </summary>
	public TranslationMap(string inputName)
	{
		_inputName		= inputName;
	}

	/// <summary>
	/// Copy constructor.
	/// </summary>
	public TranslationMap(TranslationMap source)
	{
		_inputName		= source._inputName;
		_outputField	= source._outputField;
		_unitsConverter = new UnitsConverter(source._unitsConverter);
		_dataType		= source._dataType;
	}

	#endregion

	#region Properties

	/// <summary>
	/// Name in the input file.
	/// </summary>
	[XmlAttribute("inputname")]
	public string InputName
	{
		get
		{
			return _inputName;
		}

		set
		{
			_inputName = value;
			NotifyPropertyChanged("InputName");
		}
	}

	/// <summary>
	/// Name to convert to.  A string associated with the OutputField.
	/// </summary>
	[XmlIgnore()]
	public string OutputName
	{
		get
		{
			// If the Field type was not known (no TranslationMap was configured) then we get an Unknown value.  For this case,
			// we wish to pass along the input name as the output name.  This allows us to identify or separate the input values
			// from each other.
			//if (_outputField == Field.Unknown)
			//{
			//	return _inputName;
			//}
			//else
			//{
			return Attributes.GetDescription(_outputField);
			//}
		}

		set
		{
			this.OutputField = Enumerations.GetInstanceFromDescription<Field>(value);
			NotifyPropertyChanged("OutputName");
		}
	}

	/// <summary>
	/// Type of Field to convert to.
	/// </summary>
	[XmlAttribute("outputfield")]
	public Field OutputField
	{
		get
		{
			return _outputField;
		}

		set
		{
			_outputField = value;
			NotifyPropertyChanged("OutputField");
		}
	}

	/// <summary>
	/// Provides the best available unique name of the input source.  If the TranslationMap exists and has it's OutputField set to any value
	/// except "Unknown," this returns the OutputName.  If the OutputField == Field.Unknown then this returns the InputName.
	/// </summary>
	[XmlIgnore()]
	public string ResolvedName
	{
		get
		{
			//If the Field type was not known (no TranslationMap was configured) then we get an Unknown value.  For this case,
			//we wish to pass along the input name as the output name.  This allows us to identify or separate the input values
			//from each other.
			if (_outputField == Field.Unknown)
			{
				return this.InputName;
			}
			else
			{
				return this.OutputName;
			}
		}
	}

	/// <summary>
	/// Type of data.
	/// </summary>
	[XmlElement("type")]
	public DataType DataType
	{
		get
		{
			return _dataType;
		}

		set
		{
			_dataType = value;
		}
	}

	/// <summary>
	/// Type of data as a description string.  Used for data binding on the edit form..
	/// </summary>
	[XmlIgnore()]
	public string DataTypeString
	{
		get
		{
			return Attributes.GetDescription(_dataType);
		}

		set
		{
			_dataType = Enumerations.GetInstanceFromDescription<DataType>(value);
			NotifyPropertyChanged("DataTypeString");
		}
	}

	/// <summary>
	/// Data used to change the units from those in the input file to internal units.
	/// </summary>
	[XmlElement("conversion")]
	public UnitsConverter UnitsConverter
	{
		get
		{
			return _unitsConverter;
		}

		set
		{
			_unitsConverter = value;
		}
	}

	/// <summary>
	/// Data binding access to units.
	/// </summary>
	[XmlIgnore()]
	public bool NegateUnits
	{
		get
		{
			return _unitsConverter.Negate;
		}

		set
		{
			_unitsConverter.Negate = value;
			NotifyPropertyChanged("NegateUnits");
		}
	}

	/// <summary>
	/// Data binding access to units.
	/// </summary>
	[XmlIgnore()]
	public string CatagoryOfUnits
	{
		get
		{
			return _unitsConverter.Category;
		}

		set
		{
			_unitsConverter.Category = value;
			NotifyPropertyChanged("CatagoryOfUnits");
		}
	}

	/// <summary>
	/// Data binding access to units.
	/// </summary>
	[XmlIgnore()]
	public string FromUnits
	{
		get
		{
			return _unitsConverter.From;
		}

		set
		{
			_unitsConverter.From = value;
			NotifyPropertyChanged("FromUnits");
		}
	}

	/// <summary>
	/// Data binding access to units.
	/// </summary>
	[XmlIgnore()]
	public string ToUnits
	{
		get
		{
			return _unitsConverter.To;
		}

		set
		{
			_unitsConverter.To = value;
			NotifyPropertyChanged("ToUnits");
		}
	}

	#endregion

	#region Methods

	#endregion

	#region Interfaces and Events

	/// <summary>
	/// Notify that a property changed.
	/// 
	/// INotifyPropertyChanged Interface
	/// </summary>
	/// <param name="info">Information.</param>
	private void NotifyPropertyChanged(string info)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
	}

	#endregion

} // End class.