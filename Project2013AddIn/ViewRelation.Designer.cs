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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.ViewTab = new System.Windows.Forms.TabControl();
            this.tabPageRelationship = new System.Windows.Forms.TabPage();
            this.tabPageConstraint = new System.Windows.Forms.TabPage();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.projectAddinDBDataSet = new Project2013AddIn.ProjectAddinDBDataSet();
            this.relationTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.relationTableTableAdapter = new Project2013AddIn.ProjectAddinDBDataSetTableAdapters.RelationTableTableAdapter();
            this.recordDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.task1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.task2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.relationshipsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.overlapDaysDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.projectAddinDBDataSet1 = new Project2013AddIn.ProjectAddinDBDataSet1();
            this.constraintTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.constraintTableTableAdapter = new Project2013AddIn.ProjectAddinDBDataSet1TableAdapters.ConstraintTableTableAdapter();
            this.recordDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taskDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.durationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.constraintsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ViewTab.SuspendLayout();
            this.tabPageRelationship.SuspendLayout();
            this.tabPageConstraint.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectAddinDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.relationTableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectAddinDBDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.constraintTableBindingSource)).BeginInit();
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
            // ViewTab
            // 
            this.ViewTab.Controls.Add(this.tabPageRelationship);
            this.ViewTab.Controls.Add(this.tabPageConstraint);
            this.ViewTab.Location = new System.Drawing.Point(23, 7);
            this.ViewTab.Name = "ViewTab";
            this.ViewTab.SelectedIndex = 0;
            this.ViewTab.Size = new System.Drawing.Size(452, 311);
            this.ViewTab.TabIndex = 3;
            // 
            // tabPageRelationship
            // 
            this.tabPageRelationship.Controls.Add(this.dataGridView1);
            this.tabPageRelationship.Location = new System.Drawing.Point(4, 22);
            this.tabPageRelationship.Name = "tabPageRelationship";
            this.tabPageRelationship.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRelationship.Size = new System.Drawing.Size(444, 285);
            this.tabPageRelationship.TabIndex = 0;
            this.tabPageRelationship.Text = "Relationship";
            this.tabPageRelationship.UseVisualStyleBackColor = true;
            // 
            // tabPageConstraint
            // 
            this.tabPageConstraint.Controls.Add(this.dataGridView2);
            this.tabPageConstraint.Location = new System.Drawing.Point(4, 22);
            this.tabPageConstraint.Name = "tabPageConstraint";
            this.tabPageConstraint.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageConstraint.Size = new System.Drawing.Size(444, 285);
            this.tabPageConstraint.TabIndex = 1;
            this.tabPageConstraint.Text = "Constraint";
            this.tabPageConstraint.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.recordDataGridViewTextBoxColumn1,
            this.taskDataGridViewTextBoxColumn,
            this.durationDataGridViewTextBoxColumn,
            this.constraintsDataGridViewTextBoxColumn,
            this.date1DataGridViewTextBoxColumn,
            this.date2DataGridViewTextBoxColumn});
            this.dataGridView2.DataSource = this.constraintTableBindingSource;
            this.dataGridView2.Location = new System.Drawing.Point(1, 0);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(443, 282);
            this.dataGridView2.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle16;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.recordDataGridViewTextBoxColumn,
            this.task1DataGridViewTextBoxColumn,
            this.task2DataGridViewTextBoxColumn,
            this.relationshipsDataGridViewTextBoxColumn,
            this.overlapDaysDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.relationTableBindingSource;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle17;
            this.dataGridView1.Location = new System.Drawing.Point(1, 0);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle18;
            this.dataGridView1.Size = new System.Drawing.Size(443, 282);
            this.dataGridView1.TabIndex = 1;
            // 
            // projectAddinDBDataSet
            // 
            this.projectAddinDBDataSet.DataSetName = "ProjectAddinDBDataSet";
            this.projectAddinDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            // relationshipsDataGridViewTextBoxColumn
            // 
            this.relationshipsDataGridViewTextBoxColumn.DataPropertyName = "Relationships";
            this.relationshipsDataGridViewTextBoxColumn.HeaderText = "Relationships";
            this.relationshipsDataGridViewTextBoxColumn.Name = "relationshipsDataGridViewTextBoxColumn";
            // 
            // overlapDaysDataGridViewTextBoxColumn
            // 
            this.overlapDaysDataGridViewTextBoxColumn.DataPropertyName = "OverlapDays";
            this.overlapDaysDataGridViewTextBoxColumn.HeaderText = "OverlapDays";
            this.overlapDaysDataGridViewTextBoxColumn.Name = "overlapDaysDataGridViewTextBoxColumn";
            // 
            // projectAddinDBDataSet1
            // 
            this.projectAddinDBDataSet1.DataSetName = "ProjectAddinDBDataSet1";
            this.projectAddinDBDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // constraintTableBindingSource
            // 
            this.constraintTableBindingSource.DataMember = "ConstraintTable";
            this.constraintTableBindingSource.DataSource = this.projectAddinDBDataSet1;
            // 
            // constraintTableTableAdapter
            // 
            this.constraintTableTableAdapter.ClearBeforeFill = true;
            // 
            // recordDataGridViewTextBoxColumn1
            // 
            this.recordDataGridViewTextBoxColumn1.DataPropertyName = "Record";
            this.recordDataGridViewTextBoxColumn1.HeaderText = "Record";
            this.recordDataGridViewTextBoxColumn1.Name = "recordDataGridViewTextBoxColumn1";
            this.recordDataGridViewTextBoxColumn1.ReadOnly = true;
            this.recordDataGridViewTextBoxColumn1.Visible = false;
            // 
            // taskDataGridViewTextBoxColumn
            // 
            this.taskDataGridViewTextBoxColumn.DataPropertyName = "Task";
            this.taskDataGridViewTextBoxColumn.HeaderText = "Task";
            this.taskDataGridViewTextBoxColumn.Name = "taskDataGridViewTextBoxColumn";
            // 
            // durationDataGridViewTextBoxColumn
            // 
            this.durationDataGridViewTextBoxColumn.DataPropertyName = "Duration";
            this.durationDataGridViewTextBoxColumn.HeaderText = "Duration";
            this.durationDataGridViewTextBoxColumn.Name = "durationDataGridViewTextBoxColumn";
            this.durationDataGridViewTextBoxColumn.Visible = false;
            // 
            // constraintsDataGridViewTextBoxColumn
            // 
            this.constraintsDataGridViewTextBoxColumn.DataPropertyName = "Constraints";
            this.constraintsDataGridViewTextBoxColumn.HeaderText = "Constraints";
            this.constraintsDataGridViewTextBoxColumn.Name = "constraintsDataGridViewTextBoxColumn";
            // 
            // date1DataGridViewTextBoxColumn
            // 
            this.date1DataGridViewTextBoxColumn.DataPropertyName = "Date1";
            this.date1DataGridViewTextBoxColumn.HeaderText = "Date1";
            this.date1DataGridViewTextBoxColumn.Name = "date1DataGridViewTextBoxColumn";
            // 
            // date2DataGridViewTextBoxColumn
            // 
            this.date2DataGridViewTextBoxColumn.DataPropertyName = "Date2";
            this.date2DataGridViewTextBoxColumn.HeaderText = "Date2";
            this.date2DataGridViewTextBoxColumn.Name = "date2DataGridViewTextBoxColumn";
            // 
            // ViewRelation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 373);
            this.Controls.Add(this.ViewTab);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnOK);
            this.Name = "ViewRelation";
            this.Text = "View Details";
            this.Load += new System.EventHandler(this.ViewRelation_Load);
            this.ViewTab.ResumeLayout(false);
            this.tabPageRelationship.ResumeLayout(false);
            this.tabPageConstraint.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectAddinDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.relationTableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectAddinDBDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.constraintTableBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TabControl ViewTab;
        private System.Windows.Forms.TabPage tabPageRelationship;
        private System.Windows.Forms.TabPage tabPageConstraint;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private ProjectAddinDBDataSet projectAddinDBDataSet;
        private System.Windows.Forms.BindingSource relationTableBindingSource;
        private ProjectAddinDBDataSetTableAdapters.RelationTableTableAdapter relationTableTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn recordDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn task1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn task2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn relationshipsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn overlapDaysDataGridViewTextBoxColumn;
        private ProjectAddinDBDataSet1 projectAddinDBDataSet1;
        private System.Windows.Forms.BindingSource constraintTableBindingSource;
        private ProjectAddinDBDataSet1TableAdapters.ConstraintTableTableAdapter constraintTableTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn recordDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn taskDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn durationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn constraintsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn date1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn date2DataGridViewTextBoxColumn;
        //private System.Windows.Forms.DataGridViewTextBoxColumn recordDataGridViewTextBoxColumn;
        //private System.Windows.Forms.DataGridViewTextBoxColumn task1DataGridViewTextBoxColumn;
        //private System.Windows.Forms.DataGridViewTextBoxColumn task2DataGridViewTextBoxColumn;
        //private System.Windows.Forms.DataGridViewTextBoxColumn relationshipDataGridViewTextBoxColumn;
        //private System.Windows.Forms.DataGridViewTextBoxColumn overlapDaysDataGridViewTextBoxColumn;
    }
}