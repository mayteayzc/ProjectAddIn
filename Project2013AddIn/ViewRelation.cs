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
        
        public ViewRelation()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ViewRelation_Load(object sender, EventArgs e)
        {
            cn.Open();
            cmd.Connection = cn;
            cmd.CommandText = "Select * from RelationTable";
            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter(cmd);

            adp.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            



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
    } 
}


