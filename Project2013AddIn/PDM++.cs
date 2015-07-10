using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public void btnconcurrent_Click(object sender, RibbonControlEventArgs e)
        {
            AddBinary Relation = new AddBinary();
            Relation.ComboBoxRela.SelectedItem = "Concurrent";
            Relation.Show();
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
            AddMultiple Relation = new AddMultiple();
            Relation.comboBoxRelation.SelectedItem = "Disjoint";
            Relation.Show();
        }

        private void btnMeet_Click(object sender, RibbonControlEventArgs e)
        {
            AddMultiple Relation = new AddMultiple();
            Relation.comboBoxRelation.SelectedItem = "Meet";
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
            if (Globals.ThisAddIn.Application.ActiveSelection != null)
                constraint.comboBoxTaskName.SelectedItem = Globals.ThisAddIn.Application.ActiveSelection.Tasks[1].Name.ToString();
            else
                constraint.comboBoxTaskName.SelectedIndex = 1;
            constraint.labelDate1.Text = "Start Date";
            constraint.labelDate2.Text = "End Date";
            constraint.Show();
        }

        private void btnDueaft_Click(object sender, RibbonControlEventArgs e)
        {
            AddUnary constraint = new AddUnary();
            constraint.comboBoxConstraint.SelectedItem = "Due After";
            constraint.comboBoxTaskName.SelectedItem = Globals.ThisAddIn.Application.ActiveSelection.Tasks[1].Name.ToString();
            constraint.labelDate1.Text = "Date";
            constraint.labelDate2.Text = "";
            constraint.dateTimePicker2.Enabled = false;
            constraint.Show();
        }

        private void btnDuebf_Click(object sender, RibbonControlEventArgs e)
        {
            AddUnary constraint = new AddUnary();
            constraint.comboBoxConstraint.SelectedItem = "Due Before";
            constraint.comboBoxTaskName.SelectedItem = Globals.ThisAddIn.Application.ActiveSelection.Tasks[1].Name.ToString();
            constraint.labelDate1.Text = "Date";
            constraint.labelDate2.Text = "";
            constraint.dateTimePicker2.Enabled = false;
            constraint.Show();
        }

        private void btnStartaft_Click(object sender, RibbonControlEventArgs e)
        {
            AddUnary constraint = new AddUnary();
            constraint.comboBoxConstraint.SelectedItem = "Start After";
            constraint.comboBoxTaskName.SelectedItem = Globals.ThisAddIn.Application.ActiveSelection.Tasks[1].Name.ToString();
            constraint.labelDate1.Text = "Date";
            constraint.labelDate2.Text = "";
            constraint.dateTimePicker2.Enabled = false;
            constraint.Show();
        }

        private void btnStartbf_Click(object sender, RibbonControlEventArgs e)
        {
            AddUnary constraint = new AddUnary();
            constraint.comboBoxConstraint.SelectedItem = "Start Before";
            constraint.comboBoxTaskName.SelectedItem = Globals.ThisAddIn.Application.ActiveSelection.Tasks[1].Name.ToString();
            constraint.labelDate1.Text = "Date";
            constraint.labelDate2.Text = "";
            constraint.dateTimePicker2.Enabled = false;
            constraint.Show();
        }

        private void btnUpdate_Click(object sender, RibbonControlEventArgs e)
        {
            //read from table and update according to the datatable.
            //same as pressing ok in view relationship
            //event=viewrelationship.btnok_click?
            
            
        }

        private void buttonBetween_Click(object sender, RibbonControlEventArgs e)
        {

        }




    }
}
