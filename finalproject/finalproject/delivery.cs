using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace finalproject
{
    public partial class delivery : Form
    {
        SqlConnection cn;

        SqlDataAdapter data;

        SqlCommand cm;

        DataTable tb;

        int dk = 0;
        public delivery()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            delivery_note.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void showGRD1()
        {

            string s = "select * from phone";

            data = new SqlDataAdapter(s, cn);

            tb = new DataTable();

            data.Fill(tb);

            grd1.DataSource = tb;

        }

        public void showGRD2()

        {

            string s = "select * from phone_fake";

            data = new SqlDataAdapter(s, cn);

            tb = new DataTable();

            data.Fill(tb);

            grd2.DataSource = tb;

        }
        private void delivery_Load(object sender, EventArgs e)
        {
            string sql = "initial catalog = final; data source = LAPTOP-90QEEVDN; integrated security = true";

            cn = new SqlConnection(sql);

            cn.Open();

            formload();
        }

        

        void formload()
        {

            button1.Enabled = false;

            txtiddelivery.Enabled = false;

            txtid.Enabled = false;

            txtname.Enabled = false;

            txtbrand.Enabled = false;

            txtram.Enabled = false;

            txtstorage.Enabled = false;

            txttotal.Enabled = false;

            //button5.Enabled = false;

            //button6.Enabled = false;

            //button7.Enabled = true;

            //int s = int.Parse(txtprice.Text) * int.Parse(txtquantity.Text);

            

            grbox1.Visible = false;

            grbox1.Enabled = false;

            showGRD1();

            showGRD2();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.Enabled = false;
        }

        private void grd1_Click(object sender, EventArgs e)
        {
            txtid.Text = grd1.CurrentRow.Cells[0].Value.ToString();

            txtbrand.Text = grd1.CurrentRow.Cells[1].Value.ToString();

            txtname.Text = grd1.CurrentRow.Cells[2].Value.ToString();

            txtram.Text = grd1.CurrentRow.Cells[3].Value.ToString();

            txtstorage.Text = grd1.CurrentRow.Cells[4].Value.ToString();

            txtprice.Text = grd1.CurrentRow.Cells[5].Value.ToString();

            txtquantity.Text = grd1.CurrentRow.Cells[6].Value.ToString();

            //txttotal.Text = grd1.CurrentRow.Cells[7].Value.ToString();


            grbox1.Visible = true;

            grbox1.Enabled = true;
            

        }

        private void button4_Click(object sender, EventArgs e)
        {
            

            string s = "select * from phone_fake where id_f = '" + txtid.Text + "' ";
            data = new SqlDataAdapter(s, cn);
            tb = new DataTable();
            data.Fill(tb);

            int value1 = int.Parse(txtprice.Text);
            int value2 = int.Parse(txtquantity.Text);

            // Multiply the values
            double result = value1 * value2;

            s = "insert into phone_fake values ('" + txtid.Text + "','" + txtbrand.Text + "','" + txtname.Text + "','" + txtram.Text + "','" + txtstorage.Text + "','" + int.Parse(txtprice.Text) + "','" + int.Parse(txtquantity.Text) + "','" + int.Parse(result.ToString()) + "')";

            cm = new SqlCommand(s, cn);
            cm.ExecuteNonQuery();


            formload();

            button1.Enabled = true;
        }

        private void txttotal_TextChanged(object sender, EventArgs e)
        {
            //txtprice
        }

        private void txtprice_TextChanged(object sender, EventArgs e)
        {
            //int s = int.Parse(txtprice.Text) * int.Parse(txtquantity.Text);
            //txttotal.Text = s.ToString();
        }

        private void txtquantity_TextChanged(object sender, EventArgs e)
        {
            //int s = int.Parse(txtprice.Text) * int.Parse(txtquantity.Text);
            //txttotal.Text = s.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to delete?", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string sql = "delete from phone_fake where id_f ='" + txtid.Text + "'";
                cm = new SqlCommand(sql, cn);
                cm.ExecuteNonQuery();
                txtid.Clear();
                txtbrand.Clear();
                txtname.Clear();
                txtram.ResetText();
                txtstorage.ResetText();
                txtprice.Clear();
                txtquantity.Clear();
                formload();
            }
        }

        private void grd2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void grd2_Click(object sender, EventArgs e)
        {
            txtid.Text = grd2.CurrentRow.Cells[0].Value.ToString();

            txtbrand.Text = grd2.CurrentRow.Cells[1].Value.ToString();

            txtname.Text = grd2.CurrentRow.Cells[2].Value.ToString();

            txtram.Text = grd2.CurrentRow.Cells[3].Value.ToString();

            txtstorage.Text = grd2.CurrentRow.Cells[4].Value.ToString();

            txtprice.Text = grd2.CurrentRow.Cells[5].Value.ToString();

            txtquantity.Text = grd2.CurrentRow.Cells[6].Value.ToString();

            //txttotal.Text = grd1.CurrentRow.Cells[7].Value.ToString();


            grbox1.Visible = true;

            grbox1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id_acc = Form1.email_acc;

            delivery_note.Clear();

            delivery_note.Text += "***********************************************\n\n";
            delivery_note.Text += "************     DELIVERY NOTE     ************\n\n";
            delivery_note.Text += "***********************************************\n\n";
            delivery_note.Text += "Date: " + DateTime.Now + "\n\n";

            delivery_note.Text += "Accountant: " + id_acc + "\n\n";
            delivery_note.Text += "Agent: " + txtemail.Text + "\n\n";

            delivery_note.Text += "List of phones: " + "\n";
            
            for(int i = 1; i < grd2.Rows.Count-1 ; i++)
            {
                delivery_note.Text += i + ":" + grd2.Rows[i].Cells[0].Value.ToString() + "," + grd2.Rows[i].Cells[5].Value.ToString() + "," + grd2.Rows[i].Cells[6].Value.ToString() + " - Total : " + grd2.Rows[i].Cells[7].Value.ToString() + "\n";
            }

            delivery_note.Text += "-----------------------------------------------\n\n";

        }
    }
}
