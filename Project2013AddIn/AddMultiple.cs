using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MSProject = Microsoft.Office.Interop.MSProject;
using HostApplication = Microsoft.Office.Interop.MSProject.Application;

namespace Project2013AddIn
{
    public partial class AddMultiple : Form
    {
        public AddMultiple()
        {
            InitializeComponent();
            MSProject.Project project = Globals.ThisAddIn.Application.ActiveProject;

            int count = project.Tasks.Count;
            int index = 1;
            string[] datasource = new string[count+1];
            foreach (MSProject.Task task in project.Tasks)
            {
                if (task == null)
                {
                    continue;
                }
                String name = task.Name;
                datasource[index++] = name;
            }
            datasource[0] = "NA";
            this.comboBoxTask1.DataSource = datasource;
            this.comboBoxTask2.DataSource = datasource.Clone();
            this.comboBoxTask3.DataSource = datasource.Clone(); 
            this.comboBoxTask4.DataSource = datasource.Clone(); 
            this.comboBoxTask5.DataSource = datasource.Clone();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        public void btnMore_Click(object sender, EventArgs e)
        {
            if(btnMore.Text=="More Tasks")
            {
                this.panelMore.Show();
                btnMore.Text = "Less Tasks";
            }
            else
            {
                this.panelMore.Hide();
                btnMore.Text = "More Tasks";
                this.Size=new Size(372,213);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string[] tasks = new string[5];
            int i, j;
            bool same = false;
            bool success=false;

            tasks[0] = this.comboBoxTask1.SelectedItem.ToString();
            tasks[1] = this.comboBoxTask2.SelectedItem.ToString();
            tasks[2] = this.comboBoxTask3.SelectedItem.ToString();
            tasks[3] = this.comboBoxTask4.SelectedItem.ToString();
            tasks[4] = this.comboBoxTask5.SelectedItem.ToString();
            string relation = this.comboBoxRelation.SelectedItem.ToString();
            
            //at least fill in 2 tasks
            if (this.comboBoxTask1.SelectedItem.ToString() == "NA" || this.comboBoxTask2.SelectedItem.ToString() == "NA" || comboBoxRelation.SelectedItem.ToString() == "")
                MessageBox.Show("Please fill in all feilds.");
            //if panelmore not visible,check if the two tasks are the same
            if (btnMore.Text=="More Tasks")
            {
                if (this.comboBoxTask1.SelectedIndex == this.comboBoxTask2.SelectedIndex)
                    MessageBox.Show("Please select two different activities.");
                else
                {
                    tasks[2] = tasks[3] = tasks[4] = "NA";
                    success = ThisAddIn.MultipleRelation(relation, tasks[0], tasks[1], tasks[2], tasks[3], tasks[4]);
                    if (success)
                        this.Hide();
                }                    
            }

            //if panel more is visible, check if same tasks entered twice or more.
            else
            {
                for (i = 0; i < 5; i++)
                {
                    for (j = i + 1; j < 5; j++)
                    {
                        if (tasks[i] == tasks[j] && tasks[i] != "NA" && tasks[i] != null)
                            same = true;
                    }
                }
                if (same)
                    MessageBox.Show("Error: Please do not select the same task twice.");
                else
                {
                    
                    success = ThisAddIn.MultipleRelation(relation, tasks[0], tasks[1], tasks[2], tasks[3], tasks[4]);
                    if (success)
                        this.Hide();
                }
            }
            
        }

    }
}
