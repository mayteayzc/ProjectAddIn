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
    public partial class AddConstraint : Form
    {
        MSProject.Project project = Globals.ThisAddIn.Application.ActiveProject;

        SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=
           E:\MS\FYP\Project2013AddIn\Project2013AddIn\ProjectAddinDB.mdf;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter adp = new SqlDataAdapter();

        public AddConstraint()
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
                string taskname = comboBoxTaskName.SelectedItem.ToString();
                string constraint = comboBoxConstraint.SelectedItem.ToString();
                DateTime date1 = dateTimePicker1.Value;
                DateTime date2 = dateTimePicker2.Value;
                DateTime date3 = date1;

            //check if there are existing constraints that contradicting the new constraint.
            //Microsoft.Office.Interop.MSProject.Dependencies.

               if(taskname=="Can Not Occur")
               {
                   if(DateTime.Compare(date1,date2)>0)
                   {
                         if(MessageBox.Show("Start Date is later than End Date. Do you want to switch them?","Comfirm",MessageBoxButtons.YesNo)==DialogResult.Yes)
                         {
                             date1=date2;
                             date2=date3;
                         }
                         else
                             MessageBox.Show("Please select valid date before continue");
                   }
               }

               else
               {
                   int id = 0;
                   bool found1 = false;

                   foreach (MSProject.Task task in project.Tasks)
                   {
                       if (task.Name.Equals(taskname))
                       {
                           id = task.UniqueID;
                           found1 = true;
                       }
                   }

                   if (found1 == false)
                   {
                       MessageBox.Show("Error: Task can not be found.");
                       this.Close();
                   }
                   else
                   {
                       MSProject.Task thistask = project.Tasks.UniqueID[id];
                   
                       if(thistask.Duration==null)
                          thistask.Duration7=1;
                       if(thistask.Start==null)
                          thistask.Start=DateTime.Today.Date;

                       cn.Open();
                       cmd.Connection = cn;
                       if (constraint == "Can Not Occur")
                           cmd.CommandText = "INSERT INTO ConstraintTable (Task,Duration,Constraints,Date1,Date2) Values ('"+taskname+"','"+thistask.Duration/480+"','"+constraint+"','"+date1+"','"+date2+"')";

                       else
                           cmd.CommandText = "INSERT INTO ConstraintTable (Task,Constraints,Date1) Values ('" + taskname + "','" + constraint + "','" + date1 + "')";
                       cmd.ExecuteNonQuery();
                       cn.Close();

                      
                      switch (constraint)
                      {
                          case "Can Not Occur":
                              if((DateTime.Compare(date1,thistask.Start)<0||DateTime.Compare(date1,thistask.Start)==0) & DateTime.Compare(thistask.Start,date2)<0)
                                  thistask.Start = date2;

                              else if(DateTime.Compare(date1,thistask.Finish)<0 & DateTime.Compare(date2,thistask.Finish)<0)
                              {
                                  //get banned days
                                  int BannedDays =0;
                                  while(DateTime.Compare(date1,date2)<0)
                                  {
                                      BannedDays+=1;
                                      date1=date1.AddDays(1);
                                  }
                                  
                                  //then increase the duration by the overlapped days
                                  thistask.Duration += BannedDays*480;
                              }
                              else if (DateTime.Compare(date1, thistask.Finish) < 0 & DateTime.Compare(date2, thistask.Finish) > 0)
                              {
                                  int BannedDays = 0;
                                  while (DateTime.Compare(thistask.Finish, date2) < 0)
                                  {
                                      BannedDays += 1;
                                      thistask.Duration += 480;
                                  }
                              }
                              this.Hide();
                              break;

                          case "Due After"://what does due after means exactly?? if due after 30/4, then finish 30/04 can? or must be 01/05??
                              thistask.Manual = false;
                              thistask.ConstraintType = MSProject.PjConstraint.pjFNET; //FinishNoEarlierThan	Value=6. Finish no earlier than (FNET).
                              thistask.ConstraintDate = date1;
                              thistask.Manual = true;//???should we do so?
                              this.Hide();
                              break;
   
                          case "Due Before":
                              thistask.Manual = false;
                              thistask.ConstraintType = MSProject.PjConstraint.pjFNLT;//FinishNoLaterThan	Value=7. Finish no later than (FNLT).
                              thistask.ConstraintDate = date1;
                              thistask.Manual = true;
                              this.Hide();
                              break;

                          case "Start After"://similar question as due after.
                              thistask.Manual = false;
                              thistask.ConstraintType = MSProject.PjConstraint.pjSNET;//StartNoEarlierThan	Value=4. Start no earlier than (SNET).
                              thistask.ConstraintDate = date1;
                              thistask.Manual = true;
                              this.Hide();
                              break;

                          case "Start Before":
                              thistask.Manual = false;
                              thistask.ConstraintType = MSProject.PjConstraint.pjSNLT;////StartNoLaterThan	Value=5. Start no later than (SNLT).
                              thistask.ConstraintDate = date1;
                              thistask.Manual = true;
                              this.Hide();
                              break;

                       }
                   }
               }       
            }
        }
    }
}
