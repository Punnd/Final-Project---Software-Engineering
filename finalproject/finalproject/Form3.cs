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
    public partial class Form3 : Form
    {

        SqlConnection cn;

        SqlDataAdapter data;

        SqlCommand cm;

        DataTable tb;
        public Form3()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            connect();

            formload();
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

        public void showGRD1()
        {

            string s = "select * from P_Order where d_status = 0";

            data = new SqlDataAdapter(s, cn);

            tb = new DataTable();

            data.Fill(tb);

            grd1.DataSource = tb;

        }

        public void showGRD2()
        {

            string s = "select * from Order_detail";

            data = new SqlDataAdapter(s, cn);

            tb = new DataTable();

            data.Fill(tb);

            grd2.DataSource = tb;

        }

        public void showGRD3()
        {

            string s = "select * from phone";

            data = new SqlDataAdapter(s, cn);

            tb = new DataTable();

            data.Fill(tb);

            grd3.DataSource = tb;

        }

        void formload()
        {
            button1.Visible = false;

            button2.Visible = false;

            showGRD1();

            //showGRD2();

            showGRD3();
        }

        private void grd1_Click(object sender, EventArgs e)
        {
            button1.Visible = true;

            button2.Visible = true;

            id_agent.Text = grd1.CurrentRow.Cells[1].Value.ToString();

            id_order.Text = grd1.CurrentRow.Cells[0].Value.ToString();

            address.Text = grd1.CurrentRow.Cells[3].Value.ToString();

            string s = "select * from Order_detail where order_id = '" + grd1.CurrentRow.Cells[0].Value.ToString() + "' ";

            data = new SqlDataAdapter(s, cn);

            tb = new DataTable();

            data.Fill(tb);

            grd2.DataSource = tb;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string s1 = "delete from Order_detail where order_id = '" + grd1.CurrentRow.Cells[0].Value.ToString() + "'";
            string s2 = "delete from P_Order where id = '" + grd1.CurrentRow.Cells[0].Value.ToString() + "'";

            data = new SqlDataAdapter(s1, cn);

            data = new SqlDataAdapter(s2, cn);

            tb = new DataTable();

            data.Fill(tb);

            grd2.DataSource = tb;

            formload();

        }

        public void autoId()
        {

            string s = "select DISTINCT id FROM delivery order by id ";
            data = new SqlDataAdapter(s, cn);
            tb = new DataTable();
            data.Fill(tb);


            if (tb.Rows.Count == 0)
            {
                textBox1.Text = "DL0001";
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

                textBox1.Text = res;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string id_acc = Form1.email_acc;

            int a = 0;

            autoId();

            for( int i = 0; i < grd2.Rows.Count -1; i++ )
            {

                int s = Convert.ToInt32(grd2.Rows[i].Cells[0].Value);

                string l = Convert.ToString(grd2.Rows[i].Cells[2].Value);

                if( s != null && l != null)
                {

                    string query = "select * from phone where id = '" + l +"'"; 

                    DataTable dt = selectQuery(query);

                    if(dt.Rows.Count != 0)
                    {
                        for ( int j = 0; j < grd3.Rows.Count - 1; j++)
                        {
                            //string or_de = grd2.Rows[i].Cells[2].ToString();

                            string phone = grd3.Rows[j].Cells[0].Value.ToString();

                            if( String.Compare(l,phone, true) ==0 )
                            {
                                int x = Convert.ToInt32(grd3.Rows[j].Cells[5].Value);

                                int y = Convert.ToInt32(grd2.Rows[i].Cells[4].Value);

                                int z = Convert.ToInt32(grd3.Rows[j].Cells[6].Value);

                                int w = z - y;

                                int t = w * x;

                                string query_1 = "update phone set quantity = '" + w + "' where id = '" + l + "' ";
                                cm = new SqlCommand(query_1, cn);
                                cm.ExecuteNonQuery();
                                string query_2 = "update phone set total = '" + t + "' where id = '" + l + "'";
                                cm = new SqlCommand(query_2, cn);
                                cm.ExecuteNonQuery();

                            }
                            


                        }
                        //string x = Convert.ToString(grd2.Rows[i].Cells[2].Value);
                        
                        


                    }

                }

                int b = Convert.ToInt32(grd2.Rows[i].Cells[6].Value);

                a = a + b;

                string detail = "insert into delivery_detail values ('" + textBox1.Text +"', '" + grd2.Rows[i].Cells[2].Value.ToString() + "','" + grd2.Rows[i].Cells[4].Value.ToString() + "','" + grd2.Rows[i].Cells[6].Value.ToString() + "')";
                cm = new SqlCommand(detail, cn);
                cm.ExecuteNonQuery();
                

            }

            //textBox1: id of delivery

            string deliveryy = "insert into delivery values ('" + textBox1.Text + "', '" + id_acc.ToString() +"', '" + id_agent.Text + "', '" + address.Text + "' ,'"  + DateTime.Today.ToString() + "', '" + a + "') ";
            cm = new SqlCommand(deliveryy, cn);
            cm.ExecuteNonQuery();

            string order = "update P_Order set d_status = 1 , descrip = 'confirmed' where id = '"  + grd1.CurrentRow.Cells[0].Value + "' ";
            cm = new SqlCommand(order, cn);
            cm.ExecuteNonQuery();


            string sql = "delete from Order_detail where order_id = " + id_order.Text + ""; 
            cm = new SqlCommand(sql, cn);
            cm.ExecuteNonQuery();

            //showGRD2();

            formload();

        }

        private void grd1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
