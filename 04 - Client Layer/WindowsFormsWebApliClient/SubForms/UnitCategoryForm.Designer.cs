namespace ADS.BankingAnalytics.Client.WindowsFormsWebApliClient.SubForms
{
    partial class UnitCategoryForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblOrganization = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUnitCategoryName = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.cmbUnitCategories = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmbAdditionalFields = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.chkIsMandatory = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtAdditionalFieldName = new System.Windows.Forms.TextBox();
            this.txtAdditionalFieldDescription = new System.Windows.Forms.TextBox();
            this.txtAdditionalFieldBusinessMeaning = new System.Windows.Forms.TextBox();
            this.rbString = new System.Windows.Forms.RadioButton();
            this.rbInteger = new System.Windows.Forms.RadioButton();
            this.rbDecimal = new System.Windows.Forms.RadioButton();
            this.rbDateTime = new System.Windows.Forms.RadioButton();
            this.rbBoolean = new System.Windows.Forms.RadioButton();
            this.label10 = new System.Windows.Forms.Label();
            this.btnAddField = new System.Windows.Forms.Button();
            this.btnClearField = new System.Windows.Forms.Button();
            this.btnSaveDefinitions = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Organization:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblOrganization
            // 
            this.lblOrganization.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblOrganization.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblOrganization.Location = new System.Drawing.Point(119, 14);
            this.lblOrganization.Name = "lblOrganization";
            this.lblOrganization.Size = new System.Drawing.Size(236, 23);
            this.lblOrganization.TabIndex = 1;
            this.lblOrganization.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Unit Category Name:";
            // 
            // txtUnitCategoryName
            // 
            this.txtUnitCategoryName.Location = new System.Drawing.Point(119, 52);
            this.txtUnitCategoryName.Name = "txtUnitCategoryName";
            this.txtUnitCategoryName.Size = new System.Drawing.Size(236, 20);
            this.txtUnitCategoryName.TabIndex = 3;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(199, 87);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(280, 87);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cmbAdditionalFields);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cmbUnitCategories);
            this.panel1.Location = new System.Drawing.Point(12, 146);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(370, 398);
            this.panel1.TabIndex = 6;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(292, 550);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cmbUnitCategories
            // 
            this.cmbUnitCategories.FormattingEnabled = true;
            this.cmbUnitCategories.Location = new System.Drawing.Point(118, 14);
            this.cmbUnitCategories.Name = "cmbUnitCategories";
            this.cmbUnitCategories.Size = new System.Drawing.Size(236, 21);
            this.cmbUnitCategories.TabIndex = 0;
            this.cmbUnitCategories.SelectedIndexChanged += new System.EventHandler(this.cmbUnitCategories_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Unit Categories:";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txtUnitCategoryName);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.lblOrganization);
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(370, 126);
            this.panel2.TabIndex = 8;
            // 
            // cmbAdditionalFields
            // 
            this.cmbAdditionalFields.FormattingEnabled = true;
            this.cmbAdditionalFields.Location = new System.Drawing.Point(118, 52);
            this.cmbAdditionalFields.Name = "cmbAdditionalFields";
            this.cmbAdditionalFields.Size = new System.Drawing.Size(236, 21);
            this.cmbAdditionalFields.TabIndex = 2;
            this.cmbAdditionalFields.SelectedIndexChanged += new System.EventHandler(this.cmbAdditionalFields_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Defined Fields:";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btnSaveDefinitions);
            this.panel3.Controls.Add(this.btnClearField);
            this.panel3.Controls.Add(this.btnAddField);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.rbBoolean);
            this.panel3.Controls.Add(this.rbDateTime);
            this.panel3.Controls.Add(this.rbDecimal);
            this.panel3.Controls.Add(this.rbInteger);
            this.panel3.Controls.Add(this.rbString);
            this.panel3.Controls.Add(this.txtAdditionalFieldBusinessMeaning);
            this.panel3.Controls.Add(this.txtAdditionalFieldDescription);
            this.panel3.Controls.Add(this.txtAdditionalFieldName);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.chkIsMandatory);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Location = new System.Drawing.Point(3, 93);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(362, 300);
            this.panel3.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(70, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Name:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(45, 76);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Description:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(49, 181);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Field Type:";
            // 
            // chkIsMandatory
            // 
            this.chkIsMandatory.AutoSize = true;
            this.chkIsMandatory.Location = new System.Drawing.Point(114, 149);
            this.chkIsMandatory.Name = "chkIsMandatory";
            this.chkIsMandatory.Size = new System.Drawing.Size(15, 14);
            this.chkIsMandatory.TabIndex = 5;
            this.chkIsMandatory.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 113);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "Business Meaning:";
            // 
            // txtAdditionalFieldName
            // 
            this.txtAdditionalFieldName.Location = new System.Drawing.Point(114, 37);
            this.txtAdditionalFieldName.Name = "txtAdditionalFieldName";
            this.txtAdditionalFieldName.Size = new System.Drawing.Size(236, 20);
            this.txtAdditionalFieldName.TabIndex = 7;
            // 
            // txtAdditionalFieldDescription
            // 
            this.txtAdditionalFieldDescription.Location = new System.Drawing.Point(114, 73);
            this.txtAdditionalFieldDescription.Name = "txtAdditionalFieldDescription";
            this.txtAdditionalFieldDescription.Size = new System.Drawing.Size(236, 20);
            this.txtAdditionalFieldDescription.TabIndex = 8;
            // 
            // txtAdditionalFieldBusinessMeaning
            // 
            this.txtAdditionalFieldBusinessMeaning.Location = new System.Drawing.Point(114, 110);
            this.txtAdditionalFieldBusinessMeaning.Name = "txtAdditionalFieldBusinessMeaning";
            this.txtAdditionalFieldBusinessMeaning.Size = new System.Drawing.Size(236, 20);
            this.txtAdditionalFieldBusinessMeaning.TabIndex = 9;
            // 
            // rbString
            // 
            this.rbString.AutoSize = true;
            this.rbString.Location = new System.Drawing.Point(114, 179);
            this.rbString.Name = "rbString";
            this.rbString.Size = new System.Drawing.Size(46, 17);
            this.rbString.TabIndex = 10;
            this.rbString.TabStop = true;
            this.rbString.Text = "Text";
            this.rbString.UseVisualStyleBackColor = true;
            // 
            // rbInteger
            // 
            this.rbInteger.AutoSize = true;
            this.rbInteger.Location = new System.Drawing.Point(114, 202);
            this.rbInteger.Name = "rbInteger";
            this.rbInteger.Size = new System.Drawing.Size(58, 17);
            this.rbInteger.TabIndex = 11;
            this.rbInteger.TabStop = true;
            this.rbInteger.Text = "Integer";
            this.rbInteger.UseVisualStyleBackColor = true;
            // 
            // rbDecimal
            // 
            this.rbDecimal.AutoSize = true;
            this.rbDecimal.Location = new System.Drawing.Point(115, 225);
            this.rbDecimal.Name = "rbDecimal";
            this.rbDecimal.Size = new System.Drawing.Size(63, 17);
            this.rbDecimal.TabIndex = 12;
            this.rbDecimal.TabStop = true;
            this.rbDecimal.Text = "Decimal";
            this.rbDecimal.UseVisualStyleBackColor = true;
            // 
            // rbDateTime
            // 
            this.rbDateTime.AutoSize = true;
            this.rbDateTime.Location = new System.Drawing.Point(115, 248);
            this.rbDateTime.Name = "rbDateTime";
            this.rbDateTime.Size = new System.Drawing.Size(83, 17);
            this.rbDateTime.TabIndex = 13;
            this.rbDateTime.TabStop = true;
            this.rbDateTime.Text = "Date && Time";
            this.rbDateTime.UseVisualStyleBackColor = true;
            // 
            // rbBoolean
            // 
            this.rbBoolean.AutoSize = true;
            this.rbBoolean.Location = new System.Drawing.Point(115, 271);
            this.rbBoolean.Name = "rbBoolean";
            this.rbBoolean.Size = new System.Drawing.Size(83, 17);
            this.rbBoolean.TabIndex = 14;
            this.rbBoolean.TabStop = true;
            this.rbBoolean.Text = "True / False";
            this.rbBoolean.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(37, 149);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "Is Mandatory:";
            // 
            // btnAddField
            // 
            this.btnAddField.Location = new System.Drawing.Point(275, 238);
            this.btnAddField.Name = "btnAddField";
            this.btnAddField.Size = new System.Drawing.Size(75, 23);
            this.btnAddField.TabIndex = 16;
            this.btnAddField.Text = "Add Field";
            this.btnAddField.UseVisualStyleBackColor = true;
            this.btnAddField.Click += new System.EventHandler(this.btnAddField_Click);
            // 
            // btnClearField
            // 
            this.btnClearField.Location = new System.Drawing.Point(275, 209);
            this.btnClearField.Name = "btnClearField";
            this.btnClearField.Size = new System.Drawing.Size(75, 23);
            this.btnClearField.TabIndex = 17;
            this.btnClearField.Text = "Clear All";
            this.btnClearField.UseVisualStyleBackColor = true;
            this.btnClearField.Click += new System.EventHandler(this.btnClearField_Click);
            // 
            // btnSaveDefinitions
            // 
            this.btnSaveDefinitions.Location = new System.Drawing.Point(275, 268);
            this.btnSaveDefinitions.Name = "btnSaveDefinitions";
            this.btnSaveDefinitions.Size = new System.Drawing.Size(75, 23);
            this.btnSaveDefinitions.TabIndex = 18;
            this.btnSaveDefinitions.Text = "Save List";
            this.btnSaveDefinitions.UseVisualStyleBackColor = true;
            this.btnSaveDefinitions.Click += new System.EventHandler(this.btnSaveDefinitions_Click);
            // 
            // UnitCategoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 582);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.panel1);
            this.Name = "UnitCategoryForm";
            this.Text = "UnitCategoryForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblOrganization;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUnitCategoryName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbUnitCategories;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cmbAdditionalFields;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtAdditionalFieldBusinessMeaning;
        private System.Windows.Forms.TextBox txtAdditionalFieldDescription;
        private System.Windows.Forms.TextBox txtAdditionalFieldName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox chkIsMandatory;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton rbBoolean;
        private System.Windows.Forms.RadioButton rbDateTime;
        private System.Windows.Forms.RadioButton rbDecimal;
        private System.Windows.Forms.RadioButton rbInteger;
        private System.Windows.Forms.RadioButton rbString;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnAddField;
        private System.Windows.Forms.Button btnClearField;
        private System.Windows.Forms.Button btnSaveDefinitions;
    }
}