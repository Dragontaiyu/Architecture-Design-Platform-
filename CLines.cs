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
    public class CLines
    {
        private DGI01 form;
        private string[] link;
        private Graphics gs;
        public List<string> myLines
        { get; set; }
        public manipulation B1
        {
            get; set;
        }
        public manipulation B2
        {
            get; set;
        }
        public CLines( manipulation pb1,manipulation pb2, DGI01 f)
        {
            B1 = pb1;
            B2 = pb2;
            form = f;
            gs = form.CreateGraphics();
            this.Drawing(gs);
            connection setting = new connection(pb1, pb2);
            setting.ShowDialog();
            myLines = new List<string>(setting.getlist());
            /*foreach (string s in myLines)
            {
                Debug.WriteLine(s);
            }*/
        }
        public void Drawing(Graphics gs)

        {
            int x1 = B1.Location.X + B1.Width / 2;
            int x2 = B2.Location.X + B2.Width / 2;
            int y1 = B1.Location.Y + B1.Height / 2;
            int y2 = B2.Location.Y + B2.Height / 2;

            Brush br1 = new SolidBrush(Color.RoyalBlue);
            Pen p1 = new Pen(br1, 3);
            gs.DrawLine(p1, x1, y1, x2, y2);
        }
        public void checking()
        {

        }
         
    }
}

