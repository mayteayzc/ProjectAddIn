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
            
            MSProject.Project project = Globals.ThisAddIn.Application.ActiveProject;
            int i=1;
            foreach(MSProject.Task task in project.Tasks)
            {
                if (task.ID == 1)
                {
                    i = task.UniqueID;
                    break;
                }
            }

            string Binary = project.Tasks.UniqueID[i].GetField(Globals.ThisAddIn.Application.FieldNameToFieldConstant("Text29"));
            string Unary = project.Tasks.UniqueID[i].GetField(Globals.ThisAddIn.Application.FieldNameToFieldConstant("Text30"));
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
            int id1, id2;
            string tk1,tk2, rela, d;

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

                id1=Convert.ToInt32(tk1);
                id2=Convert.ToInt32(tk2);
                
                foreach(MSProject.Task tsk in project.Tasks)
                {
                    if (tsk.UniqueID == id1)
                        tk1 = tsk.Name.ToString();
                    if (tsk.UniqueID == id2)
                        tk2 = tsk.Name.ToString();
                }
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
            int id;

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

                id = Convert.ToInt32(tk);
                foreach(MSProject.Task task in project.Tasks)
                {
                    if (task.UniqueID == id)
                    {
                        tk = task.Name.ToString();
                        break;
                    }
                        
                }

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
                this.btnUpdate.IsAccessible = false; //after delete, must update
                if (tabControl1.SelectedTab == tabControl1.TabPages["tabPageBinary"])
                {
                    //record down the information
                    string tk1 = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
                    string tk2 = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
                    string rela = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value.ToString();
                    string d = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value.ToString();
                    int id1 = 1;
                    int id2 = 1;
                    foreach(MSProject.Task task in project.Tasks)
                    {
                        if (task.Name.Equals(tk1))
                            id1 = task.UniqueID;
                        if (task.Name.Equals(tk2))
                            id2 = task.UniqueID;
                    }
                    //delete records at datagridview
                    dataGridView1.Rows.RemoveAt(this.dataGridView1.CurrentRow.Index);
                    
                    //remove from binarydata               
                    int i = 1;
                    foreach (MSProject.Task task in project.Tasks)
                    {
                        if (task.ID == 1)
                        {
                            i = task.UniqueID;
                            break;
                        } 
                    }

                    string Binary = project.Tasks.UniqueID[i].GetField(Globals.ThisAddIn.Application.FieldNameToFieldConstant("Text29"));
                    Binary = Binary.Replace(id1.ToString() + "," + id2.ToString() + "," + rela + "," + d + ";", "");
                    project.Tasks.UniqueID[i].SetField(Globals.ThisAddIn.Application.FieldNameToFieldConstant("Text29"), Binary);

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
                        note1 = note1.Replace(remove1 + ",", "");

                    else
                        note1 = note1.Replace(remove1, "");

                    if (note2.IndexOf(",") > 0)
                        note2=note2.Replace( remove2 + ",", "");
                    else
                        note2=note2.Replace(remove2, "");

                    project.Tasks.UniqueID[id1].Text27 = note1;
                    project.Tasks.UniqueID[id2].Text27 = note2;

                    //reset gantt chart style
                    if (note1 == "" || note1 == null)
                        ThisAddIn.ResetGanttBarFormat(project.Tasks.UniqueID[id1]);

                    if (note2 == "" || note2 == null)
                        ThisAddIn.ResetGanttBarFormat(project.Tasks.UniqueID[id2]);
                   
                    
                }

                if (tabControl1.SelectedTab == tabControl1.TabPages["tabPageUnary"])
                {
                    //RECORD
                    string tk = dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[0].Value.ToString();
                    string rela = dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[1].Value.ToString();
                    string date1 = dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[2].Value.ToString();
                    string date2 = dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[3].Value.ToString();
                    int id = 1;
                    foreach (MSProject.Task task in project.Tasks)
                    {
                        if (task.Name.Equals(tk))
                        {
                            id = task.UniqueID;
                            break;
                        }
                    }

                    //remove records from table
                    dataGridView2.Rows.RemoveAt(this.dataGridView2.CurrentRow.Index);
                    //remove from unary records
                    int i = 1;
                    foreach (MSProject.Task task in project.Tasks)
                    {
                        if (task.ID == 1)
                            i = task.UniqueID;
                    }
                    string Unary = project.Tasks.UniqueID[i].GetField(Globals.ThisAddIn.Application.FieldNameToFieldConstant("Text30"));
                    Unary = Unary.Replace(id + "," + rela + "," + date1 + "," + date2 +";", "");
                    project.Tasks.UniqueID[i].SetField(Globals.ThisAddIn.Application.FieldNameToFieldConstant("Text30"), Unary);

                    //remove from schedule
                    project.Tasks.UniqueID[id].Manual = false;
                }

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //binary
            if (tabControl1.SelectedTab == tabControl1.TabPages["tabPageBinary"])
            {
                int id1=0;
                int id2=0;
                string tk1, tk2, rela, d;
                int days;

                for (int i=0;i<dataGridView1.RowCount;i++)
                {
                    tk1 = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    tk2 = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    rela = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    d = dataGridView1.Rows[i].Cells[3].Value.ToString();
                    
                    foreach (MSProject.Task tk in project.Tasks)
                    {
                        if(tk.Name.Equals(tk1))
                            id1=tk.UniqueID;
                        if(tk.Name.Equals(tk2))
                            id2=tk.UniqueID;
                    }

                    if (id1 == 0 || id2 == 0)
                    {
                        MessageBox.Show("Task " + project.Tasks.UniqueID[id1].Name + " or " + project.Tasks.UniqueID[id2].Name + "Can not be found.");
                        return;
                    }

                    days = Convert.ToInt32(d);

                    foreach (MSProject.Task predecessor in project.Tasks.UniqueID[id1].PredecessorTasks)
                    {
                        if (predecessor.UniqueID == id2)
                            project.Tasks.UniqueID[id2].UnlinkSuccessors(project.Tasks.UniqueID[id1]);
                    }

                    foreach (MSProject.Task predecessor in project.Tasks.UniqueID[id2].PredecessorTasks)
                    {
                        if (predecessor.UniqueID == id1)
                            project.Tasks.UniqueID[id1].UnlinkSuccessors(project.Tasks.UniqueID[id2]);
                    }

                    ThisAddIn.BinaryTGA(id1, id2, rela, days);              
                }

            }
            if (tabControl1.SelectedTab == tabControl1.TabPages["tabPageUnary"])
            {
                int id = 0;
                string tk, rela, d1, d2;
                DateTime date1;
                DateTime date2=DateTime.Today;

                for (int i = 0; i < dataGridView2.RowCount; i++)
                {
                    tk = dataGridView2.Rows[i].Cells[0].Value.ToString();
                    rela = dataGridView2.Rows[i].Cells[1].Value.ToString();
                    d1 = dataGridView2.Rows[i].Cells[2].Value.ToString();
                    d2= dataGridView2.Rows[i].Cells[3].Value.ToString();

                    foreach (MSProject.Task task in project.Tasks)
                    {
                        if (task.Name.Equals(tk))
                            id= task.UniqueID;
                    }

                    if (id == 0)
                    {
                        MessageBox.Show("Task " + project.Tasks.UniqueID[id].Name + "Can not be found.");
                        return;
                    }

                    date1 = Convert.ToDateTime(d1);
                    if(d2!=null& d2!="")
                        date2 = Convert.ToDateTime(d2);
                    
                    ThisAddIn.UnaryUpdate(id,rela,date1,date2);
                }
            }

            this.Hide();
        }
    }
}