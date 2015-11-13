using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Tools.Ribbon;
using MSProject = Microsoft.Office.Interop.MSProject;
using HostApplication = Microsoft.Office.Interop.MSProject.Application;


namespace Project2013AddIn
{
    public partial class newPDM
    {
        private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
        {
        }

        private void btnContain_Click(object sender, RibbonControlEventArgs e)
        {
            AddBinary Relation = new AddBinary();
            Relation.ComboBoxRela.SelectedItem = "Contain";
            Relation.NumericDays.Enabled = false;
            Relation.Show();
        }

        private void btnDisjoint_Click(object sender, RibbonControlEventArgs e)
        {
            AddBinary Relation = new AddBinary();
            Relation.ComboBoxRela.SelectedItem = "Disjoint";
            Relation.NumericDays.Enabled = false;
            Relation.Show();
        }

        private void btnMeet_Click(object sender, RibbonControlEventArgs e)
        {
            AddBinary Relation = new AddBinary();
            Relation.ComboBoxRela.SelectedItem = "Meet";
            Relation.NumericDays.Enabled = false;
            Relation.Show();
        }

        private void btnOverlap_Click(object sender, RibbonControlEventArgs e)
        {
            AddBinary Relation = new AddBinary();
            Relation.ComboBoxRela.SelectedItem = "Overlap";
            Relation.Show();
        }

        private void btnViewDetail_Click(object sender, RibbonControlEventArgs e)
        {
            ViewRelationship View = new ViewRelationship();
            View.Show();
        }

        private void btnCannot_Click(object sender, RibbonControlEventArgs e)
        {
            AddUnary constraint = new AddUnary();
            constraint.comboBoxConstraint.SelectedItem = "Can Not Occur";
            constraint.labelDate1.Text = "Start Date";
            constraint.labelDate2.Text = "End Date";
            constraint.Show();
        }

        private void btnDueaft_Click(object sender, RibbonControlEventArgs e)
        {
            AddUnary constraint = new AddUnary();
            constraint.comboBoxConstraint.SelectedItem = "Due After";
            constraint.labelDate1.Text = "Date";
            constraint.labelDate2.Text = "";
            constraint.dateTimePicker2.Enabled = false;
            constraint.Show();
        }

        private void btnDuebf_Click(object sender, RibbonControlEventArgs e)
        {
            AddUnary constraint = new AddUnary();
            constraint.comboBoxConstraint.SelectedItem = "Due Before";
            constraint.labelDate1.Text = "Date";
            constraint.labelDate2.Text = "";
            constraint.dateTimePicker2.Enabled = false;
            constraint.Show();
        }

        private void btnStartaft_Click(object sender, RibbonControlEventArgs e)
        {
            AddUnary constraint = new AddUnary();
            constraint.comboBoxConstraint.SelectedItem = "Start After";
            constraint.labelDate1.Text = "Date";
            constraint.labelDate2.Text = "";
            constraint.dateTimePicker2.Enabled = false;
            constraint.Show();
        }

        private void btnStartbf_Click(object sender, RibbonControlEventArgs e)
        {
            AddUnary constraint = new AddUnary();
            constraint.comboBoxConstraint.SelectedItem = "Start Before";
            constraint.labelDate1.Text = "Date";
            constraint.labelDate2.Text = "";
            constraint.dateTimePicker2.Enabled = false;
            constraint.Show();
        }

        private void btnConditionalTask_Click(object sender, RibbonControlEventArgs e)
        {
            ConditonalTask condition = new ConditonalTask();
            condition.Show();
        }

        private void btnOptimization_Click(object sender, RibbonControlEventArgs e)
        {
            if (MessageBox.Show("This function will calculate the near optimum arrangement of PDM++ binary relationships based on heuristic approch, click Yes to continue.", "Confirmed", MessageBoxButtons.YesNo) == DialogResult.Yes)
                ThisAddIn.GeneticAlgorithm();
        }

        private void btnUpdateCondition_Click(object sender, RibbonControlEventArgs e)
        {
            ThisAddIn.UpdateCondition();
        }

        private void btnManageCondition_Click(object sender, RibbonControlEventArgs e)
        {
            ManageCondition manage = new ManageCondition();
            manage.Show();
        }




    }
}
