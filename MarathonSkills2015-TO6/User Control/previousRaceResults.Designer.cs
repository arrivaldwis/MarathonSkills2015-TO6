namespace MarathonSkills2015_TO6.User_Control
{
    partial class previousRaceResults
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
            this.cbMarathon = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbRaceEvent = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbAgeCategory = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbGender = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.lblRunnerFinished = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTotRunner = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblRaceTime = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.label2.Location = new System.Drawing.Point(298, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(184, 24);
            this.label2.TabIndex = 9;
            this.label2.Text = "Previous race results";
            // 
            // cbMarathon
            // 
            this.cbMarathon.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbMarathon.BackColor = System.Drawing.Color.White;
            this.cbMarathon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbMarathon.FormattingEnabled = true;
            this.cbMarathon.Location = new System.Drawing.Point(182, 79);
            this.cbMarathon.Name = "cbMarathon";
            this.cbMarathon.Size = new System.Drawing.Size(132, 21);
            this.cbMarathon.TabIndex = 66;
            this.cbMarathon.SelectedIndexChanged += new System.EventHandler(this.cbMarathon_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.label6.Location = new System.Drawing.Point(98, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 18);
            this.label6.TabIndex = 65;
            this.label6.Text = "Marathon:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cbRaceEvent
            // 
            this.cbRaceEvent.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbRaceEvent.BackColor = System.Drawing.Color.White;
            this.cbRaceEvent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbRaceEvent.FormattingEnabled = true;
            this.cbRaceEvent.Location = new System.Drawing.Point(182, 115);
            this.cbRaceEvent.Name = "cbRaceEvent";
            this.cbRaceEvent.Size = new System.Drawing.Size(132, 21);
            this.cbRaceEvent.TabIndex = 68;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.label1.Location = new System.Drawing.Point(85, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 18);
            this.label1.TabIndex = 67;
            this.label1.Text = "Race Event:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cbAgeCategory
            // 
            this.cbAgeCategory.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbAgeCategory.BackColor = System.Drawing.Color.White;
            this.cbAgeCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbAgeCategory.FormattingEnabled = true;
            this.cbAgeCategory.Items.AddRange(new object[] {
            "Any",
            "Under 18",
            "18 to 29",
            "30 to 39",
            "40 to 55",
            "56 to 70",
            "Over 70"});
            this.cbAgeCategory.Location = new System.Drawing.Point(452, 119);
            this.cbAgeCategory.Name = "cbAgeCategory";
            this.cbAgeCategory.Size = new System.Drawing.Size(132, 21);
            this.cbAgeCategory.TabIndex = 72;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.label3.Location = new System.Drawing.Point(348, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 18);
            this.label3.TabIndex = 71;
            this.label3.Text = "Age category:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cbGender
            // 
            this.cbGender.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbGender.BackColor = System.Drawing.Color.White;
            this.cbGender.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbGender.FormattingEnabled = true;
            this.cbGender.Location = new System.Drawing.Point(452, 82);
            this.cbGender.Name = "cbGender";
            this.cbGender.Size = new System.Drawing.Size(132, 21);
            this.cbGender.TabIndex = 70;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.label4.Location = new System.Drawing.Point(378, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 18);
            this.label4.TabIndex = 69;
            this.label4.Text = "Gender:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // button5
            // 
            this.button5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button5.BackColor = System.Drawing.Color.White;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.Black;
            this.button5.Location = new System.Drawing.Point(601, 107);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(121, 32);
            this.button5.TabIndex = 73;
            this.button5.Text = "Search";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // lblRunnerFinished
            // 
            this.lblRunnerFinished.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblRunnerFinished.AutoSize = true;
            this.lblRunnerFinished.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRunnerFinished.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblRunnerFinished.Location = new System.Drawing.Point(420, 173);
            this.lblRunnerFinished.Name = "lblRunnerFinished";
            this.lblRunnerFinished.Size = new System.Drawing.Size(56, 16);
            this.lblRunnerFinished.TabIndex = 77;
            this.lblRunnerFinished.Text = "Gender:";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.label5.Location = new System.Drawing.Point(253, 173);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(161, 16);
            this.label5.TabIndex = 76;
            this.label5.Text = "Total runners finished:";
            // 
            // lblTotRunner
            // 
            this.lblTotRunner.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTotRunner.AutoSize = true;
            this.lblTotRunner.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotRunner.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblTotRunner.Location = new System.Drawing.Point(159, 173);
            this.lblTotRunner.Name = "lblTotRunner";
            this.lblTotRunner.Size = new System.Drawing.Size(56, 16);
            this.lblTotRunner.TabIndex = 75;
            this.lblTotRunner.Text = "Gender:";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.label7.Location = new System.Drawing.Point(50, 173);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 16);
            this.label7.TabIndex = 74;
            this.label7.Text = "Total runners:";
            // 
            // lblRaceTime
            // 
            this.lblRaceTime.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblRaceTime.AutoSize = true;
            this.lblRaceTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRaceTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblRaceTime.Location = new System.Drawing.Point(661, 173);
            this.lblRaceTime.Name = "lblRaceTime";
            this.lblRaceTime.Size = new System.Drawing.Size(56, 16);
            this.lblRaceTime.TabIndex = 79;
            this.lblRaceTime.Text = "Gender:";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.label9.Location = new System.Drawing.Point(516, 173);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(139, 16);
            this.label9.TabIndex = 78;
            this.label9.Text = "Average race time:";
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listView1.Location = new System.Drawing.Point(29, 205);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(749, 283);
            this.listView1.TabIndex = 80;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Rank";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Race Time";
            this.columnHeader2.Width = 115;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Runner name";
            this.columnHeader3.Width = 118;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Country";
            // 
            // previousRaceResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.lblRaceTime);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblRunnerFinished);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblTotRunner);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.cbAgeCategory);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbGender);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbRaceEvent);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbMarathon);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Name = "previousRaceResult";
            this.Size = new System.Drawing.Size(801, 510);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label lblRaceTime;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblRunnerFinished;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTotRunner;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ComboBox cbAgeCategory;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbGender;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbRaceEvent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbMarathon;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
    }
}
