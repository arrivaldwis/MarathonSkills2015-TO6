namespace MarathonSkills2015_TO6.User_Control
{
    partial class sponsorOverview
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
            this.label2 = new System.Windows.Forms.Label();
            this.cbRunner = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.lblTotSponsorship = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblCharities = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();

            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.label2.Location = new System.Drawing.Point(295, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(196, 24);
            this.label2.TabIndex = 9;
            this.label2.Text = "Sponsorship overview";
            // 
            // cbRunner
            // 
            this.cbRunner.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbRunner.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbRunner.FormattingEnabled = true;
            this.cbRunner.Items.AddRange(new object[] {
            "Charity Name",
            "Total Amount"});
            this.cbRunner.Location = new System.Drawing.Point(283, 57);
            this.cbRunner.Name = "cbRunner";
            this.cbRunner.Size = new System.Drawing.Size(198, 21);
            this.cbRunner.TabIndex = 66;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.label7.Location = new System.Drawing.Point(217, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 18);
            this.label7.TabIndex = 65;
            this.label7.Text = "Sort by:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // button5
            // 
            this.button5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button5.BackColor = System.Drawing.Color.White;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.Black;
            this.button5.Location = new System.Drawing.Point(487, 56);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(121, 32);
            this.button5.TabIndex = 70;
            this.button5.Text = "Sort";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // lblTotSponsorship
            // 
            this.lblTotSponsorship.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTotSponsorship.AutoSize = true;
            this.lblTotSponsorship.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotSponsorship.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblTotSponsorship.Location = new System.Drawing.Point(551, 113);
            this.lblTotSponsorship.Name = "lblTotSponsorship";
            this.lblTotSponsorship.Size = new System.Drawing.Size(56, 16);
            this.lblTotSponsorship.TabIndex = 81;
            this.lblTotSponsorship.Text = "Gender:";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.label5.Location = new System.Drawing.Point(406, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(139, 16);
            this.label5.TabIndex = 80;
            this.label5.Text = "Total Sponsorship:";
            // 
            // lblCharities
            // 
            this.lblCharities.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblCharities.AutoSize = true;
            this.lblCharities.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCharities.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblCharities.Location = new System.Drawing.Point(282, 113);
            this.lblCharities.Name = "lblCharities";
            this.lblCharities.Size = new System.Drawing.Size(56, 16);
            this.lblCharities.TabIndex = 79;
            this.lblCharities.Text = "Gender:";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.label1.Location = new System.Drawing.Point(203, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 16);
            this.label1.TabIndex = 78;
            this.label1.Text = "Charities:";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(27, 146);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(741, 335);
            this.flowLayoutPanel1.TabIndex = 82;

            // 
            // sponsorOverview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.lblTotSponsorship);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblCharities);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.cbRunner);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Name = "sponsorOverview";
            this.Size = new System.Drawing.Size(789, 501);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbRunner;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label lblTotSponsorship;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblCharities;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
