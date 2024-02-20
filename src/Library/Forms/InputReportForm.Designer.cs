namespace DataConverter
{
	partial class InputReportForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.buttonOK = new System.Windows.Forms.Button();
			this.labelNumberOfLinesRead = new System.Windows.Forms.Label();
			this.textBoxNumberOfLines = new System.Windows.Forms.TextBox();
			this.textBoxNumberOfRecords = new System.Windows.Forms.TextBox();
			this.labelNumberOfRecords = new System.Windows.Forms.Label();
			this.labelCorruptionReport = new System.Windows.Forms.Label();
			this.textBoxNumberOfCorruptedRecords = new System.Windows.Forms.TextBox();
			this.textBoxCorruptionReport = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// buttonOK
			// 
			this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOK.Location = new System.Drawing.Point(212, 235);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(80, 23);
			this.buttonOK.TabIndex = 3;
			this.buttonOK.Text = "&OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			// 
			// labelNumberOfLinesRead
			// 
			this.labelNumberOfLinesRead.AutoSize = true;
			this.labelNumberOfLinesRead.Location = new System.Drawing.Point(12, 13);
			this.labelNumberOfLinesRead.Name = "labelNumberOfLinesRead";
			this.labelNumberOfLinesRead.Size = new System.Drawing.Size(104, 13);
			this.labelNumberOfLinesRead.TabIndex = 9;
			this.labelNumberOfLinesRead.Text = "Number of lines read";
			// 
			// textBoxNumberOfLines
			// 
			this.textBoxNumberOfLines.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxNumberOfLines.Location = new System.Drawing.Point(212, 10);
			this.textBoxNumberOfLines.Name = "textBoxNumberOfLines";
			this.textBoxNumberOfLines.ReadOnly = true;
			this.textBoxNumberOfLines.Size = new System.Drawing.Size(80, 20);
			this.textBoxNumberOfLines.TabIndex = 11;
			this.textBoxNumberOfLines.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// textBoxNumberOfRecords
			// 
			this.textBoxNumberOfRecords.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxNumberOfRecords.Location = new System.Drawing.Point(212, 36);
			this.textBoxNumberOfRecords.Name = "textBoxNumberOfRecords";
			this.textBoxNumberOfRecords.ReadOnly = true;
			this.textBoxNumberOfRecords.Size = new System.Drawing.Size(80, 20);
			this.textBoxNumberOfRecords.TabIndex = 13;
			this.textBoxNumberOfRecords.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// labelNumberOfRecords
			// 
			this.labelNumberOfRecords.AutoSize = true;
			this.labelNumberOfRecords.Location = new System.Drawing.Point(12, 39);
			this.labelNumberOfRecords.Name = "labelNumberOfRecords";
			this.labelNumberOfRecords.Size = new System.Drawing.Size(94, 13);
			this.labelNumberOfRecords.TabIndex = 12;
			this.labelNumberOfRecords.Text = "Number of records";
			// 
			// labelCorruptionReport
			// 
			this.labelCorruptionReport.AutoSize = true;
			this.labelCorruptionReport.Location = new System.Drawing.Point(12, 65);
			this.labelCorruptionReport.Name = "labelCorruptionReport";
			this.labelCorruptionReport.Size = new System.Drawing.Size(142, 13);
			this.labelCorruptionReport.TabIndex = 14;
			this.labelCorruptionReport.Text = "Number of corrupted records";
			// 
			// textBoxNumberOfCorruptedRecords
			// 
			this.textBoxNumberOfCorruptedRecords.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxNumberOfCorruptedRecords.Location = new System.Drawing.Point(212, 62);
			this.textBoxNumberOfCorruptedRecords.Name = "textBoxNumberOfCorruptedRecords";
			this.textBoxNumberOfCorruptedRecords.ReadOnly = true;
			this.textBoxNumberOfCorruptedRecords.Size = new System.Drawing.Size(80, 20);
			this.textBoxNumberOfCorruptedRecords.TabIndex = 15;
			this.textBoxNumberOfCorruptedRecords.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// textBoxCorruptionReport
			// 
			this.textBoxCorruptionReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxCorruptionReport.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxCorruptionReport.Location = new System.Drawing.Point(15, 119);
			this.textBoxCorruptionReport.Multiline = true;
			this.textBoxCorruptionReport.Name = "textBoxCorruptionReport";
			this.textBoxCorruptionReport.ReadOnly = true;
			this.textBoxCorruptionReport.Size = new System.Drawing.Size(277, 110);
			this.textBoxCorruptionReport.TabIndex = 17;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 102);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(83, 13);
			this.label1.TabIndex = 16;
			this.label1.Text = "Corrupted report";
			// 
			// InputReportForm
			// 
			this.AcceptButton = this.buttonOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(304, 270);
			this.Controls.Add(this.textBoxCorruptionReport);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBoxNumberOfCorruptedRecords);
			this.Controls.Add(this.labelCorruptionReport);
			this.Controls.Add(this.textBoxNumberOfRecords);
			this.Controls.Add(this.labelNumberOfRecords);
			this.Controls.Add(this.textBoxNumberOfLines);
			this.Controls.Add(this.labelNumberOfLinesRead);
			this.Controls.Add(this.buttonOK);
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(320, 1000);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(320, 38);
			this.Name = "InputReportForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Input Statistics";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Label labelNumberOfLinesRead;
		private System.Windows.Forms.TextBox textBoxNumberOfLines;
		private System.Windows.Forms.TextBox textBoxNumberOfRecords;
		private System.Windows.Forms.Label labelNumberOfRecords;
		private System.Windows.Forms.Label labelCorruptionReport;
		private System.Windows.Forms.TextBox textBoxNumberOfCorruptedRecords;
		private System.Windows.Forms.TextBox textBoxCorruptionReport;
		private System.Windows.Forms.Label label1;
	}
}