namespace DataConverter
{
	partial class EditTranslationMatrixForm
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
			this.buttonImportNames = new System.Windows.Forms.Button();
			this.buttonSave = new System.Windows.Forms.Button();
			this.buttonSaveAndClose = new System.Windows.Forms.Button();
			this.bindingSourceTranslationMap = new System.Windows.Forms.BindingSource(this.components);
			this.dataGridViewColumnInputName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewColumnOutputName = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.dataGridViewColumnDataType = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.NegateUnits = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.dataGridViewColumnCatagoryOfUnits = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.dataGridViewColumnFromUnits = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.dataGridViewColumnToUnits = new System.Windows.Forms.DataGridViewComboBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewTranslationMatrix)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bindingSourceTranslationMap)).BeginInit();
			this.SuspendLayout();
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(703, 377);
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
			this.dataGridViewTranslationMatrix.AllowUserToResizeRows = false;
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
            this.dataGridViewColumnInputName,
            this.dataGridViewColumnOutputName,
            this.dataGridViewColumnDataType,
            this.NegateUnits,
            this.dataGridViewColumnCatagoryOfUnits,
            this.dataGridViewColumnFromUnits,
            this.dataGridViewColumnToUnits});
			this.dataGridViewTranslationMatrix.DataSource = this.bindingSourceTranslationMap;
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridViewTranslationMatrix.DefaultCellStyle = dataGridViewCellStyle3;
			this.dataGridViewTranslationMatrix.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
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
			this.dataGridViewTranslationMatrix.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			this.dataGridViewTranslationMatrix.Size = new System.Drawing.Size(771, 359);
			this.dataGridViewTranslationMatrix.TabIndex = 0;
			this.dataGridViewTranslationMatrix.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTranslationMatrix_CellClick);
			this.dataGridViewTranslationMatrix.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTranslationMatrix_CellValueChanged);
			this.dataGridViewTranslationMatrix.CurrentCellDirtyStateChanged += new System.EventHandler(this.dataGridViewTranslationMatrix_CurrentCellDirtyStateChanged);
			this.dataGridViewTranslationMatrix.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridViewTranslationMatrix_DataError);
			// 
			// buttonImportNames
			// 
			this.buttonImportNames.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonImportNames.Location = new System.Drawing.Point(12, 377);
			this.buttonImportNames.Name = "buttonImportNames";
			this.buttonImportNames.Size = new System.Drawing.Size(109, 23);
			this.buttonImportNames.TabIndex = 1;
			this.buttonImportNames.Text = "&Import Names...";
			this.buttonImportNames.UseVisualStyleBackColor = true;
			this.buttonImportNames.Click += new System.EventHandler(this.buttonImportNames_Click);
			// 
			// buttonSave
			// 
			this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSave.Location = new System.Drawing.Point(519, 377);
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
			this.buttonSaveAndClose.Location = new System.Drawing.Point(605, 377);
			this.buttonSaveAndClose.Name = "buttonSaveAndClose";
			this.buttonSaveAndClose.Size = new System.Drawing.Size(80, 23);
			this.buttonSaveAndClose.TabIndex = 3;
			this.buttonSaveAndClose.Text = "S&ave && Close";
			this.buttonSaveAndClose.UseVisualStyleBackColor = true;
			this.buttonSaveAndClose.Click += new System.EventHandler(this.buttonSaveAndClose_Click);
			// 
			// bindingSourceTranslationMap
			// 
			this.bindingSourceTranslationMap.DataSource = typeof(DataConverter.TranslationMap);
			// 
			// dataGridViewColumnInputName
			// 
			this.dataGridViewColumnInputName.DataPropertyName = "InputName";
			dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dataGridViewColumnInputName.DefaultCellStyle = dataGridViewCellStyle2;
			this.dataGridViewColumnInputName.HeaderText = "Input Name";
			this.dataGridViewColumnInputName.Name = "dataGridViewColumnInputName";
			this.dataGridViewColumnInputName.ReadOnly = true;
			// 
			// dataGridViewColumnOutputName
			// 
			this.dataGridViewColumnOutputName.DataPropertyName = "OutputName";
			this.dataGridViewColumnOutputName.HeaderText = "Output Name";
			this.dataGridViewColumnOutputName.Name = "dataGridViewColumnOutputName";
			this.dataGridViewColumnOutputName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewColumnOutputName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			// 
			// dataGridViewColumnDataType
			// 
			this.dataGridViewColumnDataType.DataPropertyName = "DataTypeString";
			this.dataGridViewColumnDataType.HeaderText = "Data Type";
			this.dataGridViewColumnDataType.Name = "dataGridViewColumnDataType";
			this.dataGridViewColumnDataType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewColumnDataType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			// 
			// NegateUnits
			// 
			this.NegateUnits.DataPropertyName = "NegateUnits";
			this.NegateUnits.FillWeight = 40F;
			this.NegateUnits.HeaderText = "Negate Units";
			this.NegateUnits.Name = "NegateUnits";
			// 
			// dataGridViewColumnCatagoryOfUnits
			// 
			this.dataGridViewColumnCatagoryOfUnits.DataPropertyName = "CatagoryOfUnits";
			this.dataGridViewColumnCatagoryOfUnits.HeaderText = "Catagory Of Units";
			this.dataGridViewColumnCatagoryOfUnits.Name = "dataGridViewColumnCatagoryOfUnits";
			this.dataGridViewColumnCatagoryOfUnits.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewColumnCatagoryOfUnits.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			// 
			// dataGridViewColumnFromUnits
			// 
			this.dataGridViewColumnFromUnits.DataPropertyName = "FromUnits";
			this.dataGridViewColumnFromUnits.HeaderText = "From Units";
			this.dataGridViewColumnFromUnits.Name = "dataGridViewColumnFromUnits";
			// 
			// dataGridViewColumnToUnits
			// 
			this.dataGridViewColumnToUnits.DataPropertyName = "ToUnits";
			this.dataGridViewColumnToUnits.HeaderText = "To Units";
			this.dataGridViewColumnToUnits.Name = "dataGridViewColumnToUnits";
			// 
			// EditTranslationMatrixForm
			// 
			this.AcceptButton = this.buttonSaveAndClose;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(795, 412);
			this.Controls.Add(this.buttonSave);
			this.Controls.Add(this.buttonImportNames);
			this.Controls.Add(this.dataGridViewTranslationMatrix);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonSaveAndClose);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "EditTranslationMatrixForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Edit Translation Matrix";
			this.Shown += new System.EventHandler(this.EditTranslationMatrixForm_Shown);
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewTranslationMatrix)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bindingSourceTranslationMap)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button buttonCancel;
		internal System.Windows.Forms.DataGridView dataGridViewTranslationMatrix;
		private System.Windows.Forms.BindingSource bindingSourceTranslationMap;
		private System.Windows.Forms.Button buttonImportNames;
		private System.Windows.Forms.Button buttonSave;
		private System.Windows.Forms.Button buttonSaveAndClose;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewColumnInputName;
		private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewColumnOutputName;
		private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewColumnDataType;
		private System.Windows.Forms.DataGridViewCheckBoxColumn NegateUnits;
		private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewColumnCatagoryOfUnits;
		private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewColumnFromUnits;
		private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewColumnToUnits;
	}
}