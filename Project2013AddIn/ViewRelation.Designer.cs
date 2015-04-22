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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnOK = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.recordDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.task1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.task2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.relationshipDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.overlapDaysDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.relationTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.projectAddinDBDataSet = new Project2013AddIn.ProjectAddinDBDataSet();
            this.btnDelete = new System.Windows.Forms.Button();
            this.projectAddinDBDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.relationTableTableAdapter = new Project2013AddIn.ProjectAddinDBDataSetTableAdapters.RelationTableTableAdapter();
            this.Relationships = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.relationTableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectAddinDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectAddinDBDataSetBindingSource)).BeginInit();
            this.Relationships.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(266, 338);
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
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.recordDataGridViewTextBoxColumn,
            this.task1DataGridViewTextBoxColumn,
            this.task2DataGridViewTextBoxColumn,
            this.relationshipDataGridViewTextBoxColumn,
            this.overlapDaysDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.relationTableBindingSource;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.Location = new System.Drawing.Point(1, 5);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.Size = new System.Drawing.Size(442, 279);
            this.dataGridView1.TabIndex = 1;
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
            // relationTableBindingSource
            // 
            this.relationTableBindingSource.DataMember = "RelationTable";
            this.relationTableBindingSource.DataSource = this.projectAddinDBDataSet;
            // 
            // projectAddinDBDataSet
            // 
            this.projectAddinDBDataSet.DataSetName = "ProjectAddinDBDataSet";
            this.projectAddinDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(146, 338);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // projectAddinDBDataSetBindingSource
            // 
            this.projectAddinDBDataSetBindingSource.DataSource = this.projectAddinDBDataSet;
            this.projectAddinDBDataSetBindingSource.Position = 0;
            // 
            // relationTableTableAdapter
            // 
            this.relationTableTableAdapter.ClearBeforeFill = true;
            // 
            // Relationships
            // 
            this.Relationships.Controls.Add(this.tabPage1);
            this.Relationships.Controls.Add(this.tabPage2);
            this.Relationships.Location = new System.Drawing.Point(23, 7);
            this.Relationships.Name = "Relationships";
            this.Relationships.SelectedIndex = 0;
            this.Relationships.Size = new System.Drawing.Size(454, 311);
            this.Relationships.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(446, 285);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Relationships";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridView2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(446, 285);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Constraint";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(3, 0);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(440, 282);
            this.dataGridView2.TabIndex = 0;
            // 
            // ViewRelation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 373);
            this.Controls.Add(this.Relationships);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnOK);
            this.Name = "ViewRelation";
            this.Text = "View Details";
            this.Load += new System.EventHandler(this.ViewRelation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.relationTableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectAddinDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectAddinDBDataSetBindingSource)).EndInit();
            this.Relationships.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.BindingSource projectAddinDBDataSetBindingSource;
        private ProjectAddinDBDataSet projectAddinDBDataSet;
        private System.Windows.Forms.BindingSource relationTableBindingSource;
        private ProjectAddinDBDataSetTableAdapters.RelationTableTableAdapter relationTableTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn recordDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn task1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn task2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn relationshipDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn overlapDaysDataGridViewTextBoxColumn;
        private System.Windows.Forms.TabControl Relationships;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridView2;
        //private System.Windows.Forms.DataGridViewTextBoxColumn recordDataGridViewTextBoxColumn;
        //private System.Windows.Forms.DataGridViewTextBoxColumn task1DataGridViewTextBoxColumn;
        //private System.Windows.Forms.DataGridViewTextBoxColumn task2DataGridViewTextBoxColumn;
        //private System.Windows.Forms.DataGridViewTextBoxColumn relationshipDataGridViewTextBoxColumn;
        //private System.Windows.Forms.DataGridViewTextBoxColumn overlapDaysDataGridViewTextBoxColumn;
    }
}