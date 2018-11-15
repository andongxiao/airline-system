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
    public partial class person_inf : UserControl
    {
        public person_inf()
        {
            InitializeComponent();
            var cb = new SqlConnectionStringBuilder();
            cb.DataSource = "mynewserver7-10.database.windows.net";
            cb.UserID = "SeverAdmin";
            cb.Password = "523015302xX";
            cb.InitialCatalog = "mySampleDatabase";
            var conn = new SqlConnection(cb.ConnectionString);
            SqlCommand SelectCommand = new SqlCommand("select * from personinfo WHERE Id='" + app.strid + "'", conn);
            SqlDataReader myReader;
            conn.Open();
            myReader = SelectCommand.ExecuteReader();
            while (myReader.Read())
            {

                textBox1.Text = myReader[1].ToString();
                textBox12.Text = myReader[2].ToString();
                textBox2.Text = myReader[3].ToString();
                textBox3.Text = myReader[4].ToString();
                textBox4.Text = myReader[5].ToString();
                textBox5.Text = myReader[6].ToString();
                textBox6.Text = myReader[7].ToString();
                textBox7.Text = myReader[8].ToString();
                textBox14.Text = myReader[9].ToString();
            }
            conn.Close();
        }

        private void person_inf_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {   ///verify           
                var cb = new SqlConnectionStringBuilder();
                cb.DataSource = "mynewserver7-10.database.windows.net";
                cb.UserID = "SeverAdmin";
                cb.Password = "523015302xX";
                cb.InitialCatalog = "mySampleDatabase";
                var conn = new SqlConnection(cb.ConnectionString);
                SqlCommand sltcmd = new SqlCommand("select * from personinfo WHERE Id='" + app.strid + "'",conn);
                SqlDataReader myReader;
                conn.Open();
                myReader = sltcmd.ExecuteReader();
                int count = 0;
                // string id = "0";              
                while (myReader.Read())
                {
                    count = count + 1;
                  //  app.strid = myReader[0].ToString();

                }
                conn.Close();
                if (count != 0)
                {
                SqlCommand cmd = new SqlCommand("UPDATE personinfo set FirstName='"
                                                        + textBox1.Text + "',LastName = '"
                                                        + textBox12.Text + "', Address ='"
                                                        + textBox2.Text + "', City ='"
                                                        + textBox3.Text + "', State='"
                                                        + textBox4.Text + "', Zipcode='"
                                                        + textBox5.Text + "', Phone ='"
                                                        + textBox6.Text + "', Country='"
                                                        + textBox7.Text + "', PassportId='" + textBox14.Text + "' WHERE Id='" + app.strid + "'", conn);
                SqlDataReader myReader_;
                conn.Open();
                myReader_ = cmd.ExecuteReader();
                conn.Close();
               
                }
                else
                {
                    //SqlCommand cmd = new SqlCommand("INSERT INTO personinfo (Id) VALUES('" + app.strid + "')", conn);
                    SqlCommand cmd = new SqlCommand("INSERT INTO personinfo (LastName,FirstName,Address,City,State,Zipcode,Phone,Country,Id,PassportId) VALUES('" + textBox1.Text + "', '" + textBox12.Text + "',  '" + textBox2.Text + "',  '" + textBox3.Text + "', '" + textBox4.Text + "' , '" + textBox5.Text + "',  '" + textBox6.Text + "', '" + textBox7.Text + "', '" + app.strid + "' , '" + textBox14.Text + "')", conn);                                      
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
