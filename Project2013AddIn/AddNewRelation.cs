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
                this.Hide();
                {
                    DateTime Start=new DateTime(2015,01,01), Finish=new DateTime(2015,01,01);
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
                    
                    string relation =rela;
                    switch(relation)
                    {
                        case "Concurrent":
                            project.Tasks.UniqueID[id2].Duration = project.Tasks.UniqueID[id1].Duration;
                            project.Tasks.UniqueID[id2].Start = project.Tasks.UniqueID[id1].Start;
                            break;
                       
                        case "Contain":
                            if (project.Tasks.UniqueID[id2].Duration > project.Tasks.UniqueID[id1].Duration)
                                MessageBox.Show("Error: Please make sure duration of activity 1 is longer than activity 2 in a Contain relationship.");
                            else if (DateTime.Compare(project.Tasks.UniqueID[id1].Start, project.Tasks.UniqueID[id2].Start) > 0)
                                project.Tasks.UniqueID[id2].Start = project.Tasks.UniqueID[id1].Start;
                            else if (DateTime.Compare(project.Tasks.UniqueID[id1].Finish, project.Tasks.UniqueID[id2].Finish) < 0)
                                {
                                    while (project.Tasks.UniqueID[id1].Finish < project.Tasks.UniqueID[id2].Finish)
                                        project.Tasks.UniqueID[id1].Start=project.Tasks.UniqueID[id1].Start.AddDays(1);
                                    project.Tasks.UniqueID[id1].Start=project.Tasks.UniqueID[id1].Start.SubtractDays(1);
                                }
                                break;
                       
                        case "Disjoint":
                            //check empty field in start, finish, duration first.
                            //only amend when overlap.
                            if (DateTime.Compare(project.Tasks.UniqueID[id1].Finish, project.Tasks.UniqueID[id2].Start) < 0
                                    || DateTime.Compare(project.Tasks.UniqueID[id2].Finish, project.Tasks.UniqueID[id1].Start) < 0)
                                  break;
                            else
                            {
                                if (DateTime.Compare(project.Tasks.UniqueID[id1].Start, project.Tasks.UniqueID[id2].Start) < 0)
                                    project.Tasks.UniqueID[id2].Start = project.Tasks.UniqueID[id1].Finish.AddDays(1);
                                else if (DateTime.Equals(project.Tasks.UniqueID[id1].Start, project.Tasks.UniqueID[id2].Start))
                                    project.Tasks.UniqueID[id2].Start = project.Tasks.UniqueID[id1].Finish.AddDays(1);
                                else
                                    project.Tasks.UniqueID[id1].Start = project.Tasks.UniqueID[id2].Finish.AddDays(1);
                             }
                            break;
                        
                        case "Meet":
                            //check empty field in start, finish, duration first. 
                            if (DateTime.Compare(project.Tasks.UniqueID[id1].Start, project.Tasks.UniqueID[id2].Start) < 0)
                            {
                                if (DateTime.Compare(project.Tasks.UniqueID[id1].Finish, project.Tasks.UniqueID[id2].Start) < 0)
                                {
                                    while (project.Tasks.UniqueID[id1].Finish < project.Tasks.UniqueID[id2].Start)
                                        project.Tasks.UniqueID[id1].Start = project.Tasks.UniqueID[id1].Start.AddDays(1);
                                    project.Tasks.UniqueID[id1].Start = project.Tasks.UniqueID[id1].Start.SubtractDays(1);
                                }
                                else
                                    project.Tasks.UniqueID[id2].Start = project.Tasks.UniqueID[id1].Finish.AddDays(1);
                            }

                            else if (DateTime.Equals(project.Tasks.UniqueID[id1].Start, project.Tasks.UniqueID[id2].Start))
                                project.Tasks.UniqueID[id2].Start = project.Tasks.UniqueID[id1].Finish.AddDays(1);
                            else
                            {
                                if (DateTime.Compare(project.Tasks.UniqueID[id2].Finish, project.Tasks.UniqueID[id1].Start) < 0)
                                {
                                    while (project.Tasks.UniqueID[id2].Finish < project.Tasks.UniqueID[id1].Start)
                                        project.Tasks.UniqueID[id2].Start = project.Tasks.UniqueID[id2].Start.AddDays(1);
                                    project.Tasks.UniqueID[id2].Start = project.Tasks.UniqueID[id1].Start.SubtractDays(1);
                                }
                                else
                                    project.Tasks.UniqueID[id1].Start = project.Tasks.UniqueID[id2].Finish.AddDays(1);
                            }                              
                            break;
                       
                        case "Overlap":
                            
                            OverlapDays OL = new OverlapDays();
                            OL.Show();
                           

                            if (D==0)
                                MessageBox.Show("lololololo");
                            
                            if (D > project.Tasks.UniqueID[id1].Duration || D > project.Tasks.UniqueID[id2].Duration)
                                MessageBox.Show("Overlap days cannot be longer than the duration of tasks.");
                            
                            MSProject.Task first;
                            MSProject.Task second;

                            if(DateTime.Compare(project.Tasks.UniqueID[id1].Start, project.Tasks.UniqueID[id2].Start) < 0)
                            {
                                first = project.Tasks.UniqueID[id1];
                                second = project.Tasks.UniqueID[id2];
                            }
                            
                            else 
                            {
                                first = project.Tasks.UniqueID[id2];
                                second = project.Tasks.UniqueID[id1];
                            }
                               
                            int difference = first.Duration - D;
                            DateTime reference = first.Start.AddDays(difference);

                            while (DateTime.Compare(reference, second.Start) < 0)
                            {
                                    first.Start = first.Start.AddDays(1);
                                    reference = reference.AddDays(1);
                            }
                            break;
                    }
                             
            }
        }
        }

       // public static void GetOverLap (decimal Number)
        //{
           // D = (int)Number;
       // }
      
        private void AddNewRelation_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Help helptext=new Help();
            helptext.Show();
        }
}
}
