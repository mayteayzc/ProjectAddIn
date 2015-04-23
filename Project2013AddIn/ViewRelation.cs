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

namespace Project2013AddIn
{
    public partial class ViewRelation : Form
    {
        SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;
             AttachDbFilename=E:\MS\FYP\Project2013AddIn\Project2013AddIn\ProjectAddinDB.mdf;Integrated Security=True");
        SqlCommand cmd1 = new SqlCommand();
        SqlCommand cmd2 = new SqlCommand();
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();
        SqlDataAdapter adp1= new SqlDataAdapter();
        SqlDataAdapter adp2 = new SqlDataAdapter();

        
        public ViewRelation()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            cn.Close();
            //update
            //check MSproject relationships for predecessor??? no need since only PDM++ relationships modefied.
            //then check PDM++ relation
            this.Hide();
        }

        private void ViewRelation_Load(object sender, EventArgs e)
        {

            cn.Open();
            cmd1.Connection = cn;
            cmd1.CommandText = "Select * from RelationTable";
            cmd2.Connection = cn;
            cmd2.CommandText = "Select * from ConstraintTable";

            adp1.SelectCommand = cmd1;
            adp1.Fill(dt1);
            dataGridView1.DataSource = dt1;

            
            adp2.SelectCommand = cmd2;
            adp2.Fill(dt2);
            dataGridView2.DataSource = dt2;
                       
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Delete current selection?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (ViewTab.SelectedTab==ViewTab.TabPages["tabPageRelationship"])
                {
                    cmd1.CommandText = "Delete from RelationTable where Task1='" + dataGridView1.CurrentRow.Cells[1].Value + "' AND Task2='" + dataGridView1.CurrentRow.Cells[2].Value + "' AND Relationships='" + dataGridView1.CurrentRow.Cells[3].Value + "'";
                    cmd1.ExecuteNonQuery();
                    dataGridView1.Rows.RemoveAt(this.dataGridView1.CurrentRow.Index);
                }

                if(ViewTab.SelectedTab==ViewTab.TabPages["tabPageConstraint"])
                {
                    cmd2.CommandText = "Delete from ConstraintTable where Task='" + dataGridView2.CurrentRow.Cells[1].Value + "' AND Constraints='" + dataGridView2.CurrentRow.Cells[3].Value + "' AND Date1='" + dataGridView2.CurrentRow.Cells[4].Value + "'";
                    cmd2.ExecuteNonQuery();
                    dataGridView2.Rows.RemoveAt(this.dataGridView2.CurrentRow.Index);
                }
            }
           
        }
        
    } 

}


