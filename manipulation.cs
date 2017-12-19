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

    public class manipulation : PictureBox
    {
        private Graphics gs;
        private DGI01 form;
        public string type
        { get;}
        private Point P1;
        private Point P2;
        private List<manipulation> PictureBoxs1;
        private PictureBox trash;
        private RadioButton R1;
        private RadioButton R2;
        private RadioButton R3;
        public List<CLines> lines;
        public ports port
         { get; }
        public manipulation(DGI01 f, string n, List<manipulation> P, PictureBox trashbox, RadioButton R01, RadioButton R02, RadioButton R03, ref List<CLines> l,ports p)
        {
            form = f;
            type = n;
            this.MouseMove += new MouseEventHandler(mousemove);
            this.DoubleClick += new EventHandler(element_doubleclick);
            this.MouseHover += new EventHandler(Mouse_Hover);
            this.MouseClick += new MouseEventHandler(mouse_click);
            this.MouseDown += new MouseEventHandler(mouse_down);
            this.MouseUp += new MouseEventHandler(mouse_up);
            gs = form.CreateGraphics();
            PictureBoxs1 = P;
            trash = trashbox;
            R1 = R01;
            R2 = R02;
            R3 = R03;
            lines = l;
            port = p;
        }
        private void mouse_click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && R3.Checked)
            {
                //Debug.WriteLine(this.Location);
                PictureBoxs1.Remove(this);
                form.Controls.Remove(this);
                List<CLines> cl_remove = new List<CLines>();
                foreach (CLines cl in lines)
                {
                    if (cl.B1 == this || cl.B2 == this)
                    {
                        cl_remove.Add(cl);
                    }

                }
                foreach (CLines c1 in cl_remove)
                {
                    lines.Remove(c1);
                }

                keepdrawing();
            }
            else if (e.Button == MouseButtons.Left && R3.Checked)
            {
                List<CLines> cl_remove = new List<CLines>();
                foreach (CLines cl in lines)
                {
                    if (cl.B1 == this || cl.B2 == this)
                    {
                        cl_remove.Add(cl);
                    }

                }
                foreach (CLines c1 in cl_remove)
                {
                    lines.Remove(c1);
                }

                keepdrawing();
            }


        }
        private void mouse_down(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && R2.Checked)
            {
                Debug.WriteLine("MouseDown:   " + this.Location);
                P1.X = this.Location.X + this.Width / 2;
                P1.Y = this.Location.Y + this.Height / 2;

            }


        }
        private void mouse_up(object sender, MouseEventArgs e)
        {
            form.Refresh();
            keepdrawing();
            if (e.Button == MouseButtons.Left && R2.Checked)
            {
                Point P3 = form.PointToClient(Cursor.Position);
                for (int x = 0; x < PictureBoxs1.Count(); x++)
                {

                    if (PictureBoxs1[x].Location.X < P3.X && (PictureBoxs1[x].Location.X + PictureBoxs1[x].Width) > P3.X
           && PictureBoxs1[x].Location.Y < P3.Y && (PictureBoxs1[x].Location.Y + PictureBoxs1[x].Height) > P3.Y)
                    {
                        if (this != PictureBoxs1[x])
                        {


                            CLines cc = new CLines(this, PictureBoxs1[x], form);
                            lines.Add(cc);
                            form.Refresh();
                            keepdrawing();

                            break;
                        }
                    }
                }
            }
        }
        private void Mouse_Hover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this, type);

        }
        private void element_doubleclick(object sender, EventArgs e)
        {

            List<CLines> collection = new List<CLines>();
                     //Debug.WriteLine(lines.Count());
            foreach (CLines l in lines)
            {
                
               if (l.B1 == this || l.B2 == this)
                {
                    collection.Add(l);
                                   /*  foreach (string x in l.myLines)
                                    {
                                      Debug.WriteLine(x);
                                }*/

                }
            }
    
            parameters setting = new parameters(collection);
            setting.ShowDialog();

        }   
       
        private void mousemove(object sender, MouseEventArgs e)
        {

            var p = form.PointToClient(Cursor.Position);
            p.X -= this.Width / 2;
            p.Y -= this.Height / 2;
            //Debug.WriteLine(p);

            if (e.Button == MouseButtons.Left && R1.Checked)
            {

                this.Location = p;

                form.Refresh();

                keepdrawing();

            }
            else if (e.Button == MouseButtons.Left && R2.Checked)
            {
                P2 = form.PointToClient(Cursor.Position);


                form.Refresh();
                Brush br1 = new SolidBrush(Color.SteelBlue);
                Pen p1 = new Pen(br1, 5);
                /*Point m1 = new Point((P1.X + P2.X) / 2, P1.Y);
                Point m2 = new Point(m1.X, P2.Y);
                gs.DrawLine(p1, P1, m1);
                gs.DrawLine(p1, m1, m2);
                gs.DrawLine(p1, m2, P2);*/

                p1.EndCap = LineCap.ArrowAnchor;
                gs.DrawLine(p1, P1, P2);
                keepdrawing();
            }
               this.BringToFront();
            if (trash.Bounds.IntersectsWith(this.Bounds))
            {
                PictureBoxs1.Remove(this);
                form.Controls.Remove(this);
                List<CLines> cl_remove = new List<CLines>();
                foreach (CLines cl in lines)
                {
                    if (cl.B1 == this || cl.B2 == this)
                    {
                        cl_remove.Add(cl);
                    }

                }
                foreach (CLines c1 in cl_remove)
                {
                    lines.Remove(c1);
                }

                keepdrawing();
                trash.Image = Properties.Resources.newtrash;
            }
        }
        public void keepdrawing()
        {
            this.Refresh();

            foreach (CLines cc in lines)
            {
                cc.Drawing(gs);
            }
        }
    }
}

