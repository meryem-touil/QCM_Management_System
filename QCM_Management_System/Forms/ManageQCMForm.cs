using QCM_Management_System.Forms;
using QCM_Management_System.Models;
using QCM_ManagementSystem.DataAccess;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QCM_Management_System.Forms
{
    public partial class ManageQCMForm : Form
    {
        private User currentUser;

        public ManageQCMForm(User user)
        {
            InitializeComponent();
            currentUser = user;
            LoadQCMs();
        }

        private void LoadQCMs()
        {
            // defensive checks
            if (dgvQCMs == null)
            {
                MessageBox.Show("Internal error: dgvQCMs is not initialized.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                DataTable dt = new DataTable();

                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    if (conn == null)
                    {
                        MessageBox.Show("Database connection is null.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    conn.Open();

                    string query = @"SELECT 
                                        q.IdQCM, 
                                        q.Title, 
                                        q.Description, 
                                        q.Duration as 'Duration (min)', 
                                        u.FullName as 'Created By',
                                        q.CreatedAt as 'Created Date',
                                        CASE WHEN q.IsActive = 1 THEN 'Active' ELSE 'Inactive' END as Status,
                                        (SELECT COUNT(*) FROM Questions WHERE IdQCM = q.IdQCM) as 'Questions Count'
                                    FROM QCM q
                                    INNER JOIN Users u ON q.CreatedBy = u.IdUser
                                    ORDER BY q.CreatedAt DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }

                // Ensure control handle exists (prevents some internal NREs when changing column widths)
                var _ = dgvQCMs.Handle;

                // Bind data
                dgvQCMs.DataSource = dt;

                // Temporarily disable AutoSizeColumnsMode to safely set Widths when mode = Fill
                var previousMode = dgvQCMs.AutoSizeColumnsMode;
                try
                {
                    dgvQCMs.SuspendLayout();
                    dgvQCMs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

                    if (dgvQCMs.Columns != null && dgvQCMs.Columns.Count > 0)
                    {
                        DataGridViewColumn col;

                        if (dgvQCMs.Columns.Contains("IdQCM"))
                        {
                            col = dgvQCMs.Columns["IdQCM"];
                            if (col != null && col.DataGridView != null)
                                col.Visible = false;
                        }

                        if (dgvQCMs.Columns.Contains("Title"))
                        {
                            col = dgvQCMs.Columns["Title"];
                            if (col != null && col.DataGridView != null) col.Width = 200;
                        }

                        if (dgvQCMs.Columns.Contains("Description"))
                        {
                            col = dgvQCMs.Columns["Description"];
                            if (col != null && col.DataGridView != null) col.Width = 250;
                        }

                        if (dgvQCMs.Columns.Contains("Duration (min)"))
                        {
                            col = dgvQCMs.Columns["Duration (min)"];
                            if (col != null && col.DataGridView != null) col.Width = 100;
                        }

                        if (dgvQCMs.Columns.Contains("Created By"))
                        {
                            col = dgvQCMs.Columns["Created By"];
                            if (col != null && col.DataGridView != null) col.Width = 150;
                        }

                        if (dgvQCMs.Columns.Contains("Created Date"))
                        {
                            col = dgvQCMs.Columns["Created Date"];
                            if (col != null && col.DataGridView != null) col.Width = 150;
                        }

                        if (dgvQCMs.Columns.Contains("Status"))
                        {
                            col = dgvQCMs.Columns["Status"];
                            if (col != null && col.DataGridView != null) col.Width = 80;
                        }

                        if (dgvQCMs.Columns.Contains("Questions Count"))
                        {
                            col = dgvQCMs.Columns["Questions Count"];
                            if (col != null && col.DataGridView != null) col.Width = 120;
                        }
                    }
                }
                finally
                {
                    dgvQCMs.AutoSizeColumnsMode = previousMode;
                    dgvQCMs.ResumeLayout();
                }

                if (lblTotalQCMs != null)
                    lblTotalQCMs.Text = $"Total QCMs: {dgvQCMs.Rows.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading QCMs: " + ex.Message + "\n\n" + ex.StackTrace, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCreateNew_Click(object sender, EventArgs e)
        {
            CreateQCMForm createForm = new CreateQCMForm(currentUser);
            createForm.ShowDialog();
            LoadQCMs(); // Refresh list after creating
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvQCMs.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a QCM to view questions", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int qcmId = (int)dgvQCMs.SelectedRows[0].Cells["IdQCM"].Value;
            string title = dgvQCMs.SelectedRows[0].Cells["Title"].Value.ToString();

            ViewQuestionsForm viewForm = new ViewQuestionsForm(qcmId, title);
            viewForm.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvQCMs.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a QCM to delete", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string title = dgvQCMs.SelectedRows[0].Cells["Title"].Value.ToString();

            DialogResult result = MessageBox.Show(
                $"Are you sure you want to delete '{title}'?\n\nThis will also delete all questions and answers!",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                DeleteQCM();
            }
        }

        private void tsiToggleActive_Click(object sender, EventArgs e)
        {
            if (dgvQCMs == null || dgvQCMs.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a QCM first.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var cell = dgvQCMs.SelectedRows[0].Cells["IdQCM"];
            if (cell == null || cell.Value == null)
            {
                MessageBox.Show("Selected row does not contain a valid QCM id.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int qcmId = (int)cell.Value;

            // Read current status text if available
            string statusText = null;
            if (dgvQCMs.SelectedRows[0].Cells["Status"] != null)
            {
                var statusCell = dgvQCMs.SelectedRows[0].Cells["Status"];
                statusText = statusCell?.Value?.ToString();
            }

            bool newActive = true; // default to activate
            if (!string.IsNullOrEmpty(statusText) && statusText.Equals("Active", StringComparison.OrdinalIgnoreCase))
            {
                newActive = false; // currently active -> deactivate
            }

            var confirm = MessageBox.Show(
                $"Are you sure you want to {(newActive ? "activate" : "deactivate")} this QCM?",
                "Confirm",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    if (conn == null)
                    {
                        MessageBox.Show("Unable to obtain a database connection.", "Database Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    conn.Open();

                    string updateQuery = "UPDATE QCM SET IsActive = @IsActive WHERE IdQCM = @IdQcm";

                    using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@IsActive", newActive ? 1 : 0);
                        cmd.Parameters.AddWithValue("@IdQcm", qcmId);

                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            MessageBox.Show($"QCM {(newActive ? "activated" : "deactivated")} successfully.", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadQCMs();
                        }
                        else
                        {
                            MessageBox.Show("No rows were updated. The QCM may not exist.", "Warning",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error toggling QCM active state: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteQCM()
        {
            try
            {
                int qcmId = (int)dgvQCMs.SelectedRows[0].Cells["IdQCM"].Value;

                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    string query = "DELETE FROM QCM WHERE IdQCM = @QcmId";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@QcmId", qcmId);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("QCM deleted successfully!", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadQCMs();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting QCM: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadQCMs();
            MessageBox.Show("List refreshed!", "Info",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}