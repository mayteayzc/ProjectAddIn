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
    public partial class AddConstraint : Form
    {
        MSProject.Project project = Globals.ThisAddIn.Application.ActiveProject;
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

    }
}
