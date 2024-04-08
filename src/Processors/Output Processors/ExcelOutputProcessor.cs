//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.ComponentModel;
//using System.Xml.Serialization;

////using APS.Export;

//using DocumentFormat.OpenXml.Packaging;
//using DocumentFormat.OpenXml.Spreadsheet;
//using DocumentFormat.OpenXml.Drawing.Charts;

//namespace DataConverter
//{
//	/// <summary>
//	/// Excel output processors.
//	/// </summary>
//	[ProcessorMetaData(Name = "Excel Output Processor",
//					   DataLocation = DataLocation.Disk,
//					   FilterString = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*",
//					   Description = ""
//					  )
//	]
//	public class ExcelOutputProcessor : OutputProcessor
//	{
//		#region Enumerations

//		private enum Styles
//		{
//			DefaultText,
//			DefaultNumber,
//			TextWithBorder,
//			NumberWithBorder,
//			CenteredBold,
//			CenteredBoldWithBorder,
//			RoadMapHeader1,
//			RoadMapHeader2,
//			RoadMapHeader3,
//			BestValuesBody,
//			BaseLineHeader1,
//			BaseLineHeader2,
//			BaseLineBody,
//			ComparisonHeader1,
//			ComparisonHeader2,
//			ComparisonBody,
//			ComparisonBodyGoodROP,
//			ComparisonBodyBadROP,
//			Length
//		}

//		/// <summary>
//		/// Colors for designated objects.
//		/// </summary>
//		public enum ColorType
//		{
//			OptimumValueCurve,
//			ProjectStartDepth,
//			ProjectEndDepth,

//			OptimumValuesTable,
//			BaseLineWellTable,
//			ComparisonWellTable,

//			HighlightFill,
//			DividerCells,

//			BestValuesExcelSheet,
//			BaseLineExcelSheet,
//			ComparisonExcelSheet,
//			ComparisonGoodROP,
//			ComparisonBadROP,

//			Length
//		}

//		#endregion

//		#region Members

//		private FastExcelWriter										_writer								= new FastExcelWriter();
//		private FastWorksheet										_fastWorksheet;

//		RecordTranslationMetaData									_currentRecordMetaData;

//		#region Styles

//		private uint[]												_styles								= new uint[(int)Styles.Length];

//		private static System.Drawing.Color[]						_featureColors						= new System.Drawing.Color[]
//																										{
//																											// Optimum, start depth, and end depth curve colors for run time.
//																											System.Drawing.Color.FromArgb(191, 191, 191),
//																											System.Drawing.Color.FromArgb( 92, 193,  50),
//																											System.Drawing.Color.FromArgb(220,   0,   0),

//																											// Run time table shading for optimum, base line, and comparison wells.
//																											System.Drawing.Color.FromArgb(134,176,226),
//																											System.Drawing.Color.FromArgb(215,228,190),
//																											System.Drawing.Color.FromArgb(250,191,142),

//																											// Highlighted fill and divider (grey) cells.
//																											System.Drawing.Color.FromArgb(255,255,153),
//																											System.Drawing.Color.FromArgb(226,107, 10),

//																											// Optimum, start depth, and end depth curve System.Drawing.Colors for Excel export.
//																											System.Drawing.Color.FromArgb( 22, 54, 92),
//																											System.Drawing.Color.FromArgb(118,147, 60),
//																											System.Drawing.Color.FromArgb(226,107, 10),

//																											// Good and bad ROP conditional formatting for Excel export.
//																											System.Drawing.Color.FromArgb(  0,176,  0),
//																											System.Drawing.Color.FromArgb(255,  0, 80),
//																										};

