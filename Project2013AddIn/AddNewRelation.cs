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
        public static int D;

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
                
                {
                    
                    int id1 = 0, id2 = 0;
                    bool found1 = false, found2 = false;

                    foreach (MSProject.Task task in project.Tasks)
                    {
                        if (task.Name.Equals(act1))
                        {
                            id1 = task.UniqueID;
                            found1 = true;
                        }

                        if (task.Name.Equals(act2))
                        {
                            id2 = task.UniqueID;
                            found2 = true;
                        }
                    }

                    if (found1 == false || found2 == false)
                    MessageBox.Show("Error: Task can not be found.");

                    //check empty fileds.
                    if (project.Tasks.UniqueID[id1].Duration == null)
                        project.Tasks.UniqueID[id1].Duration7 = 1;

                    if (project.Tasks.UniqueID[id2].Duration == null)
                        project.Tasks.UniqueID[id2].Duration7 = 1;

                    if (project.Tasks.UniqueID[id1].Start == null)
                        project.Tasks.UniqueID[id1].Start = DateTime.Today;

                    if (project.Tasks.UniqueID[id2].Start == null)
                        project.Tasks.UniqueID[id2].Start = DateTime.Today;
                   
                    MSProject.Task first;
                    MSProject.Task second;
                    
                    string relation =rela;
                    switch(relation)
                    {
                        case "Concurrent":
                            //activity 1 is the reference.
                            if (project.Tasks.UniqueID[id1].Duration != project.Tasks.UniqueID[id2].Duration)
                                MessageBox.Show("Please make sure activity 1 and activity 2 have equal duration in a Concurrent relationship.");
                            else
                            {
                                 project.Tasks.UniqueID[id2].Duration = project.Tasks.UniqueID[id1].Duration;
                                 project.Tasks.UniqueID[id2].Start = project.Tasks.UniqueID[id1].Start;
                                 this.Hide(); 
                            }
                            break;
                       
                        case "Contain":
                            if (project.Tasks.UniqueID[id2].Duration > project.Tasks.UniqueID[id1].Duration)
                            {
                                first = project.Tasks.UniqueID[id2];
                                second = project.Tasks.UniqueID[id1];
                            }
                            else
                            {
                                first= project.Tasks.UniqueID[id1];
                                second= project.Tasks.UniqueID[id2];
                            }

                            if (DateTime.Compare(first.Start, second.Start) > 0)
                                first.Start = second.Start;
                            if (DateTime.Compare(first.Finish, second.Finish) < 0)
                                {
                                    while (first.Finish != second.Finish)
                                        first.Start=first.Start.AddDays(1);
                                }
                            this.Hide();
                            break;
                       
                        case "Disjoint":
                            //only change when overlap.
                            //check if there is 3rd task in disjoint.Need to store sassigned relationships first.
                            if (DateTime.Compare(project.Tasks.UniqueID[id1].Finish, project.Tasks.UniqueID[id2].Start) < 0
                                    || DateTime.Compare(project.Tasks.UniqueID[id2].Finish, project.Tasks.UniqueID[id1].Start) < 0)
                                  break;
                            else
                            {
                                if (DateTime.Compare(project.Tasks.UniqueID[id1].Start, project.Tasks.UniqueID[id2].Start) < 0)
                                    project.Tasks.UniqueID[id2].Start = project.Tasks.UniqueID[id1].Finish;
                                else if (DateTime.Equals(project.Tasks.UniqueID[id1].Start, project.Tasks.UniqueID[id2].Start))
                                    project.Tasks.UniqueID[id2].Start = project.Tasks.UniqueID[id1].Finish;
                                else
                                    project.Tasks.UniqueID[id1].Start = project.Tasks.UniqueID[id2].Finish;
                             }
                            this.Hide();
                            break;
                        
                        case "Meet":
                            //need to modefy, easier way, since the methods are the same.
                            

                            if (DateTime.Compare(project.Tasks.UniqueID[id1].Start, project.Tasks.UniqueID[id2].Start) < 0)
                            {
                                first = project.Tasks.UniqueID[id1];
                                second = project.Tasks.UniqueID[id2];
                            }
                            else
                            {
                                first=project.Tasks.UniqueID[id2];
                                second=project.Tasks.UniqueID[id1];
                            }
                            
                            if (DateTime.Compare(first.Finish, second.Start) < 0)
                                {
                                    while (first.Finish != second.Start)
                                        first.Start = first.Start.AddDays(1);
                                }
                            else
                                    second.Start = first.Finish;
                            this.Hide();
                            break;
                       
                        case "Overlap":
                            //overlap exact how many days or overlap at least how many days?
                            //here is at least, for overlap more than specified days, no change is made.
                            //by default everyday includes 8 working hrs, 480 mins.
                            if (NumericDays.Value<0  || NumericDays.Value==0)
                                MessageBox.Show("please select a positive number for overlap days.");

                            else if (NumericDays.Value > project.Tasks.UniqueID[id1].Duration/480 || NumericDays.Value > project.Tasks.UniqueID[id2].Duration/480)
                                MessageBox.Show("Overlap days cannot be longer than the duration of tasks.");
                            
                            else
                            {
                                
                                if (DateTime.Compare(project.Tasks.UniqueID[id1].Start, project.Tasks.UniqueID[id2].Start) < 0)
                                {
                                    first = project.Tasks.UniqueID[id1];
                                    second = project.Tasks.UniqueID[id2];
                                }

                                else
                                {
                                    first = project.Tasks.UniqueID[id2];
                                    second = project.Tasks.UniqueID[id1];
                                }

                                if (DateTime.Compare(first.Finish, second.Start) < 0)
                                {
                                    while (first.Finish != second.Start)
                                        first.Start = first.Start.AddDays(1);
                                }

                                int D = 0;
                                DateTime reference=second.Start;
                                while(D!=(int)NumericDays.Value)
                                {
                                    first.Start = first.Start.AddDays(1);
                                    while(DateTime.Compare(reference,first.Finish)<0)
                                    {
                                    if(reference.DayOfWeek==DayOfWeek.Monday||reference.DayOfWeek==DayOfWeek.Tuesday||reference.DayOfWeek==DayOfWeek.Wednesday
                                        ||reference.DayOfWeek==DayOfWeek.Thursday||reference.DayOfWeek==DayOfWeek.Friday)
                                        D=D+1;
                                    reference=reference.AddDays(1);
                                    }
                                }
                                this.Hide();
                            }
                            break;
                    }
                             
            }
        }
        }

      
      
        private void AddNewRelation_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Help helptext=new Help();
            helptext.Show();
        }

        private void ComboBoxRela_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBoxRela.SelectedItem.ToString() =="Overlap")
                NumericDays.Enabled = true;
            else
                NumericDays.Enabled=false;
        }

}
} 
