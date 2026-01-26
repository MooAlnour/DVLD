namespace DVLD.People
{
    partial class frmAddEditPersonInfo
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
            this.ucAddEditPersonInfo1 = new DVLD.People.ucAddEditPersonInfo();
            this.SuspendLayout();
            // 
            // ucAddEditPersonInfo1
            // 
            this.ucAddEditPersonInfo1.Location = new System.Drawing.Point(12, 101);
            this.ucAddEditPersonInfo1.Name = "ucAddEditPersonInfo1";
            this.ucAddEditPersonInfo1.Size = new System.Drawing.Size(864, 402);
            this.ucAddEditPersonInfo1.TabIndex = 0;
            // 
            // AddEditPersonInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 531);
            this.Controls.Add(this.ucAddEditPersonInfo1);
            this.Name = "AddEditPersonInfo";
            this.Text = "AddEditPersonInfo";
            this.Load += new System.EventHandler(this.AddEditPersonInfo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ucAddEditPersonInfo ucAddEditPersonInfo1;
    }
}