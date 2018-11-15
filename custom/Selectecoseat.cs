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
    public partial class Selectecoseat : Form
    {
        bool[] seatCheck = new bool[32];
        //seatCheck = new bool[32];
        public Selectecoseat()
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
                SqlCommand SelectCommand = new SqlCommand("select * from dbo.Ecoseat where Id = '" + app.fliid + "'", conn);
                SqlDataReader myReader;
                conn.Open();
                myReader = SelectCommand.ExecuteReader();

                while (myReader.Read())
                {
                    seatCheck[0] = (bool)myReader["A20"];
                    seatCheck[1] = (bool)myReader["B20"];
                    seatCheck[2] = (bool)myReader["C20"];
                    seatCheck[3] = (bool)myReader["D20"];
                    seatCheck[4] = (bool)myReader["E20"];
                    seatCheck[5] = (bool)myReader["F20"];
                    seatCheck[6] = (bool)myReader["G20"];
                    seatCheck[7] = (bool)myReader["H20"];
                    seatCheck[8] = (bool)myReader["A21"];
                    seatCheck[9] = (bool)myReader["B21"];
                    seatCheck[10] = (bool)myReader["C21"];
                    seatCheck[11] = (bool)myReader["D21"];
                    seatCheck[12] = (bool)myReader["E21"];
                    seatCheck[13] = (bool)myReader["F21"];
                    seatCheck[14] = (bool)myReader["G21"];
                    seatCheck[15] = (bool)myReader["H21"];
                    seatCheck[16] = (bool)myReader["A22"];
                    seatCheck[17] = (bool)myReader["B22"];
                    seatCheck[18] = (bool)myReader["C22"];
                    seatCheck[19] = (bool)myReader["D22"];
                    seatCheck[20] = (bool)myReader["E22"];
                    seatCheck[21] = (bool)myReader["F22"];
                    seatCheck[22] = (bool)myReader["G22"];

                    seatCheck[23] = (bool)myReader["H22"];
                    seatCheck[24] = (bool)myReader["A23"];
                    seatCheck[25] = (bool)myReader["B23"];
                    seatCheck[26] = (bool)myReader["C23"];
                    seatCheck[27] = (bool)myReader["D23"];
                    seatCheck[28] = (bool)myReader["E23"];
                    seatCheck[29] = (bool)myReader["F23"];
                    seatCheck[30] = (bool)myReader["G23"];
                    seatCheck[31] = (bool)myReader["H23"];
                }
                conn.Close();
                PictureBox[] boxes = { A20, B20, C20, D20, E20, F20, G20, H20, A21, B21, C21, D21, E21, F21, G21, H21, A22, B22, C22, D22, E22, F22, G22, H22,
                A23, B23, C23, D23, E23, F23, G23, H23};
                for (int i = 0; i < boxes.Length; i++)
                {
                    if (seatCheck[i] == true)
                        boxes[i].Image = Image.FromFile(globals.srchair);
                    else
                        boxes[i].Image = Image.FromFile(globals.sgchair);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        string selectedseat = "";
        private void button1_Click(object sender, EventArgs e)
        {            
            ///////
            try
            {
                var cb = new SqlConnectionStringBuilder();
                cb.DataSource = "mynewserver7-10.database.windows.net";
                cb.UserID = "SeverAdmin";
                cb.Password = "523015302xX";
                cb.InitialCatalog = "mySampleDatabase";
                var conn = new SqlConnection(cb.ConnectionString);
                SqlCommand cmd = new SqlCommand("UPDATE Ecoseat SET " + selectedseat + " = 1 WHERE Id = '" + app.fliid + "';", conn);
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
           // this.Owner.Refresh();
        }

        private void A20_Click(object sender, EventArgs e)
        {
            if (seatCheck[0] == false)
            {
                if (selectedseat == "")
                {
                    A20.Image = Image.FromFile(globals.sychair);
                    selectedseat = "A20";
                    button1.Enabled = true;
                    return;
                }
                if (selectedseat == "A20")
                {
                    A20.Image = Image.FromFile(globals.sgchair);
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

        private void B20_Click(object sender, EventArgs e)
        {
            if (seatCheck[1] == false)
            {
                if (selectedseat == "")
                {
                    B20.Image = Image.FromFile(globals.sychair);
                    selectedseat = "B20";
                    button1.Enabled = true;
                    return;
                }
                if (selectedseat == "B20")
                {
                    B20.Image = Image.FromFile(globals.sgchair);
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

        private void C20_Click(object sender, EventArgs e)
        {
            if (seatCheck[2] == false)
            {


                if (selectedseat == "")
                {
                    C20.Image = Image.FromFile(globals.sychair);
                    selectedseat = "C20";
                    button1.Enabled = true;
                    return;
                }
                if (selectedseat == "C20")
                {
                    C20.Image = Image.FromFile(globals.sgchair);
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

        private void D20_Click(object sender, EventArgs e)
        {
            if (seatCheck[3] == false)
            {
                if (selectedseat == "")
                {
                    D20.Image = Image.FromFile(globals.sychair);
                    selectedseat = "D20";
                    button1.Enabled = true;
                    return;
                }
                if (selectedseat == "D20")
                {
                    D20.Image = Image.FromFile(globals.sgchair);
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

        private void E20_Click(object sender, EventArgs e)
        {
            if (seatCheck[4] == false)
            {
                if (selectedseat == "")
                {
                    E20.Image = Image.FromFile(globals.sychair);
                    selectedseat = "E20";
                    button1.Enabled = true;
                    return;
                }
                if (selectedseat == "E20")
                {
                    E20.Image = Image.FromFile(globals.sgchair);
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

        private void F20_Click(object sender, EventArgs e)
        {
            if (seatCheck[5] == false)
            {
                if (selectedseat == "")
                {
                    F20.Image = Image.FromFile(globals.sychair);
                    selectedseat = "F20";
                    button1.Enabled = true;
                    return;
                }
                if (selectedseat == "F20")
                {
                    F20.Image = Image.FromFile(globals.sgchair);
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

        private void G20_Click(object sender, EventArgs e)
        {
            if (seatCheck[6] == false)
            {
                if (selectedseat == "")
                {
                    G20.Image = Image.FromFile(globals.sychair);
                    selectedseat = "G20";
                    button1.Enabled = true;
                    return;
                }
                if (selectedseat == "G20")
                {
                    G20.Image = Image.FromFile(globals.sgchair);
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

        private void H20_Click(object sender, EventArgs e)
        {
            if (seatCheck[7] == false)
            {
                if (selectedseat == "")
                {
                    H20.Image = Image.FromFile(globals.sychair);
                    selectedseat = "H20";
                    button1.Enabled = true;
                    return;
                }
                if (selectedseat == "H20")
                {
                    H20.Image = Image.FromFile(globals.sgchair);
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

        private void A21_Click(object sender, EventArgs e)
        {
            if (seatCheck[8] == false)
            {
                if (selectedseat == "")
                {
                    A21.Image = Image.FromFile(globals.sychair);
                    selectedseat = "A21";
                    button1.Enabled = true;
                    return;
                }
                if (selectedseat == "A21")
                {
                    A21.Image = Image.FromFile(globals.sgchair);
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

        private void B21_Click(object sender, EventArgs e)
        {
            if (seatCheck[9] == false)
            {
                if (selectedseat == "")
                {
                    B21.Image = Image.FromFile(globals.sychair);
                    selectedseat = "B21";
                    button1.Enabled = true;
                    return;
                }
                if (selectedseat == "B21")
                {
                    B21.Image = Image.FromFile(globals.sgchair);
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

        private void C21_Click(object sender, EventArgs e)
        {
            if (seatCheck[10] == false)
            {
                if (selectedseat == "")
                {
                    C21.Image = Image.FromFile(globals.sychair);
                    selectedseat = "C21";
                    button1.Enabled = true;
                    return;
                }
                if (selectedseat == "C21")
                {
                    C21.Image = Image.FromFile(globals.sgchair);
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

        private void D21_Click(object sender, EventArgs e)
        {
            if (seatCheck[11] == false)
            {
                if (selectedseat == "")
                {
                    D21.Image = Image.FromFile(globals.sychair);
                    selectedseat = "D21";
                    button1.Enabled = true;
                    return;
                }
                if (selectedseat == "D21")
                {
                    D21.Image = Image.FromFile(globals.sgchair);
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

        private void E21_Click(object sender, EventArgs e)
        {
            if (seatCheck[12] == false)
            {
                if (selectedseat == "")
                {
                    E21.Image = Image.FromFile(globals.sychair);
                    selectedseat = "E21";
                    button1.Enabled = true;
                    return;
                }
                if (selectedseat == "E21")
                {
                    E21.Image = Image.FromFile(globals.sgchair);
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

        private void F21_Click(object sender, EventArgs e)
        {
            if (seatCheck[13] == false)
            {
                if (selectedseat == "")
                {
                    F21.Image = Image.FromFile(globals.sychair);
                    selectedseat = "F21";
                    button1.Enabled = true;
                    return;
                }
                if (selectedseat == "F21")
                {
                    F21.Image = Image.FromFile(globals.sgchair);
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

        private void G21_Click(object sender, EventArgs e)
        {
            if (seatCheck[14] == false)
            {
                if (selectedseat == "")
                {
                    G21.Image = Image.FromFile(globals.sychair);
                    selectedseat = "G21";
                    button1.Enabled = true;
                    return;
                }
                if (selectedseat == "G21")
                {
                    G21.Image = Image.FromFile(globals.sgchair);
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

        private void H21_Click(object sender, EventArgs e)
        {
            if (seatCheck[15] == false)
            {
                if (selectedseat == "")
                {
                    H21.Image = Image.FromFile(globals.sychair);
                    selectedseat = "H21";
                    button1.Enabled = true;
                    return;
                }
                if (selectedseat == "H21")
                {
                    H21.Image = Image.FromFile(globals.sgchair);
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

        private void A22_Click(object sender, EventArgs e)
        {
            if (seatCheck[16] == false)
            {
                if (selectedseat == "")
                {
                    A22.Image = Image.FromFile(globals.sychair);
                    selectedseat = "A22";
                    button1.Enabled = true;
                    return;
                }
                if (selectedseat == "A22")
                {
                    A22.Image = Image.FromFile(globals.sgchair);
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

        private void B22_Click(object sender, EventArgs e)
        {
            if (seatCheck[17] == false)
            {
                if (selectedseat == "")
                {
                    B22.Image = Image.FromFile(globals.sychair);
                    selectedseat = "B22";
                    button1.Enabled = true;
                    return;
                }
                if (selectedseat == "B22")
                {
                    B22.Image = Image.FromFile(globals.sgchair);
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

        private void C22_Click(object sender, EventArgs e)
        {
            if (seatCheck[18] == false)
            {
                if (selectedseat == "")
                {
                    C22.Image = Image.FromFile(globals.sychair);
                    selectedseat = "C22";
                    button1.Enabled = true;
                    return;
                }
                if (selectedseat == "C22")
                {
                    C22.Image = Image.FromFile(globals.sgchair);
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

        private void D22_Click(object sender, EventArgs e)
        {
            if (seatCheck[19] == false)
            {
                if (selectedseat == "")
                {
                    D22.Image = Image.FromFile(globals.sychair);
                    selectedseat = "D22";
                    button1.Enabled = true;
                    return;
                }
                if (selectedseat == "D22")
                {
                    D22.Image = Image.FromFile(globals.sgchair);
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

        private void E22_Click(object sender, EventArgs e)
        {
            if (seatCheck[20] == false)
            {
                if (selectedseat == "")
                {
                    E22.Image = Image.FromFile(globals.sychair);
                    selectedseat = "E22";
                    button1.Enabled = true;
                    return;
                }
                if (selectedseat == "E22")
                {
                    E22.Image = Image.FromFile(globals.sgchair);
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

        private void F22_Click(object sender, EventArgs e)
        {
            if (seatCheck[21] == false)
            {
                if (selectedseat == "")
                {
                    F22.Image = Image.FromFile(globals.sychair);
                    selectedseat = "F22";
                    button1.Enabled = true;
                }
                else if (selectedseat == "F22")
                {
                    F22.Image = Image.FromFile(globals.sgchair);
                    selectedseat = "";
                    button1.Enabled = false;
                }
                else
                {
                    MessageBox.Show("You can only pick one seat");
                }
            }
        }

        private void G22_Click(object sender, EventArgs e)
        {
            if (seatCheck[22] == false)
            {
                if (selectedseat == "")
                {
                    G22.Image = Image.FromFile(globals.sychair);
                    selectedseat = "G22";
                    button1.Enabled = true;
                }
                else if (selectedseat == "G22")
                {
                    G22.Image = Image.FromFile(globals.sgchair);
                    selectedseat = "";
                    button1.Enabled = false;
                }
                else
                {
                    MessageBox.Show("You can only pick one seat");
                }
            }
        }

        private void H22_Click(object sender, EventArgs e)
        {
            if (seatCheck[23] == false)
            {
                if (selectedseat == "")
                {
                    H22.Image = Image.FromFile(globals.sychair);
                    selectedseat = "H22";
                    button1.Enabled = true;
                }
                else if (selectedseat == "H22")
                {
                    H22.Image = Image.FromFile(globals.sgchair);
                    selectedseat = "";
                    button1.Enabled = false;
                }
                else
                {
                    MessageBox.Show("You can only pick one seat");
                }
            }
        }

        private void A23_Click(object sender, EventArgs e)
        {
            if (seatCheck[24] == false)
            {
                if (selectedseat == "")
                {
                    A23.Image = Image.FromFile(globals.sychair);
                    selectedseat = "A23";
                    button1.Enabled = true;
                }
                else if (selectedseat == "A23")
                {
                    A23.Image = Image.FromFile(globals.sgchair);
                    selectedseat = "";
                    button1.Enabled = false;
                }
                else
                {
                    MessageBox.Show("You can only pick one seat");
                }
            }
        }

        private void B23_Click(object sender, EventArgs e)
        {
            if (seatCheck[25] == false)
            {
                if (selectedseat == "")
                {
                    B23.Image = Image.FromFile(globals.sychair);
                    selectedseat = "B23";
                    button1.Enabled = true;
                }
                else if (selectedseat == "B23")
                {
                    B23.Image = Image.FromFile(globals.sgchair);
                    selectedseat = "";
                    button1.Enabled = false;
                }
                else
                {
                    MessageBox.Show("You can only pick one seat");
                }
            }
        }

        private void C23_Click(object sender, EventArgs e)
        {
            if (seatCheck[26] == false)
            {
                if (selectedseat == "")
                {
                    C23.Image = Image.FromFile(globals.sychair);
                    selectedseat = "C23";
                    button1.Enabled = true;
                }
                else if (selectedseat == "C23")
                {
                    C23.Image = Image.FromFile(globals.sgchair);
                    selectedseat = "";
                    button1.Enabled = false;
                }
                else
                {
                    MessageBox.Show("You can only pick one seat");
                }
            }
        }

        private void D23_Click(object sender, EventArgs e)
        {
            if (seatCheck[27] == false)
            {
                if (selectedseat == "")
                {
                    D23.Image = Image.FromFile(globals.sychair);
                    selectedseat = "D23";
                    button1.Enabled = true;
                }
                else if (selectedseat == "D23")
                {
                    D23.Image = Image.FromFile(globals.sgchair);
                    selectedseat = "";
                    button1.Enabled = false;
                }
                else
                {
                    MessageBox.Show("You can only pick one seat");
                }
            }
        }

        private void E23_Click(object sender, EventArgs e)
        {
            if (seatCheck[28] == false)
            {
                if (selectedseat == "")
                {
                    E23.Image = Image.FromFile(globals.sychair);
                    selectedseat = "E23";
                    button1.Enabled = true;
                }
                else if (selectedseat == "E23")
                {
                    E23.Image = Image.FromFile(globals.sgchair);
                    selectedseat = "";
                    button1.Enabled = false;
                }
                else
                {
                    MessageBox.Show("You can only pick one seat");
                }
            }
        }

        private void F23_Click(object sender, EventArgs e)
        {
            if (seatCheck[29] == false)
            {
                if (selectedseat == "")
                {
                    F23.Image = Image.FromFile(globals.sychair);
                    selectedseat = "F23";
                    button1.Enabled = true;
                }
                else if (selectedseat == "F23")
                {
                    F23.Image = Image.FromFile(globals.sgchair);
                    selectedseat = "";
                    button1.Enabled = false;
                }
                else
                {
                    MessageBox.Show("You can only pick one seat");
                }
            }
        }

        private void G23_Click(object sender, EventArgs e)
        {
            if (seatCheck[30] == false)
            {
                if (selectedseat == "")
                {
                    G23.Image = Image.FromFile(globals.sychair);
                    selectedseat = "G23";
                    button1.Enabled = true;
                }
                else if (selectedseat == "G23")
                {
                    G23.Image = Image.FromFile(globals.sgchair);
                    selectedseat = "";
                    button1.Enabled = false;
                }
                else
                {
                    MessageBox.Show("You can only pick one seat");
                }
            }
        }

        private void H23_Click(object sender, EventArgs e)
        {
            if (seatCheck[31] == false)
            {
                if (selectedseat == "")
            {
                H23.Image = Image.FromFile(globals.sychair);
                selectedseat = "H23";
                button1.Enabled = true;
            }
            else if (selectedseat == "H23")
            {
                H23.Image = Image.FromFile(globals.sgchair);
                selectedseat = "";
                button1.Enabled = false;
            }
            else
            {
                MessageBox.Show("You can only pick one seat");
            }
                }
        }
    }
}
