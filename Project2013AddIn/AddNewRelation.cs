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
                this.Hide();
                unsafe
                {
                    int duration=0;
                    int* DurationAct1=&duration, DurationAct2=&duration;
                    DateTime Start=new DateTime(2015,01,01), Finish=new DateTime(2015,01,01);
                    DateTime* StartAct1=&Start, FinishAct1=&Finish, StartAct2=&Start, FinishAct2=&Finish;
                    bool found1 = false, found2 = false;

                    foreach (MSProject.Task task in project.Tasks)
                    {
                        if (task.Name == this.ComboBoxAct1.SelectedItem.ToString())
                        {
                            *StartAct1 = task.ScheduledStart;
                            *FinishAct1 = task.ScheduledFinish;
                            *DurationAct1 = task.ScheduledDuration;
                            found1 = true;
                        }

                        if (task.Name == this.ComboBoxAct2.SelectedItem.ToString())
                        {
                            *StartAct2 = task.ScheduledStart;
                            *FinishAct2 = task.ScheduledFinish;
                            *DurationAct2 = task.ScheduledDuration;
                            found2 = true;
                        }
                    }

                    if (found1 == false || found2 == false)
                    MessageBox.Show("Error: Task can not be found.");
                    
                    string relation = this.ComboBoxRela.SelectedItem.ToString();
                    switch(relation)
                    {
                        case "Concurrent":
                            *StartAct2 = *StartAct1;
                            *DurationAct2 = *DurationAct1;
                            break;
                        case "Contain":
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
