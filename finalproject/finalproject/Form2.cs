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
    public partial class Form2 : Form
    {
        SqlConnection cn;

        SqlDataAdapter data;

        SqlCommand cm;

        DataTable tb;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
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

            string s = "select * from reveived";

            data = new SqlDataAdapter(s, cn);

            tb = new DataTable();

            data.Fill(tb);

            grd1.DataSource = tb;

        }

        public void showGRD2()
        {

            string s = "select * from reveived_detail";

            data = new SqlDataAdapter(s, cn);

            tb = new DataTable();

            data.Fill(tb);

            grd2.DataSource = tb;

        }

        void formload()
        {
            monthCalendar1.Enabled = false;

            showGRD1();
            
            showGRD2();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string s = DateTime.Today.ToString();
            //DateTime dt = DateTime.Now;
            //string ketqua = dt.ToString("MM/dd/yyyy");
            string s = DateTime.Today.ToString("yyyy/MM/dd");
            if(s != null) 
            {
                string query = "select * from reveived where date = '" + s + "'";

                data = new SqlDataAdapter(query, cn);

                tb = new DataTable();

                data.Fill(tb);

                grd1.DataSource = tb;

                int check = grd1.Rows.Count - 1;

                string m = "";

                if ( check == 0)
                {

                    string detail = "select * from reveived_detail where id_reveived = '" + grd1.Rows[0].Cells[0].Value + "'";

                }
                else
                {
                    for (int i = 0; i < grd1.Rows.Count - 1; i++)
                    {

                        m = grd1.Rows[i].Cells[0].Value.ToString(); 

                    }

                    string detail = "select * from reveived_detail where id_reveived in ( '" + m + "')";

                    data = new SqlDataAdapter(detail, cn);

                    tb = new DataTable();

                    data.Fill(tb);

                    grd2.DataSource = tb;
                }
                

                
            }
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string s = DateTime.Today.AddDays(-1).ToString("yyyy/MM/dd");
            if(s != null)
            {
                string query = "select * from reveived where date = '" + s + "'";

                data = new SqlDataAdapter(query, cn);

                tb = new DataTable();

                data.Fill(tb);

                int check = grd1.Rows.Count - 1;

                string m = "";

                grd1.DataSource = tb;
                if (check == 0)
                {

                    string detail = "select * from reveived_detail where id_reveived = '" + grd1.Rows[0].Cells[0].Value + "'";

                }
                else
                {
                    for (int i = 0; i < grd1.Rows.Count - 1; i++)
                    {
                        if(i != grd1.Rows.Count -1 )
                        {
                            m = grd1.Rows[i].Cells[0].Value.ToString() + "," + grd1.Rows[i + 1].Cells[0].Value.ToString();
                        }
                        else
                        {
                            m = grd1.Rows[i].Cells[0].Value.ToString();
                        }

                    }

                    string detail = "select * from reveived_detail where id_reveived in ( '" + m + "')";

                    data = new SqlDataAdapter(detail, cn);

                    tb = new DataTable();

                    data.Fill(tb);

                    grd2.DataSource = tb;
                }
            }
        }
    }
}
