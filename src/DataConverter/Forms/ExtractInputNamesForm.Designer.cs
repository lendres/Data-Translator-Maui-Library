namespace DataConverter
{
	partial class ExtractInputNamesForm
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
			this.textBoxInputSource = new System.Windows.Forms.TextBox();
			this.buttonBrowseInputSource = new System.Windows.Forms.Button();
			this.labelInputSource = new System.Windows.Forms.Label();
			this.comboBoxInputProcessor = new System.Windows.Forms.ComboBox();
			this.labelInputProcessor = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.CausesValidation = false;
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(440, 112);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(80, 23);
			this.buttonCancel.TabIndex = 6;
			this.buttonCancel.Text = "&Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			// 
			// buttonOK
			// 
			this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOK.Location = new System.Drawing.Point(342, 112);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(80, 23);
			this.buttonOK.TabIndex = 5;
			this.buttonOK.Text = "&OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// textBoxInputSource
			// 
			this.textBoxInputSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxInputSource.Location = new System.Drawing.Point(12, 74);
			this.textBoxInputSource.Name = "textBoxInputSource";
			this.textBoxInputSource.Size = new System.Drawing.Size(417, 20);
			this.textBoxInputSource.TabIndex = 3;
			// 
			// buttonBrowseInputSource
			// 
			this.buttonBrowseInputSource.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonBrowseInputSource.Location = new System.Drawing.Point(440, 72);
			this.buttonBrowseInputSource.Name = "buttonBrowseInputSource";
			this.buttonBrowseInputSource.Size = new System.Drawing.Size(80, 23);
			this.buttonBrowseInputSource.TabIndex = 4;
			this.buttonBrowseInputSource.Text = "Browse...";
			this.buttonBrowseInputSource.UseVisualStyleBackColor = true;
			this.buttonBrowseInputSource.Click += new System.EventHandler(this.buttonBrowseInputSource_Click);
			// 
			// labelInputSource
			// 
			this.labelInputSource.AutoSize = true;
			this.labelInputSource.Location = new System.Drawing.Point(9, 58);
			this.labelInputSource.Name = "labelInputSource";
			this.labelInputSource.Size = new System.Drawing.Size(68, 13);
			this.labelInputSource.TabIndex = 2;
			this.labelInputSource.Text = "Input Source";
			// 
			// comboBoxInputProcessor
			// 
			this.comboBoxInputProcessor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBoxInputProcessor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxInputProcessor.FormattingEnabled = true;
			this.comboBoxInputProcessor.Location = new System.Drawing.Point(12, 24);
			this.comboBoxInputProcessor.Name = "comboBoxInputProcessor";
			this.comboBoxInputProcessor.Size = new System.Drawing.Size(507, 21);
			this.comboBoxInputProcessor.TabIndex = 1;
			this.comboBoxInputProcessor.SelectedIndexChanged += new System.EventHandler(this.comboBoxInputProcessor_SelectedIndexChanged);
			// 
			// labelInputProcessor
			// 
			this.labelInputProcessor.AutoSize = true;
			this.labelInputProcessor.Location = new System.Drawing.Point(9, 8);
			this.labelInputProcessor.Name = "labelInputProcessor";
			this.labelInputProcessor.Size = new System.Drawing.Size(81, 13);
			this.labelInputProcessor.TabIndex = 0;
			this.labelInputProcessor.Text = "Input Processor";
			// 
			// ExtractInputNamesForm
			// 
			this.AcceptButton = this.buttonOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(532, 147);
			this.Controls.Add(this.labelInputProcessor);
			this.Controls.Add(this.comboBoxInputProcessor);
			this.Controls.Add(this.textBoxInputSource);
			this.Controls.Add(this.buttonBrowseInputSource);
			this.Controls.Add(this.labelInputSource);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOK);
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(5000, 185);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(400, 185);
			this.Name = "ExtractInputNamesForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Extract Input Names";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.TextBox textBoxInputSource;
		private System.Windows.Forms.Button buttonBrowseInputSource;
		private System.Windows.Forms.Label labelInputSource;
		private System.Windows.Forms.ComboBox comboBoxInputProcessor;
		private System.Windows.Forms.Label labelInputProcessor;

	} // End class.
} // End namespace.