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
	/// 
	/// </summary>
	public static class Validation
	{
		#region Members

		#endregion

		#region Construction

		/// <summary>
		/// Default constructor.
		/// </summary>
		static Validation()
		{
		}

		#endregion

		#region Properties

		#endregion

		#region Methods

		/// <summary>
		/// Custom date parsing function used to account for different 
		/// </summary>
		/// <param name="dateTime">A string containing text which is supposed to be a DateTime.  The string will attempt </param>
		/// <param name="result"></param>
		/// <returns></returns>
		public static bool TryParseDate(string dateTime, out DateTime result)
		{
			if (DateTime.TryParse(dateTime, out result))
			{
				return true;
			}

			// The DDM file contains it's own, let's call it 'special,' format, so we try to parse that.
			if (DateTime.TryParseExact(dateTime, "yy/MM/dd HH:mm:ss", System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat, System.Globalization.DateTimeStyles.None, out result))
			{
				return true;
			}

			// We were not able to parse the DateTime entry so it is invalid.
			return false;
		}

		#endregion

	} // End class.
} // End namespace.