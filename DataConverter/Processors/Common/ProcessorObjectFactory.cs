using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Xml.Serialization;
using DigitalProduction.Generic;
using System.Reflection;

namespace DataConverter
{
	/// <summary>
	/// Creates instances of objects from names.
	/// </summary>
	public static class ProcessorObjectFactory
	{
		#region Enumerations

		#endregion

		#region Delegates

		#endregion

		#region Events

		#endregion

		#region Members

		private static ObjectFactory<string, InputProcessor>			_inputProcessorFactory			= new ObjectFactory<string, InputProcessor>();
		private static ObjectFactory<string, OutputProcessor>			_outputProcessorFactory			= new ObjectFactory<string, OutputProcessor>();

		#endregion

		#region Construction

		/// <summary>
		/// Default constructor.
		/// </summary>
		static ProcessorObjectFactory()
		{
			RegisterInputProcessors();
			RegisterOutputProcessors();
		}

		/// <summary>
		/// Automatically gathers all of the classes derived from the InputProcessor and registers them with the object factory.
		/// </summary>
		private static void RegisterInputProcessors()
		{
			// Find all the derived classes.
			List<Type>				processorTypes		= GetConcreteSubclassTypes(typeof(InputProcessor));
			List<ProcessorMetaData>	processorMetaData	= GetProcessorMetaData(processorTypes);

			MethodInfo method = typeof(ObjectFactory<string, InputProcessor>).GetMethod("Register", new Type[] {typeof(string)});

			for (int i = 0; i < processorTypes.Count; i++)
			{
				// Invoke the "Register" method for the derived processor type.
				MethodInfo genericMethod = method.MakeGenericMethod(processorTypes[i]);
				genericMethod.Invoke(_inputProcessorFactory, new object[] {processorMetaData[i].Name});
			}
		}

		/// <summary>
		/// Automatically gathers all of the classes derived from the OutputProcessor and registers them with the object factory.
		/// </summary>
		private static void RegisterOutputProcessors()
		{
			// Find all the derived classes.
			List<Type>				processorTypes		= GetConcreteSubclassTypes(typeof(OutputProcessor));
			List<ProcessorMetaData>	processorMetaData	= GetProcessorMetaData(processorTypes);

			MethodInfo method = typeof(ObjectFactory<string, OutputProcessor>).GetMethod("Register", new Type[] {typeof(string)});

			for (int i = 0; i < processorTypes.Count; i++)
			{
				// Invoke the "Register" method for the derived processor type.
				MethodInfo genericMethod = method.MakeGenericMethod(processorTypes[i]);
				genericMethod.Invoke(_outputProcessorFactory, new object[] {processorMetaData[i].Name});
			}
		}

		#endregion

		#region Properties

		/// <summary>
		/// Get an array of all the InputProcessor names.
		/// </summary>
		public static string[] InputProcessorNames
		{
			get
			{
				return _inputProcessorFactory.GetArrayOfKeys();
			}
		}

		/// <summary>
		/// Get an array of all the OutputProcessor names.
		/// </summary>
		public static string[] OutputProcessorNames
		{
			get
			{
				return _outputProcessorFactory.GetArrayOfKeys();
			}
		}

		/// <summary>
		/// Get an array of all the InputProcessor's ProcessorMetaData.
		/// </summary>
		public static List<ProcessorMetaData> InputProcessorMetaData
		{
			get
			{
				return GetProcessorMetaData(GetConcreteSubclassTypes(typeof(InputProcessor)));
			}
		}

		/// <summary>
		/// Get an array of all the OutputProcessor's ProcessorMetaData.
		/// </summary>
		public static List<ProcessorMetaData> OutputProcessorMetaData
		{
			get
			{
				return GetProcessorMetaData(GetConcreteSubclassTypes(typeof(OutputProcessor)));
			}
		}

		#endregion

		#region Methods

		/// <summary>
		/// Make an InputProcessor from the supplied name.
		/// </summary>
		/// <param name="name">The InputProcessor name found in the ProcessorMetaData.</param>
		public static InputProcessor CreateInputProcessor(string name)
		{
			return _inputProcessorFactory.Create(name);
		}

		/// <summary>
		/// Make an OutputProcessor from the supplied name.
		/// </summary>
		/// <param name="name">The OutputProcessor name found in the ProcessorMetaData.</param>
		public static OutputProcessor CreateOutputProcessor(string name)
		{
			return _outputProcessorFactory.Create(name);
		}

		/// <summary>
		/// Get the ProcessorMetaData from the ProcessorMetaData.Name string.
		/// </summary>
		public static ProcessorMetaData GetProcessorMetaDataFromName(string name)
		{
			List<ProcessorMetaData> processorMetaDataList	= GetAllProcessorsMetaData();
			ProcessorMetaData processorMetaData				= processorMetaDataList.Find(item => item.Name == name);

			if (processorMetaData == null)
			{
				throw new Exception("The ProcessorsMetaData name supplied is not valid.\n\nName: " + name);
			}

			return processorMetaData;
		}

		/// <summary>
		/// Get a List of all the meta data for every type of processor.  Includes both input and output processors, but
		/// does not include abstract classes.
		/// </summary>
		private static List<ProcessorMetaData> GetAllProcessorsMetaData()
		{
			List<Type> processorTypes = GetConcreteSubclassTypes(typeof(Processor));
			return GetProcessorMetaData(processorTypes);
		}

		/// <summary>
		/// Get all concrete classes derived from the specified type.
		/// </summary>
		/// <param name="type">Class Type to get derived classes of.</param>
		private static List<Type> GetConcreteSubclassTypes(Type type)
		{
			return DigitalProduction.Reflection.Assembly.GetConcreteSubclassTypesOf(type);
		}

		/// <summary>
		/// Get the ProcessorMetaData for all of the Types supplied.
		/// </summary>
		/// <param name="processorTypes">List of Types to get meta data for.</param>
		private static List<ProcessorMetaData> GetProcessorMetaData(List<Type> processorTypes)
		{
			List<ProcessorMetaData> processorMetaData = new List<ProcessorMetaData>(processorTypes.Count);
			for (int i = 0; i < processorTypes.Count; i++)
			{
				processorMetaData.Add(DigitalProduction.Reflection.Attributes.GetAttribute<ProcessorMetaData>(processorTypes[i]));
			}
			return processorMetaData;
		}

		#endregion

		#region XML

		#endregion

	} // End class.
} // End namespace.