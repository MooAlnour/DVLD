namespace DVLD.Tests.TestAppointment
{
    partial class frmVisionTest
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
            this.btnClose = new System.Windows.Forms.Button();
            this.ucScheduleTest1 = new DVLD.Tests.Control.ucScheduleTest();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = global::DVLD.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(510, 691);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(134, 36);
            this.btnClose.TabIndex = 127;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // ucScheduleTest1
            // 
            this.ucScheduleTest1.Location = new System.Drawing.Point(12, 22);
            this.ucScheduleTest1.Name = "ucScheduleTest1";
            this.ucScheduleTest1.Size = new System.Drawing.Size(632, 663);
            this.ucScheduleTest1.TabIndex = 128;
            this.ucScheduleTest1.TestType = DVLD.Business.clsManageTestType.enTestType.VisionTest;
            // 
            // frmVisionTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(693, 743);
            this.Controls.Add(this.ucScheduleTest1);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmVisionTest";
            this.Text = "Vision Test";
            this.Load += new System.EventHandler(this.frmVisionTest_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnClose;
        private Control.ucScheduleTest ucScheduleTest1;
    }
}