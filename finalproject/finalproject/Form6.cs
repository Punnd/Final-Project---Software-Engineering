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
    public partial class Form6 : Form
    {

        SqlConnection cn;

        SqlDataAdapter data;

        SqlCommand cm;

        DataTable tb;
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {

            monthCalendar1.Visible = false;

            connect();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
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
            string date = DateTime.Today.Month.ToString();
            

            if(date != null)
            {
                string s = "select sum(total) from reveived where MONTH(date) = '" + date + "' ";
                data = new SqlDataAdapter(s, cn);

                tb = new DataTable();

                data.Fill(tb);

                grd1.DataSource = tb;

                string x = "select sum(total) from delivery where MONTH(date) = '" + date + "' ";

                data = new SqlDataAdapter(x, cn);

                tb = new DataTable();

                data.Fill(tb);

                grd2.DataSource = tb;
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            string date = DateTime.Today.AddMonths(-1).Month.ToString();


            if (date != null)
            {
                string s = "select sum(total) from reveived where MONTH(date) = '" + date + "' ";
                data = new SqlDataAdapter(s, cn);

                tb = new DataTable();

                data.Fill(tb);

                grd1.DataSource = tb;

                string x = "select sum(total) from delivery where MONTH(date) = '" + date + "' ";

                data = new SqlDataAdapter(x, cn);

                tb = new DataTable();

                data.Fill(tb);

                grd2.DataSource = tb;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            monthCalendar1.Visible = true;



        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            string month = monthCalendar1.SelectionRange.Start.Month.ToString();
            string year = monthCalendar1.SelectionRange.Start.Year.ToString();

            if(month != null && year != null)
            {
                string s = "select sum(total) from reveived where MONTH(date) = '" + month + "' and YEAR(date) = '" + year +"' ";
                data = new SqlDataAdapter(s, cn);

                tb = new DataTable();

                data.Fill(tb);

                grd1.DataSource = tb;

                string x = "select sum(total) from delivery where MONTH(date) = '" + month + "' and YEAR(date) = '" + year + "' ";

                data = new SqlDataAdapter(x, cn);

                tb = new DataTable();

                data.Fill(tb);

                grd2.DataSource = tb;
            }
        }
    }
}
