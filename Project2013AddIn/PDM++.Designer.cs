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
            this.btnconcurrent = this.Factory.CreateRibbonButton();
            this.btnContain = this.Factory.CreateRibbonButton();
            this.btnDisjoint = this.Factory.CreateRibbonButton();
            this.btnMeet = this.Factory.CreateRibbonButton();
            this.btnOverlap = this.Factory.CreateRibbonButton();
            this.group2 = this.Factory.CreateRibbonGroup();
            this.btnCannot = this.Factory.CreateRibbonButton();
            this.btnDueaft = this.Factory.CreateRibbonButton();
            this.btnDuebf = this.Factory.CreateRibbonButton();
            this.btnStartaft = this.Factory.CreateRibbonButton();
            this.btnStartbf = this.Factory.CreateRibbonButton();
            this.Control = this.Factory.CreateRibbonGroup();
            this.btnView = this.Factory.CreateRibbonButton();
            this.btnUpdate = this.Factory.CreateRibbonButton();
            this.group3 = this.Factory.CreateRibbonGroup();
            this.btnMetaint = this.Factory.CreateRibbonButton();
            this.btnAltSch = this.Factory.CreateRibbonButton();
            this.group4 = this.Factory.CreateRibbonGroup();
            this.tab1.SuspendLayout();
            this.group1.SuspendLayout();
            this.group2.SuspendLayout();
            this.Control.SuspendLayout();
            this.group3.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.group1);
            this.tab1.Groups.Add(this.group2);
            this.tab1.Groups.Add(this.Control);
            this.tab1.Groups.Add(this.group3);
            this.tab1.Groups.Add(this.group4);
            this.tab1.Label = "PDM++";
            this.tab1.Name = "tab1";
            // 
            // group1
            // 
            this.group1.Items.Add(this.btnconcurrent);
            this.group1.Items.Add(this.btnContain);
            this.group1.Items.Add(this.btnDisjoint);
            this.group1.Items.Add(this.btnMeet);
            this.group1.Items.Add(this.btnOverlap);
            this.group1.Label = "Binary Relationship";
            this.group1.Name = "group1";
            // 
            // btnconcurrent
            // 
            this.btnconcurrent.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnconcurrent.Image = ((System.Drawing.Image)(resources.GetObject("btnconcurrent.Image")));
            this.btnconcurrent.Label = "Concurrent";
            this.btnconcurrent.Name = "btnconcurrent";
            this.btnconcurrent.ScreenTip = "Two activities start and end at the same time.";
            this.btnconcurrent.ShowImage = true;
            this.btnconcurrent.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnconcurrent_Click);
            // 
            // btnContain
            // 
            this.btnContain.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnContain.Image = ((System.Drawing.Image)(resources.GetObject("btnContain.Image")));
            this.btnContain.Label = "Contain";
            this.btnContain.Name = "btnContain";
            this.btnContain.ScreenTip = "Activity 2 happens only within the duration of Activity 1.";
            this.btnContain.ShowImage = true;
            this.btnContain.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnContain_Click);
            // 
            // btnDisjoint
            // 
            this.btnDisjoint.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnDisjoint.Image = ((System.Drawing.Image)(resources.GetObject("btnDisjoint.Image")));
            this.btnDisjoint.Label = "Disjoint";
            this.btnDisjoint.Name = "btnDisjoint";
            this.btnDisjoint.ScreenTip = "Two activities can not happen together.";
            this.btnDisjoint.ShowImage = true;
            this.btnDisjoint.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnDisjoint_Click);
            // 
            // btnMeet
            // 
            this.btnMeet.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnMeet.Image = ((System.Drawing.Image)(resources.GetObject("btnMeet.Image")));
            this.btnMeet.Label = "Meet";
            this.btnMeet.Name = "btnMeet";
            this.btnMeet.ScreenTip = "Activity 2 starts immediately after Activity 1 or vice versa.";
            this.btnMeet.ShowImage = true;
            this.btnMeet.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnMeet_Click);
            // 
            // btnOverlap
            // 
            this.btnOverlap.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnOverlap.Image = ((System.Drawing.Image)(resources.GetObject("btnOverlap.Image")));
            this.btnOverlap.Label = "Overlap";
            this.btnOverlap.Name = "btnOverlap";
            this.btnOverlap.ScreenTip = "Duration of two activities overlap each other.";
            this.btnOverlap.ShowImage = true;
            this.btnOverlap.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnOverlap_Click);
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
            // btnCannot
            // 
            this.btnCannot.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnCannot.Image = ((System.Drawing.Image)(resources.GetObject("btnCannot.Image")));
            this.btnCannot.Label = "Cannot Occur";
            this.btnCannot.Name = "btnCannot";
            this.btnCannot.ShowImage = true;
            this.btnCannot.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnCannot_Click);
            // 
            // btnDueaft
            // 
            this.btnDueaft.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnDueaft.Image = ((System.Drawing.Image)(resources.GetObject("btnDueaft.Image")));
            this.btnDueaft.Label = "Due After";
            this.btnDueaft.Name = "btnDueaft";
            this.btnDueaft.ShowImage = true;
            this.btnDueaft.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnDueaft_Click);
            // 
            // btnDuebf
            // 
            this.btnDuebf.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnDuebf.Image = ((System.Drawing.Image)(resources.GetObject("btnDuebf.Image")));
            this.btnDuebf.Label = "Due Before";
            this.btnDuebf.Name = "btnDuebf";
            this.btnDuebf.ShowImage = true;
            this.btnDuebf.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnDuebf_Click);
            // 
            // btnStartaft
            // 
            this.btnStartaft.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnStartaft.Image = ((System.Drawing.Image)(resources.GetObject("btnStartaft.Image")));
            this.btnStartaft.Label = "Start After";
            this.btnStartaft.Name = "btnStartaft";
            this.btnStartaft.ShowImage = true;
            this.btnStartaft.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnStartaft_Click);
            // 
            // btnStartbf
            // 
            this.btnStartbf.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnStartbf.Image = ((System.Drawing.Image)(resources.GetObject("btnStartbf.Image")));
            this.btnStartbf.Label = "Start Before";
            this.btnStartbf.Name = "btnStartbf";
            this.btnStartbf.ShowImage = true;
            this.btnStartbf.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnStartbf_Click);
            // 
            // Control
            // 
            this.Control.Items.Add(this.btnView);
            this.Control.Items.Add(this.btnUpdate);
            this.Control.Label = "Control";
            this.Control.Name = "Control";
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
            // btnUpdate
            // 
            this.btnUpdate.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnUpdate.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdate.Image")));
            this.btnUpdate.Label = "Update Schedule";
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.ShowImage = true;
            this.btnUpdate.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnUpdate_Click);
            // 
            // group3
            // 
            this.group3.Items.Add(this.btnMetaint);
            this.group3.Items.Add(this.btnAltSch);
            this.group3.Label = "Alternative Schedule";
            this.group3.Name = "group3";
            // 
            // btnMetaint
            // 
            this.btnMetaint.Label = "Meta Interval";
            this.btnMetaint.Name = "btnMetaint";
            // 
            // btnAltSch
            // 
            this.btnAltSch.Label = "Alternative Schedule";
            this.btnAltSch.Name = "btnAltSch";
            // 
            // group4
            // 
            this.group4.Label = "Dynamic Requirement";
            this.group4.Name = "group4";
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
            this.Control.ResumeLayout(false);
            this.Control.PerformLayout();
            this.group3.ResumeLayout(false);
            this.group3.PerformLayout();

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnconcurrent;
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
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group3;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnMetaint;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnAltSch;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group4;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup Control;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnView;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnUpdate;
    }

    partial class ThisRibbonCollection
    {
        internal newPDM Ribbon1
        {
            get { return this.GetRibbon<newPDM>(); }
        }
    }
}
