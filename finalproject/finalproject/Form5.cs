using iTextSharp.text.pdf;
using iTextSharp.text;
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
    public partial class Form5 : Form
    {

        SqlConnection cn;

        SqlDataAdapter data;

        SqlCommand cm;

        DataTable tb;

        public Form5()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
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

        public void showGRD1()
        {

            string s = "select * from delivery";

            data = new SqlDataAdapter(s, cn);

            tb = new DataTable();

            data.Fill(tb);

            grd1.DataSource = tb;

        }

        public void showGRD2()
        {

            string s = "select * from delivery_detail";

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

        private void button1_Click(object sender, EventArgs e)
        {
            string s = DateTime.Today.ToString("yyyy/MM/dd");
            if (s != null)
            {
                string query = "select * from delivery where date = '" + s + "'";

                data = new SqlDataAdapter(query, cn);

                tb = new DataTable();

                data.Fill(tb);

                grd1.DataSource = tb;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string s = DateTime.Today.AddDays(-1).ToString("yyyy/MM/dd");
            if (s != null)
            {
                string query = "select * from delivery where date = '" + s + "'";

                data = new SqlDataAdapter(query, cn);

                tb = new DataTable();

                data.Fill(tb);



                grd1.DataSource = tb;

            }
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


            if (s1 != null && s2 != null && s3 != null && s4 != null && s5 != null && s6 != null && s7 != null)
            {
                string query = "select * from delivery where date in ('" + s1 + "','" + s2 + "','" + s3 + "','" + s4 + "','" + s5 + "','" + s6 + "','" + s7 + "')";
                data = new SqlDataAdapter(query, cn);

                tb = new DataTable();

                data.Fill(tb);

                grd1.DataSource = tb;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string s = DateTime.Today.Month.ToString();
            if (s != null)
            {
                string query = "select * from delivery where MONTH(date) = '" + s + "'";

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
                string query = "select * from delivery where MONTH(date) = '" + s + "'";

                data = new SqlDataAdapter(query, cn);

                tb = new DataTable();

                data.Fill(tb);

                grd1.DataSource = tb;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Visible = true;

            dateTimePicker1.Enabled = true;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            string s = dateTimePicker1.Value.ToString("yyyy/MM/dd");

            if (s != null)
            {
                string query = "select * from delivery where date = '" + s + "'";

                data = new SqlDataAdapter(query, cn);

                tb = new DataTable();

                data.Fill(tb);

                grd1.DataSource = tb;

            }
        }

        private void grd1_Click(object sender, EventArgs e)
        {
            string s = "select * from delivery_detail where id_delivery = '" + grd1.CurrentRow.Cells[0].Value.ToString() + "' ";

            data = new SqlDataAdapter(s, cn);

            tb = new DataTable();

            data.Fill(tb);

            grd2.DataSource = tb;
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            connect();

            formload();
        }

        private void button8_Click(object sender, EventArgs e)
        {


            if (grd2.Rows.Count - 1 > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF (*.pdf)|*.pdf";
                sfd.FileName = "Output.pdf";
                bool fileError = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                        }
                        catch (IOException ex)
                        {
                            fileError = true;
                            MessageBox.Show("It wasn't possible to write the data to the disk." + ex.Message);
                        }
                    }
                    if (!fileError)
                    {
                        try
                        {


                            PdfPTable pdfTable = new PdfPTable(grd2.Columns.Count);
                            pdfTable.DefaultCell.Padding = 3;
                            pdfTable.WidthPercentage = 100;
                            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
                            //add column
                            foreach (DataGridViewColumn column in grd2.Columns)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                                pdfTable.AddCell(cell);
                            }

                            //add value
                            for (int i = 0; i < grd2.Rows.Count - 1; ++i)
                            {
                                for (int j = 0; j < grd2.Columns.Count; ++j)
                                {
                                    // string s = grd.Rows[i].Cells[j].Value.ToString();
                                    pdfTable.AddCell(grd2.Rows[i].Cells[j].Value.ToString());

                                }
                            }


                            using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                            {
                                iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document(PageSize.A4, 10f, 20f, 20f, 10f);
                                PdfWriter.GetInstance(pdfDoc, stream);
                                pdfDoc.Open();
                                pdfDoc.Add(new Paragraph("Goods Delivery"));
                                pdfDoc.Add(new Paragraph("ID: " + grd1.CurrentRow.Cells[0].Value + ""));
                                pdfDoc.Add(new Paragraph("Date: " + grd1.CurrentRow.Cells[4].Value + ""));
                                pdfDoc.Add(new Paragraph("\n"));
                                pdfDoc.Add(pdfTable);
                                //pdfDoc.Add(new Paragraph("Total: + " + total.Text + ""));
                                pdfDoc.Close();
                                stream.Close();
                            }

                            MessageBox.Show("Data Exported Successfully !!!", "Info");
                            // Application.Run(sfd.FileName);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error :" + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No Record To Export !!!", "Info");
            }
        }
    }
}
