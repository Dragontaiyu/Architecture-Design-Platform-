using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DGI01
{
    public partial class HVAC_GEN : MetroFramework.Forms.MetroForm
    {
        public HVAC_GEN()
        {
            InitializeComponent();
        }
        /*public void hidePanels()
        {
            panel1.Width = 0;
            panel2.Width = 0;
        }*/
        private void HVAC_GEN_Load(object sender, EventArgs e)
        {
            //hidePanels();
        }

        private void metroTile2_Click(object sender, EventArgs e)
        {
            /*hidePanels();
            panel2.Location =new Point(166,191);
            panel2.Width = 667;
            panel2.Height = 428;
            Graphics gs = CreateGraphics();
            Rectangle rect = ClientRectangle;
            rect.Location = new Point(164, 190);
            rect.Width = 669;
            rect.Height = 430;
            gs.DrawRectangle(Pens.DarkOrange, rect);
            label5.Location = new Point(90, 45);
            label5.Size = new Size(420, 60);
            comboBox1.Location = new Point(310,40);
            comboBox1.Size = new Size(300,35);
            label6.Location = new Point(90, 105);
            label6.Size = new Size(420, 60);
            comboBox2.Location = new Point(310, 100);
            comboBox2.Size = new Size(300, 35);
            label7.Location = new Point(90, 165);
            label7.Size = new Size(420, 60);
            textBox4.Location = new Point(310, 160);
            textBox4.Size = new Size(300, 35);
            label8.Location = new Point(90, 225);
            label8.Size = new Size(420, 60);
            textBox5.Location = new Point(310, 220);
            textBox5.Size = new Size(300, 35);
            label9.Location = new Point(90, 285);
            label9.Size = new Size(420, 60);
            textBox6.Location = new Point(310, 280);
            textBox6.Size = new Size(240, 35);
            label10.Location = new Point(560, 285);
            label10.Size = new Size(420, 60);
            button3.Location = new Point(300, 340);
            button3.Size = new Size(100, 60);*/

        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            /*hidePanels();
            panel1.Location = new Point(166, 191);
            panel1.Width = 667;
            panel1.Height = 428;
            Graphics gs = CreateGraphics();
            Rectangle rect = ClientRectangle;
            rect.Location = new Point(164, 190);
            rect.Width = 669;
            rect.Height = 430;
            gs.DrawRectangle(Pens.CornflowerBlue, rect);
            label1.Location= new Point(30,40);
            label1.Size = new Size(320,50);
            textBox1.Location = new Point(205,40);
            textBox1.Size = new Size(300,25);*/
            this.Hide();
            New_Project mainwin = new New_Project();
            mainwin.ShowDialog();
            this.Close();


        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void metroTile4_Click(object sender, EventArgs e)
        {
       
            /*hidePanels();
            Graphics gs = CreateGraphics();
            Rectangle rect = ClientRectangle;
            rect.Location = new Point(164, 190);
            rect.Width = 669;
            rect.Height = 430;
            gs.DrawRectangle(Pens.White, rect);*/
        
    }

        private void metroTile5_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to EXIT?", "EXIT", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
                Application.Exit();
            }
        }
    }
}
