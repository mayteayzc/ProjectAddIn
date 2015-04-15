using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;

namespace Project2013AddIn
{
    public partial class newPDM
    {
        private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
        {
        }

        public void btnconcurrent_Click(object sender, RibbonControlEventArgs e)
        {
            AddNewRelation Relation = new AddNewRelation();
            Relation.ComboBoxRela.SelectedItem = "Concurrent";
            Relation.NumericDays.Enabled = false;
            Relation.Show();
         }

        private void btnContain_Click(object sender, RibbonControlEventArgs e)
        {
            AddNewRelation Relation = new AddNewRelation();
            Relation.ComboBoxRela.SelectedItem = "Contain";
            Relation.NumericDays.Enabled = false;
            Relation.Show();
        }

        private void btnDisjoint_Click(object sender, RibbonControlEventArgs e)
        {
            AddNewRelation Relation = new AddNewRelation();
            Relation.ComboBoxRela.SelectedItem = "Disjoint";
            Relation.NumericDays.Enabled = false;
            Relation.Show();
        }

        private void btnMeet_Click(object sender, RibbonControlEventArgs e)
        {
            AddNewRelation Relation = new AddNewRelation();
            Relation.ComboBoxRela.SelectedItem = "Meet";
            Relation.NumericDays.Enabled = false;
            Relation.Show();
        }

        private void btnOverlap_Click(object sender, RibbonControlEventArgs e)
        {
            AddNewRelation Relation = new AddNewRelation();
            Relation.ComboBoxRela.SelectedItem = "Overlap";
            Relation.Show();
        }

        private void btnViewRelation_Click(object sender, RibbonControlEventArgs e)
        {
            ViewRelation View = new ViewRelation();
            View.Show();
        }
    }
}
