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
            MSProject.Project project = Globals.ThisAddIn.Application.ActiveProject;
            MSProject.PjCustomField BinaryField = MSProject.PjCustomField.pjCustomTaskText29;
            MSProject.PjCustomField UnaryField = MSProject.PjCustomField.pjCustomTaskText30;

            if (project.Application.CustomFieldGetName(BinaryField) != "Binary Relationship")
                project.Application.CustomFieldRename(BinaryField, "Binary Relationship", Type.Missing);

            if (project.Application.CustomFieldGetName(UnaryField) != "Unary Relationship")
                project.Application.CustomFieldRename(UnaryField, "Unary Relationship", Type.Missing);

            //check if first task has been deleted, if did, record the first task where the info is stored.
            int i=1;
            foreach(MSProject.Task task in project.Tasks)
            {
                if (task.ID == 1)
                    i = task.UniqueID;
            }

            string Binary = project.Tasks.UniqueID[i].GetField(Globals.ThisAddIn.Application.FieldNameToFieldConstant("Binary Relationship"));
            string Unary = project.Tasks.UniqueID[i].GetField(Globals.ThisAddIn.Application.FieldNameToFieldConstant("Unary Relationship"));
            string BinaryData;
            string UnaryData;

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

            dataGridView1.DataSource = dt1;
            dataGridView2.DataSource = dt2;

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Delete current selection?","Confirmed",MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                this.btnOK.IsAccessible = false; //after delete, must update
                if (tabControl1.SelectedTab == tabControl1.TabPages["tabPageBinary"])
                {
                    //record down the information
                    string tk1 = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
                    string tk2 = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
                    string rela =dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value.ToString();
                    int id1 = 1;
                    int id2 = 1;
                    foreach(MSProject.Task task in project.Tasks)
                    {
                        if (task.Name.Equals(tk1))
                            id1 = task.UniqueID;
                        if (task.Name.Equals(tk2))
                            id2 = task.UniqueID;
                    }
                    //remove links
                    bool id1_before_id2 = true;
                    //to remove the existing links between 1 and 2, check which one is the predecessor first.
                    foreach (MSProject.Task predecessor in project.Tasks.UniqueID[id1].PredecessorTasks)
                    {
                        if (predecessor.UniqueID == id2)
                        {
                            id1_before_id2 = false;
                            project.Tasks.UniqueID[id2].UnlinkSuccessors(project.Tasks.UniqueID[id1]);
                        }

                    }

                    if (id1_before_id2)
                        project.Tasks.UniqueID[id1].UnlinkSuccessors(project.Tasks.UniqueID[id2]);
                    
                    //delete related records in text27
                    string note1 = project.Tasks.UniqueID[id1].Text27;
                    string note2 = project.Tasks.UniqueID[id2].Text27;
                    string relation = "";
                    string remove1, remove2;

                    switch (rela)
                    {
                        case "Contain":
                            relation="CN";
                            break;

                        case "Disjoint":
                            relation="D";
                            break;

                        case "Meet":
                            relation="M";
                            break;

                        case "Overlap":
                            relation="O";
                            break;
                    }

                    remove1=relation+project.Tasks.UniqueID[id2].ID.ToString();
                    remove2=relation+project.Tasks.UniqueID[id1].ID.ToString();

                    if (note1.IndexOf(",") > 0)
                        note1 = note1.Replace("," + remove1, "");

                    else
                        note1 = note1.Replace(remove1, "");

                    if (note2.IndexOf(",") > 0)
                        note2=note2.Replace("," + remove2, "");
                    else
                        note2=note2.Replace(remove2, "");

                    project.Tasks.UniqueID[id1].Text27 = note1;
                    project.Tasks.UniqueID[id2].Text27 = note2;

                    //reset gantt chart style
                    if (note1 == "" || note1 == null)
                        ThisAddIn.ResetGanttBarFormat(project.Tasks.UniqueID[id1]);

                    if (note2 == "" || note2 == null)
                        ThisAddIn.ResetGanttBarFormat(project.Tasks.UniqueID[id2]);
                   
                    //delete records
                    dataGridView1.Rows.RemoveAt(this.dataGridView1.CurrentRow.Index);
                }

                if (tabControl1.SelectedTab == tabControl1.TabPages["tabPageUnary"])
                {
                    //remove records
                    dataGridView2.Rows.RemoveAt(this.dataGridView2.CurrentRow.Index);
                    //remove unary constraints
                    string tk = dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[0].Value.ToString();
                    int id = 1;
                    foreach (MSProject.Task task in project.Tasks)
                    {
                        if (task.Name.Equals(tk))
                            id = task.UniqueID;
                    }
                    //project.Tasks.UniqueID[id].ConstraintType=MSProject???????
                }

            }
        }

        public void btnUpdate_Click(object sender, EventArgs e)
        {
            //empty the custom field.
            MSProject.PjCustomField BinaryField = MSProject.PjCustomField.pjCustomTaskText29;
            MSProject.PjCustomField UnaryField = MSProject.PjCustomField.pjCustomTaskText30;

            if (project.Application.CustomFieldGetName(BinaryField) != "Binary Relationship")
                project.Application.CustomFieldRename(BinaryField, "Binary Relationship", Type.Missing);
            if (project.Application.CustomFieldGetName(UnaryField) != "Unary Relationship")
                project.Application.CustomFieldRename(UnaryField, "Unary Relationship", Type.Missing);

            int i=1;
            foreach (MSProject.Task task in project.Tasks)
            {
                if (task.ID == 1)
                    i = task.UniqueID;
            }

            project.Tasks.UniqueID[i].SetField(Globals.ThisAddIn.Application.FieldNameToFieldConstant("Binary Relationship"), "");
            project.Tasks.UniqueID[i].SetField(Globals.ThisAddIn.Application.FieldNameToFieldConstant("Unary Relationship"), "");

            //just to update the text field.
            //first assign unary can avoid shifting forward wrongly, since unary may shift forward but binary will always shift backwards. so does multiple
            int j = 0;
            int count = dataGridView2.Rows.Count;
            string Unary="";
            while (j<count)
            {
                DataGridViewRow row2 = dataGridView2.Rows[j];
                string date1 = row2.Cells[2].Value.ToString();
                string date2 = row2.Cells[3].Value.ToString();
               
                if(row2.Cells[1].Value.ToString()=="Can Not Occur")
                    Unary=Unary+row2.Cells[0].Value.ToString()+","+row2.Cells[1].Value.ToString()+","+date1+","+date2+";";
                else
                    Unary=Unary+row2.Cells[0].Value.ToString()+","+row2.Cells[1].Value.ToString()+","+date1+","+";";
                j++;
            }

            //for binary, need to update the records in text field
            int k = 0;
            count = dataGridView1.Rows.Count;
            string Binary="";
            while (k < count)
            {
                DataGridViewRow row1 = dataGridView1.Rows[k];
                string days = row1.Cells[3].Value.ToString();
                string tk1, tk2,rela;
                tk1 = row1.Cells[0].Value.ToString();
                tk2 = row1.Cells[1].Value.ToString();
                rela = row1.Cells[2].Value.ToString();
   
                Binary=Binary+tk1+","+tk2+","+rela+","+days+";";
                k++;
            }

            project.Tasks.UniqueID[i].SetField(Globals.ThisAddIn.Application.FieldNameToFieldConstant("Binary Relationship"), Binary);
            project.Tasks.UniqueID[i].SetField(Globals.ThisAddIn.Application.FieldNameToFieldConstant("Unary Relationship"), Unary);     
            this.Hide();  
    }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}

       
