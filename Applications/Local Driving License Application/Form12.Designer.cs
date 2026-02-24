namespace DVLD.Applications.Local_Driving_License_Application
{
    partial class Form12
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
            this.ucLocalDrivingApplicationInfo1 = new DVLD.Applications.Local_Driving_License_Application.ucLocalDrivingApplicationInfo();
            this.SuspendLayout();
            // 
            // ucLocalDrivingApplicationInfo1
            // 
            this.ucLocalDrivingApplicationInfo1.Location = new System.Drawing.Point(12, 12);
            this.ucLocalDrivingApplicationInfo1.Name = "ucLocalDrivingApplicationInfo1";
            this.ucLocalDrivingApplicationInfo1.Size = new System.Drawing.Size(922, 445);
            this.ucLocalDrivingApplicationInfo1.TabIndex = 0;
            // 
            // Form12
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 488);
            this.Controls.Add(this.ucLocalDrivingApplicationInfo1);
            this.Name = "Form12";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private ucLocalDrivingApplicationInfo ucLocalDrivingApplicationInfo1;
    }
}