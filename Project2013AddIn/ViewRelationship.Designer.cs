namespace Project2013AddIn
{
    partial class ViewRelationship
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
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageMultiple = new System.Windows.Forms.TabPage();
            this.tabPageBinary = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabPageUnary = new System.Windows.Forms.TabPage();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.tabPageMultiple.SuspendLayout();
            this.tabPageBinary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPageUnary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(105, 450);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(226, 450);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(344, 450);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageMultiple);
            this.tabControl1.Controls.Add(this.tabPageBinary);
            this.tabControl1.Controls.Add(this.tabPageUnary);
            this.tabControl1.Location = new System.Drawing.Point(34, 32);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(449, 397);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPageMultiple
            // 
            this.tabPageMultiple.Controls.Add(this.dataGridView3);
            this.tabPageMultiple.Location = new System.Drawing.Point(4, 22);
            this.tabPageMultiple.Name = "tabPageMultiple";
            this.tabPageMultiple.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMultiple.Size = new System.Drawing.Size(441, 371);
            this.tabPageMultiple.TabIndex = 2;
            this.tabPageMultiple.Text = "Multiple Relationship";
            this.tabPageMultiple.UseVisualStyleBackColor = true;
            // 
            // tabPageBinary
            // 
            this.tabPageBinary.Controls.Add(this.dataGridView1);
            this.tabPageBinary.Location = new System.Drawing.Point(4, 22);
            this.tabPageBinary.Name = "tabPageBinary";
            this.tabPageBinary.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageBinary.Size = new System.Drawing.Size(441, 371);
            this.tabPageBinary.TabIndex = 0;
            this.tabPageBinary.Text = "Binary Relationship";
            this.tabPageBinary.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(445, 371);
            this.dataGridView1.TabIndex = 0;
            // 
            // tabPageUnary
            // 
            this.tabPageUnary.Controls.Add(this.dataGridView2);
            this.tabPageUnary.Location = new System.Drawing.Point(4, 22);
            this.tabPageUnary.Name = "tabPageUnary";
            this.tabPageUnary.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageUnary.Size = new System.Drawing.Size(441, 371);
            this.tabPageUnary.TabIndex = 1;
            this.tabPageUnary.Text = "Unary Relationship";
            this.tabPageUnary.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(0, 0);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(442, 371);
            this.dataGridView2.TabIndex = 0;
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToAddRows = false;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(0, 0);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.ReadOnly = true;
            this.dataGridView3.Size = new System.Drawing.Size(441, 371);
            this.dataGridView3.TabIndex = 0;
            // 
            // ViewRelationship
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 489);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnDelete);
            this.Name = "ViewRelationship";
            this.Text = "View Relationship";
            this.tabControl1.ResumeLayout(false);
            this.tabPageMultiple.ResumeLayout(false);
            this.tabPageBinary.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPageUnary.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageBinary;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabPage tabPageUnary;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TabPage tabPageMultiple;
        private System.Windows.Forms.DataGridView dataGridView3;
    }
}