using QCM_Management_System.Models;
using QCM_Management_System.Forms;
using QCM_Management_System.Utils;
using QCM_ManagementSystem.DataAccess;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QCM_Management_System
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter username and password", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            User user = AuthenticateUser(username, password);

            if (user != null)
            {
                // Enregistrer l'utilisateur dans la session
                SessionManager.Login(user);

                MessageBox.Show($"Welcome {user.FullName}!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Redirection selon le rôle
                if (user.Role == "Admin")
                {
                    // Redirection vers la form AdminDashboard
                    AdminDashboard adminForm = new AdminDashboard(user);
                    adminForm.Show();
                    this.Hide(); // Cache le LoginForm
                }
                else if (user.Role == "User")
                {
                    UserDashboard userForm = new UserDashboard(user);
                    userForm.Show();
                    this.Hide();
                }

                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private User AuthenticateUser(string username, string password)
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT IdUser, Username, FullName, Role, CreatedAt FROM Users WHERE Username = @Username AND PasswordHash = @Password";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new User
                                {
                                    IdUser = (int)reader["IdUser"],
                                    Username = reader["Username"].ToString(),
                                    FullName = reader["FullName"].ToString(),
                                    Role = reader["Role"].ToString(),
                                    CreatedAt = (DateTime)reader["CreatedAt"]
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return null;
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.ShowDialog();  // ShowDialog bloque le LoginForm jusqu'à la fermeture

            // Optionnel : Vider les champs après l'inscription
            txtUsername.Clear();
            txtPassword.Clear();
            txtUsername.Focus();
        }
    }
}