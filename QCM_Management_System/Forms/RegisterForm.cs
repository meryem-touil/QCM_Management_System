using QCM_Management_System.Business;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace QCM_Management_System.Forms
{
    public partial class RegisterForm : Form
    {
        private UserService userService = new UserService();

        // Color scheme - Green theme for registration
        private Color primaryColor = Color.FromArgb(26, 188, 156);
        private Color primaryHoverColor = Color.FromArgb(22, 160, 133);
        private Color borderColor = Color.FromArgb(189, 195, 199);
        private Color focusBorderColor = Color.FromArgb(26, 188, 156);
        private Color gradientStart = Color.FromArgb(46, 204, 113);
        private Color gradientEnd = Color.FromArgb(26, 188, 156);

        public RegisterForm()
        {
            InitializeComponent();
            InitializeCustomStyles();
        }

        private void InitializeCustomStyles()
        {
            // Set Enter key to trigger registration
            this.AcceptButton = btnRegister;

            // Focus on username textbox
            txtUsername.Focus();

            // Make the form look more modern
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;

            // Add shadow effect simulation
            this.BackColor = Color.FromArgb(240, 240, 240);
            this.Padding = new Padding(3);

            // Set password char for password fields
            txtPassword.PasswordChar = '●';
            txtConfirmPassword.PasswordChar = '●';
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

        // Paint event for rounded corners on register container
        private void pnlRegisterContainer_Paint(object sender, PaintEventArgs e)
        {
            // Draw subtle shadow
            using (Pen shadowPen = new Pen(Color.FromArgb(30, 0, 0, 0), 8))
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.DrawRectangle(shadowPen, 2, 2, pnlRegisterContainer.Width - 4, pnlRegisterContainer.Height - 4);
            }
        }

        // Paint events for textbox borders
        private void pnlUsername_Paint(object sender, PaintEventArgs e)
        {
            DrawTextBoxBorder(e, txtUsername.Focused, pnlUsername);
        }

        private void pnlFullName_Paint(object sender, PaintEventArgs e)
        {
            DrawTextBoxBorder(e, txtFullName.Focused, pnlFullName);
        }

        private void pnlPassword_Paint(object sender, PaintEventArgs e)
        {
            DrawTextBoxBorder(e, txtPassword.Focused, pnlPassword);
        }

        private void pnlConfirmPassword_Paint(object sender, PaintEventArgs e)
        {
            DrawTextBoxBorder(e, txtConfirmPassword.Focused, pnlConfirmPassword);
        }

        // Helper method to draw textbox borders
        private void DrawTextBoxBorder(PaintEventArgs e, bool isFocused, Panel panel)
        {
            Color borderClr = isFocused ? focusBorderColor : borderColor;
            int borderWidth = isFocused ? 2 : 1;

            using (Pen pen = new Pen(borderClr, borderWidth))
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                Rectangle rect = new Rectangle(0, 0, panel.Width - 1, panel.Height - 1);
                DrawRoundedRectangle(e.Graphics, pen, rect, 5);
            }
        }

        // Paint events for buttons (rounded corners)
        private void btnRegister_Paint(object sender, PaintEventArgs e)
        {
            Button btn = (Button)sender;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using (GraphicsPath path = GetRoundedRectanglePath(btn.ClientRectangle, 5))
            {
                btn.Region = new Region(path);
            }
        }

        private void btnCancel_Paint(object sender, PaintEventArgs e)
        {
            Button btn = (Button)sender;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using (GraphicsPath path = GetRoundedRectanglePath(btn.ClientRectangle, 5))
            {
                btn.Region = new Region(path);
            }
        }

        // Helper methods for rounded rectangles
        private void DrawRoundedRectangle(Graphics graphics, Pen pen, Rectangle rect, int radius)
        {
            using (GraphicsPath path = GetRoundedRectanglePath(rect, radius))
            {
                graphics.DrawPath(pen, path);
            }
        }

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

        // Focus events for textboxes
        private void txtUsername_Enter(object sender, EventArgs e)
        {
            pnlUsername.Invalidate();
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            pnlUsername.Invalidate();
        }

        private void txtFullName_Enter(object sender, EventArgs e)
        {
            pnlFullName.Invalidate();
        }

        private void txtFullName_Leave(object sender, EventArgs e)
        {
            pnlFullName.Invalidate();
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            pnlPassword.Invalidate();
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            pnlPassword.Invalidate();
        }

        private void txtConfirmPassword_Enter(object sender, EventArgs e)
        {
            pnlConfirmPassword.Invalidate();
        }

        private void txtConfirmPassword_Leave(object sender, EventArgs e)
        {
            pnlConfirmPassword.Invalidate();
        }

        // Button hover effects
        private void btnRegister_MouseEnter(object sender, EventArgs e)
        {
            btnRegister.BackColor = primaryHoverColor;
        }

        private void btnRegister_MouseLeave(object sender, EventArgs e)
        {
            btnRegister.BackColor = primaryColor;
        }

        private void btnCancel_MouseEnter(object sender, EventArgs e)
        {
            btnCancel.BackColor = Color.FromArgb(236, 240, 241);
        }

        private void btnCancel_MouseLeave(object sender, EventArgs e)
        {
            btnCancel.BackColor = Color.White;
        }

        // Register button click - Your original logic
        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string confirmPassword = txtConfirmPassword.Text.Trim();
            string fullName = txtFullName.Text.Trim();

            if (string.IsNullOrEmpty(username) ||
                string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(confirmPassword) ||
                string.IsNullOrEmpty(fullName))
            {
                MessageBox.Show("Veuillez remplir tous les champs", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Les mots de passe ne correspondent pas", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (userService.UsernameExists(username))
            {
                MessageBox.Show("Nom d'utilisateur déjà existant", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool success = userService.CreateUser(username, password, fullName, "User");

            if (success)
            {
                MessageBox.Show("Compte créé avec succès", "Succès",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Erreur lors de la création du compte", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Cancel button click - Your original logic
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
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