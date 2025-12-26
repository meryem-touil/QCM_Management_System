using QCM_ManagementSystem.DataAccess;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QCM_Management_System
{
    public partial class UserManagementForm : Form
    {
        public UserManagementForm()
        {
            InitializeComponent();
            LoadUsers();
        }

        private void LoadUsers()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    string query = @"SELECT IdUser, Username, FullName, Role, 
                                           CreatedAt as 'Registration Date'
                                    FROM Users 
                                    ORDER BY CreatedAt DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dgvUsers.DataSource = dt;

                        if (dgvUsers.Columns["IdUser"] != null)
                        {
                            dgvUsers.Columns["IdUser"].Visible = false;
                        }
                    }
                }

                lblTotalUsers.Text = $"Total Users: {dgvUsers.Rows.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading users: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMakeAdmin_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user first", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int userId = (int)dgvUsers.SelectedRows[0].Cells["IdUser"].Value;
            string username = dgvUsers.SelectedRows[0].Cells["Username"].Value.ToString();
            string currentRole = dgvUsers.SelectedRows[0].Cells["Role"].Value.ToString();

            if (currentRole == "Admin")
            {
                MessageBox.Show("This user is already an Admin!", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Are you sure you want to make '{username}' an Admin?",
                "Confirm Action",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                UpdateUserRole(userId, "Admin");
            }
        }

        private void btnRemoveAdmin_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user first", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int userId = (int)dgvUsers.SelectedRows[0].Cells["IdUser"].Value;
            string username = dgvUsers.SelectedRows[0].Cells["Username"].Value.ToString();
            string currentRole = dgvUsers.SelectedRows[0].Cells["Role"].Value.ToString();

            if (currentRole == "User")
            {
                MessageBox.Show("This user is already a regular User!", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Are you sure you want to remove Admin rights from '{username}'?",
                "Confirm Action",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                UpdateUserRole(userId, "User");
            }
        }

        private void UpdateUserRole(int userId, string newRole)
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    string query = "UPDATE Users SET Role = @Role WHERE IdUser = @UserId";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Role", newRole);
                        cmd.Parameters.AddWithValue("@UserId", userId);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show($"User role updated to '{newRole}' successfully!",
                                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            LoadUsers();
                        }
                        else
                        {
                            MessageBox.Show("Failed to update user role", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating user role: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadUsers();
            MessageBox.Show("User list refreshed!", "Info",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvUsers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvUsers.Columns[e.ColumnIndex].Name == "Role")
            {
                if (e.Value != null && e.Value.ToString() == "Admin")
                {
                    e.CellStyle.BackColor = System.Drawing.Color.LightGreen;
                    e.CellStyle.ForeColor = System.Drawing.Color.DarkGreen;
                    e.CellStyle.Font = new System.Drawing.Font(dgvUsers.Font, System.Drawing.FontStyle.Bold);
                }
                else
                {
                    e.CellStyle.BackColor = System.Drawing.Color.LightBlue;
                    e.CellStyle.ForeColor = System.Drawing.Color.DarkBlue;
                }
            }
        }
    }
}