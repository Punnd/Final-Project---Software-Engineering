using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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

        public void connect()
        {
            string s = "initial catalog = final; data source = LAPTOP-90QEEVDN; integrated security = true";
            cn = new SqlConnection(s);
            cn.Open();

        }
        public DataTable selectQuery(string sql)
        {
            connect();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sql, cn);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            return dt;
        }

        public void autoId()
        {
            string s = "select DISTINCT id FROM delivery order by id ";
            data = new SqlDataAdapter(s, cn);
            tb = new DataTable();
            data.Fill(tb);


            if (tb.Rows.Count == 0)
            {
                txtiddelivery.Text = "DL0001";
            }
            else
            {

                string res = "";

                int stt = tb.Rows.Count;
                stt++;
                if (stt < 10)
                    res += "DL" + "000" + (stt).ToString();
                else if (stt < 100)
                    res += "DL" + "00" + (stt).ToString();
                else if (stt < 1000)
                    res += "DL" + "0" + (stt).ToString();
                else
                    res += "DL" + (stt).ToString();

                txtiddelivery.Text = res;
            }

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
            /*string sql = "initial catalog = final; data source = LAPTOP-90QEEVDN; integrated security = true";

            cn = new SqlConnection(sql);

            cn.Open();*/

            connect();

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

            int a = 0;

            //autoId();

            string s1 = "select DISTINCT id FROM delivery order by id ";
            data = new SqlDataAdapter(s1, cn);
            tb = new DataTable();
            data.Fill(tb);


            if (tb.Rows.Count == 0)
            {
                txtiddelivery.Text = "DL0001";
            }
            else
            {

                string res = "";

                int stt = tb.Rows.Count;
                stt++;
                if (stt < 10)
                    res += "DL" + "000" + (stt).ToString();
                else if (stt < 100)
                    res += "DL" + "00" + (stt).ToString();
                else if (stt < 1000)
                    res += "DL" + "0" + (stt).ToString();
                else
                    res += "DL" + (stt).ToString();

                txtiddelivery.Text = res;
            }



            delivery_note.Clear();

            delivery_note.Text += "***********************************************\n\n";
            delivery_note.Text += "************     DELIVERY NOTE     ************\n\n";
            delivery_note.Text += "***********************************************\n\n";
            delivery_note.Text += "Date: " + DateTime.Now + "\n\n";

            delivery_note.Text += "Accountant: " + id_acc + "\n\n";
            delivery_note.Text += "Agent: " + txtemail.Text + "\n\n";

            delivery_note.Text += "List of phones: " + "\n";
            
            for(int i = 0; i < grd2.Rows.Count-1 ; i++)
            {
                delivery_note.Text += i + ":" + grd2.Rows[i].Cells[0].Value.ToString() + "," + grd2.Rows[i].Cells[5].Value.ToString() + "," + grd2.Rows[i].Cells[6].Value.ToString() + " - Total : " + grd2.Rows[i].Cells[7].Value.ToString() + "\n";
            }

            delivery_note.Text += "-----------------------------------------------\n\n";


            for(int i = 0; i < grd2.Rows.Count - 1; i++)
            {
                

                string s = Convert.ToString(grd2.Rows[i].Cells[0].Value);

                if(s != null)
                {
                    string query = "select * from phone where id = '" + s + "'";

                    DataTable dt = selectQuery(query);
                    if(dt.Rows.Count != 0)
                    {
                        for(int j = 0; j < grd1.Rows.Count - 1 ; j++)
                        {
                            string l = Convert.ToString(grd1.Rows[j].Cells[0].Value);

                            if (l != null)
                            {
                                string query_1 = "select * from phone where id = '" + l + "'";

                                DataTable dl = selectQuery(query_1);

                                if (dl.Rows.Count > 0 && l == s )
                                {
                                    int x = Convert.ToInt32(grd1.Rows[j].Cells[6].Value);
                                    int y = Convert.ToInt32(grd2.Rows[i].Cells[6].Value);
                                    int t = Convert.ToInt32(grd1.Rows[i].Cells[5].Value);
                                    int z = x - y;
                                    int w = z * t;

                                    query = "update phone set price = '" + grd1.Rows[i].Cells[5].Value.ToString() + "', quantity = '" + z.ToString() + "', total = '" + w.ToString() + "' where id = '" + grd2.Rows[i].Cells[0].Value.ToString() + "'";
                                    cm = new SqlCommand(query, cn);
                                    cm.ExecuteNonQuery();

                                    

                                }
                            }
                        }
                    }
                }
                int b = Convert.ToInt32(grd2.Rows[i].Cells[7].Value);

                a = a + b;

                string detail = "insert into delivery_detail values ('"  + txtiddelivery.Text + "','" + grd2.Rows[i].Cells[0].Value.ToString() + "','" + grd2.Rows[i].Cells[6].Value + "','" + grd2.Rows[i].Cells[7].Value + "')";

                cm = new SqlCommand(detail, cn);
                cm.ExecuteNonQuery();
            }

            string deliveryy = "insert into delivery values ('" + txtiddelivery.Text + "', '" + id_acc.ToString() + "', '" + txtIDagent.Text + "','" + txtadd.Text + "','" + DateTime.Today.ToString() + "', '" + a + "') ";
            cm = new SqlCommand(deliveryy, cn);
            cm.ExecuteNonQuery();


            string delete = "delete from phone_fake";
            cm = new SqlCommand(delete, cn);
            cm.ExecuteNonQuery();


            formload();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            
        }

        private void delivery_note_TextChanged(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int x = 10;
            int y = 0;
            int charpos = 0;
            while (charpos < delivery_note.Text.Length)
            {
                if (delivery_note.Text[charpos] == '\n')
                {
                    charpos++;
                    y += 20;
                    x = 10;
                }
                else if (delivery_note.Text[charpos] == '\r')
                {
                    charpos++;
                }
                else
                {
                    delivery_note.Select(charpos, 1);
                    e.Graphics.DrawString(delivery_note.SelectedText, delivery_note.SelectionFont, new SolidBrush(delivery_note.SelectionColor), new PointF(x, y));
                    x = x + 8;
                    charpos++;
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            PrintDocument doc = new PrintDocument();
            PrintDialog pd = new PrintDialog();
            PrintPreviewDialog ppd = new PrintPreviewDialog();
            ppd.Document = doc;
            pd.Document = doc;
            doc.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            if (ppd.ShowDialog() == DialogResult.OK)
            {
                if (pd.ShowDialog() == DialogResult.OK)
                {
                    doc.Print();
                }
            }
        }
    }
}
