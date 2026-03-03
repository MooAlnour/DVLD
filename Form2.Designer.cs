namespace DVLD
{
    partial class Form2
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
            this.ucScheduleTest1 = new DVLD.Tests.Control.ucScheduleTest();
            this.SuspendLayout();
            // 
            // ucScheduleTest1
            // 
            this.ucScheduleTest1.Location = new System.Drawing.Point(12, 12);
            this.ucScheduleTest1.Name = "ucScheduleTest1";
            this.ucScheduleTest1.Size = new System.Drawing.Size(632, 690);
            this.ucScheduleTest1.TabIndex = 0;
            this.ucScheduleTest1.TestType = DVLD.Business.clsManageTestType.enTestType.VisionTest;
            this.ucScheduleTest1.Load += new System.EventHandler(this.ucScheduleTest1_Load);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 715);
            this.Controls.Add(this.ucScheduleTest1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Tests.Control.ucScheduleTest ucScheduleTest1;
    }
}