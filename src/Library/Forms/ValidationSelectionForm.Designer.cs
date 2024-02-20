namespace DataConverter
{
	partial class ValidationSelectionForm
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
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonOK = new System.Windows.Forms.Button();
			this.checkBoxNumberOfColumnValidation = new System.Windows.Forms.CheckBox();
			this.checkBoxDateFormatValidation = new System.Windows.Forms.CheckBox();
			this.checkBoxHighPassDateValidation = new System.Windows.Forms.CheckBox();
			this.dateTimePickerHighPassDateValidation = new System.Windows.Forms.DateTimePicker();
			this.checkBoxLowPassDateValidation = new System.Windows.Forms.CheckBox();
			this.dateTimePickerLowPassDateValidation = new System.Windows.Forms.DateTimePicker();
			this.dateTimePickerHighPassTimeValidation = new System.Windows.Forms.DateTimePicker();
			this.dateTimePickerLowPassTimeValidation = new System.Windows.Forms.DateTimePicker();
			this.SuspendLayout();
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(294, 206);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(80, 23);
			this.buttonCancel.TabIndex = 4;
			this.buttonCancel.Text = "&Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			// 
			// buttonOK
			// 
			this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOK.Location = new System.Drawing.Point(196, 206);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(80, 23);
			this.buttonOK.TabIndex = 3;
			this.buttonOK.Text = "&OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new System.EventHandler(this.bntOK_Click);
			// 
			// checkBoxNumberOfColumnValidation
			// 
			this.checkBoxNumberOfColumnValidation.AutoSize = true;
			this.checkBoxNumberOfColumnValidation.Location = new System.Drawing.Point(12, 14);
			this.checkBoxNumberOfColumnValidation.Name = "checkBoxNumberOfColumnValidation";
			this.checkBoxNumberOfColumnValidation.Size = new System.Drawing.Size(349, 17);
			this.checkBoxNumberOfColumnValidation.TabIndex = 12;
			this.checkBoxNumberOfColumnValidation.Text = "Number of columns in record must match number of column headers.";
			this.checkBoxNumberOfColumnValidation.UseVisualStyleBackColor = true;
			// 
			// checkBoxDateFormatValidation
			// 
			this.checkBoxDateFormatValidation.AutoSize = true;
			this.checkBoxDateFormatValidation.Location = new System.Drawing.Point(12, 47);
			this.checkBoxDateFormatValidation.Name = "checkBoxDateFormatValidation";
			this.checkBoxDateFormatValidation.Size = new System.Drawing.Size(191, 17);
			this.checkBoxDateFormatValidation.TabIndex = 19;
			this.checkBoxDateFormatValidation.Text = "Entries must be formatted correctly.";
			this.checkBoxDateFormatValidation.UseVisualStyleBackColor = true;
			// 
			// checkBoxHighPassDateValidation
			// 
			this.checkBoxHighPassDateValidation.AutoSize = true;
			this.checkBoxHighPassDateValidation.Location = new System.Drawing.Point(12, 80);
			this.checkBoxHighPassDateValidation.Name = "checkBoxHighPassDateValidation";
			this.checkBoxHighPassDateValidation.Size = new System.Drawing.Size(193, 17);
			this.checkBoxHighPassDateValidation.TabIndex = 20;
			this.checkBoxHighPassDateValidation.Text = "Exclude records BEFORE the date:";
			this.checkBoxHighPassDateValidation.UseVisualStyleBackColor = true;
			this.checkBoxHighPassDateValidation.CheckedChanged += new System.EventHandler(this.checkBoxHighPassDateValidation_CheckedChanged);
			// 
			// dateTimePickerHighPassDateValidation
			// 
			this.dateTimePickerHighPassDateValidation.Location = new System.Drawing.Point(48, 104);
			this.dateTimePickerHighPassDateValidation.Name = "dateTimePickerHighPassDateValidation";
			this.dateTimePickerHighPassDateValidation.Size = new System.Drawing.Size(200, 20);
			this.dateTimePickerHighPassDateValidation.TabIndex = 21;
			this.dateTimePickerHighPassDateValidation.Value = new System.DateTime(2015, 1, 1, 0, 0, 0, 0);
			// 
			// checkBoxLowPassDateValidation
			// 
			this.checkBoxLowPassDateValidation.AutoSize = true;
			this.checkBoxLowPassDateValidation.Location = new System.Drawing.Point(12, 137);
			this.checkBoxLowPassDateValidation.Name = "checkBoxLowPassDateValidation";
			this.checkBoxLowPassDateValidation.Size = new System.Drawing.Size(185, 17);
			this.checkBoxLowPassDateValidation.TabIndex = 22;
			this.checkBoxLowPassDateValidation.Text = "Exclude records AFTER the date:";
			this.checkBoxLowPassDateValidation.UseVisualStyleBackColor = true;
			this.checkBoxLowPassDateValidation.CheckedChanged += new System.EventHandler(this.checkBoxLowPassDateValidation_CheckedChanged);
			// 
			// dateTimePickerLowPassDateValidation
			// 
			this.dateTimePickerLowPassDateValidation.Location = new System.Drawing.Point(48, 160);
			this.dateTimePickerLowPassDateValidation.Name = "dateTimePickerLowPassDateValidation";
			this.dateTimePickerLowPassDateValidation.Size = new System.Drawing.Size(200, 20);
			this.dateTimePickerLowPassDateValidation.TabIndex = 23;
			this.dateTimePickerLowPassDateValidation.Value = new System.DateTime(2015, 1, 1, 0, 0, 0, 0);
			// 
			// dateTimePickerHighPassTimeValidation
			// 
			this.dateTimePickerHighPassTimeValidation.Format = System.Windows.Forms.DateTimePickerFormat.Time;
			this.dateTimePickerHighPassTimeValidation.Location = new System.Drawing.Point(254, 104);
			this.dateTimePickerHighPassTimeValidation.Name = "dateTimePickerHighPassTimeValidation";
			this.dateTimePickerHighPassTimeValidation.ShowUpDown = true;
			this.dateTimePickerHighPassTimeValidation.Size = new System.Drawing.Size(120, 20);
			this.dateTimePickerHighPassTimeValidation.TabIndex = 24;
			this.dateTimePickerHighPassTimeValidation.Value = new System.DateTime(2015, 1, 1, 0, 0, 0, 0);
			// 
			// dateTimePickerLowPassTimeValidation
			// 
			this.dateTimePickerLowPassTimeValidation.Format = System.Windows.Forms.DateTimePickerFormat.Time;
			this.dateTimePickerLowPassTimeValidation.Location = new System.Drawing.Point(254, 160);
			this.dateTimePickerLowPassTimeValidation.Name = "dateTimePickerLowPassTimeValidation";
			this.dateTimePickerLowPassTimeValidation.ShowUpDown = true;
			this.dateTimePickerLowPassTimeValidation.Size = new System.Drawing.Size(120, 20);
			this.dateTimePickerLowPassTimeValidation.TabIndex = 25;
			this.dateTimePickerLowPassTimeValidation.Value = new System.DateTime(2015, 1, 1, 0, 0, 0, 0);
			// 
			// ValidationSelectionForm
			// 
			this.AcceptButton = this.buttonOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(386, 241);
			this.Controls.Add(this.dateTimePickerLowPassTimeValidation);
			this.Controls.Add(this.dateTimePickerHighPassTimeValidation);
			this.Controls.Add(this.dateTimePickerLowPassDateValidation);
			this.Controls.Add(this.checkBoxLowPassDateValidation);
			this.Controls.Add(this.dateTimePickerHighPassDateValidation);
			this.Controls.Add(this.checkBoxHighPassDateValidation);
			this.Controls.Add(this.checkBoxDateFormatValidation);
			this.Controls.Add(this.checkBoxNumberOfColumnValidation);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOK);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ValidationSelectionForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Validation";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.CheckBox checkBoxNumberOfColumnValidation;
		private System.Windows.Forms.CheckBox checkBoxDateFormatValidation;
		private System.Windows.Forms.CheckBox checkBoxHighPassDateValidation;
		private System.Windows.Forms.DateTimePicker dateTimePickerHighPassDateValidation;
		private System.Windows.Forms.CheckBox checkBoxLowPassDateValidation;
		private System.Windows.Forms.DateTimePicker dateTimePickerLowPassDateValidation;
		private System.Windows.Forms.DateTimePicker dateTimePickerHighPassTimeValidation;
		private System.Windows.Forms.DateTimePicker dateTimePickerLowPassTimeValidation;
	}
}