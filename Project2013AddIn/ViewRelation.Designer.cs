namespace Project2013AddIn
{
    partial class ViewRelation
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnOK = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnDelete = new System.Windows.Forms.Button();
            this.Task1 = new System.Windows.Forms.Label();
            this.Task2 = new System.Windows.Forms.Label();
            this.Relationship = new System.Windows.Forms.Label();
            this.OverlapDays = new System.Windows.Forms.Label();
            this.Task1Text = new System.Windows.Forms.TextBox();
            this.Task2Text = new System.Windows.Forms.TextBox();
            this.OverlapDaysText = new System.Windows.Forms.TextBox();
            this.RelationshipText = new System.Windows.Forms.TextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.projectAddinDBDataSet = new Project2013AddIn.ProjectAddinDBDataSet();
            this.projectAddinDBDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.relationTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.relationTableTableAdapter = new Project2013AddIn.ProjectAddinDBDataSetTableAdapters.RelationTableTableAdapter();
            this.recordDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.task1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.task2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.relationshipDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.overlapDaysDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectAddinDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectAddinDBDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.relationTableBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(58, 253);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.recordDataGridViewTextBoxColumn,
            this.task1DataGridViewTextBoxColumn,
            this.task2DataGridViewTextBoxColumn,
            this.relationshipDataGridViewTextBoxColumn,
            this.overlapDaysDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.relationTableBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(221, 12);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.Size = new System.Drawing.Size(429, 279);
            this.dataGridView1.TabIndex = 1;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(58, 195);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // Task1
            // 
            this.Task1.AutoSize = true;
            this.Task1.Location = new System.Drawing.Point(19, 41);
            this.Task1.Name = "Task1";
            this.Task1.Size = new System.Drawing.Size(37, 13);
            this.Task1.TabIndex = 3;
            this.Task1.Text = "Task1";
            // 
            // Task2
            // 
            this.Task2.AutoSize = true;
            this.Task2.Location = new System.Drawing.Point(19, 81);
            this.Task2.Name = "Task2";
            this.Task2.Size = new System.Drawing.Size(37, 13);
            this.Task2.TabIndex = 4;
            this.Task2.Text = "Task2";
            // 
            // Relationship
            // 
            this.Relationship.AutoSize = true;
            this.Relationship.Location = new System.Drawing.Point(19, 120);
            this.Relationship.Name = "Relationship";
            this.Relationship.Size = new System.Drawing.Size(65, 13);
            this.Relationship.TabIndex = 5;
            this.Relationship.Text = "Relationship";
            // 
            // OverlapDays
            // 
            this.OverlapDays.AutoSize = true;
            this.OverlapDays.Location = new System.Drawing.Point(19, 157);
            this.OverlapDays.Name = "OverlapDays";
            this.OverlapDays.Size = new System.Drawing.Size(68, 13);
            this.OverlapDays.TabIndex = 6;
            this.OverlapDays.Text = "OverlapDays";
            // 
            // Task1Text
            // 
            this.Task1Text.Location = new System.Drawing.Point(90, 38);
            this.Task1Text.Name = "Task1Text";
            this.Task1Text.Size = new System.Drawing.Size(100, 20);
            this.Task1Text.TabIndex = 7;
            // 
            // Task2Text
            // 
            this.Task2Text.Location = new System.Drawing.Point(90, 78);
            this.Task2Text.Name = "Task2Text";
            this.Task2Text.Size = new System.Drawing.Size(100, 20);
            this.Task2Text.TabIndex = 8;
            // 
            // OverlapDaysText
            // 
            this.OverlapDaysText.Location = new System.Drawing.Point(90, 154);
            this.OverlapDaysText.Name = "OverlapDaysText";
            this.OverlapDaysText.Size = new System.Drawing.Size(100, 20);
            this.OverlapDaysText.TabIndex = 9;
            // 
            // RelationshipText
            // 
            this.RelationshipText.Location = new System.Drawing.Point(90, 117);
            this.RelationshipText.Name = "RelationshipText";
            this.RelationshipText.Size = new System.Drawing.Size(100, 20);
            this.RelationshipText.TabIndex = 10;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(58, 224);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 11;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // projectAddinDBDataSet
            // 
            this.projectAddinDBDataSet.DataSetName = "ProjectAddinDBDataSet";
            this.projectAddinDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // projectAddinDBDataSetBindingSource
            // 
            this.projectAddinDBDataSetBindingSource.DataSource = this.projectAddinDBDataSet;
            this.projectAddinDBDataSetBindingSource.Position = 0;
            // 
            // relationTableBindingSource
            // 
            this.relationTableBindingSource.DataMember = "RelationTable";
            this.relationTableBindingSource.DataSource = this.projectAddinDBDataSet;
            // 
            // relationTableTableAdapter
            // 
            this.relationTableTableAdapter.ClearBeforeFill = true;
            // 
            // recordDataGridViewTextBoxColumn
            // 
            this.recordDataGridViewTextBoxColumn.DataPropertyName = "Record";
            this.recordDataGridViewTextBoxColumn.HeaderText = "Record";
            this.recordDataGridViewTextBoxColumn.Name = "recordDataGridViewTextBoxColumn";
            this.recordDataGridViewTextBoxColumn.ReadOnly = true;
            this.recordDataGridViewTextBoxColumn.Visible = false;
            // 
            // task1DataGridViewTextBoxColumn
            // 
            this.task1DataGridViewTextBoxColumn.DataPropertyName = "Task1";
            this.task1DataGridViewTextBoxColumn.HeaderText = "Task1";
            this.task1DataGridViewTextBoxColumn.Name = "task1DataGridViewTextBoxColumn";
            // 
            // task2DataGridViewTextBoxColumn
            // 
            this.task2DataGridViewTextBoxColumn.DataPropertyName = "Task2";
            this.task2DataGridViewTextBoxColumn.HeaderText = "Task2";
            this.task2DataGridViewTextBoxColumn.Name = "task2DataGridViewTextBoxColumn";
            // 
            // relationshipDataGridViewTextBoxColumn
            // 
            this.relationshipDataGridViewTextBoxColumn.DataPropertyName = "Relationship";
            this.relationshipDataGridViewTextBoxColumn.HeaderText = "Relationship";
            this.relationshipDataGridViewTextBoxColumn.Name = "relationshipDataGridViewTextBoxColumn";
            // 
            // overlapDaysDataGridViewTextBoxColumn
            // 
            this.overlapDaysDataGridViewTextBoxColumn.DataPropertyName = "OverlapDays";
            this.overlapDaysDataGridViewTextBoxColumn.HeaderText = "OverlapDays";
            this.overlapDaysDataGridViewTextBoxColumn.Name = "overlapDaysDataGridViewTextBoxColumn";
            // 
            // ViewRelation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 332);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.RelationshipText);
            this.Controls.Add(this.OverlapDaysText);
            this.Controls.Add(this.Task2Text);
            this.Controls.Add(this.Task1Text);
            this.Controls.Add(this.OverlapDays);
            this.Controls.Add(this.Relationship);
            this.Controls.Add(this.Task2);
            this.Controls.Add(this.Task1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnOK);
            this.Name = "ViewRelation";
            this.Text = "View PDM++ Relationships";
            this.Load += new System.EventHandler(this.ViewRelation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectAddinDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectAddinDBDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.relationTableBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label Task1;
        private System.Windows.Forms.Label Task2;
        private System.Windows.Forms.Label Relationship;
        private System.Windows.Forms.Label OverlapDays;
        private System.Windows.Forms.TextBox Task1Text;
        private System.Windows.Forms.TextBox Task2Text;
        private System.Windows.Forms.TextBox OverlapDaysText;
        private System.Windows.Forms.TextBox RelationshipText;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.BindingSource projectAddinDBDataSetBindingSource;
        private ProjectAddinDBDataSet projectAddinDBDataSet;
        private System.Windows.Forms.BindingSource relationTableBindingSource;
        private ProjectAddinDBDataSetTableAdapters.RelationTableTableAdapter relationTableTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn recordDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn task1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn task2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn relationshipDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn overlapDaysDataGridViewTextBoxColumn;
        //private System.Windows.Forms.DataGridViewTextBoxColumn recordDataGridViewTextBoxColumn;
        //private System.Windows.Forms.DataGridViewTextBoxColumn task1DataGridViewTextBoxColumn;
        //private System.Windows.Forms.DataGridViewTextBoxColumn task2DataGridViewTextBoxColumn;
        //private System.Windows.Forms.DataGridViewTextBoxColumn relationshipDataGridViewTextBoxColumn;
        //private System.Windows.Forms.DataGridViewTextBoxColumn overlapDaysDataGridViewTextBoxColumn;
    }
}