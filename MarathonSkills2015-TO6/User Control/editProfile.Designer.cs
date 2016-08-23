namespace MarathonSkills2015_TO6.User_Control
{
    partial class editProfile
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
            this.label12 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.cbRegStatus = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.dtDOB = new System.Windows.Forms.DateTimePicker();
            this.cbCountry = new System.Windows.Forms.ComboBox();
            this.cbGender = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtFirstname = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLastname = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPasswordAgain = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.label12.Location = new System.Drawing.Point(357, 118);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(317, 39);
            this.label12.TabIndex = 121;
            this.label12.Text = "Leave these field blank if you do not want change password";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button3
            // 
            this.button3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button3.BackColor = System.Drawing.Color.White;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.Black;
            this.button3.Location = new System.Drawing.Point(351, 449);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(121, 32);
            this.button3.TabIndex = 120;
            this.button3.Text = "Cancel";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            this.button5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button5.BackColor = System.Drawing.Color.White;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.Black;
            this.button5.Location = new System.Drawing.Point(224, 449);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(121, 32);
            this.button5.TabIndex = 119;
            this.button5.Text = "Save";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // cbRegStatus
            // 
            this.cbRegStatus.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbRegStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRegStatus.FormattingEnabled = true;
            this.cbRegStatus.Location = new System.Drawing.Point(415, 322);
            this.cbRegStatus.Name = "cbRegStatus";
            this.cbRegStatus.Size = new System.Drawing.Size(198, 21);
            this.cbRegStatus.TabIndex = 118;
            this.cbRegStatus.Visible = false;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.label11.Location = new System.Drawing.Point(352, 266);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(322, 43);
            this.label11.TabIndex = 117;
            this.label11.Text = "Registration Status";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label11.Visible = false;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.label10.Location = new System.Drawing.Point(352, 75);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(322, 43);
            this.label10.TabIndex = 116;
            this.label10.Text = "Change password";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEmail
            // 
            this.lblEmail.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblEmail.Location = new System.Drawing.Point(124, 94);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(251, 43);
            this.lblEmail.TabIndex = 115;
            this.lblEmail.Text = "Email:";
            this.lblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtDOB
            // 
            this.dtDOB.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtDOB.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDOB.Location = new System.Drawing.Point(127, 276);
            this.dtDOB.Name = "dtDOB";
            this.dtDOB.Size = new System.Drawing.Size(121, 20);
            this.dtDOB.TabIndex = 114;
            // 
            // cbCountry
            // 
            this.cbCountry.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCountry.FormattingEnabled = true;
            this.cbCountry.Location = new System.Drawing.Point(127, 322);
            this.cbCountry.Name = "cbCountry";
            this.cbCountry.Size = new System.Drawing.Size(121, 21);
            this.cbCountry.TabIndex = 113;
            this.cbCountry.SelectedIndexChanged += new System.EventHandler(this.cbCountry_SelectedIndexChanged);
            // 
            // cbGender
            // 
            this.cbGender.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGender.FormattingEnabled = true;
            this.cbGender.Location = new System.Drawing.Point(127, 231);
            this.cbGender.Name = "cbGender";
            this.cbGender.Size = new System.Drawing.Size(121, 21);
            this.cbGender.TabIndex = 112;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.label7.Location = new System.Drawing.Point(16, 309);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 43);
            this.label7.TabIndex = 111;
            this.label7.Text = "Country:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.label8.Location = new System.Drawing.Point(16, 266);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 43);
            this.label8.TabIndex = 110;
            this.label8.Text = "Date of Birth:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.label9.Location = new System.Drawing.Point(16, 223);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(104, 43);
            this.label9.TabIndex = 109;
            this.label9.Text = "Gender:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtFirstname
            // 
            this.txtFirstname.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtFirstname.Location = new System.Drawing.Point(127, 150);
            this.txtFirstname.Name = "txtFirstname";
            this.txtFirstname.Size = new System.Drawing.Size(166, 20);
            this.txtFirstname.TabIndex = 108;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.label5.Location = new System.Drawing.Point(16, 180);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 43);
            this.label5.TabIndex = 107;
            this.label5.Text = "Last Name:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtLastname
            // 
            this.txtLastname.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtLastname.Location = new System.Drawing.Point(127, 193);
            this.txtLastname.Name = "txtLastname";
            this.txtLastname.Size = new System.Drawing.Size(166, 20);
            this.txtLastname.TabIndex = 106;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.label6.Location = new System.Drawing.Point(16, 137);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 43);
            this.label6.TabIndex = 105;
            this.label6.Text = "First Name:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPasswordAgain
            // 
            this.txtPasswordAgain.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtPasswordAgain.Location = new System.Drawing.Point(493, 213);
            this.txtPasswordAgain.Name = "txtPasswordAgain";
            this.txtPasswordAgain.PasswordChar = '*';
            this.txtPasswordAgain.Size = new System.Drawing.Size(166, 20);
            this.txtPasswordAgain.TabIndex = 104;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.label4.Location = new System.Drawing.Point(358, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 43);
            this.label4.TabIndex = 103;
            this.label4.Text = "Password Again:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtPassword.Location = new System.Drawing.Point(493, 170);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(166, 20);
            this.txtPassword.TabIndex = 102;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.label3.Location = new System.Drawing.Point(362, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 43);
            this.label3.TabIndex = 101;
            this.label3.Text = "Password:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.label2.Location = new System.Drawing.Point(16, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 43);
            this.label2.TabIndex = 100;
            this.label2.Text = "Email:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.label1.Location = new System.Drawing.Point(-12, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(713, 43);
            this.label1.TabIndex = 99;
            this.label1.Text = "Edit your profile";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // editProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label12);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.cbRegStatus);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.dtDOB);
            this.Controls.Add(this.cbCountry);
            this.Controls.Add(this.cbGender);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtFirstname);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtLastname);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtPasswordAgain);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Name = "editProfile";
            this.Size = new System.Drawing.Size(688, 495);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ComboBox cbRegStatus;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.DateTimePicker dtDOB;
        private System.Windows.Forms.ComboBox cbCountry;
        private System.Windows.Forms.ComboBox cbGender;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtFirstname;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtLastname;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPasswordAgain;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
