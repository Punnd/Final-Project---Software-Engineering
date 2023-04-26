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
            string s = "select top 1 id from reveived order by id desc ";
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
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string s = "select top 1 id from reveived order by id desc ";
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
            }

            
        }
        public void showGRD1()

        {

            string s = "select * from phone_fake";

            data = new SqlDataAdapter(s, cn);

            tb = new DataTable();

            data.Fill(tb);

            grd1.DataSource = tb;

        }

        void formload()
        {

            button4.Enabled = false;

            button5.Enabled = false;

            button6.Enabled = false;

            button7.Enabled = true;




            showGRD1();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            string sql = "initial catalog = final; data source = LAPTOP-90QEEVDN; integrated security = true";

            cn = new SqlConnection(sql);

            cn.Open();

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

            autoId();
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

        private void button1_Click(object sender, EventArgs e)
        {

            string sql = "initial catalog = final; data source = LAPTOP-90QEEVDN; integrated security = true";

            cn = new SqlConnection(sql);

            cn.Open();

            for (int i = 0; i < grd1.Rows.Count-1; i++)
            {
                string newValue = grd1.Rows[i].Cells[0].Value.ToString(); // Lấy giá trị mới của ô
                //string id = grd1.Rows[i].Cells["id"].Value.ToString(); // Lấy giá trị id của dòng tương ứng

                //string connString = "your_connection_string";
                string query = "SELECT * FROM phone WHERE id = '" + newValue + "'"; // Lấy giá trị cột thứ 0 trong database
                using (SqlConnection conn = new SqlConnection(sql))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        
                        while (reader.Read()) // Duyệt qua từng hàng trong bảng
                        {
                            // Lấy giá trị của cột thứ 0 trong hàng đang duyệt của database
                            int dbValue = reader.GetInt32(reader.GetOrdinal("id")); // Thay column_name bằng tên cột tương ứng

                            // Lấy giá trị của cột thứ 0 trong hàng đang duyệt của DataGridView
                            int dgvValue = Convert.ToInt32(grd1.Rows[i].Cells[0].Value); // Giả sử cột thứ 0 là cột đầu tiên

                            // So sánh giá trị của hai cột
                            if (dbValue == dgvValue)
                            {
                                // Các giá trị khớp nhau
                            }
                            else
                            {
                                query = "insert into phone values ('" + grd1.Rows[i].Cells[0].ToString() + "','" + grd1.Rows[i].Cells[1].ToString() + "','" + grd1.Rows[i].Cells[2].ToString() + "','" + grd1.Rows[i].Cells[3].ToString() + "','" + grd1.Rows[i].Cells[4].ToString() + "','" + grd1.Rows[i].Cells[5].ToString() + "','" + grd1.Rows[i].Cells[6].ToString() + "','" + grd1.Rows[i].Cells[7].ToString() + "')";
                                cm = new SqlCommand(query, cn);
                                cm.ExecuteNonQuery();
                            }

                            
                        }
                    }
                    conn.Close();
                }
            }
        }
        //public string 
    }
}
