namespace Library
{
    partial class View
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.booksbtn = new System.Windows.Forms.Button();
            this.studbtn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.debtbtn = new System.Windows.Forms.Button();
            this.searchtxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Connect";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(93, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Disconnected";
            // 
            // booksbtn
            // 
            this.booksbtn.Enabled = false;
            this.booksbtn.Location = new System.Drawing.Point(613, 367);
            this.booksbtn.Name = "booksbtn";
            this.booksbtn.Size = new System.Drawing.Size(175, 23);
            this.booksbtn.TabIndex = 2;
            this.booksbtn.Text = "Show Books";
            this.booksbtn.UseVisualStyleBackColor = true;
            this.booksbtn.Click += new System.EventHandler(this.shbooksbtn_Click);
            // 
            // studbtn
            // 
            this.studbtn.Enabled = false;
            this.studbtn.Location = new System.Drawing.Point(396, 367);
            this.studbtn.Name = "studbtn";
            this.studbtn.Size = new System.Drawing.Size(175, 23);
            this.studbtn.TabIndex = 3;
            this.studbtn.Text = "Show Student";
            this.studbtn.UseVisualStyleBackColor = true;
            this.studbtn.Click += new System.EventHandler(this.srudbtn_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 58);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(776, 303);
            this.dataGridView1.TabIndex = 4;
            // 
            // debtbtn
            // 
            this.debtbtn.Enabled = false;
            this.debtbtn.Location = new System.Drawing.Point(396, 396);
            this.debtbtn.Name = "debtbtn";
            this.debtbtn.Size = new System.Drawing.Size(175, 23);
            this.debtbtn.TabIndex = 5;
            this.debtbtn.Text = "Current Student debt";
            this.debtbtn.UseVisualStyleBackColor = true;
            this.debtbtn.Click += new System.EventHandler(this.debtbtn_Click);
            // 
            // searchtxt
            // 
            this.searchtxt.Enabled = false;
            this.searchtxt.Location = new System.Drawing.Point(580, 22);
            this.searchtxt.Name = "searchtxt";
            this.searchtxt.Size = new System.Drawing.Size(208, 20);
            this.searchtxt.TabIndex = 7;
            this.searchtxt.TextChanged += new System.EventHandler(this.searchtxt_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(490, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Search Student";
            // 
            // View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.searchtxt);
            this.Controls.Add(this.debtbtn);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.studbtn);
            this.Controls.Add(this.booksbtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "View";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button booksbtn;
        private System.Windows.Forms.Button studbtn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button debtbtn;
        private System.Windows.Forms.TextBox searchtxt;
        private System.Windows.Forms.Label label2;
    }
}

