﻿namespace DataConverter;

/// <summary>
/// 
/// </summary>
public class Controller
{
	#region Members

	private InputProcessor?					_inputProcessor;
	private Validator?						_validator;
	private Translator?						_translator;
	private OutputProcessor?					_outputProcessor;

	#endregion

	#region Construction

	/// <summary>
	/// Constructor.
	/// </summary>
	public Controller()
	{
	}

	#endregion

	#region Properties

	/// <summary>
	/// InputProcessor.
	/// </summary>
	public InputProcessor? InputProcessor
	{
		get
		{
			return _inputProcessor;
		}
	}

	/// <summary>
	/// Validator.
	/// </summary>
	public Validator? Validator
	{
		get
		{
			return _validator;
		}
	}

	/// <summary>
	/// OutputProcessor.
	/// </summary>
	public OutputProcessor? OutputProcessor
	{
		get
		{
			return _outputProcessor;
		}
	}

	#endregion

	#region Methods

	public void TranslateData(Configuration configuration, string inputFile, string outputFile, List<ValidationCheck> validationChecks)
	{
		// Control flow is:
		// Input -> Validate -> Translation -> Output.
		ConstructInstances(configuration);

		SetupTranslation(validationChecks);

		RunTranslation(inputFile, outputFile);
	}

	private void ConstructInstances(Configuration configuration)
	{
		// Control flow is:
		// Input -> Validate -> Translation -> Output.
		_inputProcessor			= ProcessorObjectFactory.CreateInputProcessor(configuration.InputProcessorName);
		_validator				= new Validator();
		_translator				= new Translator(System.IO.Path.Combine(TranslatorPreferences.TranslationMatrixDirectory, configuration.TranslationMatrixFile));
		_outputProcessor		= ProcessorObjectFactory.CreateOutputProcessor(configuration.OutputProcessorName);
	}

	private void SetupTranslation(List<ValidationCheck> validationChecks)
	{
		if (_inputProcessor == null)
		{
			throw new NullReferenceException("The input processor is null.");
		}
		if (_validator == null)
		{
			throw new NullReferenceException("The validator is null.");
		}
		if (_translator == null)
		{
			throw new NullReferenceException("The translator is null.");
		}

		// Setup.
		// Control flow is:
		// Input -> Validate -> Translation -> Output.
		_inputProcessor.Validator		= _validator;

		_validator.Translator			= _translator;
		_validator.AddValidationChecks(validationChecks);

		_translator.OutputProcessor		= _outputProcessor;
	}

	private void RunTranslation(string inputFile, string outputFile)
	{
		if (_outputProcessor == null)
		{
			throw new NullReferenceException("The output processor is null.");				
		}

		if (_inputProcessor == null)
		{
			throw new NullReferenceException("The input processor is null.");
		}

		// Processing.
		_outputProcessor.Open(outputFile);
		_inputProcessor.Open(inputFile);

		_inputProcessor.Process();

		_inputProcessor.Close();
		_outputProcessor.Close();
	}

	#endregion

} // End class.