﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

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
            dateTimePicker1.Enabled = false;

            dateTimePicker1.Visible = false;

            showGRD1();
            
            //showGRD2();
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

                

                grd1.DataSource = tb;
                
            }
        }

        private void grd1_Click(object sender, EventArgs e)
        {
            string s = "select * from reveived_detail where id_reveived = '" + grd1.CurrentRow.Cells[0].Value.ToString() +"' ";

            data = new SqlDataAdapter(s, cn);

            tb = new DataTable();

            data.Fill(tb);

            grd2.DataSource = tb;
        }

        private void button3_Click(object sender, EventArgs e)
        {

            string s1 = DateTime.Today.ToString("yyyy/MM/dd");

            

            string s2 = DateTime.Today.AddDays(-1).ToString("yyyy/MM/dd");

            

            string s3 = DateTime.Today.AddDays(-2).ToString("yyyy/MM/dd");

            

            string s4 = DateTime.Today.AddDays(-3).ToString("yyyy/MM/dd");

            

            string s5 = DateTime.Today.AddDays(-4).ToString("yyyy/MM/dd");

            

            string s6 = DateTime.Today.AddDays(-5).ToString("yyyy/MM/dd");

           

            string s7 = DateTime.Today.AddDays(-6).ToString("yyyy/MM/dd");


            if ( s1 != null && s2 != null && s3 != null && s4 != null && s5 != null && s6 != null && s7 != null)
            {
                string query = "select * from reveived where date in ('" + s1 + "','" + s2 +"','" + s3 +"','" + s4 + "','" + s5 + "','" + s6 + "','" + s7 + "')";
                data = new SqlDataAdapter(query, cn);

                tb = new DataTable();

                data.Fill(tb);

                grd1.DataSource = tb;
            }
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string s = DateTime.Today.Month.ToString();
            if(s != null)
            {
                string query = "select * from reveived where MONTH(date) = '" + s + "'";

                data = new SqlDataAdapter(query, cn);

                tb = new DataTable();

                data.Fill(tb);

                grd1.DataSource = tb;
            }

            

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string s = DateTime.Today.AddMonths(-1).Month.ToString();
            
            if (s != null)
            {
                string query = "select * from reveived where MONTH(date) = '" + s + "'";

                data = new SqlDataAdapter(query, cn);

                tb = new DataTable();

                data.Fill(tb);

                grd1.DataSource = tb;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            string s = dateTimePicker1.Value.ToString("yyyy/MM/dd");

            if (s != null)
            {
                string query = "select * from reveived where date = '" + s + "'";

                data = new SqlDataAdapter(query, cn);

                tb = new DataTable();

                data.Fill(tb);

                grd1.DataSource = tb;

            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Visible = true;

            dateTimePicker1.Enabled = true;


        }
    }
}
