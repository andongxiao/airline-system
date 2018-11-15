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
    public partial class order : Form
    {
        string[] price = new string[2];
        public order()
        {
            InitializeComponent();
            comboBox1.Items.Add("First Price");
            comboBox1.Items.Add("Economy Price");
            button1.Enabled = false;
            var cb = new SqlConnectionStringBuilder();
            cb.DataSource = "mynewserver7-10.database.windows.net";
            cb.UserID = "SeverAdmin";
            cb.Password = "523015302xX";
            cb.InitialCatalog = "mySampleDatabase";
            var conn = new SqlConnection(cb.ConnectionString);
            SqlCommand SelectCommand = new SqlCommand("select * from dbo.FlightInfo WHERE Id='" + app.fliid + "'  ;", conn);
            SqlDataReader myReader;
            conn.Open();
            myReader = SelectCommand.ExecuteReader();
            
            while (myReader.Read())
            {

                textBox1.Text = myReader[0].ToString();
                textBox2.Text = myReader[1].ToString();
                textBox3.Text = myReader[2].ToString();
                textBox6.Text = myReader[3].ToString();
                textBox5.Text = myReader[4].ToString();
                textBox4.Text = myReader[5].ToString();
                textBox12.Text = myReader[6].ToString();
                textBox11.Text = myReader[7].ToString();
                price[0] = myReader["FirstPrice"].ToString();
                price[1] = myReader["EcoPrice"].ToString();
            }
            conn.Close();

            var conn1 = new SqlConnection(cb.ConnectionString);
            SqlCommand SelectCommand1 = new SqlCommand("select * from personinfo WHERE Id='" + app.strid + "'  ;", conn1);
            SqlDataReader myReader1;
            conn1.Open();
            myReader1 = SelectCommand1.ExecuteReader();
            while (myReader1.Read())
            {

                textBox18.Text = myReader1[1].ToString();
                textBox7.Text = myReader1[2].ToString();
                textBox17.Text = myReader1[3].ToString();
                textBox16.Text = myReader1[4].ToString();
                textBox15.Text = myReader1[5].ToString();
                textBox13.Text = myReader1[6].ToString();
                textBox9.Text = myReader1[7].ToString();
                textBox8.Text = myReader1[8].ToString();
                textBox14.Text = myReader1[9].ToString();
            }
            conn1.Close();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
            if (comboBox1.Text == "First Price") textBox10.Text = price[0];
            if (comboBox1.Text == "Economy Price") textBox10.Text = price[1];
        }

        private void button2_Click(object sender, EventArgs e)
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
                string query = "INSERT INTO dbo.Flightorder (Customid,Flightid,FirstName,LastName,Passportid,Priority,Date,Depart,Arrival,Origin,Destination) VALUES ('" + app.strid + "', '" + app.fliid + "','" + textBox18.Text.Trim() + "','" + textBox7.Text.Trim() + "','" + textBox14.Text.Trim() + "','" + comboBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox6.Text + "','" + textBox5.Text + "','" + textBox4.Text + "')";
                // "VALUES (@LastName, @FirstName,@Category,@Username,@Password)";
                SqlCommand sqlCmd = new SqlCommand(query, conn);
                sqlCmd.ExecuteNonQuery();
                conn.Close();
            }
            try
            {               
                var conn = new SqlConnection(cb.ConnectionString);
                SqlCommand cmd = new SqlCommand("UPDATE FlightInfo set Seats = Seats - 1 WHERE Id ='" + app.fliid + "'", conn);
                SqlDataReader myReader;
                conn.Open();
                myReader = cmd.ExecuteReader();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            this.Close();
        }
    }
}
