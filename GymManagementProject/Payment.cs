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

namespace GymManagementProject
{
    public partial class Payment : Form
    {
        public Payment()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Kerem\\Documents\\GymDb.mdf;Integrated Security=True;Connect Timeout=30");

        private void FillName()
        {
            conn.Open();

            SqlCommand cmd = new SqlCommand("select MName from MemberTbl", conn);

            SqlDataReader rdr;

            rdr = cmd.ExecuteReader();

            DataTable dt = new DataTable();

            dt.Columns.Add("MName", typeof(string));

            dt.Load(rdr);

            cmbxMemberName.ValueMember = "MName";

            cmbxMemberName.DataSource = dt;

            conn.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            //tbxMemberName.Text = "";
            tbxAmount.Text = "";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            MainForm form = new MainForm();

            form.Show();

            this.Hide();
        }

        private void Payment_Load(object sender, EventArgs e)
        {
            FillName();

            Populate();
        }

        private void Populate()
        {
            conn.Open();

            string query = "select * from PaymentTbl";

            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);

            SqlCommandBuilder builder = new SqlCommandBuilder();

            var ds = new DataSet();

            adapter.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];

            conn.Close();
        }
        
        private void FilterByName()
        {
            conn.Open();

            string query = "select * from PaymentTbl where PMember='"+tbxSearch.Text+"'";

            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);

            SqlCommandBuilder builder = new SqlCommandBuilder();

            var ds = new DataSet();

            adapter.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];

            conn.Close();
        }


        private void btnPay_Click(object sender, EventArgs e)
        {
            if (cmbxMemberName.Text == "" || tbxAmount.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                string payperiode = dtpPeriode.Value.Month.ToString()+dtpPeriode.Value.Year.ToString();

                conn.Open();

                SqlDataAdapter sda = new SqlDataAdapter("select count(*) from PaymentTbl where PMember='"+cmbxMemberName.SelectedValue.ToString()+"' and PMonth='"+payperiode+"'", conn);

                DataTable dt = new DataTable();

                sda.Fill(dt);

                if (dt.Rows[0][0].ToString() == "1")
                {
                    MessageBox.Show("Already paid for this month");
                }
                else
                {
                    string query = "insert into PaymentTbl values('" + payperiode + "', '" + cmbxMemberName.SelectedValue.ToString() + "'," + tbxAmount.Text + ")";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Amount paid succesfully");
                }

                conn.Close();

                Populate();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            FilterByName();

            tbxSearch.Text = "";
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Populate();
        }
    }
}
