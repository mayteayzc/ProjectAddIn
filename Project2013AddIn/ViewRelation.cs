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
            //update
            //check MSproject relationships for predecessor??? no need since only PDM++ relationships modefied.
            //then check PDM++ relation
            this.Hide();
        }

        private void ViewRelation_Load(object sender, EventArgs e)
        {

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

            dataGridView1.Rows.RemoveAt(this.dataGridView1.CurrentRow.Index);
        }
        
    } 

}


