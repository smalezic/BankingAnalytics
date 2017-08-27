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
            this.cmbOrganizations = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbUnits = new System.Windows.Forms.ComboBox();
            this.btnAddOrganization = new System.Windows.Forms.Button();
            this.txtOrganizationName = new System.Windows.Forms.TextBox();
            this.chkHasParent = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUnitName = new System.Windows.Forms.TextBox();
            this.btnAddUnitToList = new System.Windows.Forms.Button();
            this.btnSaveUnitList = new System.Windows.Forms.Button();
            this.lblOrganizationName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblUnitName = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(529, 324);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtOrganizationName);
            this.groupBox1.Controls.Add(this.btnAddOrganization);
            this.groupBox1.Controls.Add(this.cmbOrganizations);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(411, 295);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Organizations";
            // 
            // cmbOrganizations
            // 
            this.cmbOrganizations.FormattingEnabled = true;
            this.cmbOrganizations.Location = new System.Drawing.Point(50, 19);
            this.cmbOrganizations.Name = "cmbOrganizations";
            this.cmbOrganizations.Size = new System.Drawing.Size(160, 21);
            this.cmbOrganizations.TabIndex = 0;
            this.cmbOrganizations.SelectedIndexChanged += new System.EventHandler(this.cmbOrganizations_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblUnitName);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.lblOrganizationName);
            this.groupBox2.Controls.Add(this.btnSaveUnitList);
            this.groupBox2.Controls.Add(this.btnAddUnitToList);
            this.groupBox2.Controls.Add(this.txtUnitName);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.chkHasParent);
            this.groupBox2.Controls.Add(this.cmbUnits);
            this.groupBox2.Location = new System.Drawing.Point(430, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(442, 295);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Units";
            // 
            // cmbUnits
            // 
            this.cmbUnits.FormattingEnabled = true;
            this.cmbUnits.Location = new System.Drawing.Point(51, 19);
            this.cmbUnits.Name = "cmbUnits";
            this.cmbUnits.Size = new System.Drawing.Size(160, 21);
            this.cmbUnits.TabIndex = 0;
            this.cmbUnits.SelectedIndexChanged += new System.EventHandler(this.cmbUnits_SelectedIndexChanged);
            // 
            // btnAddOrganization
            // 
            this.btnAddOrganization.Location = new System.Drawing.Point(217, 63);
            this.btnAddOrganization.Name = "btnAddOrganization";
            this.btnAddOrganization.Size = new System.Drawing.Size(108, 23);
            this.btnAddOrganization.TabIndex = 1;
            this.btnAddOrganization.Text = "Add Organization";
            this.btnAddOrganization.UseVisualStyleBackColor = true;
            this.btnAddOrganization.Click += new System.EventHandler(this.btnAddOrganization_Click);
            // 
            // txtOrganizationName
            // 
            this.txtOrganizationName.Location = new System.Drawing.Point(50, 66);
            this.txtOrganizationName.Name = "txtOrganizationName";
            this.txtOrganizationName.Size = new System.Drawing.Size(160, 20);
            this.txtOrganizationName.TabIndex = 2;
            // 
            // chkHasParent
            // 
            this.chkHasParent.AutoSize = true;
            this.chkHasParent.Location = new System.Drawing.Point(50, 183);
            this.chkHasParent.Name = "chkHasParent";
            this.chkHasParent.Size = new System.Drawing.Size(101, 17);
            this.chkHasParent.TabIndex = 1;
            this.chkHasParent.Text = "Has Parent Unit";
            this.chkHasParent.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Name:";
            // 
            // txtUnitName
            // 
            this.txtUnitName.Location = new System.Drawing.Point(50, 157);
            this.txtUnitName.Name = "txtUnitName";
            this.txtUnitName.Size = new System.Drawing.Size(160, 20);
            this.txtUnitName.TabIndex = 3;
            // 
            // btnAddUnitToList
            // 
            this.btnAddUnitToList.Location = new System.Drawing.Point(218, 156);
            this.btnAddUnitToList.Name = "btnAddUnitToList";
            this.btnAddUnitToList.Size = new System.Drawing.Size(75, 23);
            this.btnAddUnitToList.TabIndex = 4;
            this.btnAddUnitToList.Text = "Add To List";
            this.btnAddUnitToList.UseVisualStyleBackColor = true;
            this.btnAddUnitToList.Click += new System.EventHandler(this.btnAddUnitToList_Click);
            // 
            // btnSaveUnitList
            // 
            this.btnSaveUnitList.Location = new System.Drawing.Point(302, 156);
            this.btnSaveUnitList.Name = "btnSaveUnitList";
            this.btnSaveUnitList.Size = new System.Drawing.Size(75, 23);
            this.btnSaveUnitList.TabIndex = 5;
            this.btnSaveUnitList.Text = "Save List";
            this.btnSaveUnitList.UseVisualStyleBackColor = true;
            this.btnSaveUnitList.Click += new System.EventHandler(this.btnSaveUnitList_Click);
            // 
            // lblOrganizationName
            // 
            this.lblOrganizationName.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblOrganizationName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblOrganizationName.Location = new System.Drawing.Point(81, 65);
            this.lblOrganizationName.Name = "lblOrganizationName";
            this.lblOrganizationName.Size = new System.Drawing.Size(160, 21);
            this.lblOrganizationName.TabIndex = 6;
            this.lblOrganizationName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Organization:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(46, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Unit:";
            // 
            // lblUnitName
            // 
            this.lblUnitName.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblUnitName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblUnitName.Location = new System.Drawing.Point(81, 95);
            this.lblUnitName.Name = "lblUnitName";
            this.lblUnitName.Size = new System.Drawing.Size(160, 23);
            this.lblUnitName.TabIndex = 10;
            this.lblUnitName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 359);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnExit);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.TextBox txtOrganizationName;
        private System.Windows.Forms.CheckBox chkHasParent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblOrganizationName;
        private System.Windows.Forms.Button btnSaveUnitList;
        private System.Windows.Forms.Button btnAddUnitToList;
        private System.Windows.Forms.TextBox txtUnitName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblUnitName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}

