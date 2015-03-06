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
        public AddNewRelation()
        {
            InitializeComponent();
            MSProject.Project project = Globals.ThisAddIn.Application.ActiveProject;
            int count = project.Tasks.Count;
            int index = 0;
            string[] datasource = new string[count];
            foreach(MSProject.Task task in project.Tasks) {
                if(task == null) {
                    continue;
                }
                String name = task.Name;
                datasource[index++] = name;
            }
            this.ComboBoxAct1.DataSource = datasource;
            this.ComboBoxAct2.DataSource = datasource;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if(this.ComboBoxAct1.SelectedIndex == this.ComboBoxAct2.SelectedIndex) {
                MessageBox.Show("Please re-enter");
            }
            this.Hide();
        }

        private void AddNewRelation_Load(object sender, EventArgs e)
        {

        }

     
        
    }
}
