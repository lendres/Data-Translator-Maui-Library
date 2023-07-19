namespace DataConverter
{
	/// <summary>
	/// Meta data used for translations.
	/// </summary>
	public abstract class TranslationMetaData
	{
		#region Members
		
		private int						_number;

		#endregion

		#region Construction

		/// <summary>
		/// Default constructor.
		/// </summary>
		protected TranslationMetaData()
		{
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		public TranslationMetaData(int number)
		{
			_number	= number;
		}

		#endregion

		#region Properties

		/// <summary>
		/// Count or number.
		/// </summary>
		public int Number
		{
			get
			{
				return _number;
			}
		}

		#endregion

		#region Methods

		#endregion

	} // End class.
} // End namespace.