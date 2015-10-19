namespace Project2013AddIn
{
    partial class AddUnary
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
            this.comboBoxTaskName = new System.Windows.Forms.ComboBox();
            this.LabelTaskName = new System.Windows.Forms.Label();
            this.labelDate1 = new System.Windows.Forms.Label();
            this.labelDate2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.comboBoxConstraint = new System.Windows.Forms.ComboBox();
            this.LabelConstraint = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBoxTaskName
            // 
            this.comboBoxTaskName.FormattingEnabled = true;
            this.comboBoxTaskName.Location = new System.Drawing.Point(153, 31);
            this.comboBoxTaskName.Name = "comboBoxTaskName";
            this.comboBoxTaskName.Size = new System.Drawing.Size(121, 21);
            this.comboBoxTaskName.TabIndex = 0;
            // 
            // LabelTaskName
            // 
            this.LabelTaskName.AutoSize = true;
            this.LabelTaskName.Location = new System.Drawing.Point(78, 34);
            this.LabelTaskName.Name = "LabelTaskName";
            this.LabelTaskName.Size = new System.Drawing.Size(62, 13);
            this.LabelTaskName.TabIndex = 1;
            this.LabelTaskName.Text = "Task Name";
            // 
            // labelDate1
            // 
            this.labelDate1.AutoSize = true;
            this.labelDate1.Location = new System.Drawing.Point(78, 121);
            this.labelDate1.Name = "labelDate1";
            this.labelDate1.Size = new System.Drawing.Size(30, 13);
            this.labelDate1.TabIndex = 2;
            this.labelDate1.Text = "Date";
            // 
            // labelDate2
            // 
            this.labelDate2.AutoSize = true;
            this.labelDate2.Location = new System.Drawing.Point(78, 160);
            this.labelDate2.Name = "labelDate2";
            this.labelDate2.Size = new System.Drawing.Size(36, 13);
            this.labelDate2.TabIndex = 3;
            this.labelDate2.Text = "Date2";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(153, 115);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 4;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(153, 154);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker2.TabIndex = 5;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(115, 210);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(224, 210);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // comboBoxConstraint
            // 
            this.comboBoxConstraint.FormattingEnabled = true;
            this.comboBoxConstraint.Items.AddRange(new object[] {
            "Between",
            "Can Not Occur",
            "Due After",
            "Due Before",
            "Start After",
            "Start Before"});
            this.comboBoxConstraint.Location = new System.Drawing.Point(153, 71);
            this.comboBoxConstraint.Name = "comboBoxConstraint";
            this.comboBoxConstraint.Size = new System.Drawing.Size(121, 21);
            this.comboBoxConstraint.TabIndex = 8;
            this.comboBoxConstraint.SelectedIndexChanged += new System.EventHandler(this.comboBoxConstraint_SelectedIndexChanged);
            // 
            // LabelConstraint
            // 
            this.LabelConstraint.AutoSize = true;
            this.LabelConstraint.Location = new System.Drawing.Point(78, 74);
            this.LabelConstraint.Name = "LabelConstraint";
            this.LabelConstraint.Size = new System.Drawing.Size(54, 13);
            this.LabelConstraint.TabIndex = 9;
            this.LabelConstraint.Text = "Constraint";
            // 
            // AddUnary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 261);
            this.Controls.Add(this.LabelConstraint);
            this.Controls.Add(this.comboBoxConstraint);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.labelDate2);
            this.Controls.Add(this.labelDate1);
            this.Controls.Add(this.LabelTaskName);
            this.Controls.Add(this.comboBoxTaskName);
            this.Name = "AddUnary";
            this.Text = "Add A New Constraint";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabelTaskName;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label LabelConstraint;
        public System.Windows.Forms.ComboBox comboBoxConstraint;
        public System.Windows.Forms.Label labelDate1;
        public System.Windows.Forms.Label labelDate2;
        public System.Windows.Forms.DateTimePicker dateTimePicker2;
        public System.Windows.Forms.ComboBox comboBoxTaskName;
    }
}