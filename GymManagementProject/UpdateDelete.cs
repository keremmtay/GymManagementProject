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
    public partial class UpdateDelete : Form
    {
        public UpdateDelete()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Kerem\\Documents\\GymDb.mdf;Integrated Security=True;Connect Timeout=30");

        private void Populate()
        {
            conn.Open();

            string query = "select * from MemberTbl";

            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);

            SqlCommandBuilder builder = new SqlCommandBuilder();

            var ds = new DataSet();

            adapter.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];

            conn.Close();
        }

        private void UpdateDelete_Load(object sender, EventArgs e)
        {
            Populate();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        int key = 0;

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            key = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            tbxMemberName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            tbxPhone.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            cmbxGender.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            tbxAge.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            tbxAmount.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            cmbxTiming.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
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

        private void btnBack_Click(object sender, EventArgs e)
        {
            MainForm form = new MainForm();

            form.Show();

            this.Hide();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select A Member To Delete");
            }
            else
            {
                try
                {
                    conn.Open();

                    string query = "delete from MemberTbl where MId=" + key + ";";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Member Successfully Deleted");

                    conn.Close();

                    Populate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);                    
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (key == 0 || tbxMemberName.Text == "" || tbxPhone.Text == "" || tbxAge.Text == "" || tbxAmount.Text == "" || cmbxGender.Text == "" || cmbxTiming.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    conn.Open();

                    string query = "update MemberTbl set MName='" + tbxMemberName.Text + "', MPhone='" + tbxPhone.Text + "', MGen='" + cmbxGender.Text + "', MAge=" + tbxAge.Text + ",MAmount=" + tbxAmount.Text + ", MTiming='" + cmbxTiming.Text + "' where MId='"+key+"';";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Member Successfully Updated");

                    conn.Close();

                    Populate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
