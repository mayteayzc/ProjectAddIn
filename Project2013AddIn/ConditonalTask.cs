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
    public partial class ConditonalTask : Form
    {
        MSProject.Project project = Globals.ThisAddIn.Application.ActiveProject;

        public ConditonalTask()
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
            this.comboBox1.DataSource = datasource;
            this.comboBox2.DataSource = datasource.Clone();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //check condtional taks and reference task are not the same
            string ConTask = this.comboBox1.SelectedItem.ToString();
            string RefTask = this.comboBox2.SelectedItem.ToString();
            int ConditionTaskID = 0;
            int ReferenceTaskID = 0;
            int D = (int) this.numericUpDown1.Value;
            DateTime ScheduledFinish = this.dateTimePicker1.Value;

            if(ConTask==RefTask)
            {
                MessageBox.Show("Conditional task and reference tasks can not be the same.");
                return;
            }
            
            foreach (MSProject.Task tk in project.Tasks)
            {
                if (tk.Name == ConTask)
                    ConditionTaskID = tk.UniqueID;

                if (tk.Name == RefTask)
                    ReferenceTaskID = tk.UniqueID;
            }

            //check if tasks are found
            if(ConditionTaskID==0||ReferenceTaskID==0)
            {
                MessageBox.Show("Conditional task or reference task can not be found.");
                return;
            }

            //else, if found, then proceed
            MSProject.Task ConditionalTk = project.Tasks.UniqueID[ConditionTaskID];
            MSProject.Task ReferenceTk = project.Tasks.UniqueID[ReferenceTaskID];

            if (DateTime.Compare(ScheduledFinish, ReferenceTk.Finish) < 0) //DELAY
            {
                int days = (int)(ReferenceTk.Finish - ScheduledFinish) / 480;
                if (days > D)
                    ConditionalTk.Active = true;
                else
                    ConditionalTk.Active = false;
            }

            else //if no delay
                ConditionalTk.Active = false;
            
            //strore the info in text28
            int i = 1;
            foreach (MSProject.Task task in project.Tasks)
            {
                if (task.ID == 1)
                    i = task.UniqueID;
            }

            string Condition = project.Tasks.UniqueID[i].GetField(Globals.ThisAddIn.Application.FieldNameToFieldConstant("Text28"));
            string NewBinaryString = Condition + ConTask + "," + RefTask + "," + ScheduledFinish.ToString() + "," + "Delay" + D.ToString()+";";
            project.Tasks.UniqueID[i].SetField(Globals.ThisAddIn.Application.FieldNameToFieldConstant("Text28"), NewBinaryString);

            this.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
