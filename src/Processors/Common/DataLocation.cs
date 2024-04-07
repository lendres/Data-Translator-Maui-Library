using System.ComponentModel;

namespace DataConverter
{
	/// <summary>
	/// Location of the data source or output for a processor.
	/// 
	/// The "Description" attribute can be accessed using Reflection to get a string representing the enumeration type.
	/// 
	/// The "Length" enumeration can be used in loops as a convenient way of terminating a loop that does not have to be changed if
	/// the number of items in the enumeration changes.  The "Length" enumeration must be the last item.
	/// for (int i = 0; i &lt; (int)EnumType.Length; i++) {...}
	/// </summary>
	public enum DataLocation
	{
		/// <summary>Reads/writes the data from/to disk.</summary>
		[Description("Data located on the disk.")]
		Disk,

		/// <summary>Reads/writes the data from/to memory.</summary>
		[Description("Data located in memory.")]
		Memory,

		/// <summary>The number of types/items in the enumeration.</summary>
		[Description("Length")]
		Length

	} // End enum.
} // End namespace.