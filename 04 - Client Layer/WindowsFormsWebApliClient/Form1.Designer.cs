namespace ADS.BankingAnalytics.Client.WindowsFormsWebApliClient
{
    partial class Form1
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
            this.btnExit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rchAdditionalFields = new System.Windows.Forms.RichTextBox();
            this.lblSelectedUnitParentName = new System.Windows.Forms.Label();
            this.lblSelectedUnitName = new System.Windows.Forms.Label();
            this.lblSelectedUnitId = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAddOrganization = new System.Windows.Forms.Button();
            this.cmbOrganizations = new System.Windows.Forms.ComboBox();
            this.cmbUnits = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnTemp = new System.Windows.Forms.Button();
            this.btnAddAdditionalFieldValue = new System.Windows.Forms.Button();
            this.txtAdditionalFieldValue = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbAdditionalFields = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbUnitCategories = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lblUnitName = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblOrganizationName = new System.Windows.Forms.Label();
            this.btnSaveUnitList = new System.Windows.Forms.Button();
            this.btnAddUnitToList = new System.Windows.Forms.Button();
            this.txtUnitName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkHasParent = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddUnitCategory = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(797, 560);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAddUnitCategory);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.btnAddOrganization);
            this.groupBox1.Controls.Add(this.cmbOrganizations);
            this.groupBox1.Controls.Add(this.cmbUnits);
            this.groupBox1.Controls.Add(this.cmbUnitCategories);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(411, 524);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Organizations";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(46, 108);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Unit:";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.rchAdditionalFields);
            this.panel1.Controls.Add(this.lblSelectedUnitParentName);
            this.panel1.Controls.Add(this.lblSelectedUnitName);
            this.panel1.Controls.Add(this.lblSelectedUnitId);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(6, 243);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(399, 275);
            this.panel1.TabIndex = 11;
            // 
            // rchAdditionalFields
            // 
            this.rchAdditionalFields.Location = new System.Drawing.Point(6, 123);
            this.rchAdditionalFields.Name = "rchAdditionalFields";
            this.rchAdditionalFields.Size = new System.Drawing.Size(379, 147);
            this.rchAdditionalFields.TabIndex = 6;
            this.rchAdditionalFields.Text = "";
            // 
            // lblSelectedUnitParentName
            // 
            this.lblSelectedUnitParentName.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblSelectedUnitParentName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSelectedUnitParentName.Location = new System.Drawing.Point(50, 86);
            this.lblSelectedUnitParentName.Name = "lblSelectedUnitParentName";
            this.lblSelectedUnitParentName.Size = new System.Drawing.Size(100, 23);
            this.lblSelectedUnitParentName.TabIndex = 5;
            this.lblSelectedUnitParentName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSelectedUnitName
            // 
            this.lblSelectedUnitName.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblSelectedUnitName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSelectedUnitName.Location = new System.Drawing.Point(50, 52);
            this.lblSelectedUnitName.Name = "lblSelectedUnitName";
            this.lblSelectedUnitName.Size = new System.Drawing.Size(100, 23);
            this.lblSelectedUnitName.TabIndex = 4;
            this.lblSelectedUnitName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSelectedUnitId
            // 
            this.lblSelectedUnitId.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblSelectedUnitId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSelectedUnitId.Location = new System.Drawing.Point(50, 18);
            this.lblSelectedUnitId.Name = "lblSelectedUnitId";
            this.lblSelectedUnitId.Size = new System.Drawing.Size(100, 23);
            this.lblSelectedUnitId.TabIndex = 3;
            this.lblSelectedUnitId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 91);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Parent:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Name:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Id:";
            // 
            // btnAddOrganization
            // 
            this.btnAddOrganization.Location = new System.Drawing.Point(271, 17);
            this.btnAddOrganization.Name = "btnAddOrganization";
            this.btnAddOrganization.Size = new System.Drawing.Size(121, 23);
            this.btnAddOrganization.TabIndex = 1;
            this.btnAddOrganization.Text = "Add Organization...";
            this.btnAddOrganization.UseVisualStyleBackColor = true;
            this.btnAddOrganization.Click += new System.EventHandler(this.btnAddOrganization_Click);
            // 
            // cmbOrganizations
            // 
            this.cmbOrganizations.FormattingEnabled = true;
            this.cmbOrganizations.Location = new System.Drawing.Point(81, 19);
            this.cmbOrganizations.Name = "cmbOrganizations";
            this.cmbOrganizations.Size = new System.Drawing.Size(160, 21);
            this.cmbOrganizations.TabIndex = 0;
            this.cmbOrganizations.SelectedIndexChanged += new System.EventHandler(this.cmbOrganizations_SelectedIndexChanged);
            // 
            // cmbUnits
            // 
            this.cmbUnits.FormattingEnabled = true;
            this.cmbUnits.Location = new System.Drawing.Point(81, 105);
            this.cmbUnits.Name = "cmbUnits";
            this.cmbUnits.Size = new System.Drawing.Size(160, 21);
            this.cmbUnits.TabIndex = 0;
            this.cmbUnits.SelectedIndexChanged += new System.EventHandler(this.cmbUnits_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnTemp);
            this.groupBox2.Controls.Add(this.btnAddAdditionalFieldValue);
            this.groupBox2.Controls.Add(this.txtAdditionalFieldValue);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.cmbAdditionalFields);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.lblUnitName);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.lblOrganizationName);
            this.groupBox2.Controls.Add(this.btnSaveUnitList);
            this.groupBox2.Controls.Add(this.btnAddUnitToList);
            this.groupBox2.Controls.Add(this.txtUnitName);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.chkHasParent);
            this.groupBox2.Location = new System.Drawing.Point(430, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(442, 487);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Units";
            // 
            // btnTemp
            // 
            this.btnTemp.Location = new System.Drawing.Point(80, 382);
            this.btnTemp.Name = "btnTemp";
            this.btnTemp.Size = new System.Drawing.Size(75, 23);
            this.btnTemp.TabIndex = 18;
            this.btnTemp.Text = "Temp";
            this.btnTemp.UseVisualStyleBackColor = true;
            this.btnTemp.Click += new System.EventHandler(this.btnTemp_Click);
            // 
            // btnAddAdditionalFieldValue
            // 
            this.btnAddAdditionalFieldValue.Location = new System.Drawing.Point(259, 269);
            this.btnAddAdditionalFieldValue.Name = "btnAddAdditionalFieldValue";
            this.btnAddAdditionalFieldValue.Size = new System.Drawing.Size(75, 23);
            this.btnAddAdditionalFieldValue.TabIndex = 17;
            this.btnAddAdditionalFieldValue.Text = "Add Value";
            this.btnAddAdditionalFieldValue.UseVisualStyleBackColor = true;
            this.btnAddAdditionalFieldValue.Click += new System.EventHandler(this.btnAddAdditionalFieldValue_Click);
            // 
            // txtAdditionalFieldValue
            // 
            this.txtAdditionalFieldValue.Location = new System.Drawing.Point(93, 271);
            this.txtAdditionalFieldValue.Name = "txtAdditionalFieldValue";
            this.txtAdditionalFieldValue.Size = new System.Drawing.Size(160, 20);
            this.txtAdditionalFieldValue.TabIndex = 16;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(50, 274);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(37, 13);
            this.label11.TabIndex = 15;
            this.label11.Text = "Value:";
            // 
            // cmbAdditionalFields
            // 
            this.cmbAdditionalFields.FormattingEnabled = true;
            this.cmbAdditionalFields.Location = new System.Drawing.Point(93, 240);
            this.cmbAdditionalFields.Name = "cmbAdditionalFields";
            this.cmbAdditionalFields.Size = new System.Drawing.Size(160, 21);
            this.cmbAdditionalFields.TabIndex = 14;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 243);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 13);
            this.label10.TabIndex = 13;
            this.label10.Text = "Additional Field:";
            // 
            // cmbUnitCategories
            // 
            this.cmbUnitCategories.FormattingEnabled = true;
            this.cmbUnitCategories.Location = new System.Drawing.Point(81, 62);
            this.cmbUnitCategories.Name = "cmbUnitCategories";
            this.cmbUnitCategories.Size = new System.Drawing.Size(160, 21);
            this.cmbUnitCategories.TabIndex = 12;
            this.cmbUnitCategories.SelectedIndexChanged += new System.EventHandler(this.cmbUnitCategories_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(23, 65);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "Category:";
            // 
            // lblUnitName
            // 
            this.lblUnitName.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblUnitName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblUnitName.Location = new System.Drawing.Point(93, 96);
            this.lblUnitName.Name = "lblUnitName";
            this.lblUnitName.Size = new System.Drawing.Size(160, 23);
            this.lblUnitName.TabIndex = 10;
            this.lblUnitName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(58, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Unit:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Organization:";
            // 
            // lblOrganizationName
            // 
            this.lblOrganizationName.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblOrganizationName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblOrganizationName.Location = new System.Drawing.Point(93, 66);
            this.lblOrganizationName.Name = "lblOrganizationName";
            this.lblOrganizationName.Size = new System.Drawing.Size(160, 21);
            this.lblOrganizationName.TabIndex = 6;
            this.lblOrganizationName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSaveUnitList
            // 
            this.btnSaveUnitList.Location = new System.Drawing.Point(259, 313);
            this.btnSaveUnitList.Name = "btnSaveUnitList";
            this.btnSaveUnitList.Size = new System.Drawing.Size(75, 23);
            this.btnSaveUnitList.TabIndex = 5;
            this.btnSaveUnitList.Text = "Save List";
            this.btnSaveUnitList.UseVisualStyleBackColor = true;
            this.btnSaveUnitList.Click += new System.EventHandler(this.btnSaveUnitList_Click);
            // 
            // btnAddUnitToList
            // 
            this.btnAddUnitToList.Location = new System.Drawing.Point(259, 144);
            this.btnAddUnitToList.Name = "btnAddUnitToList";
            this.btnAddUnitToList.Size = new System.Drawing.Size(75, 23);
            this.btnAddUnitToList.TabIndex = 4;
            this.btnAddUnitToList.Text = "Add To List";
            this.btnAddUnitToList.UseVisualStyleBackColor = true;
            this.btnAddUnitToList.Click += new System.EventHandler(this.btnAddUnitToList_Click);
            // 
            // txtUnitName
            // 
            this.txtUnitName.Location = new System.Drawing.Point(93, 177);
            this.txtUnitName.Name = "txtUnitName";
            this.txtUnitName.Size = new System.Drawing.Size(160, 20);
            this.txtUnitName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 180);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Name:";
            // 
            // chkHasParent
            // 
            this.chkHasParent.AutoSize = true;
            this.chkHasParent.Location = new System.Drawing.Point(93, 203);
            this.chkHasParent.Name = "chkHasParent";
            this.chkHasParent.Size = new System.Drawing.Size(101, 17);
            this.chkHasParent.TabIndex = 1;
            this.chkHasParent.Text = "Has Parent Unit";
            this.chkHasParent.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Organization:";
            // 
            // btnAddUnitCategory
            // 
            this.btnAddUnitCategory.Location = new System.Drawing.Point(271, 60);
            this.btnAddUnitCategory.Name = "btnAddUnitCategory";
            this.btnAddUnitCategory.Size = new System.Drawing.Size(121, 23);
            this.btnAddUnitCategory.TabIndex = 20;
            this.btnAddUnitCategory.Text = "Add Unit Category...";
            this.btnAddUnitCategory.UseVisualStyleBackColor = true;
            this.btnAddUnitCategory.Click += new System.EventHandler(this.btnAddUnitCategory_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 595);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnExit);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbOrganizations;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbUnits;
        private System.Windows.Forms.Button btnAddOrganization;
        private System.Windows.Forms.CheckBox chkHasParent;
        private System.Windows.Forms.Label lblOrganizationName;
        private System.Windows.Forms.Button btnSaveUnitList;
        private System.Windows.Forms.Button btnAddUnitToList;
        private System.Windows.Forms.TextBox txtUnitName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblUnitName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox rchAdditionalFields;
        private System.Windows.Forms.Label lblSelectedUnitParentName;
        private System.Windows.Forms.Label lblSelectedUnitName;
        private System.Windows.Forms.Label lblSelectedUnitId;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbUnitCategories;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnAddAdditionalFieldValue;
        private System.Windows.Forms.TextBox txtAdditionalFieldValue;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbAdditionalFields;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnTemp;
        private System.Windows.Forms.Button btnAddUnitCategory;
        private System.Windows.Forms.Label label1;
    }
}

