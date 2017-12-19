using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Drawing.Drawing2D;

namespace DGI01
{
    public partial class parameters : Form
    {
        public List<int> input;
        public List<int> output;
        public List<double> coefficient;
        List<CLines> l;
        List<string> mylines;
        public parameters(List<CLines> cl)
        {
            InitializeComponent();
            this.Size = new Size(505, 230);
            this.Win.Size = new System.Drawing.Size(475, 180);
            int PointY = 10;
            foreach (CLines ml in cl)
            {
                mylines=new List<string>(ml.myLines);
                int n = mylines.Count();
                for (int i = 0; i < n; i++)
                {
                    Label la = new Label();
                    la.Text = mylines[i];
                    la.Location = new Point(0, PointY);
                    la.Font = new Font("Bold", 12);
                    la.AutoSize = true;
                    this.Win.Controls.Add(la);
                    
                    PointY += la.Height;

                }
            }
        }

        private void parameters_Load(object sender, EventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Win_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
