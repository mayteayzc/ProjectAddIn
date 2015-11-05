namespace Project2013AddIn
{
    partial class AddBinary
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
            this.ComboBoxAct1 = new System.Windows.Forms.ComboBox();
            this.ComboBoxAct2 = new System.Windows.Forms.ComboBox();
            this.ComboBoxRela = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.NumericDays = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.NumericDays)).BeginInit();
            this.SuspendLayout();
            // 
            // ComboBoxAct1
            // 
            this.ComboBoxAct1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.ComboBoxAct1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ComboBoxAct1.FormattingEnabled = true;
            this.ComboBoxAct1.Location = new System.Drawing.Point(70, 49);
            this.ComboBoxAct1.Name = "ComboBoxAct1";
            this.ComboBoxAct1.Size = new System.Drawing.Size(145, 21);
            this.ComboBoxAct1.TabIndex = 0;
            // 
            // ComboBoxAct2
            // 
            this.ComboBoxAct2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.ComboBoxAct2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ComboBoxAct2.FormattingEnabled = true;
            this.ComboBoxAct2.Location = new System.Drawing.Point(70, 117);
            this.ComboBoxAct2.Name = "ComboBoxAct2";
            this.ComboBoxAct2.Size = new System.Drawing.Size(145, 21);
            this.ComboBoxAct2.TabIndex = 1;
            // 
            // ComboBoxRela
            // 
            this.ComboBoxRela.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.ComboBoxRela.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ComboBoxRela.FormattingEnabled = true;
            this.ComboBoxRela.Items.AddRange(new object[] {
            "Contain",
            "Disjoint",
            "Meet",
            "Overlap"});
            this.ComboBoxRela.Location = new System.Drawing.Point(70, 197);
            this.ComboBoxRela.Name = "ComboBoxRela";
            this.ComboBoxRela.Size = new System.Drawing.Size(145, 21);
            this.ComboBoxRela.TabIndex = 2;
            this.ComboBoxRela.SelectedIndexChanged += new System.EventHandler(this.ComboBoxRela_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(125, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Task1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(122, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Task 2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(112, 181);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Relationship";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(42, 334);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(90, 23);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(160, 334);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(125, 259);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Days";
            // 
            // NumericDays
            // 
            this.NumericDays.Location = new System.Drawing.Point(70, 275);
            this.NumericDays.Name = "NumericDays";
            this.NumericDays.Size = new System.Drawing.Size(145, 20);
            this.NumericDays.TabIndex = 11;
            // 
            // AddBinary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(297, 393);
            this.Controls.Add(this.NumericDays);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ComboBoxRela);
            this.Controls.Add(this.ComboBoxAct2);
            this.Controls.Add(this.ComboBoxAct1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AddBinary";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add a new PDM++ relationship";
            this.Load += new System.EventHandler(this.AddNewRelation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NumericDays)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ComboBoxAct1;
        private System.Windows.Forms.ComboBox ComboBoxAct2;
        public System.Windows.Forms.ComboBox ComboBoxRela;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.NumericUpDown NumericDays;

    }
}