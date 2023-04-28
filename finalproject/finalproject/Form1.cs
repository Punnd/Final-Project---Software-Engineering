using System.Data;
using System.Data.SqlClient;

namespace finalproject
{
    public partial class Form1 : Form
    {
        SqlConnection cn;

        SqlDataAdapter data;

        SqlCommand cm;

        DataTable tb;

        public static string email_acc;
                
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string sql = "initial catalog = final; data source = LAPTOP-90QEEVDN; integrated security = true";

            cn = new SqlConnection(sql);

            cn.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String s = "SELECT email, pass FROM ketoan WHERE email='" + txtEmail.Text + "' and pass='" + txtPass.Text + "'";

            cm = new SqlCommand(s, cn);

            data = new SqlDataAdapter(cm);

            DataTable dt = new DataTable();

            data.Fill(dt);

            if (dt.Rows.Count > 0)
            {

                MessageBox.Show("Login Successfully!");

                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid Email or password");
            }

            email_acc = txtEmail.Text;
        }

        private void txtCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}