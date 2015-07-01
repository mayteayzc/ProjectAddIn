namespace Project2013AddIn
{
    partial class AddMultiple
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
            this.comboBoxRelation = new System.Windows.Forms.ComboBox();
            this.comboBoxTask1 = new System.Windows.Forms.ComboBox();
            this.comboBoxTask2 = new System.Windows.Forms.ComboBox();
            this.panelMore = new System.Windows.Forms.Panel();
            this.labelTask5 = new System.Windows.Forms.Label();
            this.comboBoxTask5 = new System.Windows.Forms.ComboBox();
            this.labelTask4 = new System.Windows.Forms.Label();
            this.comboBoxTask4 = new System.Windows.Forms.ComboBox();
            this.labelTask3 = new System.Windows.Forms.Label();
            this.comboBoxTask3 = new System.Windows.Forms.ComboBox();
            this.labelRelation = new System.Windows.Forms.Label();
            this.labelTask1 = new System.Windows.Forms.Label();
            this.labelTask2 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnMore = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.panelMore.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxRelation
            // 
            this.comboBoxRelation.FormattingEnabled = true;
            this.comboBoxRelation.Items.AddRange(new object[] {
            "Meet ",
            "Disjoint"});
            this.comboBoxRelation.Location = new System.Drawing.Point(12, 37);
            this.comboBoxRelation.Name = "comboBoxRelation";
            this.comboBoxRelation.Size = new System.Drawing.Size(121, 21);
            this.comboBoxRelation.TabIndex = 0;
            // 
            // comboBoxTask1
            // 
            this.comboBoxTask1.FormattingEnabled = true;
            this.comboBoxTask1.Location = new System.Drawing.Point(12, 88);
            this.comboBoxTask1.Name = "comboBoxTask1";
            this.comboBoxTask1.Size = new System.Drawing.Size(121, 21);
            this.comboBoxTask1.TabIndex = 1;
            // 
            // comboBoxTask2
            // 
            this.comboBoxTask2.FormattingEnabled = true;
            this.comboBoxTask2.Location = new System.Drawing.Point(12, 141);
            this.comboBoxTask2.Name = "comboBoxTask2";
            this.comboBoxTask2.Size = new System.Drawing.Size(121, 21);
            this.comboBoxTask2.TabIndex = 2;
            // 
            // panelMore
            // 
            this.panelMore.Controls.Add(this.labelTask5);
            this.panelMore.Controls.Add(this.comboBoxTask5);
            this.panelMore.Controls.Add(this.labelTask4);
            this.panelMore.Controls.Add(this.comboBoxTask4);
            this.panelMore.Controls.Add(this.labelTask3);
            this.panelMore.Controls.Add(this.comboBoxTask3);
            this.panelMore.Location = new System.Drawing.Point(10, 175);
            this.panelMore.Name = "panelMore";
            this.panelMore.Size = new System.Drawing.Size(332, 160);
            this.panelMore.TabIndex = 6;
            this.panelMore.Visible = false;
            // 
            // labelTask5
            // 
            this.labelTask5.AutoSize = true;
            this.labelTask5.Location = new System.Drawing.Point(1, 116);
            this.labelTask5.Name = "labelTask5";
            this.labelTask5.Size = new System.Drawing.Size(37, 13);
            this.labelTask5.TabIndex = 5;
            this.labelTask5.Text = "Task5";
            // 
            // comboBoxTask5
            // 
            this.comboBoxTask5.FormattingEnabled = true;
            this.comboBoxTask5.Location = new System.Drawing.Point(4, 134);
            this.comboBoxTask5.Name = "comboBoxTask5";
            this.comboBoxTask5.Size = new System.Drawing.Size(121, 21);
            this.comboBoxTask5.TabIndex = 4;
            // 
            // labelTask4
            // 
            this.labelTask4.AutoSize = true;
            this.labelTask4.Location = new System.Drawing.Point(1, 62);
            this.labelTask4.Name = "labelTask4";
            this.labelTask4.Size = new System.Drawing.Size(37, 13);
            this.labelTask4.TabIndex = 3;
            this.labelTask4.Text = "Task4";
            // 
            // comboBoxTask4
            // 
            this.comboBoxTask4.FormattingEnabled = true;
            this.comboBoxTask4.Location = new System.Drawing.Point(4, 83);
            this.comboBoxTask4.Name = "comboBoxTask4";
            this.comboBoxTask4.Size = new System.Drawing.Size(121, 21);
            this.comboBoxTask4.TabIndex = 2;
            // 
            // labelTask3
            // 
            this.labelTask3.AutoSize = true;
            this.labelTask3.Location = new System.Drawing.Point(1, 8);
            this.labelTask3.Name = "labelTask3";
            this.labelTask3.Size = new System.Drawing.Size(37, 13);
            this.labelTask3.TabIndex = 1;
            this.labelTask3.Text = "Task3";
            // 
            // comboBoxTask3
            // 
            this.comboBoxTask3.FormattingEnabled = true;
            this.comboBoxTask3.Location = new System.Drawing.Point(4, 26);
            this.comboBoxTask3.Name = "comboBoxTask3";
            this.comboBoxTask3.Size = new System.Drawing.Size(121, 21);
            this.comboBoxTask3.TabIndex = 0;
            // 
            // labelRelation
            // 
            this.labelRelation.AutoEllipsis = true;
            this.labelRelation.AutoSize = true;
            this.labelRelation.Location = new System.Drawing.Point(13, 19);
            this.labelRelation.Name = "labelRelation";
            this.labelRelation.Size = new System.Drawing.Size(65, 13);
            this.labelRelation.TabIndex = 7;
            this.labelRelation.Text = "Relationship";
            // 
            // labelTask1
            // 
            this.labelTask1.AutoSize = true;
            this.labelTask1.Location = new System.Drawing.Point(13, 70);
            this.labelTask1.Name = "labelTask1";
            this.labelTask1.Size = new System.Drawing.Size(37, 13);
            this.labelTask1.TabIndex = 8;
            this.labelTask1.Text = "Task1";
            // 
            // labelTask2
            // 
            this.labelTask2.AutoSize = true;
            this.labelTask2.Location = new System.Drawing.Point(13, 123);
            this.labelTask2.Name = "labelTask2";
            this.labelTask2.Size = new System.Drawing.Size(37, 13);
            this.labelTask2.TabIndex = 9;
            this.labelTask2.Text = "Task2";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(219, 35);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnMore
            // 
            this.btnMore.Location = new System.Drawing.Point(219, 86);
            this.btnMore.Name = "btnMore";
            this.btnMore.Size = new System.Drawing.Size(75, 23);
            this.btnMore.TabIndex = 11;
            this.btnMore.Text = "More Tasks";
            this.btnMore.UseVisualStyleBackColor = true;
            this.btnMore.Click += new System.EventHandler(this.btnMore_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(219, 136);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 12;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // AddMultiple
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(356, 174);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnMore);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.labelTask2);
            this.Controls.Add(this.labelTask1);
            this.Controls.Add(this.labelRelation);
            this.Controls.Add(this.panelMore);
            this.Controls.Add(this.comboBoxTask2);
            this.Controls.Add(this.comboBoxTask1);
            this.Controls.Add(this.comboBoxRelation);
            this.Name = "AddMultiple";
            this.Text = "Add Multiple Relationship";
            this.panelMore.ResumeLayout(false);
            this.panelMore.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxTask1;
        private System.Windows.Forms.ComboBox comboBoxTask2;
        private System.Windows.Forms.Panel panelMore;
        private System.Windows.Forms.Label labelRelation;
        private System.Windows.Forms.Label labelTask1;
        private System.Windows.Forms.Label labelTask2;
        private System.Windows.Forms.Label labelTask5;
        private System.Windows.Forms.ComboBox comboBoxTask5;
        private System.Windows.Forms.Label labelTask4;
        private System.Windows.Forms.ComboBox comboBoxTask4;
        private System.Windows.Forms.Label labelTask3;
        private System.Windows.Forms.ComboBox comboBoxTask3;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnMore;
        private System.Windows.Forms.Button btnOk;
        public System.Windows.Forms.ComboBox comboBoxRelation;
    }
}