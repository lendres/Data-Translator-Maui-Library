using System.ComponentModel;

namespace DataConverter
{
	/// <summary>
	/// Specifies if the a selected item was a New or Existing instance of an object.
    /// 
	/// The "Description" attribute can be accessed using Reflection to get a string representing the enumeration type.
	/// </summary>
	public enum InstanceSelect
	{
		/// <summary>An existing instance was/is selected.</summary>
		[Description("Existing")]
		Existing,

		/// <summary>No selection or an invalid selection was made.</summary>
		[Description("Invalid")]
		Invalid,

		/// <summary>A new instance was selected/created.</summary>
		[Description("New")]
		New

	} // End enum.
} // End namespace.