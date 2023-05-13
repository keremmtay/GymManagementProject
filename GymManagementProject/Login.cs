using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymManagementProject
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            tbxPassword.Text = "";
            tbxUsername.Text = "";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (tbxUsername.Text == "" || tbxPassword.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else if (tbxUsername.Text == "Admin" || tbxPassword.Text == "Admin")
            {
                MainForm form = new MainForm();

                form.Show();

                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong ID or Password");
            }
        }
    }
}
