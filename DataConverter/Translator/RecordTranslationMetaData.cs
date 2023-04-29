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
	public class RecordTranslationMetaData : TranslationMetaData
	{
		#region Members

		private string					_name;

		#endregion

		#region Construction

		/// <summary>
		/// Default constructor.
		/// </summary>
		private RecordTranslationMetaData()
		{
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		public RecordTranslationMetaData(string name)
		{
			_name	= name;
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		public RecordTranslationMetaData(string name, int number) :
			base(number)
		{
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

		#endregion

		#region Methods

		#endregion

	} // End class.
} // End namespace.