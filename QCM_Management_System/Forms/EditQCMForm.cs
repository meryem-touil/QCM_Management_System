using QCM_Management_System.Models;
using QCM_ManagementSystem.DataAccess;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QCM_Management_System
{
    public partial class EditQCMForm : Form
    {
        private int qcmId;

        public EditQCMForm(int qcmId)
        {
            InitializeComponent();
            this.qcmId = qcmId;
            LoadQCMData();
        }

        private void LoadQCMData()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    string query = "SELECT Title, Description, Duration, IsActive FROM QCM WHERE IdQCM = @QcmId";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@QcmId", qcmId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtTitle.Text = reader["Title"].ToString();
                                txtDescription.Text = reader["Description"] != DBNull.Value
                                    ? reader["Description"].ToString()
                                    : "";
                                numDuration.Value = (int)reader["Duration"];
                                chkIsActive.Checked = (bool)reader["IsActive"];
                            }
                            else
                            {
                                MessageBox.Show("QCM not found", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.Close();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading QCM: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Please enter QCM title", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTitle.Focus();
                return;
            }

            if (numDuration.Value < 1)
            {
                MessageBox.Show("Duration must be at least 5 minutes", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numDuration.Focus();
                return;
            }

            SaveChanges();
        }

        private void SaveChanges()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();

                    string query = @"UPDATE QCM 
                                    SET Title = @Title, 
                                        Description = @Description, 
                                        Duration = @Duration,
                                        IsActive = @IsActive
                                    WHERE IdQCM = @QcmId";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Title", txtTitle.Text.Trim());
                        cmd.Parameters.AddWithValue("@Description",
                            string.IsNullOrWhiteSpace(txtDescription.Text)
                                ? (object)DBNull.Value
                                : txtDescription.Text.Trim());
                        cmd.Parameters.AddWithValue("@Duration", numDuration.Value);
                        cmd.Parameters.AddWithValue("@IsActive", chkIsActive.Checked);
                        cmd.Parameters.AddWithValue("@QcmId", qcmId);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Failed to update QCM", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving changes: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to cancel? All unsaved changes will be lost.",
                "Confirm Cancel",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }
    }
}