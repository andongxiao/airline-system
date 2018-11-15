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
   
    public partial class customid : Form
    {
        int PanelWidth;
        bool isCollapsed;
        public customid()
        {
            InitializeComponent();
            timer2.Start();
            PanelWidth = panelLeft.Width;
            isCollapsed = false;
        }

    
        public customid(string id)
        {
            InitializeComponent();
            customidlabel.Text = id;
            timer2.Start();
            PanelWidth = panelLeft.Width;
            isCollapsed = false;
        }

        private void AddControlsToPanel(Control c)
        {
            c.Dock = DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(c);
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            moveSidePanel(button1);
            //person_inf1.BringToFront();
            person_inf perf = new person_inf();
            AddControlsToPanel(perf);
        
        }

        private void person_inf2_Load(object sender, EventArgs e)
        {

        }

        

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(isCollapsed)
            {
                panelLeft.Width = panelLeft.Width + 10;
                if(panelLeft.Width >= PanelWidth)
                {
                    timer1.Stop();
                    isCollapsed = false;
                    this.Refresh();
                }
            }
            else
            {
                panelLeft.Width = panelLeft.Width - 10;
                if(panelLeft.Width <= 40)
                {
                    timer1.Stop();
                    isCollapsed = true;
                    this.Refresh();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void moveSidePanel(Control btn)
        {
            panelsqure.Top = btn.Top;
            panelsqure.Height = btn.Height;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            moveSidePanel(button2);
            flight_inf flif = new flight_inf();
            AddControlsToPanel(flif);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            moveSidePanel(button3);
            Myflight Myff = new Myflight();
            AddControlsToPanel(Myff);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            label7.Text = dt.ToString("HH:MM:ss");
        }
    }
  
}
