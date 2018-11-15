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
    public partial class flight_inf : UserControl
    {
        public flight_inf()
        {
            InitializeComponent();
            button2.Enabled = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void flight_inf_Load(object sender, EventArgs e)
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var item = dataGridView1.Rows[e.RowIndex].Cells[0].Value;
            app.fliid = item.ToString();
            //MessageBox.Show(item.ToString());
            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            order f = new order();
            f.ShowDialog();
        }
    }
}
