namespace MarathonSkills2015_TO6.User_Control
{
    partial class runnerManagement
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
            this.lblTotRunner = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.cbSort = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbRaceEvent = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.label2.Location = new System.Drawing.Point(290, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(189, 24);
            this.label2.TabIndex = 9;
            this.label2.Text = "Runner Management";
            // 
            // lblTotRunner
            // 
            this.lblTotRunner.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTotRunner.AutoSize = true;
            this.lblTotRunner.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotRunner.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblTotRunner.Location = new System.Drawing.Point(415, 209);
            this.lblTotRunner.Name = "lblTotRunner";
            this.lblTotRunner.Size = new System.Drawing.Size(56, 16);
            this.lblTotRunner.TabIndex = 84;
            this.lblTotRunner.Text = "Gender:";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.label7.Location = new System.Drawing.Point(306, 209);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 16);
            this.label7.TabIndex = 83;
            this.label7.Text = "Total runners:";
            // 
            // button5
            // 
            this.button5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button5.BackColor = System.Drawing.Color.White;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.Black;
            this.button5.Location = new System.Drawing.Point(298, 153);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(121, 32);
            this.button5.TabIndex = 82;
            this.button5.Text = "Refresh";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // cbSort
            // 
            this.cbSort.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbSort.BackColor = System.Drawing.Color.White;
            this.cbSort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbSort.FormattingEnabled = true;
            this.cbSort.Items.AddRange(new object[] {
            "First Name",
            "Last Name",
            "Email",
            "Status"});
            this.cbSort.Location = new System.Drawing.Point(160, 164);
            this.cbSort.Name = "cbSort";
            this.cbSort.Size = new System.Drawing.Size(132, 21);
            this.cbSort.TabIndex = 81;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.label4.Location = new System.Drawing.Point(92, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 18);
            this.label4.TabIndex = 80;
            this.label4.Text = "Sort by:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cbRaceEvent
            // 
            this.cbRaceEvent.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbRaceEvent.BackColor = System.Drawing.Color.White;
            this.cbRaceEvent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbRaceEvent.FormattingEnabled = true;
            this.cbRaceEvent.Location = new System.Drawing.Point(160, 129);
            this.cbRaceEvent.Name = "cbRaceEvent";
            this.cbRaceEvent.Size = new System.Drawing.Size(132, 21);
            this.cbRaceEvent.TabIndex = 79;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.label1.Location = new System.Drawing.Point(63, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 18);
            this.label1.TabIndex = 78;
            this.label1.Text = "Race Event:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cbStatus
            // 
            this.cbStatus.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbStatus.BackColor = System.Drawing.Color.White;
            this.cbStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Location = new System.Drawing.Point(160, 93);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(132, 21);
            this.cbStatus.TabIndex = 77;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.label6.Location = new System.Drawing.Point(97, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 18);
            this.label6.TabIndex = 76;
            this.label6.Text = "Status:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.label3.Location = new System.Drawing.Point(573, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 24);
            this.label3.TabIndex = 85;
            this.label3.Text = "Export";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.label5.Location = new System.Drawing.Point(123, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 24);
            this.label5.TabIndex = 86;
            this.label5.Text = "Sort and Filter";
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(507, 93);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(202, 32);
            this.button1.TabIndex = 87;
            this.button1.Text = "Runner Details (CSV)";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(507, 131);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(202, 32);
            this.button2.TabIndex = 88;
            this.button2.Text = "Email address list";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(21, 245);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(766, 267);
            this.dataGridView1.TabIndex = 89;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.button6);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Location = new System.Drawing.Point(182, 93);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(408, 308);
            this.panel1.TabIndex = 101;
            this.panel1.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(13, 51);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(384, 241);
            this.textBox1.TabIndex = 56;
            // 
            // button6
            // 
            this.button6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button6.BackColor = System.Drawing.Color.White;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button6.Location = new System.Drawing.Point(360, 5);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(37, 32);
            this.button6.TabIndex = 23;
            this.button6.Text = "X";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(3, 3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(400, 43);
            this.label8.TabIndex = 55;
            this.label8.Text = "Email address";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // runnerManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblTotRunner);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.cbSort);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbRaceEvent);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbStatus);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Name = "runnerManagement";
            this.Size = new System.Drawing.Size(805, 529);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblTotRunner;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ComboBox cbSort;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbRaceEvent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
    }
}
