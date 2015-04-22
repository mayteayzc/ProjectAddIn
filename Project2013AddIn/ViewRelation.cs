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
        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();
        SqlDataAdapter adp = new SqlDataAdapter();

        
        public ViewRelation()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            cn.Close();
            this.Hide();
        }

        private void ViewRelation_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'projectAddinDBDataSet.RelationTable' table. You can move, or remove it, as needed.
            this.relationTableTableAdapter.Fill(this.projectAddinDBDataSet.RelationTable);
            cn.Open();
            cmd.Connection = cn;
            cmd.CommandText = "Select * from RelationTable";

            adp.SelectCommand = cmd;
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
            
        }



        private void btnDelete_Click(object sender, EventArgs e)
        {
            cmd.CommandText = "Delete from RelationTable where Task1='"+dataGridView1.CurrentRow.Cells[1].Value+"' AND Task2='"+dataGridView1.CurrentRow.Cells[2].Value+"' AND Relationship='"+dataGridView1.CurrentRow.Cells[3].Value+"'";
            cmd.ExecuteNonQuery();

            adp.Update(dt);
            dataGridView1.DataSource = dt;
           
            //if (MessageBox.Show("Delete selected relationships?", "Confirmed", MessageBoxButtons.YesNo) == DialogResult.Yes) 
            //{
                //foreach (DataGridViewRow row in dataGridView1.Rows)
                //{
                    //object cell = row.Cells["Delete"].Value;
                    //if ((string)cell== "yes")
                    //{
                        //projectAddinDBDataSet.RelationTable.Rows[row.Index].Delete();
                       // relationTableTableAdapter.Update(projectAddinDBDataSet.RelationTable);
                   // }
                //}
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            cmd.CommandText="Update RelationTable Set Task1=@tk1 AND Task2=@tk2 AND Relationship=@rela AND OverlapDays=@ovlp Where Task1=@task1 AND Task2=@task2 AND Relationship=@relationship";
            cmd.Parameters.AddWithValue("@tk1", Task1Text.Text);
            cmd.Parameters.AddWithValue("@tk2", Task2Text.Text);
            cmd.Parameters.AddWithValue("@rela", RelationshipText.Text);
            cmd.Parameters.AddWithValue("@ovlp", OverlapDaysText.Text);
            cmd.Parameters.AddWithValue("@task1", dataGridView1.CurrentRow.Cells[1].Value);
            cmd.Parameters.AddWithValue("@task2", dataGridView1.CurrentRow.Cells[2].Value);
            cmd.Parameters.AddWithValue("@relationship", dataGridView1.CurrentRow.Cells[3].Value);
            cmd.ExecuteNonQuery();

            adp.Update(dt);
            dataGridView1.DataSource = dt;
            //dataGridView1.CurrentRow.Cells[1].Value=Task1Text.Text;
            //dataGridView1.CurrentRow.Cells[2].Value=Task2Text.Text;
            //dataGridView1.CurrentRow.Cells[3].Value=RelationshipText.Text;
            //dataGridView1.CurrentRow.Cells[4].Value = OverlapDaysText.Text;
        
        }
        
    } 

}


