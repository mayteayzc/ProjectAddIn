using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MSProject = Microsoft.Office.Interop.MSProject;
using HostApplication = Microsoft.Office.Interop.MSProject.Application;

namespace Project2013AddIn
{
    public partial class AddUnary : Form
    {
        MSProject.Project project = Globals.ThisAddIn.Application.ActiveProject;

        public AddUnary()
        {
            InitializeComponent();
            int count = project.Tasks.Count;
            int index = 0;
            string[] datasource = new string[count];
            foreach (MSProject.Task task in project.Tasks)
            {
                if (task == null)
                {
                    continue;
                }
                String name = task.Name;
                datasource[index++] = name;
            }
            this.comboBoxTaskName.DataSource = datasource;
        }

        private void comboBoxConstraint_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBoxConstraint.SelectedItem.ToString() == "Can Not Occur")
            {
                this.labelDate1.Text = "Start Date";
                this.labelDate2.Text = "End Date";
                this.dateTimePicker2.Enabled = true;
            }
            else
            {
                this.labelDate1.Text = "Date";
                this.labelDate2.Text = "";
                this.dateTimePicker2.Enabled = false;
            }              
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if(comboBoxTaskName.SelectedItem==null||comboBoxConstraint.SelectedItem==null)
                MessageBox.Show("Please fill in all fields");
            else
            {
                string tkname = comboBoxTaskName.SelectedItem.ToString();
                string constraint = comboBoxConstraint.SelectedItem.ToString();
                DateTime d1 = dateTimePicker1.Value;
                DateTime d2 = dateTimePicker2.Value;
                DateTime d3 = d1;

            //check if there are existing constraints that contradicting the new constraint.
            //Microsoft.Office.Interop.MSProject.Dependencies.
                bool success = false; 
                if (constraint == "Can Not Occur")
                {
                    if (dateTimePicker1.Value.CompareTo(dateTimePicker2.Value) > 0||dateTimePicker1.Value.CompareTo(dateTimePicker2.Value)==0)
                    {
                        MessageBox.Show("End Date must be later than Start Date. Please select valid date before continue");                             
                    }
                    else
                        success = ThisAddIn.UnaryRelation(tkname, constraint, d1, d2);
                }
                else
                success=ThisAddIn.UnaryRelation(tkname, constraint, d1, d2);
                
                if (success)
                    this.Hide();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
