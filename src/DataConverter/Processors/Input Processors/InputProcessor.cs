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
	/// Base class for input processors.
	/// </summary>
	public abstract class InputProcessor : Processor
	{
		#region Members

		protected InputReport					_inputReport;
		protected Validator						_validator;

		#endregion

		#region Construction

		/// <summary>
		/// Default constructor.
		/// </summary>
		public InputProcessor()
		{
		}

		#endregion

		#region Properties

		/// <summary>
		/// Statics and information about the data read from the input.
		/// </summary>
		public InputReport InputReport
		{
			get
			{
				return _inputReport;
			}
		}

		/// <summary>
		/// The Validator the InputProcessor will pass data and commands to.
		/// </summary>
		public Validator Validator
		{
			get
			{
				return _validator;
			}

			set
			{
				_validator = value;
			}
		}

		#endregion

		#region Methods

		/// <summary>
		/// Open data source/destination.
		/// </summary>
		/// <param name="location">Location to open from.</param>
		public override void Open(string location)
		{
			base.Open(location);

			// Reset the report.
			_inputReport	= new InputReport();
		}

		/// <summary>
		/// Process the file.
		/// </summary>
		public abstract void Process();

		/// <summary>
		/// Reads the input names out of the file.
		/// </summary>
		public abstract List<string> ExtractInputNames();

		#endregion

	} // End class.
} // End namespace.