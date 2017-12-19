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
    public class ports
    {
        public List<string> input
        { get; set; }
        public List<string> output
        { get; set; }
        public List<string> coefficient
        { get; set; }
        public ports()
        { }
    }
}
