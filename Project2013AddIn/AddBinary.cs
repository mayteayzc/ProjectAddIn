using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MSProject = Microsoft.Office.Interop.MSProject;
using HostApplication = Microsoft.Office.Interop.MSProject.Application;


namespace Project2013AddIn
{
    public partial class AddBinary : Form
    {
        MSProject.Project project = Globals.ThisAddIn.Application.ActiveProject;

        public AddBinary()
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

        private void AddNewRelation_Load(object sender, EventArgs e)
        {
            
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.ComboBoxAct1.SelectedItem == null || this.ComboBoxAct2.SelectedItem == null || ComboBoxRela.SelectedItem == null)
                MessageBox.Show("Please fill in all feilds.");

            else if (this.ComboBoxAct1.SelectedIndex == this.ComboBoxAct2.SelectedIndex)
                MessageBox.Show("Please select two different activities.");

            else if(this.ComboBoxRela.SelectedItem.ToString()=="Overlap" & (int) NumericDays.Value==0)
                MessageBox.Show("please select a positive number for overlap days");
            
            //before add relationship must check if there are exisitng pdm++ relationship which is contradicting the new relation.
            //also need to check MS project relationsips. How??

            else
            {
                string tk1 = this.ComboBoxAct1.SelectedItem.ToString();
                string tk2 = this.ComboBoxAct2.SelectedItem.ToString();
                string relation = this.ComboBoxRela.SelectedItem.ToString();
                int days = (int) this.NumericDays.Value;
                int id1 = 0, id2 = 0;
                bool found1 = false, found2 = false;

                //found corresponding tasks
                foreach (MSProject.Task task in project.Tasks)
                {
                    if (task.Name.Equals(tk1))
                    {
                        id1 = task.UniqueID;
                        found1 = true;
                    }

                    if (task.Name.Equals(tk2))
                    {
                        id2 = task.UniqueID;
                        found2 = true;
                    }
                }

                if (found1 == false || found2 == false)
                {
                    MessageBox.Show("Error: Tasks can not be found.");
                }
                bool success=ThisAddIn.BinaryRelation(id1, id2, relation, days);

                if (success)
                {
                    Pen pen = new Pen(Color.FromArgb(255, 0, 0, 255), 8);
                    pen.StartCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
                    pen.EndCap = System.Drawing.Drawing2D.LineCap.RoundAnchor;
                    PaintEventArgs e;
                    e.Graphics.DrawLine(pen, 20, 175, 300, 175);
                    this.Hide();
                }
                    
             }
        }

        private void btnHelp_Click(object sender, EventArgs e)
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
