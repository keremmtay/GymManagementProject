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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnAdd_MouseHover(object sender, EventArgs e)
        {
            btnAdd.BackColor = Color.Crimson;
            btnAdd.ForeColor = Color.White;
        }

        private void btnAdd_MouseLeave(object sender, EventArgs e)
        {
            btnAdd.BackColor = Color.White;
            btnAdd.ForeColor = Color.Crimson;
        }

        private void btnUpdate_MouseHover(object sender, EventArgs e)
        {
            btnUpdate.BackColor = Color.Crimson;
            btnUpdate.ForeColor = Color.White;
        }

        private void btnUpdate_MouseLeave(object sender, EventArgs e)
        {
            btnUpdate.BackColor = Color.White;
            btnUpdate.ForeColor = Color.Crimson;
        }

        private void btnPayment_MouseHover(object sender, EventArgs e)
        {
            btnPayment.BackColor = Color.Crimson;
            btnPayment.ForeColor = Color.White;
        }

        private void btnPayment_MouseLeave(object sender, EventArgs e)
        {
            btnPayment.BackColor = Color.White;
            btnPayment.ForeColor = Color.Crimson;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddMember addMember = new AddMember();

            addMember.Show();

            this.Hide();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateDelete form = new UpdateDelete();

            form.Show();

            this.Hide();
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            Payment payment = new Payment();

            payment.Show();

            this.Hide();
        }

        private void btnViewMembers_Click(object sender, EventArgs e)
        {
            ViewMembers viewMembers = new ViewMembers();

            viewMembers.Show();

            this.Hide();
        }

        private void btnViewMembers_MouseHover(object sender, EventArgs e)
        {
            btnViewMembers.BackColor = Color.Crimson;
            btnViewMembers.ForeColor = Color.White;
        }

        private void btnViewMembers_MouseLeave(object sender, EventArgs e)
        {
            btnViewMembers.BackColor = Color.White;
            btnViewMembers.ForeColor = Color.Crimson;
        }
    }
}