//		private static System.Drawing.Color[]						_lineSeriesColors					= new System.Drawing.Color[]
//																										{
//																											System.Drawing.Color.FromArgb( 65, 141, 241), //  1
//																											System.Drawing.Color.FromArgb(252, 179,  66), //  2
//																											System.Drawing.Color.FromArgb(170,  47,  33), //  3
//																											System.Drawing.Color.FromArgb( 48, 136,  50), //  4
//																											System.Drawing.Color.FromArgb(255,   9, 241), //  5
//																											System.Drawing.Color.FromArgb(  0, 255, 255), //  6
//																											System.Drawing.Color.FromArgb(255, 227,   0), //  7
//																											System.Drawing.Color.FromArgb(230, 100,   0), //  8
//																											System.Drawing.Color.FromArgb(100, 255,  50), //  9
//																											System.Drawing.Color.FromArgb(176,   0, 227), // 10
//																											System.Drawing.Color.FromArgb(255, 102,   0), // 11
//																											System.Drawing.Color.FromArgb( 48, 221,  50), // 12
//																											System.Drawing.Color.FromArgb(  0, 156, 210), // 13
//																											System.Drawing.Color.FromArgb(140, 102, 140),
//																											System.Drawing.Color.FromArgb(100, 100, 100),
//																											System.Drawing.Color.FromArgb(  0,   0, 255),
//																											System.Drawing.Color.FromArgb (50, 160, 160),
//																											System.Drawing.Color.FromArgb(150, 160,  50),
//																											System.Drawing.Color.FromArgb(255,   0,   0)
//																										};

//		#endregion

//		#endregion

//		#region Construction

//		/// <summary>
//		/// Default constructor.
//		/// </summary>
//		public ExcelOutputProcessor()
//		{
//		}

//		#endregion

//		#region Properties

//		#endregion

//		#region Methods

//		/// <summary>
//		/// Open the output file.
//		/// </summary>
//		/// <param name="path">Path to the location to write the file to.</param>
//		public override void Open(string path)
//		{
//			_writer.CreateSpreadSheet(path);
//			GenerateWorkbookStyles(_writer.SpreadSheet);
//		}

//		/// <summary>
//		/// Pass a data read from the input to the Translator for processing.
//		/// </summary>
//		/// <param name="data">Value read from the input.</param>
//		/// <param name="metaData">MetaData describing the field.</param>
//		public override void Entry(double data, EntryTranslationMetaData metaData)
//		{
//			_writer.AddCell(_fastWorksheet, data, _styles[(int)Styles.DefaultNumber]);
//		}

//		/// <summary>
//		/// Pass a data read from the input to the Translator for processing.
//		/// </summary>
//		/// <param name="data">Value read from the input.</param>
//		/// <param name="metaData">MetaData describing the field.</param>
//		public override void Entry(DateTime data, EntryTranslationMetaData metaData)
//		{
//			_writer.AddCell(_fastWorksheet, data.ToString(), _styles[(int)Styles.DefaultText]);
//		}

//		/// <summary>
//		/// Pass a data read from the input to the Translator for processing.
//		/// </summary>
//		/// <param name="data">Value read from the input.</param>
//		/// <param name="metaData">MetaData describing the field.</param>
//		public override void Entry(string data, EntryTranslationMetaData metaData)
//		{
//			_writer.AddCell(_fastWorksheet, data, _styles[(int)Styles.DefaultText]);
//		}

//		/// <summary>
//		/// A new record (or line of data) was found.
//		/// </summary>
//		/// <param name="metaData">MetaData describing the record.</param>
//		public override void NewRecord(RecordTranslationMetaData metaData)
//		{
//			base.NewRecord(metaData);

//			_currentRecordMetaData = metaData;
//			_writer.AddRow(_fastWorksheet);
//		}

//		/// <summary>
//		/// A new table (or block of data) was found.
//		/// </summary>
//		/// <param name="metaData">MetaData describing the table.</param>
//		public override void NewTable(TableTranslationMetaData metaData)
//		{
//			base.NewTable(metaData);

//			// Create the worksheet and chart.
//			_fastWorksheet = _writer.CreateWorksheet(metaData.Name);

