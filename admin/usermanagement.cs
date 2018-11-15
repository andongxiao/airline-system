using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace airline_system
{
    public partial class usermanagement : UserControl
    {
        public usermanagement()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
            button3.Enabled = false;
            button2.Enabled = false;

        }

        private DataTable GetUserList()
        {
            DataTable dtUsers = new DataTable();
            var cb = new SqlConnectionStringBuilder();
            cb.DataSource = "mynewserver7-10.database.windows.net";
            cb.UserID = "SeverAdmin";
            cb.Password = "523015302xX";
            cb.InitialCatalog = "mySampleDatabase";
            var conn = new SqlConnection(cb.ConnectionString);
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.employeeInfo", conn))
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                dtUsers.Load(reader);
                conn.Close();
            }

            return dtUsers;
        }

        private void usermanagement_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = GetUserList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var cb = new SqlConnectionStringBuilder();
            cb.DataSource = "mynewserver7-10.database.windows.net";
            cb.UserID = "SeverAdmin";
            cb.Password = "523015302xX";
            cb.InitialCatalog = "mySampleDatabase";
            var conn = new SqlConnection(cb.ConnectionString);
            SqlCommand cmd = new SqlCommand("INSERT INTO dbo.employeeInfo (LastName,FirstName,Category,Username,Password) VALUES ('" + textBox4.Text + "','" + textBox2.Text + "','" + comboBox1.Text + "','" + textBox3.Text + "','" + textBox6.Text + "')",conn);
            conn.Open();
            cmd.ExecuteNonQuery();           
            dataGridView1.DataSource = GetUserList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string userid = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            var cb = new SqlConnectionStringBuilder();
            cb.DataSource = "mynewserver7-10.database.windows.net";
            cb.UserID = "SeverAdmin";
            cb.Password = "523015302xX";
            cb.InitialCatalog = "mySampleDatabase";
            var conn = new SqlConnection(cb.ConnectionString);
           // SqlCommand SelectCommand = new SqlCommand("select * from dbo.employeeInfo WHERE Customid='" + userid + "'", conn);
            SqlCommand cmd = new SqlCommand("UPDATE dbo.employeeInfo set LastName='"
                                                        + textBox4.Text + "',FirstName = '"
                                                        + textBox2.Text + "', Category='"
                                                        + comboBox1.Text + "', Username='"
                                                        + textBox3.Text + "', Password ='"
                                                        + textBox6.Text + "' WHERE Id='" + userid + "'", conn);
            SqlDataReader myReader;
            conn.Open();
            myReader = cmd.ExecuteReader();
            conn.Close();
            dataGridView1.DataSource = GetUserList();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            button3.Enabled = true;
            button2.Enabled = true;
            string userid = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string lastname = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            string firstname = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            string category = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            string username = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            string password = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox1.Text = userid;
            textBox4.Text = lastname;
            textBox2.Text = firstname;
            comboBox1.Text = category;
            textBox3.Text = username;
            textBox6.Text = password;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string userid = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            var cb = new SqlConnectionStringBuilder();
            cb.DataSource = "mynewserver7-10.database.windows.net";
            cb.UserID = "SeverAdmin";
            cb.Password = "523015302xX";
            cb.InitialCatalog = "mySampleDatabase";
            var conn = new SqlConnection(cb.ConnectionString);
            SqlCommand cmd = new SqlCommand("DELETE FROM dbo.employeeInfo WHERE Id='" + userid + "'", conn);
            SqlDataReader myReader;
            conn.Open();
            myReader = cmd.ExecuteReader();
            conn.Close();
            dataGridView1.DataSource = GetUserList();
        }
    }
}
