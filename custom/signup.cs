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
    public partial class signup : Form
    {
        public signup()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var cb = new SqlConnectionStringBuilder();
            cb.DataSource = "mynewserver7-10.database.windows.net";
            cb.UserID = "SeverAdmin";
            cb.Password = "523015302xX";
            cb.InitialCatalog = "mySampleDatabase";
            using (var conn = new SqlConnection(cb.ConnectionString))
            {
                conn.Open();
                string query = "INSERT INTO dbo.employeeInfo (LastName,FirstName,Category,Username,Password) VALUES ('" + textBox1.Text.Trim() + "', '" + textBox2.Text.Trim() + "','" + "custom" + "','" + textBox3.Text.Trim() + "','" + textBox4.Text.Trim() + "')";
                   // "VALUES (@LastName, @FirstName,@Category,@Username,@Password)";
                SqlCommand sqlCmd = new SqlCommand(query, conn);
               // sqlCmd.CommandType = CommandType.StoredProcedure;
               // sqlCmd.Parameters.AddWithValue("@FirstName", textBox1.Text.Trim());
               // sqlCmd.Parameters.AddWithValue("@LastName", textBox2.Text.Trim());
               // sqlCmd.Parameters.AddWithValue("@Category", "custom");
               // sqlCmd.Parameters.AddWithValue("@Username", textBox3.Text.Trim());
               // sqlCmd.Parameters.AddWithValue("@Password", textBox4.Text.Trim());
                sqlCmd.ExecuteNonQuery();
            }
            this.Close();
        }
    }
}
