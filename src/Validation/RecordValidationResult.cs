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
public enum RecordValidationResult
{
	/// <summary>Corrupted date.</summary>
	[Description("Corrupted Date")]
	CorruptedDate,

	/// <summary>Date out of range.</summary>
	[Description("Date Out of Range")]
	DateOutOfRange,

	/// <summary>Missing fields.</summary>
	[Description("Missing Fields")]
	MissingFields,

	/// <summary>Too many fields.</summary>
	[Description("Too Many Fields")]
	TooManyFields,

	/// <summary>Valid</summary>
	[Description("Valid")]
	Valid,

	///// <summary></summary>
	//[Description("")]
	//,

	/// <summary>The number of types/items in the enumeration.</summary>
	[Description("Length")]
	Length

} // End enum.