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
using System.Data.SqlClient;

namespace DGI01
{
    public partial class DGI01 : Form
    {

        public List<manipulation> PictureBoxs1;
        public PictureBox trashbox;
        public RadioButton R1;
        public RadioButton R2;
        public RadioButton R3;
        public List<CLines> connection;
        
        unity Fan;
        unity Conduit;
        unity Inlet_conduit;
        unity Flow_merge;
        unity Damper;
        ports fan=new ports();
        ports conduit = new ports();
        ports inlet_conduit = new ports();
        ports damper = new ports();
        ports flow_merge = new ports();

        public DGI01()
        {
            InitializeComponent();
            this.Size = new Size(3000, 1500);
            PictureBoxs1 = new List<manipulation>();
            connection = new List<CLines>();
            trash = trashbox;
            trash.Location = new Point(1150,550);
            label1.Location = new Point(576,610);
            R1 = radioButton1;
            R2 = radioButton2;
            R3 = radioButton3;
            R1.Checked = true;

            fan.input = new List<string> {"M1","P1","S1","T1"};
            fan.output = new List<string> { "P1", "T1", "C1" };
            conduit.input = new List<string> {"M1","P1","T1","T2","T3" };
            conduit.output = new List<string> {"T1","P1" };
            inlet_conduit.input = new List<string> {"P1","P2","T1","T2","T3" };
            inlet_conduit.output = new List<string> {"T1","M1"};
            flow_merge.input = new List<string> {"M1","M2","P1","T1","T2"};
            flow_merge.output = new List<string> {"M1","P1","P2","T1" };
            damper.input = new List<string> { "M1","P1","F1"};
            damper.output = new List<string> { "P1"};

            Fan = new unity(this, "Fan", PictureBoxs1,trashbox,R1,R2,R3,ref connection,fan);
            Fan.Image = Properties.Resources.Fan_512;
            Fan.Location = new System.Drawing.Point(0, 0);
            Fan.Size = new System.Drawing.Size(60, 65);
            Fan.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            Fan.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            Conduit = new unity(this, "Conduit", PictureBoxs1, trashbox, R1, R2, R3, ref connection,conduit);
            Conduit.Image = Properties.Resources.Conduit;
            Conduit.Location = new System.Drawing.Point(0, 65);
            Conduit.Size = new System.Drawing.Size(60, 65);
            Conduit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            Conduit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

            Inlet_conduit = new unity(this, "Inlet conduit", PictureBoxs1, trashbox, R1, R2, R3, ref connection, inlet_conduit);
            Inlet_conduit.Image = Properties.Resources.Inlet_conduit;
            Inlet_conduit.Location = new System.Drawing.Point(0, 65 * 2);
            Inlet_conduit.Size = new System.Drawing.Size(60, 65);
            Inlet_conduit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            Inlet_conduit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            Flow_merge = new unity(this, "Flow merge", PictureBoxs1, trashbox, R1, R2, R3, ref connection, flow_merge);
            Flow_merge.Image = Properties.Resources.Flow_merge;
            Flow_merge.Location = new System.Drawing.Point(0, 65 * 3);
            Flow_merge.Size = new System.Drawing.Size(60, 65);
            Flow_merge.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            Flow_merge.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            Damper = new unity(this, "Damper", PictureBoxs1, trashbox, R1, R2, R3, ref connection,damper);
            Damper.Image = Properties.Resources.Damper;
            Damper.Location = new System.Drawing.Point(0, 65 * 4);
            Damper.Size = new System.Drawing.Size(60, 65);
            Damper.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            Damper.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(Fan);
            this.panel1.Controls.Add(Conduit);
            this.panel1.Controls.Add(Inlet_conduit);
            this.panel1.Controls.Add(Flow_merge);
            this.panel1.Controls.Add(Damper);
            panel1.Size = new System.Drawing.Size(83, 65 * 3 + 3);
            panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); 
            SetStyle(ControlStyles.DoubleBuffer, true);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");

        }
        private void DGI01_Load(object sender, EventArgs e)
        {

        }
    }
}
