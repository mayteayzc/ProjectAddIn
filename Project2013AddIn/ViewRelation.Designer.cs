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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewRelation));
            this.dataSet1 = new Project2013AddIn.DataSet1();
            this.dataTableRelationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataTableRelationBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.dataTableRelationBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.dataTableRelationDataGridView = new System.Windows.Forms.DataGridView();
            this.btnOK = new System.Windows.Forms.Button();
            this.ColumnTask1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTask2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnRelationship = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOverlapDays = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableRelationBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableRelationBindingNavigator)).BeginInit();
            this.dataTableRelationBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableRelationDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataTableRelationBindingSource
            // 
            this.dataTableRelationBindingSource.DataMember = "DataTableRelation";
            this.dataTableRelationBindingSource.DataSource = this.dataSet1;
            // 
            // dataTableRelationBindingNavigator
            // 
            this.dataTableRelationBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.dataTableRelationBindingNavigator.BindingSource = this.dataTableRelationBindingSource;
            this.dataTableRelationBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.dataTableRelationBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.dataTableRelationBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.dataTableRelationBindingNavigatorSaveItem});
            this.dataTableRelationBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.dataTableRelationBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.dataTableRelationBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.dataTableRelationBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.dataTableRelationBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.dataTableRelationBindingNavigator.Name = "dataTableRelationBindingNavigator";
            this.dataTableRelationBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.dataTableRelationBindingNavigator.Size = new System.Drawing.Size(519, 25);
            this.dataTableRelationBindingNavigator.TabIndex = 0;
            this.dataTableRelationBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            // 
            // dataTableRelationBindingNavigatorSaveItem
            // 
            this.dataTableRelationBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.dataTableRelationBindingNavigatorSaveItem.Enabled = false;
            this.dataTableRelationBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("dataTableRelationBindingNavigatorSaveItem.Image")));
            this.dataTableRelationBindingNavigatorSaveItem.Name = "dataTableRelationBindingNavigatorSaveItem";
            this.dataTableRelationBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.dataTableRelationBindingNavigatorSaveItem.Text = "Save Data";
            // 
            // dataTableRelationDataGridView
            // 
            this.dataTableRelationDataGridView.AutoGenerateColumns = false;
            this.dataTableRelationDataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dataTableRelationDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataTableRelationDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnTask1,
            this.ColumnTask2,
            this.ColumnRelationship,
            this.ColumnOverlapDays});
            this.dataTableRelationDataGridView.DataSource = this.dataTableRelationBindingSource;
            this.dataTableRelationDataGridView.Location = new System.Drawing.Point(22, 43);
            this.dataTableRelationDataGridView.Name = "dataTableRelationDataGridView";
            this.dataTableRelationDataGridView.Size = new System.Drawing.Size(477, 249);
            this.dataTableRelationDataGridView.TabIndex = 1;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(219, 315);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // ColumnTask1
            // 
            this.ColumnTask1.HeaderText = "Task1";
            this.ColumnTask1.Name = "ColumnTask1";
            // 
            // ColumnTask2
            // 
            this.ColumnTask2.HeaderText = "Task2";
            this.ColumnTask2.Name = "ColumnTask2";
            // 
            // ColumnRelationship
            // 
            this.ColumnRelationship.HeaderText = "Relationship";
            this.ColumnRelationship.Name = "ColumnRelationship";
            // 
            // ColumnOverlapDays
            // 
            this.ColumnOverlapDays.HeaderText = "Overlap Days";
            this.ColumnOverlapDays.Name = "ColumnOverlapDays";
            // 
            // ViewRelation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 350);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.dataTableRelationDataGridView);
            this.Controls.Add(this.dataTableRelationBindingNavigator);
            this.Name = "ViewRelation";
            this.ShowIcon = false;
            this.Text = "View PDM++ Relationships";
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableRelationBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableRelationBindingNavigator)).EndInit();
            this.dataTableRelationBindingNavigator.ResumeLayout(false);
            this.dataTableRelationBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableRelationDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataSet1 dataSet1;
        private System.Windows.Forms.BindingSource dataTableRelationBindingSource;
        private System.Windows.Forms.BindingNavigator dataTableRelationBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton dataTableRelationBindingNavigatorSaveItem;
        private System.Windows.Forms.DataGridView dataTableRelationDataGridView;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTask1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTask2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnRelationship;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOverlapDays;
    }
}