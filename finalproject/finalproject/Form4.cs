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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int count = 0;
            count = grd1.Rows.Count;
            if (count + 1 < 10)
            {
                textBox1.Text = "I000" + count.ToString();
            }
            else if (count + 1 < 100)
            {
                textBox1.Text = "I00" + count.ToString();
            }
            else
            {
                textBox1.Text = "I0" + count.ToString();
            }
        }
    }
}
