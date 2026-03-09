namespace DVLD.Driver
{
    partial class frmShowPersonHistorylicense
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ucLicensesHistory1 = new DVLD.Driver.ucLicensesHistory();
            this.ucPersonCardWithFilter1 = new DVLD.People.Controls.ucPersonCardWithFilter();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD.Properties.Resources.PersonLicenseHistory_5121;
            this.pictureBox1.Location = new System.Drawing.Point(46, 131);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(277, 229);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // ucLicensesHistory1
            // 
            this.ucLicensesHistory1.BackColor = System.Drawing.Color.White;
            this.ucLicensesHistory1.Location = new System.Drawing.Point(12, 412);
            this.ucLicensesHistory1.Name = "ucLicensesHistory1";
            this.ucLicensesHistory1.Size = new System.Drawing.Size(1191, 337);
            this.ucLicensesHistory1.TabIndex = 2;
            // 
            // ucPersonCardWithFilter1
            // 
            this.ucPersonCardWithFilter1.BackColor = System.Drawing.Color.White;
            this.ucPersonCardWithFilter1.FilterEnabled = true;
            this.ucPersonCardWithFilter1.Location = new System.Drawing.Point(373, 53);
            this.ucPersonCardWithFilter1.Name = "ucPersonCardWithFilter1";
            this.ucPersonCardWithFilter1.ShowAddPerson = true;
            this.ucPersonCardWithFilter1.Size = new System.Drawing.Size(830, 353);
            this.ucPersonCardWithFilter1.TabIndex = 1;
            this.ucPersonCardWithFilter1.OnPersonSelected += new System.Action<int>(this.ucPersonCardWithFilter1_OnPersonSelected);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = global::DVLD.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1069, 744);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(134, 36);
            this.btnClose.TabIndex = 130;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmShowPersonHistorylicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1220, 783);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ucLicensesHistory1);
            this.Controls.Add(this.ucPersonCardWithFilter1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmShowPersonHistorylicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Show Person History license";
            this.Load += new System.EventHandler(this.frmShowPersonHistorylicense_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private People.Controls.ucPersonCardWithFilter ucPersonCardWithFilter1;
        private ucLicensesHistory ucLicensesHistory1;
        private System.Windows.Forms.Button btnClose;
    }
}