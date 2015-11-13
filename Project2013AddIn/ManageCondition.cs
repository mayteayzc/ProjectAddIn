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

namespace Project2013AddIn
{
    public partial class ManageCondition : Form
    {
        public ManageCondition()
        {
            InitializeComponent();

            MSProject.Project project = Globals.ThisAddIn.Application.ActiveProject;
            int i = 1;
            foreach (MSProject.Task task in project.Tasks)
            {
                if (task.ID == 1)
                    i = task.UniqueID;
            }

            string Condition = project.Tasks.UniqueID[i].GetField(Globals.ThisAddIn.Application.FieldNameToFieldConstant("Text28"));
            String ConditionData;
            DataTable dt1 =new DataTable();
            dt1.Columns.Add("Conditional Task", typeof(string));
            dt1.Columns.Add("Reference Task", typeof(string));
            dt1.Columns.Add("Scheudled Finish", typeof(string));
            dt1.Columns.Add("Condition", typeof(string));
            dt1.Columns.Add("Days", typeof(string));

            //process condition date
            int l1 = Condition.Length;
            int l2;
            int p1 = Condition.IndexOf(";");
            int p2;
            string ConTk, RefTk, Finish,delay,d;

            while (p1 > 0)
            {
                ConditionData = Condition.Substring(0, p1);
                l2 = ConditionData.Length;
                p2 = ConditionData.IndexOf(",");
                ConTk = ConditionData.Substring(0, p2);

                ConditionData = ConditionData.Substring(p2 + 1, l2 - p2 - 1);
                p2 = ConditionData.IndexOf(",");
                RefTk = ConditionData.Substring(0, p2);
                l2 = ConditionData.Length;

                ConditionData = ConditionData.Substring(p2 + 1, l2 - p2 - 1);
                p2 = ConditionData.IndexOf(",");
                Finish = ConditionData.Substring(0, p2);
                l2 = ConditionData.Length;

                ConditionData = ConditionData.Substring(p2 + 1, l2 - p2 - 1);
                p2 = ConditionData.IndexOf(",");
                delay = ConditionData.Substring(0, p2);
                l2 = ConditionData.Length;

                ConditionData = ConditionData.Substring(p2 + 1, l2 - p2 - 1);
                d = ConditionData;

                dt1.Rows.Add(ConTk, RefTk, Finish, "Delay",d);

                Condition= Condition.Substring(p1 + 1, l1 - p1 - 1);
                p1 = Condition.IndexOf(";");
                l1 = Condition.Length;
            }
            dataGridView1.DataSource = dt1;

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            MSProject.Project project = Globals.ThisAddIn.Application.ActiveProject;

            if (MessageBox.Show("Delete current selection?", "Confirmed", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string ConTk = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
                string RefTk = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
                string Finish = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value.ToString();
                string days = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[4].Value.ToString();
                int id1 = 0;

                foreach (MSProject.Task task in project.Tasks)
                {
                    if (task.Name.Equals(ConTk))
                        id1 = task.UniqueID;
                }

                if (id1 == 0)
                {
                    MessageBox.Show("The tasks in the record can not be found");
                    return;
                }
                
                dataGridView1.Rows.RemoveAt(this.dataGridView1.CurrentRow.Index);
                project.Tasks.UniqueID[id1].Active = true;

                //remove from Conditiondata               
                int i = 1;
                foreach (MSProject.Task task in project.Tasks)
                {
                    if (task.ID == 1)
                        i = task.UniqueID;
                }

                string Condition = project.Tasks.UniqueID[i].GetField(Globals.ThisAddIn.Application.FieldNameToFieldConstant("Text28"));
                Condition = Condition.Replace(ConTk + "," + RefTk + "," + Finish + ",Delay,"+ days +";", "");
                project.Tasks.UniqueID[i].SetField(Globals.ThisAddIn.Application.FieldNameToFieldConstant("Text28"), Condition);
                    
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
