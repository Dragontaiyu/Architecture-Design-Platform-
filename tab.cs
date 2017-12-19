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
   public class tab
    {
        public Button B
        { get; set; }
        public TextBox TB
        { get; set; }
        public Panel blocks
        { get; set; }
        public tab(Button b,TextBox t, Panel p)
        {
            B = b;
            TB = t;
            blocks = p;
        }
    }
}
