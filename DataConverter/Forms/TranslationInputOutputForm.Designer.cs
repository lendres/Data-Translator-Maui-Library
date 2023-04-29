namespace DataConverter
{
	partial class TranslationInputOutputForm
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
			this.labelConfiguration = new System.Windows.Forms.Label();
			this.textBoxOutputFile = new System.Windows.Forms.TextBox();
			this.buttonBrowseOutput = new System.Windows.Forms.Button();
			this.labelOutputFile = new System.Windows.Forms.Label();
			this.textBoxInputFile = new System.Windows.Forms.TextBox();
			this.buttonBrowseInput = new System.Windows.Forms.Button();
			this.labelInputFile = new System.Windows.Forms.Label();
			this.comboBoxConfiguration = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(440, 186);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(80, 23);
			this.buttonCancel.TabIndex = 9;
			this.buttonCancel.Text = "&Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			// 
			// buttonOK
			// 
			this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOK.Location = new System.Drawing.Point(342, 186);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(80, 23);
			this.buttonOK.TabIndex = 8;
			this.buttonOK.Text = "&OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new System.EventHandler(this.bntOK_Click);
			// 
			// labelConfiguration
			// 
			this.labelConfiguration.AutoSize = true;
			this.labelConfiguration.Location = new System.Drawing.Point(11, 9);
			this.labelConfiguration.Name = "labelConfiguration";
			this.labelConfiguration.Size = new System.Drawing.Size(69, 13);
			this.labelConfiguration.TabIndex = 0;
			this.labelConfiguration.Text = "Configuration";
			// 
			// textBoxOutputFile
			// 
			this.textBoxOutputFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxOutputFile.Location = new System.Drawing.Point(14, 142);
			this.textBoxOutputFile.Name = "textBoxOutputFile";
			this.textBoxOutputFile.Size = new System.Drawing.Size(417, 20);
			this.textBoxOutputFile.TabIndex = 6;
			// 
			// buttonBrowseOutput
			// 
			this.buttonBrowseOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonBrowseOutput.Location = new System.Drawing.Point(442, 140);
			this.buttonBrowseOutput.Name = "buttonBrowseOutput";
			this.buttonBrowseOutput.Size = new System.Drawing.Size(80, 23);
			this.buttonBrowseOutput.TabIndex = 7;
			this.buttonBrowseOutput.Text = "Browse...";
			this.buttonBrowseOutput.UseVisualStyleBackColor = true;
			this.buttonBrowseOutput.Click += new System.EventHandler(this.buttonBrowseOutput_Click);
			// 
			// labelOutputFile
			// 
			this.labelOutputFile.AutoSize = true;
			this.labelOutputFile.Location = new System.Drawing.Point(11, 126);
			this.labelOutputFile.Name = "labelOutputFile";
			this.labelOutputFile.Size = new System.Drawing.Size(58, 13);
			this.labelOutputFile.TabIndex = 5;
			this.labelOutputFile.Text = "Output File";
			// 
			// textBoxInputFile
			// 
			this.textBoxInputFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxInputFile.Location = new System.Drawing.Point(14, 85);
			this.textBoxInputFile.Name = "textBoxInputFile";
			this.textBoxInputFile.Size = new System.Drawing.Size(417, 20);
			this.textBoxInputFile.TabIndex = 3;
			// 
			// buttonBrowseInput
			// 
			this.buttonBrowseInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonBrowseInput.Location = new System.Drawing.Point(442, 83);
			this.buttonBrowseInput.Name = "buttonBrowseInput";
			this.buttonBrowseInput.Size = new System.Drawing.Size(80, 23);
			this.buttonBrowseInput.TabIndex = 4;
			this.buttonBrowseInput.Text = "Browse...";
			this.buttonBrowseInput.UseVisualStyleBackColor = true;
			this.buttonBrowseInput.Click += new System.EventHandler(this.buttonBrowseInput_Click);
			// 
			// labelInputFile
			// 
			this.labelInputFile.AutoSize = true;
			this.labelInputFile.Location = new System.Drawing.Point(11, 69);
			this.labelInputFile.Name = "labelInputFile";
			this.labelInputFile.Size = new System.Drawing.Size(50, 13);
			this.labelInputFile.TabIndex = 2;
			this.labelInputFile.Text = "Input File";
			// 
			// comboBoxConfiguration
			// 
			this.comboBoxConfiguration.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBoxConfiguration.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxConfiguration.FormattingEnabled = true;
			this.comboBoxConfiguration.Location = new System.Drawing.Point(12, 26);
			this.comboBoxConfiguration.Name = "comboBoxConfiguration";
			this.comboBoxConfiguration.Size = new System.Drawing.Size(419, 21);
			this.comboBoxConfiguration.TabIndex = 1;
			this.comboBoxConfiguration.SelectedIndexChanged += new System.EventHandler(this.comboBoxConfiguration_SelectedIndexChanged);
			// 
			// TranslationInputOutputForm
			// 
			this.AcceptButton = this.buttonOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(532, 221);
			this.Controls.Add(this.comboBoxConfiguration);
			this.Controls.Add(this.labelConfiguration);
			this.Controls.Add(this.textBoxOutputFile);
			this.Controls.Add(this.buttonBrowseOutput);
			this.Controls.Add(this.labelOutputFile);
			this.Controls.Add(this.textBoxInputFile);
			this.Controls.Add(this.buttonBrowseInput);
			this.Controls.Add(this.labelInputFile);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOK);
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(5000, 259);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(400, 259);
			this.Name = "TranslationInputOutputForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Translate";
			this.Load += new System.EventHandler(this.TranslationInputOutputForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Label labelConfiguration;
		private System.Windows.Forms.TextBox textBoxOutputFile;
		private System.Windows.Forms.Button buttonBrowseOutput;
		private System.Windows.Forms.Label labelOutputFile;
		private System.Windows.Forms.TextBox textBoxInputFile;
		private System.Windows.Forms.Button buttonBrowseInput;
		private System.Windows.Forms.Label labelInputFile;
		private System.Windows.Forms.ComboBox comboBoxConfiguration;
	}
}