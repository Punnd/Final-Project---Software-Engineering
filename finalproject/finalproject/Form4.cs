using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace finalproject
{
    public partial class Form4 : Form
    {
        SqlConnection cn;

        SqlDataAdapter data;

        SqlCommand cm;

        DataTable tb;

        int dk = 0;
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
            txtid.Text = grd1.CurrentRow.Cells[0].Value.ToString();

            txtbrand.Text = grd1.CurrentRow.Cells[1].Value.ToString();

            txtname.Text = grd1.CurrentRow.Cells[2].Value.ToString();

            txtram.Text = grd1.CurrentRow.Cells[3].Value.ToString();

            txtstorage.Text = grd1.CurrentRow.Cells[4].Value.ToString();

            txtprice.Text = grd1.CurrentRow.Cells[5].Value.ToString();

            txtquantity.Text = grd1.CurrentRow.Cells[6].Value.ToString();




            button5.Enabled = true;

            button6.Enabled = true;
        }

        public void autoId()
        {
            /*string s = "select top 1 id from reveived order by id desc ";
            data = new SqlDataAdapter(s, cn);
            tb = new DataTable();
            data.Fill(tb);

            if (tb.Rows.Count > 0)
            {
                txtGR.Text = "GR0001";
            }
            else
            {
                txtGR.Text = "GR0001";
            }*/

            string s = "select top 1 id from reveived order by id desc ";
            data = new SqlDataAdapter(s, cn);
            tb = new DataTable();
            data.Fill(tb);


            if (tb.Rows.Count == 0)
            {
                txtGR.Text = "GR0001";
            }
            else
            {

                string res = "";

                int stt = tb.Rows.Count;
                stt++;
                if (stt < 10)
                    res += "GR" + "000" + (stt).ToString();
                else if (stt < 100)
                    res += "GR" + "00" + (stt).ToString();
                else if (stt < 1000)
                    res += "GR" + "0" + (stt).ToString();
                else
                    res += "GR" + (stt).ToString();

                txtGR.Text = res;
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            /*string s = "select top 1 id from reveived order by id desc ";
            data = new SqlDataAdapter(s, cn);
            tb = new DataTable();
            data.Fill(tb);
            
            if (tb.Rows.Count > 0)
            {
                txtGR.Text = "GR0001";
            }
            else
            {
                txtGR.Text = "GR0001";
            }*/

            
        }
        public void showGRD1()

        {

            string s = "select * from phone_fake";

            data = new SqlDataAdapter(s, cn);

            tb = new DataTable();

            data.Fill(tb);

            grd1.DataSource = tb;

        }

        public void showGRD2()

        {

            string s = "select * from phone";

            data = new SqlDataAdapter(s, cn);

            tb = new DataTable();

            data.Fill(tb);

            grd2.DataSource = tb;

        }

        void formload()
        {

            button4.Enabled = false;

            button5.Enabled = false;

            button6.Enabled = false;

            button7.Enabled = false;


            

            showGRD1();

            showGRD2();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            /*string sql = "initial catalog = final; data source = LAPTOP-90QEEVDN; integrated security = true";

            cn = new SqlConnection(sql);

            cn.Open();*/

            connect();

            formload();
        }

        private void grd1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            txtid.Clear();
            txtbrand.Clear();
            txtname.Clear();
            txtram.ResetText();
            txtstorage.ResetText();
            txtprice.Clear();
            txtquantity.Clear();

            txtid.Focus();

            dk = 1;

            
            button4.Enabled = true;


        }

        private void button4_Click(object sender, EventArgs e)
        {
            int value1 = int.Parse(txtprice.Text);
            int value2 = int.Parse(txtquantity.Text);

            // Multiply the values
            double result = value1 * value2;

            if (dk == 1)
            {
                string s = "select * from phone_fake where id_f = '" + txtid.Text + "' ";
                data = new SqlDataAdapter(s, cn);
                tb = new DataTable();
                data.Fill(tb);
                if (tb.Rows.Count > 0)
                {
                    MessageBox.Show("Phone exists");
                    return;
                }

                s = "insert into phone_fake values ('" + txtid.Text + "','" + txtbrand.Text + "','" + txtname.Text + "','" + txtram.Text + "','" + txtstorage.Text + "','" + int.Parse(txtprice.Text) + "','" + int.Parse(txtquantity.Text) + "','" + int.Parse(result.ToString()) + "')";

                cm = new SqlCommand(s, cn);
                cm.ExecuteNonQuery();
            }
            else //dk =2
            {
                //Update
                string s = "update phone_fake set brand_f = '" + txtbrand.Text + "', name_f = '" + txtname.Text + "', ram_f = '" + int.Parse(txtram.Text) + "', gb_f = '" + int.Parse(txtstorage.Text) + "', price_f = '" + int.Parse(txtprice.Text) + "', quantity_f = '" + int.Parse(txtquantity.Text.ToString()) + "', total_f = '" + result + "' where id_f = '" + txtid.Text + "'";
                cm = new SqlCommand(s, cn);
                cm.ExecuteNonQuery();
            }
            formload();
        }

        private void button5_Click(object sender, EventArgs e)
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

        private void button6_Click(object sender, EventArgs e)
        {
            txtid.Enabled = false;
            txtname.Focus();
            button4.Enabled = true;
            dk = 2;
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

        private void button1_Click(object sender, EventArgs e)
        {
            string id_acc = Form1.email_acc;

            int to = 0;

            for (int i = 0; i < grd1.Rows.Count-1; i++)
            {

                string s = Convert.ToString(grd1.Rows[i].Cells[0].Value);

                

                if (s != null)
                {
                    string query = "select * from phone where id = '" + s + "'";

                    DataTable dt = selectQuery(query);


                    if (dt.Rows.Count == 0)
                    {
                        query = "insert into phone values ('" + grd1.Rows[i].Cells[0].Value.ToString() + "','" + grd1.Rows[i].Cells[1].Value.ToString() + "','" + grd1.Rows[i].Cells[2].Value.ToString() + "','" + grd1.Rows[i].Cells[3].Value.ToString() + "','" + grd1.Rows[i].Cells[4].Value.ToString() + "','" + grd1.Rows[i].Cells[5].Value.ToString() + "','" + grd1.Rows[i].Cells[6].Value.ToString() + "','" + grd1.Rows[i].Cells[7].Value.ToString() + "')";
                        cm = new SqlCommand(query, cn);
                        cm.ExecuteNonQuery();
                        //delivery d = new delivery();
                        //d.showGRD1();
                    }
                    else
                    {
                        for (int j = 0; j < grd2.Rows.Count - 1; j++)
                        {
                            string l = Convert.ToString(grd2.Rows[j].Cells[0].Value);

                            if (l != null)
                            {
                                string query_1 = "select * from phone where id = '" + l + "'";

                                DataTable dl = selectQuery(query);

                                if (dl.Rows.Count > 0)
                                {
                                    int x = Convert.ToInt32(grd2.Rows[j].Cells[6].Value);
                                    int y = Convert.ToInt32(grd1.Rows[i].Cells[6].Value);
                                    int t = Convert.ToInt16(grd1.Rows[i].Cells[5].Value);
                                    int z = x + y;
                                    int w = z * t;

                                    query = "update phone set brand = '" + grd1.Rows[i].Cells[1].Value.ToString() + "', name = '" + grd1.Rows[i].Cells[2].Value.ToString() + "', ram = '" + grd1.Rows[i].Cells[3].Value.ToString() + "', gb = '" + grd1.Rows[i].Cells[4].Value.ToString() + "', price = '" + grd1.Rows[i].Cells[5].Value.ToString() + "', quantity = '" + z.ToString() + "', total = '" + w.ToString() + "' where id = '" + grd1.Rows[i].Cells[0].Value.ToString() + "'";
                                    cm = new SqlCommand(query, cn);
                                    cm.ExecuteNonQuery();
                                }
                            }
                        }
                        
                        
                    }



                    
                }
                
                int a = Convert.ToInt32(grd1.Rows[i].Cells[7].Value);
                string m = "insert into reveived_detail values ('" + txtGR.Text + "','" + grd1.Rows[i].Cells[0].Value.ToString() + "','" + grd1.Rows[i].Cells[6].Value.ToString() + "','" + grd1.Rows[i].Cells[7].Value.ToString() + "')";

                to += a;

                cm = new SqlCommand(m, cn);
                cm.ExecuteNonQuery();
            }

            string r = "insert into reveived values ('" + txtGR.Text + "','" + id_acc.ToString() + "','" + DateTime.Now.ToString() + "','" + to + "')";
            cm = new SqlCommand(r, cn);
            cm.ExecuteNonQuery();




            string sql = "delete from phone_fake";
            cm = new SqlCommand(sql, cn);
            cm.ExecuteNonQuery();

            formload();

        }

        private void grd2_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            button7.Enabled = true;
            autoId();
        }
        //public string 
    }
}
