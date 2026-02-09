namespace DVLD.Users
{
    partial class frmShowUser
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
            this.ucUserDetails1 = new DVLD.Users.ucUserDetails();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ucUserDetails1
            // 
            this.ucUserDetails1.Location = new System.Drawing.Point(12, 81);
            this.ucUserDetails1.Name = "ucUserDetails1";
            this.ucUserDetails1.Size = new System.Drawing.Size(847, 359);
            this.ucUserDetails1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(323, 32);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(249, 46);
            this.label3.TabIndex = 105;
            this.label3.Text = "User Details";
            // 
            // frmShowUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 446);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ucUserDetails1);
            this.Name = "frmShowUser";
            this.Text = "frmShowUser";
            this.Load += new System.EventHandler(this.frmShowUser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ucUserDetails ucUserDetails1;
        private System.Windows.Forms.Label label3;
    }
}