//			for (int i = 0; i < metaData.NumberOfColumns; i++)
//			{
//				// Columns are indexed from 1, not 0, so we add one for the column index.
//				_writer.AddColumn(_fastWorksheet, i+1);
//			}

//			// Header row.
//			_writer.AddRow(_fastWorksheet);

//			// Column headers.
//			for (int i = 0; i < metaData.NumberOfColumns; i++)
//			{
//				// Columns are indexed from 1, not 0, so we add one for the column index.
//				_writer.AddCell(_fastWorksheet, metaData.ColumnHeaders[i], _styles[(int)Styles.CenteredBold]);
//			}
//		}

//		/// <summary>
//		/// Close the output file.
//		/// </summary>
//		public override void Close()
//		{
//			_writer.Close();
//		}

//		#endregion

//		#region Styles

//		/// <summary>
//		/// Get a Color straight out of the array.
//		/// </summary>
//		/// <param name="color">ColorType to get.</param>
//		/// <returns>Color.</returns>
//		public string GetColorAsHex(ColorType color)
//		{
//			return System.Drawing.ColorTranslator.ToHtml(_featureColors[(int)color]).Replace("#", "");
//		}

//		/// <summary>
//		/// Generates content of workbookStylesPart. 
//		/// </summary>
//		/// <param name="spreadsheet">Spreadsheet to create styles for.</param>
//		private void GenerateWorkbookStyles(SpreadsheetDocument spreadsheet)
//		{
//			Stylesheet stylesheet = spreadsheet.WorkbookPart.WorkbookStylesPart.Stylesheet;

//			// Add a white, bold font.
//			_writer.AddFont(11, "Calibri", true, false, "FFFFFF");
//			_writer.AddFont(9, "Calibri", true, false);

//			// Fills.
//			_writer.AddFill(PatternValues.Solid, GetColorAsHex(ColorType.BestValuesExcelSheet), GetColorAsHex(ColorType.BestValuesExcelSheet));
//			_writer.AddFill(PatternValues.Solid, GetColorAsHex(ColorType.BaseLineExcelSheet), GetColorAsHex(ColorType.BaseLineExcelSheet));
//			_writer.AddFill(PatternValues.Solid, GetColorAsHex(ColorType.ComparisonExcelSheet), GetColorAsHex(ColorType.ComparisonExcelSheet));
//			_writer.AddFill(PatternValues.Solid, GetColorAsHex(ColorType.HighlightFill), GetColorAsHex(ColorType.HighlightFill));
//			_writer.AddFill(PatternValues.Solid, GetColorAsHex(ColorType.HighlightFill), GetColorAsHex(ColorType.DividerCells));

//			// Borders.
//			_writer.AddBorder(BorderStyleValues.Medium, GetColorAsHex(ColorType.BestValuesExcelSheet));
//			_writer.AddBorder(BorderStyleValues.Medium, GetColorAsHex(ColorType.BaseLineExcelSheet));
//			_writer.AddBorder(BorderStyleValues.Medium, GetColorAsHex(ColorType.ComparisonExcelSheet));


//			// Cell formats.
//			uint position			= 0;
//			CellFormats cellFormats = stylesheet.GetFirstChild<CellFormats>();

//			// The first two are established by the ExcelWriter.
//			// Default text format.
//			_styles[(int)Styles.DefaultText] = position++;

//			// Default number format.
//			_styles[(int)Styles.DefaultNumber] = position++;

//			// Text with border.
//			CellFormat cellFormat = new CellFormat()
//			{
//				NumberFormatId	= 0,
//				FontId			= 0,
//				FillId			= 0,
//				BorderId		= 1,
//				FormatId		= 0
//			};
//			cellFormats.Append(cellFormat);
//			_styles[(int)Styles.TextWithBorder] = position++;

