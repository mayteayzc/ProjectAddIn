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
            this.Hide();
        }

        private void ViewRelation_Load(object sender, EventArgs e)
        {
            cn.Open();
            cmd.Connection=cn;
            cmd.CommandText = "Select * from RelationTable";

            DataTable tb = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(tb);

            dataGridView1.DataSource = tb;

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            cmd.Connection = cn;
            
            if(dataGridView1.SelectedRows.Count>0)
            {
            int selectedindex = dataGridView1.SelectedRows[0].Index;
            int record=int.Parse(dataGridView1[0,selectedindex].Value.ToString());
            
            cmd.CommandText = "Delete from RelationTable where Record=@record";
            //SqlParameter RowParameter=new SqlParameter();
            //RowParameter.ParameterName="@record";
            //RowParameter.Value = record;

            cmd.Parameters.AddWithValue("@record", record);
            cmd.ExecuteNonQuery();
            dataGridView1.Update();

            } 
        }

     

    }
}
