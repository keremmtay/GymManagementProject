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
    public partial class ViewMembers : Form
    {
        public ViewMembers()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Kerem\\Documents\\GymDb.mdf;Integrated Security=True;Connect Timeout=30");

        private void Populate()
        { 
            conn.Open();

            string query = "select * from MemberTbl";

            SqlDataAdapter adapter = new SqlDataAdapter(query,conn);

            SqlCommandBuilder builder = new SqlCommandBuilder();

            var ds = new DataSet();

            adapter.Fill(ds);

            dgvMembers.DataSource = ds.Tables[0];

            conn.Close();        
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ViewMembers_Load(object sender, EventArgs e)
        {
            Populate();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MainForm form = new MainForm();

            form.Show();

            this.Hide();
        }

        private void FilterByName()
        {
            conn.Open();

            string query = "select * from MemberTbl where MName='" + tbxSearch.Text + "'";

            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);

            SqlCommandBuilder builder = new SqlCommandBuilder();

            var ds = new DataSet();

            adapter.Fill(ds);

            dgvMembers.DataSource = ds.Tables[0];

            conn.Close();
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
