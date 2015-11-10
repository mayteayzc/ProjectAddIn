namespace Project2013AddIn
{
    partial class newPDM : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public newPDM()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(newPDM));
            this.tab1 = this.Factory.CreateRibbonTab();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.group2 = this.Factory.CreateRibbonGroup();
            this.Manage = this.Factory.CreateRibbonGroup();
            this.group4 = this.Factory.CreateRibbonGroup();
            this.btnContain = this.Factory.CreateRibbonButton();
            this.btnDisjoint = this.Factory.CreateRibbonButton();
            this.btnMeet = this.Factory.CreateRibbonButton();
            this.btnOverlap = this.Factory.CreateRibbonButton();
            this.btnCannot = this.Factory.CreateRibbonButton();
            this.btnDueaft = this.Factory.CreateRibbonButton();
            this.btnDuebf = this.Factory.CreateRibbonButton();
            this.btnStartaft = this.Factory.CreateRibbonButton();
            this.btnStartbf = this.Factory.CreateRibbonButton();
            this.btnView = this.Factory.CreateRibbonButton();
            this.btnOptimization = this.Factory.CreateRibbonButton();
            this.btnConditionalTask = this.Factory.CreateRibbonButton();
            this.btnManageCondition = this.Factory.CreateRibbonButton();
            this.btnUpdateCondition = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.group1.SuspendLayout();
            this.group2.SuspendLayout();
            this.Manage.SuspendLayout();
            this.group4.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.group1);
            this.tab1.Groups.Add(this.group2);
            this.tab1.Groups.Add(this.Manage);
            this.tab1.Groups.Add(this.group4);
            this.tab1.Label = "PDM++";
            this.tab1.Name = "tab1";
            // 
            // group1
            // 
            this.group1.Items.Add(this.btnContain);
            this.group1.Items.Add(this.btnDisjoint);
            this.group1.Items.Add(this.btnMeet);
            this.group1.Items.Add(this.btnOverlap);
            this.group1.Label = "Binary Relationship";
            this.group1.Name = "group1";
            // 
            // group2
            // 
            this.group2.Items.Add(this.btnCannot);
            this.group2.Items.Add(this.btnDueaft);
            this.group2.Items.Add(this.btnDuebf);
            this.group2.Items.Add(this.btnStartaft);
            this.group2.Items.Add(this.btnStartbf);
            this.group2.Label = "Unary Relationship";
            this.group2.Name = "group2";
            // 
            // Manage
            // 
            this.Manage.Items.Add(this.btnView);
            this.Manage.Items.Add(this.btnOptimization);
            this.Manage.Label = "Manage";
            this.Manage.Name = "Manage";
            // 
            // group4
            // 
            this.group4.Items.Add(this.btnConditionalTask);
            this.group4.Items.Add(this.btnManageCondition);
            this.group4.Items.Add(this.btnUpdateCondition);
            this.group4.Label = "Dynamic Requirement";
            this.group4.Name = "group4";
            // 
            // btnContain
            // 
            this.btnContain.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnContain.Image = ((System.Drawing.Image)(resources.GetObject("btnContain.Image")));
            this.btnContain.Label = "Contain (C)";
            this.btnContain.Name = "btnContain";
            this.btnContain.ScreenTip = "Activity 2 happens only within the duration of Activity 1.";
            this.btnContain.ShowImage = true;
            this.btnContain.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnContain_Click);
            // 
            // btnDisjoint
            // 
            this.btnDisjoint.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnDisjoint.Image = ((System.Drawing.Image)(resources.GetObject("btnDisjoint.Image")));
            this.btnDisjoint.Label = "Disjoint (D)";
            this.btnDisjoint.Name = "btnDisjoint";
            this.btnDisjoint.ScreenTip = "Two activities can not happen together.";
            this.btnDisjoint.ShowImage = true;
            this.btnDisjoint.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnDisjoint_Click);
            // 
            // btnMeet
            // 
            this.btnMeet.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnMeet.Image = ((System.Drawing.Image)(resources.GetObject("btnMeet.Image")));
            this.btnMeet.Label = "Meet (M)";
            this.btnMeet.Name = "btnMeet";
            this.btnMeet.ScreenTip = "Activity 2 starts immediately after Activity 1 or vice versa.";
            this.btnMeet.ShowImage = true;
            this.btnMeet.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnMeet_Click);
            // 
            // btnOverlap
            // 
            this.btnOverlap.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnOverlap.Image = ((System.Drawing.Image)(resources.GetObject("btnOverlap.Image")));
            this.btnOverlap.Label = "Overlap (O)";
            this.btnOverlap.Name = "btnOverlap";
            this.btnOverlap.ScreenTip = "Duration of two activities overlap each other.";
            this.btnOverlap.ShowImage = true;
            this.btnOverlap.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnOverlap_Click);
            // 
            // btnCannot
            // 
            this.btnCannot.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnCannot.Image = ((System.Drawing.Image)(resources.GetObject("btnCannot.Image")));
            this.btnCannot.Label = "Cannot Occur (CO)";
            this.btnCannot.Name = "btnCannot";
            this.btnCannot.ShowImage = true;
            this.btnCannot.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnCannot_Click);
            // 
            // btnDueaft
            // 
            this.btnDueaft.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnDueaft.Image = ((System.Drawing.Image)(resources.GetObject("btnDueaft.Image")));
            this.btnDueaft.Label = "Due After (DA)";
            this.btnDueaft.Name = "btnDueaft";
            this.btnDueaft.ShowImage = true;
            this.btnDueaft.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnDueaft_Click);
            // 
            // btnDuebf
            // 
            this.btnDuebf.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnDuebf.Image = ((System.Drawing.Image)(resources.GetObject("btnDuebf.Image")));
            this.btnDuebf.Label = "Due Before (DB)";
            this.btnDuebf.Name = "btnDuebf";
            this.btnDuebf.ShowImage = true;
            this.btnDuebf.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnDuebf_Click);
            // 
            // btnStartaft
            // 
            this.btnStartaft.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnStartaft.Image = ((System.Drawing.Image)(resources.GetObject("btnStartaft.Image")));
            this.btnStartaft.Label = "Start After (SA)";
            this.btnStartaft.Name = "btnStartaft";
            this.btnStartaft.ShowImage = true;
            this.btnStartaft.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnStartaft_Click);
            // 
            // btnStartbf
            // 
            this.btnStartbf.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnStartbf.Image = ((System.Drawing.Image)(resources.GetObject("btnStartbf.Image")));
            this.btnStartbf.Label = "Start Before (SB)";
            this.btnStartbf.Name = "btnStartbf";
            this.btnStartbf.ShowImage = true;
            this.btnStartbf.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnStartbf_Click);
            // 
            // btnView
            // 
            this.btnView.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnView.Image = ((System.Drawing.Image)(resources.GetObject("btnView.Image")));
            this.btnView.Label = "View Relationship";
            this.btnView.Name = "btnView";
            this.btnView.ShowImage = true;
            this.btnView.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnViewDetail_Click);
            // 
            // btnOptimization
            // 
            this.btnOptimization.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnOptimization.Image = ((System.Drawing.Image)(resources.GetObject("btnOptimization.Image")));
            this.btnOptimization.Label = "Heuristic Optimization";
            this.btnOptimization.Name = "btnOptimization";
            this.btnOptimization.ShowImage = true;
            this.btnOptimization.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnOptimization_Click);
            // 
            // btnConditionalTask
            // 
            this.btnConditionalTask.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnConditionalTask.Image = ((System.Drawing.Image)(resources.GetObject("btnConditionalTask.Image")));
            this.btnConditionalTask.Label = "Conditional Task";
            this.btnConditionalTask.Name = "btnConditionalTask";
            this.btnConditionalTask.ShowImage = true;
            this.btnConditionalTask.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnConditionalTask_Click);
            // 
            // btnManageCondition
            // 
            this.btnManageCondition.Image = global::Project2013AddIn.Properties.Resources.manage_condition;
            this.btnManageCondition.Label = "Manage Condition";
            this.btnManageCondition.Name = "btnManageCondition";
            this.btnManageCondition.ShowImage = true;
            this.btnManageCondition.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnManageCondition_Click);
            // 
            // btnUpdateCondition
            // 
            this.btnUpdateCondition.Image = global::Project2013AddIn.Properties.Resources.check;
            this.btnUpdateCondition.Label = "Update Condition";
            this.btnUpdateCondition.Name = "btnUpdateCondition";
            this.btnUpdateCondition.ShowImage = true;
            this.btnUpdateCondition.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnUpdateCondition_Click);
            // 
            // newPDM
            // 
            this.Name = "newPDM";
            this.RibbonType = "Microsoft.Project.Project";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.Ribbon1_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.group2.ResumeLayout(false);
            this.group2.PerformLayout();
            this.Manage.ResumeLayout(false);
            this.Manage.PerformLayout();
            this.group4.ResumeLayout(false);
            this.group4.PerformLayout();

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnContain;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnDisjoint;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnMeet;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnOverlap;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group2;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnCannot;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnDueaft;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnDuebf;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnStartaft;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnStartbf;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnOptimization;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnConditionalTask;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group4;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup Manage;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnView;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnUpdateCondition;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnManageCondition;
    }

    partial class ThisRibbonCollection
    {
        internal newPDM Ribbon1
        {
            get { return this.GetRibbon<newPDM>(); }
        }
    }
}
