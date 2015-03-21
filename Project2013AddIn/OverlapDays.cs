using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project2013AddIn
{
    
    public partial class OverlapDays : Form
    {
        
        public OverlapDays()
        {
            InitializeComponent();
        }

        public void btnOK_Click(object sender, EventArgs e)
        {
            if (this.overlap.Value < 0 || this.overlap.Value == 0)
                MessageBox.Show("Please choose a positive integer.");
            else
            {
               AddNewRelation.D = (int) this.overlap.Value;
               this.Hide();
            }        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.overlap.Value = 0;
            this.Hide();
        }

        
    }
}
