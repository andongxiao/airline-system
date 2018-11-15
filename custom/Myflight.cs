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
    public partial class Myflight : UserControl
    {
        public Myflight()
        {
            InitializeComponent();
            button1.Enabled = false;
            dataGridView1.AutoGenerateColumns = false;
            var cb = new SqlConnectionStringBuilder();
            cb.DataSource = "mynewserver7-10.database.windows.net";
            cb.UserID = "SeverAdmin";
            cb.Password = "523015302xX";
            cb.InitialCatalog = "mySampleDatabase";
            var conn = new SqlConnection(cb.ConnectionString);
            SqlCommand SelectCommand = new SqlCommand("select * from dbo.Flightorder WHERE Customid='" + app.strid + "'", conn);
            //SqlDataReader myReader;
            conn.Open();
           // myReader = SelectCommand.ExecuteReader();
            DataTable dtbl = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(SelectCommand);
            adapter.Fill(dtbl);
            dataGridView1.DataSource = dtbl;
            conn.Close();
            /////
          
        }
        bool isclick = false;
        private void button1_Click(object sender, EventArgs e)
        {
            string strclass = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            app.fliid = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            string passid = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            app.passid = System.Convert.ToInt32(passid);
            if (strclass == "Economy Price"){
                Selectecoseat seatecof = new Selectecoseat();
                seatecof.ShowDialog();
            }
            else
            {
                Selectfirseat seatfir = new Selectfirseat();
                seatfir.ShowDialog();
            }
            //int a = dataGridView1.CurrentCell.RowIndex;
            //string str_seat = dataGridView1.CurrentRow.Cells["Seat"].Value.ToString();
            //if(str_seat == "NULL" && isclick == true) { button1.Enabled = true; }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            isclick = true;
            int a = dataGridView1.CurrentCell.RowIndex;
            string str_seat = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            if (str_seat == "" && isclick == true) { button1.Enabled = true; }
            //if (isclick == true) { button1.Enabled = true; }
        }
    }
}
