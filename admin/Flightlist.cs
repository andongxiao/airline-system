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
    public partial class Flightlist : UserControl
    {
        public Flightlist()
        {
            InitializeComponent();
            button3.Enabled = false;
            button2.Enabled = false;
        }

        private void Flightlist_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = GetFlightList();

        }

        private DataTable GetFlightList()
        {
            DataTable dtFlights = new DataTable();
            var cb = new SqlConnectionStringBuilder();
            cb.DataSource = "mynewserver7-10.database.windows.net";
            cb.UserID = "SeverAdmin";
            cb.Password = "523015302xX";
            cb.InitialCatalog = "mySampleDatabase";
            var conn = new SqlConnection(cb.ConnectionString);
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.FlightInfo", conn))
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                dtFlights.Load(reader);
            }

            return dtFlights;
        }

        
        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            button3.Enabled = true;
            button2.Enabled = true;
            string flightid = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string date = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            string departtime = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            string arrivaltime = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            string origin = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            string destination = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            string company = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            string terminal = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            string seats = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            string firstprice = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            string ecoprice = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            textBox1.Text = flightid;
            dateTimePicker1.Text = date;
            textBox5.Text = departtime;
            textBox7.Text = arrivaltime;
            textBox2.Text = origin;
            textBox8.Text = destination;
            textBox9.Text = company;
            textBox10.Text = terminal;
            textBox3.Text = seats;
            textBox6.Text = firstprice;
            textBox11.Text = ecoprice;
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
                SqlCommand cmd = new SqlCommand("INSERT INTO dbo.FlightInfo (Id,Date,DepartTime,ArrivalTime,Origin,Destination,Company,Terminal,Seats,FirstPrice,EcoPrice) VALUES ('" + textBox1.Text + "','" + dateTimePicker1.Text + "','" + textBox5.Text + "','" + textBox7.Text + "','" + textBox2.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + textBox10.Text + "','" + textBox3.Text + "','" + textBox6.Text + "','" + textBox11.Text + "')", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                dataGridView1.DataSource = GetFlightList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string flightid = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                var cb = new SqlConnectionStringBuilder();
                cb.DataSource = "mynewserver7-10.database.windows.net";
                cb.UserID = "SeverAdmin";
                cb.Password = "523015302xX";
                cb.InitialCatalog = "mySampleDatabase";
                var conn = new SqlConnection(cb.ConnectionString);
                // SqlCommand SelectCommand = new SqlCommand("select * from dbo.employeeInfo WHERE Customid='" + userid + "'", conn);
                SqlCommand cmd = new SqlCommand("UPDATE dbo.FlightInfo set Id='"
                                                            + textBox1.Text + "',Date = '"
                                                            + dateTimePicker1.Text + "', DepartTime='"
                                                            + textBox5.Text + "', ArrivalTime='"
                                                            + textBox7.Text + "', Origin ='"
                                                            + textBox2.Text + "', Destination ='"
                                                            + textBox8.Text + "', Company ='"
                                                            + textBox9.Text + "', Terminal='"
                                                            + textBox10.Text + "', Seats='"
                                                            + textBox3.Text + "', FirstPrice='"
                                                            + textBox6.Text + "', EcoPrice='"
                                                            + textBox11.Text + "' WHERE Id='" + flightid + "'", conn);
                SqlDataReader myReader;
                conn.Open();
                myReader = cmd.ExecuteReader();
                conn.Close();
                dataGridView1.DataSource = GetFlightList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string flightid = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            var cb = new SqlConnectionStringBuilder();
            cb.DataSource = "mynewserver7-10.database.windows.net";
            cb.UserID = "SeverAdmin";
            cb.Password = "523015302xX";
            cb.InitialCatalog = "mySampleDatabase";
            var conn = new SqlConnection(cb.ConnectionString);
            SqlCommand cmd = new SqlCommand("DELETE FROM dbo.FlightInfo WHERE Id='" + flightid + "'", conn);
            SqlDataReader myReader;
            conn.Open();
            myReader = cmd.ExecuteReader();
            conn.Close();
            dataGridView1.DataSource = GetFlightList();
        }
    }
}
