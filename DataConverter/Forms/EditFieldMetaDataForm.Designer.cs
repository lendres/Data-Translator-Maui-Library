namespace DataConverter
{
	partial class EditFieldMetaDataForm
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
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.dataGridViewTranslationMatrix = new System.Windows.Forms.DataGridView();
			this.dataGridViewColumnFieldName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewColumnShortName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewColumnLongName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewColumnDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.bindingSourceTranslationMap = new System.Windows.Forms.BindingSource(this.components);
			this.buttonSave = new System.Windows.Forms.Button();
			this.buttonSaveAndClose = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewTranslationMatrix)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bindingSourceTranslationMap)).BeginInit();
			this.SuspendLayout();
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(830, 433);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(80, 23);
			this.buttonCancel.TabIndex = 4;
			this.buttonCancel.Text = "&Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			// 
			// dataGridViewTranslationMatrix
			// 
			this.dataGridViewTranslationMatrix.AllowUserToAddRows = false;
			this.dataGridViewTranslationMatrix.AllowUserToDeleteRows = false;
			this.dataGridViewTranslationMatrix.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridViewTranslationMatrix.AutoGenerateColumns = false;
			this.dataGridViewTranslationMatrix.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGridViewTranslationMatrix.BackgroundColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewTranslationMatrix.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.dataGridViewTranslationMatrix.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewTranslationMatrix.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewColumnFieldName,
            this.dataGridViewColumnShortName,
            this.dataGridViewColumnLongName,
            this.dataGridViewColumnDescription});
			this.dataGridViewTranslationMatrix.DataSource = this.bindingSourceTranslationMap;
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridViewTranslationMatrix.DefaultCellStyle = dataGridViewCellStyle3;
			this.dataGridViewTranslationMatrix.Location = new System.Drawing.Point(12, 12);
			this.dataGridViewTranslationMatrix.Name = "dataGridViewTranslationMatrix";
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewTranslationMatrix.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
			this.dataGridViewTranslationMatrix.RowHeadersWidth = 20;
			this.dataGridViewTranslationMatrix.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridViewTranslationMatrix.Size = new System.Drawing.Size(898, 415);
			this.dataGridViewTranslationMatrix.TabIndex = 0;
			// 
			// dataGridViewColumnFieldName
			// 
			this.dataGridViewColumnFieldName.DataPropertyName = "EnumName";
			dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dataGridViewColumnFieldName.DefaultCellStyle = dataGridViewCellStyle2;
			this.dataGridViewColumnFieldName.HeaderText = "Field";
			this.dataGridViewColumnFieldName.Name = "dataGridViewColumnFieldName";
			this.dataGridViewColumnFieldName.ReadOnly = true;
			// 
			// dataGridViewColumnShortName
			// 
			this.dataGridViewColumnShortName.DataPropertyName = "ShortName";
			this.dataGridViewColumnShortName.HeaderText = "Short Name";
			this.dataGridViewColumnShortName.Name = "dataGridViewColumnShortName";
			// 
			// dataGridViewColumnLongName
			// 
			this.dataGridViewColumnLongName.DataPropertyName = "LongName";
			this.dataGridViewColumnLongName.HeaderText = "Long Name";
			this.dataGridViewColumnLongName.Name = "dataGridViewColumnLongName";
			// 
			// dataGridViewColumnDescription
			// 
			this.dataGridViewColumnDescription.DataPropertyName = "Description";
			this.dataGridViewColumnDescription.FillWeight = 200F;
			this.dataGridViewColumnDescription.HeaderText = "Description";
			this.dataGridViewColumnDescription.Name = "dataGridViewColumnDescription";
			// 
			// bindingSourceTranslationMap
			// 
			this.bindingSourceTranslationMap.DataSource = typeof(DataConverter.FieldMetaData);
			// 
			// buttonSave
			// 
			this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSave.Location = new System.Drawing.Point(646, 433);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(80, 23);
			this.buttonSave.TabIndex = 2;
			this.buttonSave.Text = "&Save";
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
			// 
			// buttonSaveAndClose
			// 
			this.buttonSaveAndClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSaveAndClose.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonSaveAndClose.Location = new System.Drawing.Point(732, 433);
			this.buttonSaveAndClose.Name = "buttonSaveAndClose";
			this.buttonSaveAndClose.Size = new System.Drawing.Size(80, 23);
			this.buttonSaveAndClose.TabIndex = 3;
			this.buttonSaveAndClose.Text = "S&ave && Close";
			this.buttonSaveAndClose.UseVisualStyleBackColor = true;
			this.buttonSaveAndClose.Click += new System.EventHandler(this.buttonSaveAndClose_Click);
			// 
			// EditFieldMetaDataForm
			// 
			this.AcceptButton = this.buttonSaveAndClose;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(922, 468);
			this.Controls.Add(this.buttonSave);
			this.Controls.Add(this.dataGridViewTranslationMatrix);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonSaveAndClose);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "EditFieldMetaDataForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Edit Field Information";
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewTranslationMatrix)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bindingSourceTranslationMap)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button buttonCancel;
		internal System.Windows.Forms.DataGridView dataGridViewTranslationMatrix;
		private System.Windows.Forms.BindingSource bindingSourceTranslationMap;
		private System.Windows.Forms.Button buttonSave;
		private System.Windows.Forms.Button buttonSaveAndClose;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewColumnFieldName;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewColumnShortName;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewColumnLongName;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewColumnDescription;
	}
}