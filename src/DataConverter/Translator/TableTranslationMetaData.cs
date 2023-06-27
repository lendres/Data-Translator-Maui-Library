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
	/// Meta data used for translations.
	/// </summary>
	public class TableTranslationMetaData : TranslationMetaData
	{
		#region Members

		private string								_name;

		private List<string>						_columnHeaders;
		private List<string>						_units;
		private List<Field>							_fields;
		private List<DataType>						_dataTypes;

		private Field								_independentAxisField		= Field.Depth;

		// We need to provide a value to initialize the size of the Lists (only because our function calls for it).
		// Also, the "default" (default but not documented, therefore not required) size is either 0 or 4 (depending on who you ask)
		// so we want to create slightly larger list sizes anyway as our Lists will be bigger, typically.  Not really much efficiency
		// gain, but its convenient to use with our function anyway.
		private static int							_initialListSize			= 20;

		#endregion

		#region Construction

		/// <summary>
		/// Default constructor.
		/// </summary>
		private TableTranslationMetaData()
		{
			InitializeLists(_initialListSize);
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		public TableTranslationMetaData(string name)
		{
			_name	= name;
			InitializeLists(_initialListSize);
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		public TableTranslationMetaData(string name, int number) :
			base(number)
		{
			_name	= name;
			InitializeLists(_initialListSize);
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		public TableTranslationMetaData(string name, int number, List<string> columnHeaders) :
			base(number)
		{
			_name	= name;
			InitializeLists(columnHeaders.Count);

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
			InitializeLists(columnHeaders.Count);

			// We might modify the column headers so we need to copy them here to make sure we don't modify the originals.
			_columnHeaders = columnHeaders.ToList();
			_independentAxisField = independentAxisField;
		}

		/// <summary>
		/// Creates the List instances and sizes them to an initial size.
		/// </summary>
		/// <param name="initialSize">Size of the Lists.</param>
		private void InitializeLists(int initialSize)
		{
			_columnHeaders	= new List<string>(initialSize);
			_units			= new List<string>(initialSize);
			_fields			= new List<Field>(initialSize);
			_dataTypes		= new List<DataType>(initialSize);
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