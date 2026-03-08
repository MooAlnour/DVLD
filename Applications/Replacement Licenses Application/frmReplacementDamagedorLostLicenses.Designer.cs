namespace DVLD.Applications.Replacement_Licenses_Application
{
    partial class frmReplacementDamagedorLostLicenses
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
            this.ucDriverLicenseInfoWithFilter1 = new DVLD.License.Control.ucDriverLicenseInfoWithFilter();
            this.lblTitel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbLostLicenses = new System.Windows.Forms.RadioButton();
            this.rbDamagedLicens = new System.Windows.Forms.RadioButton();
            this.llShowNewLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.llShowLicenseHistory = new System.Windows.Forms.LinkLabel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblCreatedBy = new System.Windows.Forms.Label();
            this.lblOldLicenseID = new System.Windows.Forms.Label();
            this.lblRenewLicenseID = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblApplicationDate = new System.Windows.Forms.Label();
            this.lblAAppFees = new System.Windows.Forms.Label();
            this.lblLRAppID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ucDriverLicenseInfoWithFilter1
            // 
            this.ucDriverLicenseInfoWithFilter1.BackColor = System.Drawing.Color.White;
            this.ucDriverLicenseInfoWithFilter1.FilterEnabled = true;
            this.ucDriverLicenseInfoWithFilter1.Location = new System.Drawing.Point(13, 67);
            this.ucDriverLicenseInfoWithFilter1.Margin = new System.Windows.Forms.Padding(4);
            this.ucDriverLicenseInfoWithFilter1.Name = "ucDriverLicenseInfoWithFilter1";
            this.ucDriverLicenseInfoWithFilter1.Size = new System.Drawing.Size(1006, 433);
            this.ucDriverLicenseInfoWithFilter1.TabIndex = 0;
            this.ucDriverLicenseInfoWithFilter1.OnLicenseSelected += new System.Action<int>(this.ucDriverLicenseInfoWithFilter1_OnLicenseSelected);
            // 
            // lblTitel
            // 
            this.lblTitel.AutoSize = true;
            this.lblTitel.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitel.ForeColor = System.Drawing.Color.Red;
            this.lblTitel.Location = new System.Drawing.Point(191, 9);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(665, 54);
            this.lblTitel.TabIndex = 1;
            this.lblTitel.Text = "Replacement for Lost Licenses";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.rbLostLicenses);
            this.groupBox1.Controls.Add(this.rbDamagedLicens);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(750, 78);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(197, 91);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Replacement for";
            // 
            // rbLostLicenses
            // 
            this.rbLostLicenses.AutoSize = true;
            this.rbLostLicenses.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbLostLicenses.Location = new System.Drawing.Point(18, 56);
            this.rbLostLicenses.Name = "rbLostLicenses";
            this.rbLostLicenses.Size = new System.Drawing.Size(121, 22);
            this.rbLostLicenses.TabIndex = 1;
            this.rbLostLicenses.Text = "Lost Licenses";
            this.rbLostLicenses.UseVisualStyleBackColor = true;
            this.rbLostLicenses.CheckedChanged += new System.EventHandler(this.rbLostLicenses_CheckedChanged);
            // 
            // rbDamagedLicens
            // 
            this.rbDamagedLicens.AutoSize = true;
            this.rbDamagedLicens.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDamagedLicens.Location = new System.Drawing.Point(18, 26);
            this.rbDamagedLicens.Name = "rbDamagedLicens";
            this.rbDamagedLicens.Size = new System.Drawing.Size(144, 22);
            this.rbDamagedLicens.TabIndex = 0;
            this.rbDamagedLicens.Text = " Damaged Licens";
            this.rbDamagedLicens.UseVisualStyleBackColor = true;
            this.rbDamagedLicens.CheckedChanged += new System.EventHandler(this.rbDamagedLicens_CheckedChanged);
            // 
            // llShowNewLicenseInfo
            // 
            this.llShowNewLicenseInfo.AutoSize = true;
            this.llShowNewLicenseInfo.Enabled = false;
            this.llShowNewLicenseInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llShowNewLicenseInfo.Location = new System.Drawing.Point(226, 686);
            this.llShowNewLicenseInfo.Name = "llShowNewLicenseInfo";
            this.llShowNewLicenseInfo.Size = new System.Drawing.Size(163, 18);
            this.llShowNewLicenseInfo.TabIndex = 134;
            this.llShowNewLicenseInfo.TabStop = true;
            this.llShowNewLicenseInfo.Text = "Show New License Info";
            this.llShowNewLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llShowNewLicenseInfo_LinkClicked);
            // 
            // llShowLicenseHistory
            // 
            this.llShowLicenseHistory.AutoSize = true;
            this.llShowLicenseHistory.Enabled = false;
            this.llShowLicenseHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llShowLicenseHistory.Location = new System.Drawing.Point(24, 686);
            this.llShowLicenseHistory.Name = "llShowLicenseHistory";
            this.llShowLicenseHistory.Size = new System.Drawing.Size(152, 18);
            this.llShowLicenseHistory.TabIndex = 133;
            this.llShowLicenseHistory.TabStop = true;
            this.llShowLicenseHistory.Text = "Show License History";
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSave.Enabled = false;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Image = global::DVLD.Properties.Resources.Save_32;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(783, 678);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(225, 36);
            this.btnSave.TabIndex = 132;
            this.btnSave.Text = "Issue Replacement";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = global::DVLD.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(612, 678);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(134, 36);
            this.btnClose.TabIndex = 131;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblCreatedBy);
            this.groupBox2.Controls.Add(this.lblOldLicenseID);
            this.groupBox2.Controls.Add(this.lblRenewLicenseID);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.lblApplicationDate);
            this.groupBox2.Controls.Add(this.lblAAppFees);
            this.groupBox2.Controls.Add(this.lblLRAppID);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(27, 497);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(992, 163);
            this.groupBox2.TabIndex = 135;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Application Info For Replacement  Licenses";
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.AutoSize = true;
            this.lblCreatedBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedBy.Location = new System.Drawing.Point(778, 117);
            this.lblCreatedBy.Name = "lblCreatedBy";
            this.lblCreatedBy.Size = new System.Drawing.Size(68, 25);
            this.lblCreatedBy.TabIndex = 22;
            this.lblCreatedBy.Text = "[????]";
            // 
            // lblOldLicenseID
            // 
            this.lblOldLicenseID.AutoSize = true;
            this.lblOldLicenseID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOldLicenseID.Location = new System.Drawing.Point(778, 82);
            this.lblOldLicenseID.Name = "lblOldLicenseID";
            this.lblOldLicenseID.Size = new System.Drawing.Size(68, 25);
            this.lblOldLicenseID.TabIndex = 21;
            this.lblOldLicenseID.Text = "[????]";
            // 
            // lblRenewLicenseID
            // 
            this.lblRenewLicenseID.AutoSize = true;
            this.lblRenewLicenseID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRenewLicenseID.Location = new System.Drawing.Point(778, 40);
            this.lblRenewLicenseID.Name = "lblRenewLicenseID";
            this.lblRenewLicenseID.Size = new System.Drawing.Size(68, 25);
            this.lblRenewLicenseID.TabIndex = 20;
            this.lblRenewLicenseID.Text = "[????]";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(559, 117);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(116, 25);
            this.label14.TabIndex = 19;
            this.label14.Text = "Created By:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(559, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(197, 25);
            this.label4.TabIndex = 18;
            this.label4.Text = "Renewed License ID:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(559, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 25);
            this.label3.TabIndex = 17;
            this.label3.Text = "Old License ID";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(21, 81);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(160, 25);
            this.label12.TabIndex = 14;
            this.label12.Text = "Application Date:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(21, 117);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(163, 25);
            this.label10.TabIndex = 13;
            this.label10.Text = "Application Fees:";
            // 
            // lblApplicationDate
            // 
            this.lblApplicationDate.AutoSize = true;
            this.lblApplicationDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationDate.Location = new System.Drawing.Point(239, 81);
            this.lblApplicationDate.Name = "lblApplicationDate";
            this.lblApplicationDate.Size = new System.Drawing.Size(68, 25);
            this.lblApplicationDate.TabIndex = 12;
            this.lblApplicationDate.Text = "[????]";
            // 
            // lblAAppFees
            // 
            this.lblAAppFees.AutoSize = true;
            this.lblAAppFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAAppFees.Location = new System.Drawing.Point(239, 117);
            this.lblAAppFees.Name = "lblAAppFees";
            this.lblAAppFees.Size = new System.Drawing.Size(68, 25);
            this.lblAAppFees.TabIndex = 11;
            this.lblAAppFees.Text = "[????]";
            // 
            // lblLRAppID
            // 
            this.lblLRAppID.AutoSize = true;
            this.lblLRAppID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLRAppID.Location = new System.Drawing.Point(239, 40);
            this.lblLRAppID.Name = "lblLRAppID";
            this.lblLRAppID.Size = new System.Drawing.Size(68, 25);
            this.lblLRAppID.TabIndex = 8;
            this.lblLRAppID.Text = "[????]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 25);
            this.label2.TabIndex = 7;
            this.label2.Text = "L.R.Applicaion ID:";
            // 
            // frmReplacementDamagedorLostLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1035, 725);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.llShowNewLicenseInfo);
            this.Controls.Add(this.llShowLicenseHistory);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblTitel);
            this.Controls.Add(this.ucDriverLicenseInfoWithFilter1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmReplacementDamagedorLostLicenses";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Replacementc Damaged or Lost Licenses";
            this.Load += new System.EventHandler(this.frmReplacementDamagedorLostLicenses_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private License.Control.ucDriverLicenseInfoWithFilter ucDriverLicenseInfoWithFilter1;
        private System.Windows.Forms.Label lblTitel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbLostLicenses;
        private System.Windows.Forms.RadioButton rbDamagedLicens;
        private System.Windows.Forms.LinkLabel llShowNewLicenseInfo;
        private System.Windows.Forms.LinkLabel llShowLicenseHistory;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblLRAppID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblApplicationDate;
        private System.Windows.Forms.Label lblAAppFees;
        private System.Windows.Forms.Label lblCreatedBy;
        private System.Windows.Forms.Label lblOldLicenseID;
        private System.Windows.Forms.Label lblRenewLicenseID;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}