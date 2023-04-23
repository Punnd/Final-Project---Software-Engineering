using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace finalproject
{
    public partial class main : Form
    {
        
        public main()
        {
            InitializeComponent();
        }

        private void gooToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.TopLevel = false;
            f4.FormBorderStyle = FormBorderStyle.None;
            f4.Dock = DockStyle.Fill;
            panel1.Controls.Add(f4);
            panel1.Tag = f4;
            f4.Show();
        }



        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void main_AutoSizeChanged(object sender, EventArgs e)
        {
            if (panel1.Tag != null)
            {
                ((Form)panel1.Tag).Size = Size;
            }
            //panel1.Size = this.ClientSize;
        }

        private void deliveryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            delivery delivery = new delivery();
            delivery.TopLevel = false;
            delivery.FormBorderStyle = FormBorderStyle.None;
            delivery.Dock = DockStyle.Fill;
            panel1.Controls.Add(delivery);
            panel1.Tag = delivery;
            delivery.Show();
        }
    }
}
