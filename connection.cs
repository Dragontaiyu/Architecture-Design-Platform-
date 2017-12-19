using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace DGI01
{
    public partial class connection : Form
    {
        private manipulation b1;
        private manipulation b2;
        private List<string> myLines;
        public connection(manipulation pb1, manipulation pb2)
        {
            InitializeComponent();
            this.Size = new Size(675, 275);
            this.panel1.Size = new System.Drawing.Size(475, 200);
            b1 = pb1;
            b2 = pb2;
            label1.Text = b1.type+"'s Collection";
            label2.Text = b2.type+"'s Collection";
            myLines = new List<string>();
            
        }
        public List<string> getlist()
        {

            return myLines;
        }
        private void connection_Load(object sender, EventArgs e)
        {
            foreach (string x in b1.port.input)
            {
                comboBox1.Items.Add(" Input  "+x);
            }

            foreach (string x in b1.port.output)
            {
                comboBox1.Items.Add(" Output  " +x);
            }
            foreach (string x in b2.port.input)
            {
                comboBox2.Items.Add(" Input  " + x);
            }

            foreach (string x in b2.port.output)
            {
                comboBox2.Items.Add(" Output  " +x);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem!=null&& comboBox2.SelectedItem!=null)
            {
                string a = b1.type + comboBox1.SelectedItem.ToString();
                string b = b2.type + comboBox2.SelectedItem.ToString();
        
                myLines.Add(a + " <===========> " + b+";");
                int n = myLines.Count();
               int PointY = 10;
                for (int i = 0; i < n; i++)
                {

                    Label x = new Label();
                    x.Text = myLines[i];
                    x.Location = new Point(0, PointY);
                    x.Font = new Font("Bold", 12);
                    x.AutoSize = true;
                    this.panel1.Controls.Add(x);
                    
                    PointY += x.Height;
                    
                }
            }
        }
    }
}
