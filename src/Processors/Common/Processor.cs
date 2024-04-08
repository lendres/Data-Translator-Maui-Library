namespace DataConverter
{
	/// <summary>
	/// Base class for processors.
	/// </summary>
	public abstract class Processor
	{
		#region Members

		private string					_openLocation		= "";

		#endregion

		#region Construction

		/// <summary>
		/// Default constructor.
		/// </summary>
		public Processor()
		{
		}

		#endregion

		#region Properties

		/// <summary>
		/// Path, URL, or connection string used to open the input or output.
		/// </summary>
		public string OpenLocation
		{
			get
			{
				return _openLocation;
			}
		}

		#endregion

		#region Methods

		/// <summary>
		/// Open data source/destination.
		/// </summary>
		/// <param name="location">Location to open from.</param>
		public virtual void Open(string location)
		{
			_openLocation = location;
		}

		/// <summary>
		/// Close the output file.
		/// </summary>
		public abstract void Close();

		#endregion

	} // End class.
} // End namespace.