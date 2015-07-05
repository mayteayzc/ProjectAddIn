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
    public partial class ViewRelationship : Form
    {
        MSProject.Project project = Globals.ThisAddIn.Application.ActiveProject;
        public ViewRelationship()
        {
            InitializeComponent();
            
            //if never renamed before then rename first.
            MSProject.PjCustomField MultipleField = MSProject.PjCustomField.pjCustomTaskText28;
            MSProject.PjCustomField BinaryField = MSProject.PjCustomField.pjCustomTaskText29;
            MSProject.PjCustomField UnaryField = MSProject.PjCustomField.pjCustomTaskText30;

            if (project.Application.CustomFieldGetName(MultipleField) != "Multiple Relationship")
                project.Application.CustomFieldRename(MultipleField, "Multiple Relationship", Type.Missing);

            if (project.Application.CustomFieldGetName(BinaryField) != "Binary Relationship")
                project.Application.CustomFieldRename(BinaryField, "Binary Relationship", Type.Missing);
                
            if (project.Application.CustomFieldGetName(UnaryField) != "Unary Relationship")
                project.Application.CustomFieldRename(UnaryField, "Unary Relationship", Type.Missing);

            //check if first task has been deleted
            int i=1;
            while(project.Tasks.UniqueID[i]==null)
            {
                i++;
            }

            string Multiple = project.Tasks.UniqueID[i].GetField(Globals.ThisAddIn.Application.FieldNameToFieldConstant("Multiple Relationship"));
            string Binary = project.Tasks.UniqueID[i].GetField(Globals.ThisAddIn.Application.FieldNameToFieldConstant("Binary Relationship"));
            string Unary = project.Tasks.UniqueID[i].GetField(Globals.ThisAddIn.Application.FieldNameToFieldConstant("Unary Relationship"));
            string MultipleData;
            string BinaryData;
            string UnaryData;
            DataTable dt3 = new DataTable();
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            dt1.Columns.Add("Task1", typeof(string));
            dt1.Columns.Add("Task2", typeof(string));
            dt1.Columns.Add("Binary Relationship", typeof(string));
            dt1.Columns.Add("Overlap Days", typeof(string));
            dt2.Columns.Add("Task", typeof(string));
            dt2.Columns.Add("Unary Relationship", typeof(string));
            dt2.Columns.Add("Date1", typeof(string));
            dt2.Columns.Add("Date2", typeof(string));
            dt3.Columns.Add("Multiple Relationship", typeof(string));
            dt3.Columns.Add("Tasks", typeof(string));

            //process binary relationships
            int l1 = Binary.Length;
            int l2;
            int p1 = Binary.IndexOf(";");
            int p2;
            string tk1, tk2, rela, d;

            while (p1 > 0)
            {
                BinaryData = Binary.Substring(0, p1);
                l2 = BinaryData.Length;
                p2 = BinaryData.IndexOf(",");
                tk1 = BinaryData.Substring(0, p2);

                BinaryData = BinaryData.Substring(p2+1 , l2 - p2-1);
                p2 = BinaryData.IndexOf(",");
                tk2 = BinaryData.Substring(0, p2);
                l2 = BinaryData.Length;

                BinaryData = BinaryData.Substring(p2+1 , l2 - p2-1);
                p2 = BinaryData.IndexOf(",");
                rela = BinaryData.Substring(0, p2);
                l2 = BinaryData.Length;

                BinaryData = BinaryData.Substring(p2 +1, l2 - p2-1);
                d = BinaryData;

                dt1.Rows.Add(tk1, tk2, rela, d);

                Binary = Binary.Substring(p1+1 , l1 - p1-1);
                p1 = Binary.IndexOf(";");
                l1 = Binary.Length;
            }

            //process Unary Relationship

            int l3 = Unary.Length;
            int l4;
            int p3 = Unary.IndexOf(";");
            int p4;
            string tk, re, d1, d2;

            while (p3 > 0)
            {
                UnaryData = Unary.Substring(0, p3);
                l4 = UnaryData.Length;
                p4 = UnaryData.IndexOf(",");
                tk = UnaryData.Substring(0, p4);

                UnaryData = UnaryData.Substring(p4 + 1 , l4 - p4 - 1);
                p4 = UnaryData.IndexOf(",");
                re = UnaryData.Substring(0, p4);
                l4 = UnaryData.Length;

                UnaryData = UnaryData.Substring(p4 + 1, l4 - p4 -1);
                p4 = UnaryData.IndexOf(",");
                d1 = UnaryData.Substring(0, p4);
                l4 = UnaryData.Length;

                UnaryData = UnaryData.Substring(p4 +1, l4 - p4 -1);
                d2 = UnaryData;

                dt2.Rows.Add(tk, re, d1, d2);

                Unary = Unary.Substring(p3 + 1, l3 - p3 -1);
                p3 = Unary.IndexOf(";");
                l3 = Unary.Length;
            }

            //process Multiple Relationship
            int p5 = Multiple.IndexOf(";");
            int p6;
            string relation, tasks;

            while (p5 > 0)
            {
                MultipleData = Multiple.Substring(0, p5);
                p6 = MultipleData.IndexOf(",");
                relation = MultipleData.Substring(0, p6);

                MultipleData = MultipleData.Substring(p6 + 1);
                tasks = MultipleData;
 
                dt3.Rows.Add(relation,tasks);

                Multiple = Multiple.Substring(p5 + 1);
                p5 = Multiple.IndexOf(";");

            }
            dataGridView3.DataSource = dt3;
            dataGridView1.DataSource = dt1;
            dataGridView2.DataSource = dt2;

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Delete current selection?","Confirmed",MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                if (tabControl1.SelectedTab == tabControl1.TabPages["tabPageBinary"])
                    dataGridView1.Rows.RemoveAt(this.dataGridView1.CurrentRow.Index);
                if (tabControl1.SelectedTab == tabControl1.TabPages["tabPageUnary"])
                    dataGridView2.Rows.RemoveAt(this.dataGridView2.CurrentRow.Index);
                if (tabControl1.SelectedTab == tabControl1.TabPages["tabPageMultiple"])
                    dataGridView3.Rows.RemoveAt(this.dataGridView3.CurrentRow.Index);

                //delete corresponding links.
                //
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {

            //set all task to auto schedule first.
            foreach (MSProject.Task task in project.Tasks)
                task.Manual = false;

            //then set to manual again for pdm++ scheduling
            foreach (MSProject.Task task in project.Tasks)
                task.Manual = true;

            //empty the custom field.
            MSProject.PjCustomField MultipleField = MSProject.PjCustomField.pjCustomTaskText28;
            MSProject.PjCustomField BinaryField = MSProject.PjCustomField.pjCustomTaskText29;
            MSProject.PjCustomField UnaryField = MSProject.PjCustomField.pjCustomTaskText30;

            if (project.Application.CustomFieldGetName(MultipleField) != "Multiple Relationship")
                project.Application.CustomFieldRename(MultipleField, "Multiple Relationship", Type.Missing);
            if (project.Application.CustomFieldGetName(BinaryField) != "Binary Relationship")
                project.Application.CustomFieldRename(BinaryField, "Binary Relationship", Type.Missing);
            if (project.Application.CustomFieldGetName(UnaryField) != "Unary Relationship")
                project.Application.CustomFieldRename(UnaryField, "Unary Relationship", Type.Missing);
            project.Tasks.UniqueID[1].SetField(Globals.ThisAddIn.Application.FieldNameToFieldConstant("Multiple Relationship"),"");
            project.Tasks.UniqueID[1].SetField(Globals.ThisAddIn.Application.FieldNameToFieldConstant("Binary Relationship"), "");
            project.Tasks.UniqueID[1].SetField(Globals.ThisAddIn.Application.FieldNameToFieldConstant("Unary Relationship"), "");

            //then reassign the relationships and record them.
            //first assign unary can avoid shifting forward wrongly, since unary may shift forward but binary will always shift backwards. so does multiple
            int j = 0;
            while (dataGridView2.Rows[j].Cells[0].Value != null)
            {
                DataGridViewRow row2 = dataGridView2.Rows[j];
                string date1 = row2.Cells[2].Value.ToString();
                string date2 = row2.Cells[3].Value.ToString();
                DateTime d1 = Convert.ToDateTime(date1);
                DateTime d2;
                if (date2 == null || date2 == "")
                    d2 = DateTime.Today;
                else
                    d2 = Convert.ToDateTime(date2);

                ThisAddIn.UnaryRelation(row2.Cells[0].Value.ToString(), row2.Cells[1].Value.ToString(), d1, d2);

                j++;
            }

            int i = 0;
            while(dataGridView1.Rows[i].Cells[0].Value!=null)
            {
               DataGridViewRow row1=dataGridView1.Rows[i];
               string days = row1.Cells[3].Value.ToString();
               int d = Convert.ToInt32(days);
               ThisAddIn.BinaryRelation(row1.Cells[0].Value.ToString(), row1.Cells[1].Value.ToString(), row1.Cells[2].Value.ToString(), d);

               i++;
            }

            int k = 0;
            int count = dataGridView3.Rows.Count;
            while (k<count)
            {
                DataGridViewRow row3 = dataGridView3.Rows[k];
                string alltasks = row3.Cells[1].Value.ToString();
                int l = alltasks.Length;
                int p = alltasks.IndexOf(",");
                string[] tasks=new string[5];
                int m=0;

                while(p>0)
                {
                    tasks[m]=alltasks.Substring(0,p);
                    alltasks=alltasks.Substring(p+1);
                    p=alltasks.IndexOf(",");
                    m++;
                }

                l=alltasks.Length;
                tasks[m]=alltasks.Substring(0,l);

                int taskcount=0;
                for(m=0;m<5;m++)
                {
                    if(tasks[m]!=null && tasks[m]!="")
                      taskcount++;
                }

                for (m = taskcount; m < 5; m++)
                {
                    tasks[m] = "NA";
                }
                ThisAddIn.MultipleRelation(row3.Cells[0].Value.ToString(), tasks[0],tasks[1],tasks[2],tasks[3],tasks[4]);

                k++;
            }
            this.Hide();  
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}

       
