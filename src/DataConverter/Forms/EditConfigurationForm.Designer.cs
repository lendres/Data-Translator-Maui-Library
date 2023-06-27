namespace DataConverter
{
	partial class EditConfigurationForm
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
			this.labelTranslationMatrixFile = new System.Windows.Forms.Label();
			this.textBoxName = new System.Windows.Forms.TextBox();
			this.labelName = new System.Windows.Forms.Label();
			this.comboBoxInputProcessor = new System.Windows.Forms.ComboBox();
			this.labelInputProcessor = new System.Windows.Forms.Label();
			this.labelOutputProcesssor = new System.Windows.Forms.Label();
			this.comboBoxOutputProcessor = new System.Windows.Forms.ComboBox();
			this.comboBoxTranslationMatrix = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.CausesValidation = false;
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(440, 224);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(80, 23);
			this.buttonCancel.TabIndex = 10;
			this.buttonCancel.Text = "&Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			// 
			// buttonOK
			// 
			this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOK.Location = new System.Drawing.Point(342, 224);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(80, 23);
			this.buttonOK.TabIndex = 9;
			this.buttonOK.Text = "&OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// labelTranslationMatrixFile
			// 
			this.labelTranslationMatrixFile.AutoSize = true;
			this.labelTranslationMatrixFile.Location = new System.Drawing.Point(9, 64);
			this.labelTranslationMatrixFile.Name = "labelTranslationMatrixFile";
			this.labelTranslationMatrixFile.Size = new System.Drawing.Size(109, 13);
			this.labelTranslationMatrixFile.TabIndex = 2;
			this.labelTranslationMatrixFile.Text = "Translation Matrix File";
			// 
			// textBoxName
			// 
			this.textBoxName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxName.Location = new System.Drawing.Point(12, 24);
			this.textBoxName.Name = "textBoxName";
			this.textBoxName.Size = new System.Drawing.Size(508, 20);
			this.textBoxName.TabIndex = 1;
			// 
			// labelName
			// 
			this.labelName.AutoSize = true;
			this.labelName.Location = new System.Drawing.Point(9, 8);
			this.labelName.Name = "labelName";
			this.labelName.Size = new System.Drawing.Size(35, 13);
			this.labelName.TabIndex = 0;
			this.labelName.Text = "Name";
			// 
			// comboBoxInputProcessor
			// 
			this.comboBoxInputProcessor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBoxInputProcessor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxInputProcessor.FormattingEnabled = true;
			this.comboBoxInputProcessor.Location = new System.Drawing.Point(12, 129);
			this.comboBoxInputProcessor.Name = "comboBoxInputProcessor";
			this.comboBoxInputProcessor.Size = new System.Drawing.Size(507, 21);
			this.comboBoxInputProcessor.TabIndex = 6;
			// 
			// labelInputProcessor
			// 
			this.labelInputProcessor.AutoSize = true;
			this.labelInputProcessor.Location = new System.Drawing.Point(9, 113);
			this.labelInputProcessor.Name = "labelInputProcessor";
			this.labelInputProcessor.Size = new System.Drawing.Size(81, 13);
			this.labelInputProcessor.TabIndex = 5;
			this.labelInputProcessor.Text = "Input Processor";
			// 
			// labelOutputProcesssor
			// 
			this.labelOutputProcesssor.AutoSize = true;
			this.labelOutputProcesssor.Location = new System.Drawing.Point(9, 164);
			this.labelOutputProcesssor.Name = "labelOutputProcesssor";
			this.labelOutputProcesssor.Size = new System.Drawing.Size(89, 13);
			this.labelOutputProcesssor.TabIndex = 7;
			this.labelOutputProcesssor.Text = "Output Processor";
			// 
			// comboBoxOutputProcessor
			// 
			this.comboBoxOutputProcessor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBoxOutputProcessor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxOutputProcessor.FormattingEnabled = true;
			this.comboBoxOutputProcessor.Location = new System.Drawing.Point(12, 180);
			this.comboBoxOutputProcessor.Name = "comboBoxOutputProcessor";
			this.comboBoxOutputProcessor.Size = new System.Drawing.Size(507, 21);
			this.comboBoxOutputProcessor.TabIndex = 8;
			// 
			// comboBoxTranslationMatrix
			// 
			this.comboBoxTranslationMatrix.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBoxTranslationMatrix.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxTranslationMatrix.FormattingEnabled = true;
			this.comboBoxTranslationMatrix.Location = new System.Drawing.Point(12, 80);
			this.comboBoxTranslationMatrix.Name = "comboBoxTranslationMatrix";
			this.comboBoxTranslationMatrix.Size = new System.Drawing.Size(507, 21);
			this.comboBoxTranslationMatrix.TabIndex = 11;
			// 
			// EditConfigurationForm
			// 
			this.AcceptButton = this.buttonOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(532, 259);
			this.Controls.Add(this.comboBoxTranslationMatrix);
			this.Controls.Add(this.labelOutputProcesssor);
			this.Controls.Add(this.comboBoxOutputProcessor);
			this.Controls.Add(this.labelInputProcessor);
			this.Controls.Add(this.comboBoxInputProcessor);
			this.Controls.Add(this.textBoxName);
			this.Controls.Add(this.labelName);
			this.Controls.Add(this.labelTranslationMatrixFile);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOK);
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(4000, 297);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(548, 297);
			this.Name = "EditConfigurationForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Edit Configuration";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Label labelTranslationMatrixFile;
		private System.Windows.Forms.TextBox textBoxName;
		private System.Windows.Forms.Label labelName;
		private System.Windows.Forms.ComboBox comboBoxInputProcessor;
		private System.Windows.Forms.Label labelInputProcessor;
		private System.Windows.Forms.Label labelOutputProcesssor;
		private System.Windows.Forms.ComboBox comboBoxOutputProcessor;
		private System.Windows.Forms.ComboBox comboBoxTranslationMatrix;

	} // End class.
} // End namespace.