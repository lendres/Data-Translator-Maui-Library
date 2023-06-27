using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Xml.Serialization;
using System.IO;

namespace DataConverter
{
	/// <summary>
	/// Base class for reading flat files (data separated by a delimiter, but otherwise un-formatted files).
	/// </summary>
	public abstract class FlatFileInputProcessor : InputProcessor
	{
		#region Members

		/// <summary>Input stream for reading file. </summary>
		protected StreamReader 				_inputStream;

		/// <summary>Delimiting characters. </summary>
		protected char[]					_delimiters					= new char[] {' ', ':', ',', '\t'};

		#endregion

		#region Construction

		/// <summary>
		/// Default constructor.
		/// </summary>
		public FlatFileInputProcessor()
		{
		}

		#endregion

		#region Properties

		#endregion

		#region Methods
				
		/// <summary>
		/// Open the output file.
		/// </summary>
		/// <param name="location">The source to use for the input.  Path to the location of the file.</param>
		public override void Open(string location)
		{
			// Allow the base class to do its work.
			base.Open(location);

			// Open input stream.
			_inputStream = File.OpenText(location);

			// Ensure there is data in the file.
			if (_inputStream.BaseStream.Length == 0)
			{
				throw new Exception("The input file does not contain data.\n\nFile: " + location);
			}
		}

		/// <summary>
		/// Close the output file.
		/// </summary>
		public override void Close()
		{
			// Close the stream.
			_inputStream.Close();
			_inputStream = null;
		}

		/// <summary>
		/// Reads until it finds the line of the input that starts with the supplied string.
		/// </summary>
		/// <param name="lineBeginning">Beginning of the line to search for.</param>
		protected void FindLineByStartString(string lineBeginning)
		{
			string line = _inputStream.ReadLine();
			_inputReport.ReadPreliminaryLine();
			
			while (!line.Trim().StartsWith(lineBeginning, StringComparison.CurrentCultureIgnoreCase))
			{
				line = _inputStream.ReadLine();
				_inputReport.ReadPreliminaryLine();

				if (_inputStream.EndOfStream)
				{
					throw new Exception("End of input file reached before line could be found.\n\nFile: " + this.OpenLocation + "\n\nSearch string: " + lineBeginning);
				}
			}
		}

		#endregion

	} // End class.
} // End namespace.