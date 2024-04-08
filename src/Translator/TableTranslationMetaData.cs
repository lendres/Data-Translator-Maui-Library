using System.Collections.Generic;
using System.Linq;

namespace DataConverter
{
	/// <summary>
	/// Meta data used for translations.
	/// </summary>
	public class TableTranslationMetaData : TranslationMetaData
	{
		#region Members

		private string								_name						= "";

		private List<string>						_columnHeaders				= new();
		private List<string>                        _units						= new();
		private List<Field>                         _fields						= new();
		private List<DataType>                      _dataTypes					= new();

		private Field								_independentAxisField		= Field.Depth;

		#endregion

		#region Construction

		/// <summary>
		/// Default constructor.
		/// </summary>
		private TableTranslationMetaData()
		{
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		public TableTranslationMetaData(string name)
		{
			_name	= name;
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		public TableTranslationMetaData(string name, int number) :
			base(number)
		{
			_name	= name;
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		public TableTranslationMetaData(string name, int number, List<string> columnHeaders) :
			base(number)
		{
			_name	= name;

			// We might modify the column headers so we need to copy them here to make sure we don't modify the originals.
			_columnHeaders = columnHeaders.ToList();
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		public TableTranslationMetaData(string name, int number, List<string> columnHeaders, Field independentAxisField) :
			base(number)
		{
			_name	= name;

			// We might modify the column headers so we need to copy them here to make sure we don't modify the originals.
			_columnHeaders			= columnHeaders.ToList();
			_independentAxisField	= independentAxisField;
		}

		#endregion

		#region Properties

		/// <summary>
		/// Name or type of data.
		/// </summary>
		public string Name
		{
			get
			{
				return _name;
			}

			set
			{
				_name = value;
			}
		}

		/// <summary>
		/// Number of column.
		/// </summary>
		public int NumberOfColumns
		{
			get
			{
				return _columnHeaders.Count;
			}
		}

		/// <summary>
		/// Column headers.
		/// </summary>
		public List<string> ColumnHeaders
		{
			get
			{
				return _columnHeaders;
			}

			set
			{
				_columnHeaders = value;
			}
		}

		/// <summary>
		/// Units for each column.
		/// </summary>
		public List<string> Units
		{
			get
			{
				return _units;
			}

			set
			{
				_units = value;
			}
		}

		/// <summary>
		/// Data types for each column.
		/// </summary>
		public List<DataType> DataTypes
		{
			get
			{
				return _dataTypes;
			}
			set
			{
				_dataTypes = value;
			}
		}


		/// <summary>
		/// Field designated to serve as the independent axis (typically this is the x-axis data).
		/// </summary>
		public Field IndependentAxisField
		{
			get
			{
				return _independentAxisField;
			}

			set
			{
				_independentAxisField = value;
			}
		}

		/// <summary>
		/// Fields of each column.
		/// </summary>
		public List<Field> Fields
		{
			get
			{
				return _fields;
			}

			set
			{
				_fields = value;
			}
		}

		#endregion

		#region Methods

		#endregion

	} // End class.
} // End namespace.