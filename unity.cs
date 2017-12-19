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
    public class unity :PictureBox 
    {
        private Graphics gs;
        private DGI01 form;
        private string type;
        private List<manipulation> PictureBoxs1;
        private PictureBox trash;
        private RadioButton R1;
        private RadioButton R2;
        private RadioButton R3;
        private List<CLines> lines;
        private ports port;
        

        public unity(DGI01 f, string n,  List<manipulation> P, PictureBox trashbox, RadioButton R01, RadioButton R02, RadioButton R03,ref List<CLines> l,ports p)
        {
            form = f;
            type = n;
            this.MouseDown += new MouseEventHandler(mouse_down);
            this.MouseMove += new MouseEventHandler(Mouse_Move);
            gs = f.CreateGraphics();
            this.MouseHover += new EventHandler(Mouse_Hover);
            PictureBoxs1 = P;
            trash = trashbox;
            R1 = R01;
            R2 = R02;
            R3 = R03;
            lines = l;
            port = p;
        }
        private void Mouse_Hover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this, type);
        }
       private void mouse_down(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && R1.Checked)
            {
                manipulation newpicture = new manipulation(form, type, PictureBoxs1, trash, R1, R2, R3, ref lines,port);
                newpicture.Width = this.Width;
                newpicture.Height = this.Height;
                newpicture.Image = this.Image;
                newpicture.SizeMode = this.SizeMode;
                newpicture.BackColor = Color.Transparent;
                PictureBoxs1.Add(newpicture);
                newpicture.Location = this.Location;
                form.Controls.Add(newpicture);
                newpicture.BringToFront();
                newpicture.Refresh();
                

            }
        }
        private void Mouse_Move(object sender, MouseEventArgs e)
        {

            var p = form.PointToClient(Cursor.Position);


            if (PictureBoxs1.Count() - 1 >= 0 && e.Button == MouseButtons.Left && R1.Checked)
            {
                p.X -= PictureBoxs1[PictureBoxs1.Count() - 1].Width / 2;
                p.Y -= PictureBoxs1[PictureBoxs1.Count() - 1].Height / 2;
                Point mousePoint = p;
                PictureBoxs1[PictureBoxs1.Count() - 1].Location = mousePoint;
                this.Refresh();
                form.Refresh();//add here
                keepdrawing();

            }
            else
            { return; }

        }
        private void keepdrawing()
        {

            this.Refresh();
            foreach (CLines cc in lines)
            {
                cc.Drawing(gs);
            }
        }
    }
}