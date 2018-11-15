using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace airline_system
{
  
    public partial class entrance : Form
    {
        public entrance()
        {
            InitializeComponent();
        }
        
        private void custom_Click(object sender, EventArgs e)
        {
            custom custom = new custom("custom");
            //this.Dispose(false);
            this.Hide();
            custom.ShowDialog(this);
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonadmin_Click(object sender, EventArgs e)
        {
            admin admin = new admin("admin");
            this.Hide();
            admin.ShowDialog(this);
            this.Close();
        }
    }
    

}
