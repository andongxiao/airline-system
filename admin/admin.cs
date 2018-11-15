using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace airline_system
{
    public partial class admin : Form
    {
        public admin()
        {
            InitializeComponent();
        }
        public admin(string text)
        {
            InitializeComponent();
            adminlabel.Text = text;
            // this.Owner.Hide();

        }
        private void admin_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var cb = new SqlConnectionStringBuilder();
                cb.DataSource = "mynewserver7-10.database.windows.net";
                cb.UserID = "SeverAdmin";
                cb.Password = "523015302xX";
                cb.InitialCatalog = "mySampleDatabase";
                var conn = new SqlConnection(cb.ConnectionString);
                SqlCommand SelectCommand = new SqlCommand("select * from dbo.employeeInfo WHERE Username='" + this.textBox1.Text + "' and Password='" + this.textBox2.Text + "' and Category= '" + "Administrator" + "' ; ", conn);
                SqlDataReader myReader;
                conn.Open();
                myReader = SelectCommand.ExecuteReader();
                int count = 0;
                // string id = "0";

                while (myReader.Read())
                {
                    count = count + 1;
                    app.strid = myReader[0].ToString();

                }
                if (count == 1)
                {
                    // string id = myReader[0].ToString();
                    adminid adminid = new adminid();
                    this.Hide();
                    adminid.ShowDialog(this);
                    this.Close();

                }
                else MessageBox.Show("Incorrect username/password");
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
