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
    public partial class adminid : Form
    {
        public adminid()
        {
            InitializeComponent();
        }
        private void AddControlsToPanel(Control c)
        {
            c.Dock = DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(c);

        }
        private void button1_Click(object sender, EventArgs e)
        {
            usermanagement userf = new usermanagement();
            AddControlsToPanel(userf);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Flightlist flistf = new Flightlist();
            AddControlsToPanel(flistf);
        }
    }
}
