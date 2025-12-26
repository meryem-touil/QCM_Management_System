using QCM_Management_System.Models;
using QCM_Management_System.Forms;
using System;
using System.Windows.Forms;

namespace QCM_Management_System
{
    public partial class AdminDashboard : Form
    {
        private User currentUser;

        public AdminDashboard(User user)
        {
            InitializeComponent();
            currentUser = user;
            lblWelcome.Text = $"Welcome Admin: {user.FullName}";
        }

        private void btnManageUsers_Click(object sender, EventArgs e)
        {
            UserManagementForm userManagementForm = new UserManagementForm();
            userManagementForm.ShowDialog();
        }

        private void btnCreateQCM_Click(object sender, EventArgs e)
        {
            ManageQCMForm manageQCMForm = new ManageQCMForm(currentUser);
            manageQCMForm.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to logout?",
                "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
                this.Close();
            }
        }

        private void AdminDashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Application.OpenForms["LoginForm"] == null)
            {
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
            }
        }
    }
}