using System.ComponentModel;

namespace DataConverter
{
	/// <summary>
	/// Enumerations to use with dynamics data.
	/// 
	/// The "Description" attribute can be accessed using Reflection to get a string representing the enumeration type.
	/// 
	/// The "Length" enumeration can be used in loops as a convenient way of terminating a loop that does not have to be changed if
	/// the number of items in the enumeration changes.  The "Length" enumeration must be the last item.
	/// for (int i = 0; i &lt; (int)EnumType.Length; i++) {...}
	/// </summary>
	public enum Field
	{
		///// <summary>.</summary>
		//[Description("")]
		//,

		/// <summary>Acceleration in the X direction.</summary>
		[Description("Acceleration X")]
		AccelerationX,

		/// <summary>Acceleration in the Y direction.</summary>
		[Description("Acceleration Y")]
		AccelerationY,

		/// <summary>Acceleration in the Z direction.</summary>
		[Description("Acceleration Z")]
		AccelerationZ,

		/// <summary>Annulus pressure.</summary>
		[Description("Annulus Pressure")]
		AnnulusPressure,

		/// <summary>Axial acceleration RMS.</summary>
		[Description("Axial Acceleration RMS")]
		AxialAccelerationRMS,

		/// <summary>Axial acceleration peak (highest single data point sampled).</summary>
		[Description("Axial Acceleration Peak")]
		AxialAccelerationPeak,

		/// <summary>Bending angle.</summary>
		[Description("Bending Angle")]
		BendingAngle,

		/// <summary>Bending angle measurement 1.</summary>
		[Description("Bending Angle Measurement 1")]
		BendingAngleMeasurement1,

		/// <summary>Bending angle measurement 2.</summary>
		[Description("Bending Angle Measurement 2")]
		BendingAngleMeasurement2,

		/// <summary>Bending angle measurement 3.</summary>
		[Description("Bending Angle Measurement 3")]
		BendingAngleMeasurement3,

		/// <summary>Bending moment.</summary>
		[Description("Bending Moment")]
		BendingMoment,

		/// <summary>Bending moment measurement 1.</summary>
		[Description("Bending Moment Measurement 1")]
		BendingMomentMeasurement1,

		/// <summary>Bending moment measurement 2.</summary>
		[Description("Bending Moment Measurement 2")]
		BendingMomentMeasurement2,

		/// <summary>Bending moment measurement 3.</summary>
		[Description("Bending Moment Measurement 3")]
		BendingMomentMeasurement3,

		/// <summary>Bore pressure.</summary>
		[Description("Bore Pressure")]
		BorePressure,

		/// <summary>Date and time.</summary>
		[Description("Date and Time")]
		DateTime,

		/// <summary>Days elapsed.</summary>
		[Description("Days")]
		Days,

		/// <summary>Depth.</summary>
		[Description("Depth")]
		Depth,

		/// <summary>Differential pressure.</summary>
		[Description("Differential Pressure")]
		DifferentialPressure,

		/// <summary>Lateral acceleration RMS.</summary>
		[Description("Lateral Acceleration RMS")]
		LateralAccelerationRMS,

		/// <summary>Lateral acceleration peak (highest single data point sampled).</summary>
		[Description("Lateral Acceleration Peak")]
		LateralAccelerationPeak,

		/// <summary>X direction magnetometer reading.</summary>
		[Description("Magnetometer X")]
		MagnetometerX,

		/// <summary>X direction magnetometer reading.</summary>
		[Description("Magnetometer Y")]
		MagnetometerY,

		/// <summary>RPM average.</summary>
		[Description("RPM Average")]
		RpmAverage,

		/// <summary>RPM maximum.</summary>
		[Description("RPM Maximum")]
		RpmMaximum,

		/// <summary>RPM minimum.</summary>
		[Description("RPM Minimum")]
		RpmMinimum,

		/// <summary>Stick-slip period.</summary>
		[Description("Stick-Slip Period")]
		StickSlipPeriod,

		/// <summary>Temperature.</summary>
		[Description("Temperature")]
		Temperature,

		/// <summary>Torque on bit.</summary>
		[Description("Torque on Bit")]
		TorqueOnBit,

		/// <summary>Torque on bit measurement 1.</summary>
		[Description("Torque on Bit Measurement 1")]
		TorqueOnBitMeasurement1,

		/// <summary>Torque on bit measurement 2.</summary>
		[Description("Torque on Bit Measurement 2")]
		TorqueOnBitMeasurement2,

		/// <summary>Torque on bit measurement 3.</summary>
		[Description("Torque on Bit Measurement 3")]
		TorqueOnBitMeasurement3,

		/// <summary>Weight on bit.</summary>
		[Description("Weight on Bit")]
		WeightOnBit,

		/// <summary>Weight on bit measurement 1.</summary>
		[Description("Weight on Bit Measurement 1")]
		WeightOnBitMeasurement1,

		/// <summary>Weight on bit measurement 2.</summary>
		[Description("Weight on Bit Measurement 2")]
		WeightOnBitMeasurement2,

		/// <summary>Weight on bit measurement 3.</summary>
		[Description("Weight on Bit Measurement 3")]
		WeightOnBitMeasurement3,

		/// <summary>Unknown.</summary>
		[Description("Unknown")]
		Unknown,

	} // End enum.
} // End namespace.