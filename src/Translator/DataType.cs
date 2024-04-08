using System.ComponentModel;

namespace DataConverter;

/// <summary>
/// Add summary here.
/// 
/// The "Description" attribute can be accessed using Reflection to get a string representing the enumeration type.
/// 
/// The "Length" enumeration can be used in loops as a convenient way of terminating a loop that does not have to be changed if
/// the number of items in the enumeration changes.  The "Length" enumeration must be the last item.
/// for (int i = 0; i &lt; (int)EnumType.Length; i++) {...}
/// </summary>
public enum DataType
{
	/// <summary>Date and/or time.</summary>
	[Description("Date and/or Time")]
	DateTime,

	/// <summary>Double.</summary>
	[Description("Double")]
	Double,

	/// <summary>String.</summary>
	[Description("String")]
	String

} // End enum.