//			// Number with border.
//			cellFormat = new CellFormat()
//			{
//				NumberFormatId	= 0,
//				FontId			= 0,
//				FillId			= 0,
//				BorderId		= 1,
//				FormatId		= 0
//			};
//			cellFormat.Append(new Alignment() {Horizontal = HorizontalAlignmentValues.Right});
//			cellFormats.Append(cellFormat);
//			_styles[(int)Styles.NumberWithBorder] = position++;

//			// Column header / centered bold.
//			cellFormat = new CellFormat()
//			{
//				NumberFormatId	= 0,
//				FontId			= 1,
//				FillId			= 0,
//				BorderId		= 0,
//				FormatId		= 0
//			};
//			cellFormat.Append(new Alignment() {Horizontal = HorizontalAlignmentValues.Center, Vertical = VerticalAlignmentValues.Center, WrapText = true});
//			cellFormats.Append(cellFormat);
//			_styles[(int)Styles.CenteredBold] = position++;

//			// Column header / centered bold with border.
//			cellFormat = new CellFormat()
//			{
//				NumberFormatId	= 0,
//				FontId			= 1,
//				FillId			= 0,
//				BorderId		= 1,
//				FormatId		= 0
//			};
//			cellFormat.Append(new Alignment() {Horizontal = HorizontalAlignmentValues.Center, Vertical = VerticalAlignmentValues.Center, WrapText = true});
//			cellFormats.Append(cellFormat);
//			_styles[(int)Styles.CenteredBoldWithBorder] = position++;

//			// Best values header 1.
//			cellFormat = new CellFormat()
//			{
//				NumberFormatId	= 0,
//				FontId			= 3,
//				FillId			= 0,
//				BorderId		= 2,
//				FormatId		= 0,
//				ApplyFont		= true,
//				ApplyAlignment	= true
//			};
//			cellFormat.Append(new Alignment() {Horizontal = HorizontalAlignmentValues.Center, Vertical = VerticalAlignmentValues.Center, WrapText = true});
//			cellFormats.Append(cellFormat);
//			_styles[(int)Styles.RoadMapHeader1] = position++;

//			// Best values header 2.
//			cellFormat = new CellFormat()
//			{
//				NumberFormatId	= 0,
//				FontId			= 1,
//				FillId			= 0,
//				BorderId		= 2,
//				FormatId		= 0,
//				ApplyFont		= true,
//				ApplyAlignment	= true
//			};
//			cellFormat.Append(new Alignment() {Horizontal = HorizontalAlignmentValues.Center, Vertical = VerticalAlignmentValues.Center, WrapText = true});
//			cellFormats.Append(cellFormat);
//			_styles[(int)Styles.RoadMapHeader2] = position++;

//			// Best values header 3.
//			cellFormat = new CellFormat()
//			{
//				NumberFormatId	= 0,
//				FontId			= 2,
//				FillId			= 2,
//				BorderId		= 2,
//				FormatId		= 0,
//				ApplyFont		= true,
//				ApplyAlignment	= true
//			};
//			cellFormat.Append(new Alignment() {Horizontal = HorizontalAlignmentValues.Center, Vertical = VerticalAlignmentValues.Center, WrapText = true});
//			cellFormats.Append(cellFormat);
//			_styles[(int)Styles.RoadMapHeader3] = position++;

//			// Base line well header 1.
//			cellFormat = new CellFormat()
//			{
//				NumberFormatId	= 0,
//				FontId			= 1,
//				FillId			= 0,
//				BorderId		= 3,
//				FormatId		= 0,
//				ApplyFont		= true,
//				ApplyAlignment	= true
//			};
//			cellFormat.Append(new Alignment() {Horizontal = HorizontalAlignmentValues.Center, Vertical = VerticalAlignmentValues.Center});
//			cellFormats.Append(cellFormat);
//			_styles[(int)Styles.BaseLineHeader1] = position++;

