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
    
    public partial class New_Project : MetroFramework.Forms.MetroForm
    {
       


        List<Button> bls = new List<Button>();
        int n;
        List<TabPage> pages = new List<TabPage>();
        List<tab> tablist = new List<tab>();
        public New_Project()
        {
            InitializeComponent();
            label1.Location = new Point(22, 65);
            label1.Size = new Size(528,46);
            textBox1.Location = new Point(231,65);
            textBox1.Size = new Size(100,24);
            metroTile1.Location = new Point(336,65);
            metroTile1.Size = new Size(240,24);
            hideTabs();
            
        }
        public void hideTabs()
        {
            tabControl1.Width = 0;
            
        }
        private void New_Project_Load(object sender, EventArgs e)
        {

        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text !="")
            {
                 n = Convert.ToInt32(textBox1.Text);
                tabControl1.Location = new Point(8, 94);
                tabControl1.Size = new Size(1255, 580);
                tabControl1.TabPages.Clear();
                pages.Clear();
                tablist.Clear();
                for (int i = 1; i <=n; i++)
                {
                    TabPage page=new TabPage();
                    page.Text = "Superblock " + i;
                    pages.Add(page);
                    tabControl1.TabPages.Add(page);
                }
                gen_blocks();


            }
        }
      

        public void gen_blocks()
        {
            
            foreach (TabPage x in tabControl1.TabPages)
            {
                Label Numberblocks = new Label();
                Numberblocks.Text = "No. blocks:";
                Numberblocks.Location = new Point(0, 12);
                Numberblocks.Size = new Size(65, 20);
                TextBox number = new TextBox();
                number.Location = new Point(65, 10);
                number.Size = new Size(60, 20);
                
                Button B = new Button();
                B.Text = "Create Blocks";
                B.Location = new Point(129, 8);
                B.Size = new Size(100, 24);
                
                Panel genblocks = new Panel();
                genblocks.Location = new Point(5, 41);
                genblocks.Size = new Size(82, 500);
                genblocks.BorderStyle = System.Windows.Forms.BorderStyle.None;
                genblocks.AutoScroll = true;
                B.Click += new EventHandler(B_Click);
                x.Controls.Add(Numberblocks);
                x.Controls.Add(number);
                x.Controls.Add(B);
                x.Controls.Add(genblocks);
                tab newpage = new tab(B,number,genblocks);
                tablist.Add(newpage);
            }
        }
        private void B_Click(object sender, EventArgs e)
        {
            gen_units();
        }
       void gen_units()
        {
            int x = tabControl1.SelectedIndex;
            int num;
            if (tablist[x].TB.Text != "")
            {
                bls.Clear();
                tablist[x].blocks.Controls.Clear();
                num = Convert.ToInt32(tablist[x].TB.Text);
                for (int s = 1; s <= num; s++)
                {
                    Button BL = new Button();
                    BL.Location = new Point(0, (s - 1) * 30);
                    BL.Size = new Size(62, 30);
                    BL.Text = "BL " + s;
                    BL.Font = new Font("regular", 12.5f);
                    BL.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
                    BL.ForeColor = Color.DarkBlue;
                    BL.Click += new EventHandler(BL_Click);
                    tablist[x].blocks.Controls.Add(BL);
                    bls.Add(BL);
                }
            }
        }
        private void BL_Click(object sender, EventArgs e)
        {

            Panel genunits = new Panel();
            genunits.Location = new Point(90, 40);
            genunits.Size = new Size(1150, 530);
            genunits.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            genunits.AutoScroll = true;
            tabControl1.SelectedTab.Controls.Add(genunits);
            //this.Hide();
            DGI01 newwin = new DGI01();
            newwin.ShowDialog();
            



            


        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
