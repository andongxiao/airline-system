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
    public partial class Selectfirseat : Form
    {
        bool[] seatCheck = new bool[18];
        public Selectfirseat()
        {
            InitializeComponent();
            button1.Enabled = false;
            try
            {
                //bool[] seatCheck;
                //seatCheck = new bool[32];
                var cb = new SqlConnectionStringBuilder();
                cb.DataSource = "mynewserver7-10.database.windows.net";
                cb.UserID = "SeverAdmin";
                cb.Password = "523015302xX";
                cb.InitialCatalog = "mySampleDatabase";
                var conn = new SqlConnection(cb.ConnectionString);
                SqlCommand SelectCommand = new SqlCommand("select * from dbo.Firseat where Id = '" + app.fliid + "'", conn);
                SqlDataReader myReader;
                conn.Open();
                myReader = SelectCommand.ExecuteReader();

                while (myReader.Read())
                {
                    seatCheck[0] = (bool)myReader["A1"];
                    seatCheck[1] = (bool)myReader["B1"];
                    seatCheck[2] = (bool)myReader["C1"];
                    seatCheck[3] = (bool)myReader["D1"];
                    seatCheck[4] = (bool)myReader["E1"];
                    seatCheck[5] = (bool)myReader["F1"];
                    
                    seatCheck[8] = (bool)myReader["A2"];
                    seatCheck[9] = (bool)myReader["B2"];
                    seatCheck[10] = (bool)myReader["C2"];
                    seatCheck[11] = (bool)myReader["D2"];
                    seatCheck[12] = (bool)myReader["E2"];
                    seatCheck[13] = (bool)myReader["F2"];
                   
                    seatCheck[16] = (bool)myReader["A3"];
                    seatCheck[17] = (bool)myReader["B3"];
                    seatCheck[18] = (bool)myReader["C3"];
                    seatCheck[19] = (bool)myReader["D3"];
                    seatCheck[20] = (bool)myReader["E3"];
                    seatCheck[21] = (bool)myReader["F3"];
                    
                    
                }
                conn.Close();
                PictureBox[] boxes = { A1, B1, C1, D1, E1, F1, A2, B2, C2, D2, E2, F2, A3, B3, C3, D3, E3, F3 };
                for (int i = 0; i < boxes.Length; i++)
                {
                    if (seatCheck[i] == true)
                        boxes[i].Image = Image.FromFile(globals.brchair);
                    else
                        boxes[i].Image = Image.FromFile(globals.bgchair);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        string selectedseat = "";
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
            ///////
            try
            {
                var cb = new SqlConnectionStringBuilder();
                cb.DataSource = "mynewserver7-10.database.windows.net";
                cb.UserID = "SeverAdmin";
                cb.Password = "523015302xX";
                cb.InitialCatalog = "mySampleDatabase";
                var conn = new SqlConnection(cb.ConnectionString);
                SqlCommand cmd = new SqlCommand("UPDATE Firseat SET " + selectedseat + " = 1 WHERE Id = '" + app.fliid + "';", conn);
                SqlDataReader myReader;
                conn.Open();
                myReader = cmd.ExecuteReader();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            /////
            try
            {
                var cb = new SqlConnectionStringBuilder();
                cb.DataSource = "mynewserver7-10.database.windows.net";
                cb.UserID = "SeverAdmin";
                cb.Password = "523015302xX";
                cb.InitialCatalog = "mySampleDatabase";
                var conn = new SqlConnection(cb.ConnectionString);
                SqlCommand cmd = new SqlCommand("UPDATE Flightorder set Seat = '" + selectedseat + "' WHERE Passportid = '" + app.passid + "'", conn);
                SqlDataReader myReader;
                conn.Open();
                myReader = cmd.ExecuteReader();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            //this.Owner.Refresh();  
            this.Close();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (seatCheck[2] == false)
            {
                if (selectedseat == "")
                {
                    C1.Image = Image.FromFile(globals.bychair);
                    selectedseat = "C1";
                    button1.Enabled = true;
                    return;
                }
                if (selectedseat == "C1")
                {
                    C1.Image = Image.FromFile(globals.bgchair);
                    selectedseat = "";
                    button1.Enabled = false;
                    return;
                }
                else
                {
                    MessageBox.Show("You can only pick one seat");
                }
            }
        }

        private void A1_Click(object sender, EventArgs e)
        {
            if (seatCheck[0] == false)
            {
                if (selectedseat == "")
                {
                    A1.Image = Image.FromFile(globals.bychair);
                    selectedseat = "A1";
                    button1.Enabled = true;
                    return;
                }
                if (selectedseat == "A1")
                {
                    A1.Image = Image.FromFile(globals.bgchair);
                    selectedseat = "";
                    button1.Enabled = false;
                    return;
                }
                else
                {
                    MessageBox.Show("You can only pick one seat");
                }
            }
        }

        private void B1_Click(object sender, EventArgs e)
        {
            if (seatCheck[1] == false)
            {
                if (selectedseat == "")
                {
                    B1.Image = Image.FromFile(globals.bychair);
                    selectedseat = "B1";
                    button1.Enabled = true;
                    return;
                }
                if (selectedseat == "B1")
                {
                    B1.Image = Image.FromFile(globals.bgchair);
                    selectedseat = "";
                    button1.Enabled = false;
                    return;
                }
                else
                {
                    MessageBox.Show("You can only pick one seat");
                }
            }
        }

        private void D1_Click(object sender, EventArgs e)
        {
            if (seatCheck[3] == false)
            {
                if (selectedseat == "")
                {
                    D1.Image = Image.FromFile(globals.bychair);
                    selectedseat = "D1";
                    button1.Enabled = true;
                    return;
                }
                if (selectedseat == "D1")
                {
                    D1.Image = Image.FromFile(globals.bgchair);
                    selectedseat = "";
                    button1.Enabled = false;
                    return;
                }
                else
                {
                    MessageBox.Show("You can only pick one seat");
                }
            }
        }

        private void E1_Click(object sender, EventArgs e)
        {
            if (seatCheck[4] == false)
            {
                if (selectedseat == "")
                {
                    E1.Image = Image.FromFile(globals.bychair);
                    selectedseat = "E1";
                    button1.Enabled = true;
                    return;
                }
                if (selectedseat == "E1")
                {
                    E1.Image = Image.FromFile(globals.bgchair);
                    selectedseat = "";
                    button1.Enabled = false;
                    return;
                }
                else
                {
                    MessageBox.Show("You can only pick one seat");
                }
            }
        }

        private void F1_Click(object sender, EventArgs e)
        {
            if (seatCheck[5] == false)
            {
                if (selectedseat == "")
                {
                    F1.Image = Image.FromFile(globals.bychair);
                    selectedseat = "F1";
                    button1.Enabled = true;
                    return;
                }
                if (selectedseat == "F1")
                {
                    F1.Image = Image.FromFile(globals.bgchair);
                    selectedseat = "";
                    button1.Enabled = false;
                    return;
                }
                else
                {
                    MessageBox.Show("You can only pick one seat");
                }
            }
        }

        private void A2_Click(object sender, EventArgs e)
        {
            if (seatCheck[6] == false)
            {
                if (selectedseat == "")
                {
                    A2.Image = Image.FromFile(globals.bychair);
                    selectedseat = "A2";
                    button1.Enabled = true;
                    return;
                }
                if (selectedseat == "A2")
                {
                    A2.Image = Image.FromFile(globals.bgchair);
                    selectedseat = "";
                    button1.Enabled = false;
                    return;
                }
                else
                {
                    MessageBox.Show("You can only pick one seat");
                }
            }
        }

        private void B2_Click(object sender, EventArgs e)
        {
            if (seatCheck[7] == false)
            {
                if (selectedseat == "")
                {
                    B2.Image = Image.FromFile(globals.bychair);
                    selectedseat = "B2";
                    button1.Enabled = true;
                    return;
                }
                if (selectedseat == "B2")
                {
                    B2.Image = Image.FromFile(globals.bgchair);
                    selectedseat = "";
                    button1.Enabled = false;
                    return;
                }
                else
                {
                    MessageBox.Show("You can only pick one seat");
                }
            }
        }

        private void C2_Click(object sender, EventArgs e)
        {
            if (seatCheck[8] == false)
            {
                if (selectedseat == "")
                {
                    C2.Image = Image.FromFile(globals.bychair);
                    selectedseat = "C2";
                    button1.Enabled = true;
                    return;
                }
                if (selectedseat == "C2")
                {
                    C2.Image = Image.FromFile(globals.bgchair);
                    selectedseat = "";
                    button1.Enabled = false;
                    return;
                }
                else
                {
                    MessageBox.Show("You can only pick one seat");
                }
            }
        }

        private void D2_Click(object sender, EventArgs e)
        {
            if (seatCheck[9] == false)
            {
                if (selectedseat == "")
                {
                    D2.Image = Image.FromFile(globals.bychair);
                    selectedseat = "D2";
                    button1.Enabled = true;
                    return;
                }
                if (selectedseat == "D2")
                {
                    D2.Image = Image.FromFile(globals.bgchair);
                    selectedseat = "";
                    button1.Enabled = false;
                    return;
                }
                else
                {
                    MessageBox.Show("You can only pick one seat");
                }
            }
        }

        private void E2_Click(object sender, EventArgs e)
        {
            if (seatCheck[10] == false)
            {
                if (selectedseat == "")
                {
                    E2.Image = Image.FromFile(globals.bychair);
                    selectedseat = "E2";
                    button1.Enabled = true;
                    return;
                }
                if (selectedseat == "E2")
                {
                    E2.Image = Image.FromFile(globals.bgchair);
                    selectedseat = "";
                    button1.Enabled = false;
                    return;
                }
                else
                {
                    MessageBox.Show("You can only pick one seat");
                }
            }
        }

        private void F2_Click(object sender, EventArgs e)
        {
            if (seatCheck[11] == false)
            {
                if (selectedseat == "")
                {
                    F2.Image = Image.FromFile(globals.bychair);
                    selectedseat = "F2";
                    button1.Enabled = true;
                    return;
                }
                if (selectedseat == "F2")
                {
                    F2.Image = Image.FromFile(globals.bgchair);
                    selectedseat = "";
                    button1.Enabled = false;
                    return;
                }
                else
                {
                    MessageBox.Show("You can only pick one seat");
                }
            }
        }

        private void A3_Click(object sender, EventArgs e)
        {
            if (seatCheck[12] == false)
            {
                if (selectedseat == "")
                {
                    A3.Image = Image.FromFile(globals.bychair);
                    selectedseat = "A3";
                    button1.Enabled = true;
                    return;
                }
                if (selectedseat == "A3")
                {
                    A3.Image = Image.FromFile(globals.bgchair);
                    selectedseat = "";
                    button1.Enabled = false;
                    return;
                }
                else
                {
                    MessageBox.Show("You can only pick one seat");
                }
            }
        }

        private void B3_Click(object sender, EventArgs e)
        {
            if (seatCheck[13] == false)
            {
                if (selectedseat == "")
                {
                    B3.Image = Image.FromFile(globals.bychair);
                    selectedseat = "B3";
                    button1.Enabled = true;
                    return;
                }
                if (selectedseat == "B3")
                {
                    B3.Image = Image.FromFile(globals.bgchair);
                    selectedseat = "";
                    button1.Enabled = false;
                    return;
                }
                else
                {
                    MessageBox.Show("You can only pick one seat");
                }
            }
        }

        private void C3_Click(object sender, EventArgs e)
        {
            if (seatCheck[14] == false)
            {
                if (selectedseat == "")
                {
                    C3.Image = Image.FromFile(globals.bychair);
                    selectedseat = "C3";
                    button1.Enabled = true;
                    return;
                }
                if (selectedseat == "C3")
                {
                    C3.Image = Image.FromFile(globals.bgchair);
                    selectedseat = "";
                    button1.Enabled = false;
                    return;
                }
                else
                {
                    MessageBox.Show("You can only pick one seat");
                }
            }
        }

        private void D3_Click(object sender, EventArgs e)
        {
            if (seatCheck[15] == false)
            {
                if (selectedseat == "")
                {
                    D3.Image = Image.FromFile(globals.bychair);
                    selectedseat = "D3";
                    button1.Enabled = true;
                    return;
                }
                if (selectedseat == "D3")
                {
                    D3.Image = Image.FromFile(globals.bgchair);
                    selectedseat = "";
                    button1.Enabled = false;
                    return;
                }
                else
                {
                    MessageBox.Show("You can only pick one seat");
                }
            }
        }

        private void E3_Click(object sender, EventArgs e)
        {
            if (seatCheck[16] == false)
            {
                if (selectedseat == "")
                {
                    E3.Image = Image.FromFile(globals.bychair);
                    selectedseat = "E3";
                    button1.Enabled = true;
                    return;
                }
                if (selectedseat == "E3")
                {
                    E3.Image = Image.FromFile(globals.bgchair);
                    selectedseat = "";
                    button1.Enabled = false;
                    return;
                }
                else
                {
                    MessageBox.Show("You can only pick one seat");
                }
            }
        }

        private void F3_Click(object sender, EventArgs e)
        {
            if (seatCheck[17] == false)
            {
                if (selectedseat == "")
                {
                    F3.Image = Image.FromFile(globals.bychair);
                    selectedseat = "F3";
                    button1.Enabled = true;
                    return;
                }
                if (selectedseat == "F3")
                {
                    F3.Image = Image.FromFile(globals.bgchair);
                    selectedseat = "";
                    button1.Enabled = false;
                    return;
                }
                else
                {
                    MessageBox.Show("You can only pick one seat");
                }
            }
        }
    }
}
