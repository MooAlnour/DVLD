namespace DVLD.Applications.Local_Driving_License_Application
{
    partial class ucLocalDrivingApplicationInfo
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblPassedTest = new System.Windows.Forms.Label();
            this.lblDLApplicationID = new System.Windows.Forms.Label();
            this.lblApplicationDate = new System.Windows.Forms.Label();
            this.lblLicenseClass = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ucApplicationInfo1 = new DVLD.Applications.ucApplicationInfo();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblPassedTest);
            this.groupBox1.Controls.Add(this.lblDLApplicationID);
            this.groupBox1.Controls.Add(this.lblApplicationDate);
            this.groupBox1.Controls.Add(this.lblLicenseClass);
            this.groupBox1.Controls.Add(this.lbl1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(904, 186);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Local Driving Application Info";
            // 
            // lblPassedTest
            // 
            this.lblPassedTest.AutoSize = true;
            this.lblPassedTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassedTest.Location = new System.Drawing.Point(539, 109);
            this.lblPassedTest.Name = "lblPassedTest";
            this.lblPassedTest.Size = new System.Drawing.Size(68, 25);
            this.lblPassedTest.TabIndex = 18;
            this.lblPassedTest.Text = "[????]";
            this.lblPassedTest.Click += new System.EventHandler(this.lblPassedTest_Click);
            // 
            // lblDLApplicationID
            // 
            this.lblDLApplicationID.AutoSize = true;
            this.lblDLApplicationID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDLApplicationID.Location = new System.Drawing.Point(138, 34);
            this.lblDLApplicationID.Name = "lblDLApplicationID";
            this.lblDLApplicationID.Size = new System.Drawing.Size(68, 25);
            this.lblDLApplicationID.TabIndex = 17;
            this.lblDLApplicationID.Text = "[????]";
            // 
            // lblApplicationDate
            // 
            this.lblApplicationDate.AutoSize = true;
            this.lblApplicationDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationDate.Location = new System.Drawing.Point(539, 34);
            this.lblApplicationDate.Name = "lblApplicationDate";
            this.lblApplicationDate.Size = new System.Drawing.Size(68, 25);
            this.lblApplicationDate.TabIndex = 14;
            this.lblApplicationDate.Text = "[????]";
            // 
            // lblLicenseClass
            // 
            this.lblLicenseClass.AutoSize = true;
            this.lblLicenseClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLicenseClass.Location = new System.Drawing.Point(363, 109);
            this.lblLicenseClass.Name = "lblLicenseClass";
            this.lblLicenseClass.Size = new System.Drawing.Size(128, 25);
            this.lblLicenseClass.TabIndex = 11;
            this.lblLicenseClass.Text = "Passed Test:";
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.Location = new System.Drawing.Point(331, 34);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(160, 25);
            this.lbl1.TabIndex = 10;
            this.lbl1.Text = "Application Date:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 25);
            this.label2.TabIndex = 9;
            this.label2.Text = "D.L.App ID:";
            // 
            // ucApplicationInfo1
            // 
            this.ucApplicationInfo1.Location = new System.Drawing.Point(3, 195);
            this.ucApplicationInfo1.Name = "ucApplicationInfo1";
            this.ucApplicationInfo1.Size = new System.Drawing.Size(916, 238);
            this.ucApplicationInfo1.TabIndex = 1;
            // 
            // ucLocalDrivingApplicationInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ucApplicationInfo1);
            this.Controls.Add(this.groupBox1);
            this.Name = "ucLocalDrivingApplicationInfo";
            this.Size = new System.Drawing.Size(932, 445);
            this.Load += new System.EventHandler(this.ucLocalDrivingApplicationInfo_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblDLApplicationID;
        private System.Windows.Forms.Label lblApplicationDate;
        private System.Windows.Forms.Label lblLicenseClass;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblPassedTest;
        private ucApplicationInfo ucApplicationInfo1;
    }
}
