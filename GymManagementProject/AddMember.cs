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
    public partial class AddMember : Form
    {
        public AddMember()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Kerem\\Documents\\GymDb.mdf;Integrated Security=True;Connect Timeout=30");

        private void AddMember_Load(object sender, EventArgs e)
        {

        }

        private void btnAddMember_Click(object sender, EventArgs e)
        {
            if (tbxMemberName.Text == "" || tbxPhone.Text == "" || tbxAmount.Text == "" || tbxAge.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else 
            {
                try
                {
                    conn.Open();

                    string query = "insert into MemberTbl values('" + tbxMemberName.Text + "','" + tbxPhone.Text + "','" + cmbxGender.SelectedItem.ToString() + "'," + tbxAge.Text + ","+tbxAmount.Text+",'" + cmbxTiming.SelectedItem.ToString() + "')";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Member Successfully Added");

                    conn.Close();

                    ResetForm();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }            
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void ResetForm()
        {
            tbxAmount.Text = "";
            tbxAge.Text = "";
            tbxMemberName.Text = "";
            tbxPhone.Text = "";
            cmbxGender.Text = "";
            cmbxTiming.Text = "";
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnBack2_Click(object sender, EventArgs e)
        {
            MainForm form = new MainForm();

            form.Show();

            this.Hide();
        }
    }
}
