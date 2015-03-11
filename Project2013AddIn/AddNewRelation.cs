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
    public partial class AddNewRelation : Form
    {
        MSProject.Project project = Globals.ThisAddIn.Application.ActiveProject;

        public AddNewRelation()
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
            this.ComboBoxAct1.DataSource = datasource;
            this.ComboBoxAct2.DataSource = datasource.Clone();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.ComboBoxAct1.SelectedItem == null || this.ComboBoxAct2.SelectedItem == null || ComboBoxRela.SelectedItem == null)
            {
                MessageBox.Show("Please fill in all feilds.");
            }

            else if (this.ComboBoxAct1.SelectedIndex == this.ComboBoxAct2.SelectedIndex)
            {
                MessageBox.Show("Please select two different activities.");
            }

            else
            {
                string act1 = this.ComboBoxAct1.SelectedItem.ToString();
                string act2 = this.ComboBoxAct2.SelectedItem.ToString();
                string rela = this.ComboBoxRela.SelectedItem.ToString();
                this.Hide();
                unsafe
                {
                    int duration=0;
                    int* DurationAct1=&duration, DurationAct2=&duration;
                    DateTime Start=new DateTime(2015,01,01), Finish=new DateTime(2015,01,01);
                    DateTime* StartAct1=&Start, FinishAct1=&Finish, StartAct2=&Start, FinishAct2=&Finish;
                    int id1 = 0, id2 = 0;
                    bool found1 = false, found2 = false;

                    foreach (MSProject.Task task in project.Tasks)
                    {
                        if (task.Name.Equals(act1))
                        {
                            *StartAct1 = task.Start;
                            *FinishAct1 = task.Finish;
                            *DurationAct1 = task.Duration;
                            id1 = task.UniqueID;
                            found1 = true;
                        }

                        if (task.Name.Equals(act2))
                        {
                            *StartAct2 = task.Start;
                            *FinishAct2 = task.Finish;
                            *DurationAct2 = task.Duration;
                            id2 = task.UniqueID;
                            found2 = true;
                        }
                    }

                    if (found1 == false || found2 == false)
                    MessageBox.Show("Error: Task can not be found.");
                    
                    string relation =rela;
                    switch(relation)
                    {
                        case "Concurrent":
                            project.Tasks.UniqueID[id2].Duration = *DurationAct1;
                            project.Tasks.UniqueID[id2].Start = *StartAct1;
                            break;
                        case "Contain":
                            if (project.Tasks.UniqueID[id2].Duration > project.Tasks.UniqueID[id1].Duration)
                                MessageBox.Show("Error: Please make sure duration of activity 1 is longer than activity 2 in a Contain relationship.");
                            else //still got problem, not working.
                            {
                                project.Tasks.UniqueID[id2].ConstraintType = Microsoft.Office.Interop.MSProject.PjConstraint.pjSNET;
                                project.Tasks.UniqueID[id2].ConstraintDate= project.Tasks.UniqueID[id1].Start;
                                project.Tasks.UniqueID[id2].ConstraintType = Microsoft.Office.Interop.MSProject.PjConstraint.pjFNLT;
                                project.Tasks.UniqueID[id2].ConstraintDate = project.Tasks.UniqueID[id1].Finish;
                            }
                            break;
                        case "Meet":
                            break;
                        case "Disjoint":
                            break;
                        case "Overlap":
                            break;
                    }
                             
            }
        }
        }

        private void AddNewRelation_Load(object sender, EventArgs e)
        {

        }
}
}
