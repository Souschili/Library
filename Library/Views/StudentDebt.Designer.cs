namespace Library.Views
{
    partial class StudentDebt
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.clsbookbtn = new System.Windows.Forms.Button();
            this.Addbokbtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(942, 207);
            this.dataGridView1.TabIndex = 0;
            // 
            // clsbookbtn
            // 
            this.clsbookbtn.Location = new System.Drawing.Point(713, 316);
            this.clsbookbtn.Name = "clsbookbtn";
            this.clsbookbtn.Size = new System.Drawing.Size(75, 23);
            this.clsbookbtn.TabIndex = 1;
            this.clsbookbtn.Text = "Close Book";
            this.clsbookbtn.UseVisualStyleBackColor = true;
            this.clsbookbtn.Click += new System.EventHandler(this.clsbookbtn_Click);
            // 
            // Addbokbtn
            // 
            this.Addbokbtn.Location = new System.Drawing.Point(617, 316);
            this.Addbokbtn.Name = "Addbokbtn";
            this.Addbokbtn.Size = new System.Drawing.Size(75, 23);
            this.Addbokbtn.TabIndex = 2;
            this.Addbokbtn.Text = "Add Book";
            this.Addbokbtn.UseVisualStyleBackColor = true;
            this.Addbokbtn.Click += new System.EventHandler(this.Addbokbtn_Click);
            // 
            // StudentDebt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 351);
            this.Controls.Add(this.Addbokbtn);
            this.Controls.Add(this.clsbookbtn);
            this.Controls.Add(this.dataGridView1);
            this.Name = "StudentDebt";
            this.Text = "StudentDebt";
            this.Load += new System.EventHandler(this.StudentDebt_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button clsbookbtn;
        private System.Windows.Forms.Button Addbokbtn;
    }
}