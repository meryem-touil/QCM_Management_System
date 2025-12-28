using QCM_Management_System.Forms;
using QCM_Management_System.Models;
using QCM_Management_System.Utils;
using QCM_ManagementSystem.DataAccess;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace QCM_Management_System
{
    public partial class LoginForm : Form
    {
        // Color scheme
        private Color primaryColor = Color.FromArgb(41, 128, 185);
        private Color primaryHoverColor = Color.FromArgb(31, 97, 141);
        private Color borderColor = Color.FromArgb(189, 195, 199);
        private Color focusBorderColor = Color.FromArgb(41, 128, 185);
        private Color gradientStart = Color.FromArgb(52, 152, 219);
        private Color gradientEnd = Color.FromArgb(41, 128, 185);

        public LoginForm()
        {
            InitializeComponent();
            InitializeCustomStyles();
        }

        private void InitializeCustomStyles()
        {
            // Set Enter key to trigger login
            this.AcceptButton = btnLogin;

            // Focus on username textbox
            txtUsername.Focus();

            // Make the form look more modern
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;

            // Add shadow effect simulation
            this.BackColor = Color.FromArgb(240, 240, 240);
            this.Padding = new Padding(3);
        }

        // Paint event for gradient background on left panel
        private void pnlLeft_Paint(object sender, PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(
                pnlLeft.ClientRectangle,
                gradientStart,
                gradientEnd,
                LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(brush, pnlLeft.ClientRectangle);
            }
        }

        // Paint event for rounded corners on login container
        private void pnlLoginContainer_Paint(object sender, PaintEventArgs e)
        {
            // Draw subtle shadow
            using (Pen shadowPen = new Pen(Color.FromArgb(30, 0, 0, 0), 8))
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.DrawRectangle(shadowPen, 2, 2, pnlLoginContainer.Width - 4, pnlLoginContainer.Height - 4);
            }
        }

        // Paint event for username textbox border
        private void pnlUsername_Paint(object sender, PaintEventArgs e)
        {
            Color borderClr = txtUsername.Focused ? focusBorderColor : borderColor;
            int borderWidth = txtUsername.Focused ? 2 : 1;

            using (Pen pen = new Pen(borderClr, borderWidth))
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                // Draw rounded rectangle
                Rectangle rect = new Rectangle(0, 0, pnlUsername.Width - 1, pnlUsername.Height - 1);
                DrawRoundedRectangle(e.Graphics, pen, rect, 5);
            }
        }

        // Paint event for password textbox border
        private void pnlPassword_Paint(object sender, PaintEventArgs e)
        {
            Color borderClr = txtPassword.Focused ? focusBorderColor : borderColor;
            int borderWidth = txtPassword.Focused ? 2 : 1;

            using (Pen pen = new Pen(borderClr, borderWidth))
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                // Draw rounded rectangle
                Rectangle rect = new Rectangle(0, 0, pnlPassword.Width - 1, pnlPassword.Height - 1);
                DrawRoundedRectangle(e.Graphics, pen, rect, 5);
            }
        }

        // Paint event for login button (rounded corners)
        private void btnLogin_Paint(object sender, PaintEventArgs e)
        {
            Button btn = (Button)sender;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using (GraphicsPath path = GetRoundedRectanglePath(btn.ClientRectangle, 5))
            {
                btn.Region = new Region(path);
            }
        }

        // Paint event for register button (rounded corners)
        private void btnRegister_Paint(object sender, PaintEventArgs e)
        {
            Button btn = (Button)sender;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using (GraphicsPath path = GetRoundedRectanglePath(btn.ClientRectangle, 5))
            {
                btn.Region = new Region(path);
            }
        }

        // Helper method to draw rounded rectangle
        private void DrawRoundedRectangle(Graphics graphics, Pen pen, Rectangle rect, int radius)
        {
            using (GraphicsPath path = GetRoundedRectanglePath(rect, radius))
            {
                graphics.DrawPath(pen, path);
            }
        }

        // Helper method to create rounded rectangle path
        private GraphicsPath GetRoundedRectanglePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int diameter = radius * 2;

            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();

            return path;
        }

        // Username textbox focus events
        private void txtUsername_Enter(object sender, EventArgs e)
        {
            pnlUsername.Invalidate();
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            pnlUsername.Invalidate();
        }

        // Password textbox focus events
        private void txtPassword_Enter(object sender, EventArgs e)
        {
            pnlPassword.Invalidate();
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            pnlPassword.Invalidate();
        }

        // Login button hover effects
        private void btnLogin_MouseEnter(object sender, EventArgs e)
        {
            btnLogin.BackColor = primaryHoverColor;
        }

        private void btnLogin_MouseLeave(object sender, EventArgs e)
        {
            btnLogin.BackColor = primaryColor;
        }

        // Register button hover effects
        private void btnRegister_MouseEnter(object sender, EventArgs e)
        {
            btnRegister.BackColor = Color.FromArgb(236, 240, 241);
        }

        private void btnRegister_MouseLeave(object sender, EventArgs e)
        {
            btnRegister.BackColor = Color.White;
        }

        // Login button click - Your original logic
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

        // Authenticate user - Your original logic
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

        // Register button click - Your original logic
        private void btnRegister_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.ShowDialog();  // ShowDialog bloque le LoginForm jusqu'à la fermeture

            // Optionnel : Vider les champs après l'inscription
            txtUsername.Clear();
            txtPassword.Clear();
            txtUsername.Focus();
        }

        // Allow closing with ESC key
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}