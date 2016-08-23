namespace MarathonSkills2015_TO6.User_Control
{
    partial class sponsorConfirmation
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
            this.label11 = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblTotAmount = new System.Windows.Forms.Label();
            this.lblCharity = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(25, 62);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(689, 52);
            this.label11.TabIndex = 68;
            this.label11.Text = "Thank you fopr sponsoring a runner in Marathon Skills 2015!\r\nYour donation will h" +
    "elp out their chosen charity";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.White;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(328, 304);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(84, 26);
            this.btnBack.TabIndex = 67;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lblTotAmount
            // 
            this.lblTotAmount.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTotAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotAmount.ForeColor = System.Drawing.Color.Gray;
            this.lblTotAmount.Location = new System.Drawing.Point(24, 218);
            this.lblTotAmount.Name = "lblTotAmount";
            this.lblTotAmount.Size = new System.Drawing.Size(696, 83);
            this.lblTotAmount.TabIndex = 66;
            this.lblTotAmount.Text = "$0";
            this.lblTotAmount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCharity
            // 
            this.lblCharity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCharity.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCharity.ForeColor = System.Drawing.Color.Gray;
            this.lblCharity.Location = new System.Drawing.Point(57, 175);
            this.lblCharity.Name = "lblCharity";
            this.lblCharity.Size = new System.Drawing.Size(629, 43);
            this.lblCharity.TabIndex = 65;
            this.lblCharity.Text = "Save the cats fund";
            this.lblCharity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(57, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(629, 43);
            this.label2.TabIndex = 64;
            this.label2.Text = "Thank you for your sponsorship!";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(57, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(629, 43);
            this.label1.TabIndex = 63;
            this.label1.Text = "Thank you for your sponsorship!";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sponsorConfirmation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.lblTotAmount);
            this.Controls.Add(this.lblCharity);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "sponsorConfirmation";
            this.Size = new System.Drawing.Size(738, 367);
            this.Load += new System.EventHandler(this.sponsorConfirmation_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblTotAmount;
        private System.Windows.Forms.Label lblCharity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
