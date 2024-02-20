namespace DataConverter
{
	partial class NewOrExistingConfigurationForm
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
			this.radioButtonEditConfiguration = new System.Windows.Forms.RadioButton();
			this.radioButtonNewConfiguration = new System.Windows.Forms.RadioButton();
			this.comboBoxEditExistingFile = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(440, 115);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(80, 23);
			this.buttonCancel.TabIndex = 4;
			this.buttonCancel.Text = "&Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// buttonOK
			// 
			this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOK.Location = new System.Drawing.Point(342, 115);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(80, 23);
			this.buttonOK.TabIndex = 3;
			this.buttonOK.Text = "&OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// radioButtonEditConfiguration
			// 
			this.radioButtonEditConfiguration.AutoSize = true;
			this.radioButtonEditConfiguration.Location = new System.Drawing.Point(13, 45);
			this.radioButtonEditConfiguration.Name = "radioButtonEditConfiguration";
			this.radioButtonEditConfiguration.Size = new System.Drawing.Size(147, 17);
			this.radioButtonEditConfiguration.TabIndex = 1;
			this.radioButtonEditConfiguration.TabStop = true;
			this.radioButtonEditConfiguration.Text = "Edit Existing Configuration";
			this.radioButtonEditConfiguration.UseVisualStyleBackColor = true;
			this.radioButtonEditConfiguration.CheckedChanged += new System.EventHandler(this.radioButtonExistingConfiguration_CheckedChanged);
			// 
			// radioButtonNewConfiguration
			// 
			this.radioButtonNewConfiguration.AutoSize = true;
			this.radioButtonNewConfiguration.Location = new System.Drawing.Point(13, 11);
			this.radioButtonNewConfiguration.Name = "radioButtonNewConfiguration";
			this.radioButtonNewConfiguration.Size = new System.Drawing.Size(155, 17);
			this.radioButtonNewConfiguration.TabIndex = 0;
			this.radioButtonNewConfiguration.TabStop = true;
			this.radioButtonNewConfiguration.Text = "Create a New Configuration";
			this.radioButtonNewConfiguration.UseVisualStyleBackColor = true;
			this.radioButtonNewConfiguration.CheckedChanged += new System.EventHandler(this.radioButtonNewConfiguration_CheckedChanged);
			// 
			// comboBoxEditExistingFile
			// 
			this.comboBoxEditExistingFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBoxEditExistingFile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxEditExistingFile.FormattingEnabled = true;
			this.comboBoxEditExistingFile.Location = new System.Drawing.Point(35, 69);
			this.comboBoxEditExistingFile.Name = "comboBoxEditExistingFile";
			this.comboBoxEditExistingFile.Size = new System.Drawing.Size(485, 21);
			this.comboBoxEditExistingFile.TabIndex = 2;
			// 
			// NewOrExistingConfigurationForm
			// 
			this.AcceptButton = this.buttonOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(532, 150);
			this.Controls.Add(this.comboBoxEditExistingFile);
			this.Controls.Add(this.radioButtonNewConfiguration);
			this.Controls.Add(this.radioButtonEditConfiguration);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOK);
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(5000, 188);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(400, 188);
			this.Name = "NewOrExistingConfigurationForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Configurations";
			this.Load += new System.EventHandler(this.NewOrExistingConfigurationForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.RadioButton radioButtonEditConfiguration;
		private System.Windows.Forms.RadioButton radioButtonNewConfiguration;
		private System.Windows.Forms.ComboBox comboBoxEditExistingFile;
	}
}