//			// Base line well header 2.
//			cellFormat = new CellFormat()
//			{
//				NumberFormatId	= 0,
//				FontId			= 2,
//				FillId			= 3,
//				BorderId		= 3,
//				FormatId		= 0,
//				ApplyFont		= true,
//				ApplyAlignment	= true
//			};
//			cellFormat.Append(new Alignment() {Horizontal = HorizontalAlignmentValues.Center, Vertical = VerticalAlignmentValues.Center, WrapText = true});
//			cellFormats.Append(cellFormat);
//			_styles[(int)Styles.BaseLineHeader2] = position++;

//			// Comparison well header 1.
//			cellFormat = new CellFormat()
//			{
//				NumberFormatId	= 0,
//				FontId			= 1,
//				FillId			= 0,
//				BorderId		= 4,
//				FormatId		= 0,
//				ApplyFont		= true,
//				ApplyAlignment	= true
//			};
//			cellFormat.Append(new Alignment() {Horizontal = HorizontalAlignmentValues.Center, Vertical = VerticalAlignmentValues.Center});
//			cellFormats.Append(cellFormat);
//			_styles[(int)Styles.ComparisonHeader1] = position++;

//			// Comparison well header 2.
//			cellFormat = new CellFormat()
//			{
//				NumberFormatId	= 0,
//				FontId			= 2,
//				FillId			= 4,
//				BorderId		= 4,
//				FormatId		= 0,
//				ApplyFont		= true,
//				ApplyAlignment	= true
//			};
//			cellFormat.Append(new Alignment() {Horizontal = HorizontalAlignmentValues.Center, Vertical = VerticalAlignmentValues.Center, WrapText = true});
//			cellFormats.Append(cellFormat);
//			_styles[(int)Styles.ComparisonHeader2] = position++;

//			// Best values body.
//			cellFormat = new CellFormat()
//			{
//				NumberFormatId		= 1,
//				FontId				= 0,
//				FillId				= 5,
//				BorderId			= 2,
//				FormatId			= 0,
//				ApplyNumberFormat	= true,
//				ApplyAlignment		= true
//			};
//			cellFormat.Append(new Alignment() {Horizontal = HorizontalAlignmentValues.Right});
//			cellFormats.Append(cellFormat);
//			_styles[(int)Styles.BestValuesBody] = position++;

//			// Base line values body.
//			cellFormat = new CellFormat()
//			{
//				NumberFormatId		= 1,
//				FontId				= 0,
//				FillId				= 0,
//				BorderId			= 3,
//				FormatId			= 0,
//				ApplyNumberFormat	= true,
//				ApplyAlignment		= true
//			};
//			cellFormat.Append(new Alignment() {Horizontal = HorizontalAlignmentValues.Right});
//			cellFormats.Append(cellFormat);
//			_styles[(int)Styles.BaseLineBody] = position++;

//			// Comparison well body.
//			cellFormat = new CellFormat()
//			{
//				NumberFormatId	= 1,
//				FontId			= 0,
//				FillId			= 0,
//				BorderId		= 4,
//				FormatId		= 0,
//				ApplyFont		= true,
//				ApplyAlignment	= true
//			};
//			cellFormat.Append(new Alignment() {Horizontal = HorizontalAlignmentValues.Right});
//			cellFormats.Append(cellFormat);
//			_styles[(int)Styles.ComparisonBody] = position++;

//			// Differential formats.  Reset position as these formats are in their own list and start from 0 again.
//			position			= 0;

//			// Comparison well body - good.
//			_writer.AddDifferentialFontFormat(GetColorAsHex(ColorType.ComparisonGoodROP));
//			_styles[(int)Styles.ComparisonBodyGoodROP] = position++;

//			// Comparison well body - bad.
//			_writer.AddDifferentialFontFormat(GetColorAsHex(ColorType.ComparisonBadROP));
//			_styles[(int)Styles.ComparisonBodyBadROP] = position++;
//		}

//		#endregion

//	} // End class.
//}