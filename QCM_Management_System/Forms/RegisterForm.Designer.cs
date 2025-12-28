namespace QCM_Management_System.Forms
{
    partial class RegisterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblSystemName = new System.Windows.Forms.Label();
            this.lblQuote = new System.Windows.Forms.Label();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.pnlRegisterContainer = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.pnlUsernameContainer = new System.Windows.Forms.Panel();
            this.pnlUsername = new System.Windows.Forms.Panel();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblUsernameIcon = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.pnlFullNameContainer = new System.Windows.Forms.Panel();
            this.pnlFullName = new System.Windows.Forms.Panel();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.lblFullNameIcon = new System.Windows.Forms.Label();
            this.lblFullName = new System.Windows.Forms.Label();
            this.pnlPasswordContainer = new System.Windows.Forms.Panel();
            this.pnlPassword = new System.Windows.Forms.Panel();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPasswordIcon = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.pnlConfirmPasswordContainer = new System.Windows.Forms.Panel();
            this.pnlConfirmPassword = new System.Windows.Forms.Panel();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.lblConfirmPasswordIcon = new System.Windows.Forms.Label();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.btnRegister = new System.Windows.Forms.Button();
            this.pnlDivider = new System.Windows.Forms.Panel();
            this.lblOr = new System.Windows.Forms.Label();
            this.lblDividerRight = new System.Windows.Forms.Label();
            this.lblDividerLeft = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblFooter = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlRegisterContainer.SuspendLayout();
            this.pnlUsernameContainer.SuspendLayout();
            this.pnlUsername.SuspendLayout();
            this.pnlFullNameContainer.SuspendLayout();
            this.pnlFullName.SuspendLayout();
            this.pnlPasswordContainer.SuspendLayout();
            this.pnlPassword.SuspendLayout();
            this.pnlConfirmPasswordContainer.SuspendLayout();
            this.pnlConfirmPassword.SuspendLayout();
            this.pnlDivider.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.White;
            this.pnlMain.Controls.Add(this.pnlRight);
            this.pnlMain.Controls.Add(this.pnlLeft);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1000, 700);
            this.pnlMain.TabIndex = 0;
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(188)))), ((int)(((byte)(156)))));
            this.pnlLeft.Controls.Add(this.lblQuote);
            this.pnlLeft.Controls.Add(this.lblSystemName);
            this.pnlLeft.Controls.Add(this.lblWelcome);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(50);
            this.pnlLeft.Size = new System.Drawing.Size(450, 700);
            this.pnlLeft.TabIndex = 0;
            this.pnlLeft.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlLeft_Paint);
            // 
            // lblWelcome
            // 
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.ForeColor = System.Drawing.Color.White;
            this.lblWelcome.Location = new System.Drawing.Point(50, 200);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(350, 70);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Join Us!";
            this.lblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSystemName
            // 
            this.lblSystemName.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSystemName.ForeColor = System.Drawing.Color.White;
            this.lblSystemName.Location = new System.Drawing.Point(50, 280);
            this.lblSystemName.Name = "lblSystemName";
            this.lblSystemName.Size = new System.Drawing.Size(350, 90);
            this.lblSystemName.TabIndex = 1;
            this.lblSystemName.Text = "Create Your Account";
            this.lblSystemName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblQuote
            // 
            this.lblQuote.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuote.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.lblQuote.Location = new System.Drawing.Point(50, 390);
            this.lblQuote.Name = "lblQuote";
            this.lblQuote.Size = new System.Drawing.Size(350, 100);
            this.lblQuote.TabIndex = 2;
            this.lblQuote.Text = "\"Start managing your quizzes today and unlock your full potential\"";
            this.lblQuote.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlRight
            // 
            this.pnlRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(251)))), ((int)(((byte)(252)))));
            this.pnlRight.Controls.Add(this.pnlRegisterContainer);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(450, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Padding = new System.Windows.Forms.Padding(40);
            this.pnlRight.Size = new System.Drawing.Size(550, 700);
            this.pnlRight.TabIndex = 1;
            // 
            // pnlRegisterContainer
            // 
            this.pnlRegisterContainer.BackColor = System.Drawing.Color.White;
            this.pnlRegisterContainer.Controls.Add(this.lblFooter);
            this.pnlRegisterContainer.Controls.Add(this.btnCancel);
            this.pnlRegisterContainer.Controls.Add(this.pnlDivider);
            this.pnlRegisterContainer.Controls.Add(this.btnRegister);
            this.pnlRegisterContainer.Controls.Add(this.pnlConfirmPasswordContainer);
            this.pnlRegisterContainer.Controls.Add(this.pnlPasswordContainer);
            this.pnlRegisterContainer.Controls.Add(this.pnlFullNameContainer);
            this.pnlRegisterContainer.Controls.Add(this.pnlUsernameContainer);
            this.pnlRegisterContainer.Controls.Add(this.lblSubtitle);
            this.pnlRegisterContainer.Controls.Add(this.lblTitle);
            this.pnlRegisterContainer.Location = new System.Drawing.Point(40, 40);
            this.pnlRegisterContainer.Name = "pnlRegisterContainer";
            this.pnlRegisterContainer.Size = new System.Drawing.Size(470, 620);
            this.pnlRegisterContainer.TabIndex = 0;
            this.pnlRegisterContainer.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlRegisterContainer_Paint);
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblTitle.Location = new System.Drawing.Point(30, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(410, 55);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Create Account";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.lblSubtitle.Location = new System.Drawing.Point(30, 75);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(410, 25);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Fill in the details to get started";
            this.lblSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlUsernameContainer
            // 
            this.pnlUsernameContainer.Controls.Add(this.lblUsername);
            this.pnlUsernameContainer.Controls.Add(this.pnlUsername);
            this.pnlUsernameContainer.Location = new System.Drawing.Point(30, 115);
            this.pnlUsernameContainer.Name = "pnlUsernameContainer";
            this.pnlUsernameContainer.Size = new System.Drawing.Size(410, 70);
            this.pnlUsernameContainer.TabIndex = 2;
            // 
            // lblUsername
            // 
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblUsername.Location = new System.Drawing.Point(0, 0);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(410, 25);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "Username";
            this.lblUsername.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // pnlUsername
            // 
            this.pnlUsername.BackColor = System.Drawing.Color.White;
            this.pnlUsername.Controls.Add(this.lblUsernameIcon);
            this.pnlUsername.Controls.Add(this.txtUsername);
            this.pnlUsername.Location = new System.Drawing.Point(0, 30);
            this.pnlUsername.Name = "pnlUsername";
            this.pnlUsername.Size = new System.Drawing.Size(410, 40);
            this.pnlUsername.TabIndex = 1;
            this.pnlUsername.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlUsername_Paint);
            // 
            // lblUsernameIcon
            // 
            this.lblUsernameIcon.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsernameIcon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.lblUsernameIcon.Location = new System.Drawing.Point(10, 0);
            this.lblUsernameIcon.Name = "lblUsernameIcon";
            this.lblUsernameIcon.Size = new System.Drawing.Size(30, 40);
            this.lblUsernameIcon.TabIndex = 0;
            this.lblUsernameIcon.Text = "👤";
            this.lblUsernameIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtUsername
            // 
            this.txtUsername.BackColor = System.Drawing.Color.White;
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.txtUsername.Location = new System.Drawing.Point(45, 10);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(355, 25);
            this.txtUsername.TabIndex = 0;
            this.txtUsername.Enter += new System.EventHandler(this.txtUsername_Enter);
            this.txtUsername.Leave += new System.EventHandler(this.txtUsername_Leave);
            // 
            // pnlFullNameContainer
            // 
            this.pnlFullNameContainer.Controls.Add(this.lblFullName);
            this.pnlFullNameContainer.Controls.Add(this.pnlFullName);
            this.pnlFullNameContainer.Location = new System.Drawing.Point(30, 195);
            this.pnlFullNameContainer.Name = "pnlFullNameContainer";
            this.pnlFullNameContainer.Size = new System.Drawing.Size(410, 70);
            this.pnlFullNameContainer.TabIndex = 3;
            // 
            // lblFullName
            // 
            this.lblFullName.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFullName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblFullName.Location = new System.Drawing.Point(0, 0);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(410, 25);
            this.lblFullName.TabIndex = 0;
            this.lblFullName.Text = "Full Name";
            this.lblFullName.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // pnlFullName
            // 
            this.pnlFullName.BackColor = System.Drawing.Color.White;
            this.pnlFullName.Controls.Add(this.lblFullNameIcon);
            this.pnlFullName.Controls.Add(this.txtFullName);
            this.pnlFullName.Location = new System.Drawing.Point(0, 30);
            this.pnlFullName.Name = "pnlFullName";
            this.pnlFullName.Size = new System.Drawing.Size(410, 40);
            this.pnlFullName.TabIndex = 1;
            this.pnlFullName.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlFullName_Paint);
            // 
            // lblFullNameIcon
            // 
            this.lblFullNameIcon.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFullNameIcon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.lblFullNameIcon.Location = new System.Drawing.Point(10, 0);
            this.lblFullNameIcon.Name = "lblFullNameIcon";
            this.lblFullNameIcon.Size = new System.Drawing.Size(30, 40);
            this.lblFullNameIcon.TabIndex = 0;
            this.lblFullNameIcon.Text = "✏️";
            this.lblFullNameIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtFullName
            // 
            this.txtFullName.BackColor = System.Drawing.Color.White;
            this.txtFullName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFullName.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFullName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.txtFullName.Location = new System.Drawing.Point(45, 10);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(355, 25);
            this.txtFullName.TabIndex = 0;
            this.txtFullName.Enter += new System.EventHandler(this.txtFullName_Enter);
            this.txtFullName.Leave += new System.EventHandler(this.txtFullName_Leave);
            // 
            // pnlPasswordContainer
            // 
            this.pnlPasswordContainer.Controls.Add(this.lblPassword);
            this.pnlPasswordContainer.Controls.Add(this.pnlPassword);
            this.pnlPasswordContainer.Location = new System.Drawing.Point(30, 275);
            this.pnlPasswordContainer.Name = "pnlPasswordContainer";
            this.pnlPasswordContainer.Size = new System.Drawing.Size(410, 70);
            this.pnlPasswordContainer.TabIndex = 4;
            // 
            // lblPassword
            // 
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblPassword.Location = new System.Drawing.Point(0, 0);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(410, 25);
            this.lblPassword.TabIndex = 0;
            this.lblPassword.Text = "Password";
            this.lblPassword.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // pnlPassword
            // 
            this.pnlPassword.BackColor = System.Drawing.Color.White;
            this.pnlPassword.Controls.Add(this.lblPasswordIcon);
            this.pnlPassword.Controls.Add(this.txtPassword);
            this.pnlPassword.Location = new System.Drawing.Point(0, 30);
            this.pnlPassword.Name = "pnlPassword";
            this.pnlPassword.Size = new System.Drawing.Size(410, 40);
            this.pnlPassword.TabIndex = 1;
            this.pnlPassword.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlPassword_Paint);
            // 
            // lblPasswordIcon
            // 
            this.lblPasswordIcon.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPasswordIcon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.lblPasswordIcon.Location = new System.Drawing.Point(10, 0);
            this.lblPasswordIcon.Name = "lblPasswordIcon";
            this.lblPasswordIcon.Size = new System.Drawing.Size(30, 40);
            this.lblPasswordIcon.TabIndex = 0;
            this.lblPasswordIcon.Text = "🔒";
            this.lblPasswordIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.White;
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.txtPassword.Location = new System.Drawing.Point(45, 10);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.Size = new System.Drawing.Size(355, 25);
            this.txtPassword.TabIndex = 0;
            this.txtPassword.Enter += new System.EventHandler(this.txtPassword_Enter);
            this.txtPassword.Leave += new System.EventHandler(this.txtPassword_Leave);
            // 
            // pnlConfirmPasswordContainer
            // 
            this.pnlConfirmPasswordContainer.Controls.Add(this.lblConfirmPassword);
            this.pnlConfirmPasswordContainer.Controls.Add(this.pnlConfirmPassword);
            this.pnlConfirmPasswordContainer.Location = new System.Drawing.Point(30, 355);
            this.pnlConfirmPasswordContainer.Name = "pnlConfirmPasswordContainer";
            this.pnlConfirmPasswordContainer.Size = new System.Drawing.Size(410, 70);
            this.pnlConfirmPasswordContainer.TabIndex = 5;
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirmPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblConfirmPassword.Location = new System.Drawing.Point(0, 0);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(410, 25);
            this.lblConfirmPassword.TabIndex = 0;
            this.lblConfirmPassword.Text = "Confirm Password";
            this.lblConfirmPassword.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // pnlConfirmPassword
            // 
            this.pnlConfirmPassword.BackColor = System.Drawing.Color.White;
            this.pnlConfirmPassword.Controls.Add(this.lblConfirmPasswordIcon);
            this.pnlConfirmPassword.Controls.Add(this.txtConfirmPassword);
            this.pnlConfirmPassword.Location = new System.Drawing.Point(0, 30);
            this.pnlConfirmPassword.Name = "pnlConfirmPassword";
            this.pnlConfirmPassword.Size = new System.Drawing.Size(410, 40);
            this.pnlConfirmPassword.TabIndex = 1;
            this.pnlConfirmPassword.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlConfirmPassword_Paint);
            // 
            // lblConfirmPasswordIcon
            // 
            this.lblConfirmPasswordIcon.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirmPasswordIcon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.lblConfirmPasswordIcon.Location = new System.Drawing.Point(10, 0);
            this.lblConfirmPasswordIcon.Name = "lblConfirmPasswordIcon";
            this.lblConfirmPasswordIcon.Size = new System.Drawing.Size(30, 40);
            this.lblConfirmPasswordIcon.TabIndex = 0;
            this.lblConfirmPasswordIcon.Text = "🔑";
            this.lblConfirmPasswordIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.BackColor = System.Drawing.Color.White;
            this.txtConfirmPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtConfirmPassword.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.txtConfirmPassword.Location = new System.Drawing.Point(45, 10);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '●';
            this.txtConfirmPassword.Size = new System.Drawing.Size(355, 25);
            this.txtConfirmPassword.TabIndex = 0;
            this.txtConfirmPassword.Enter += new System.EventHandler(this.txtConfirmPassword_Enter);
            this.txtConfirmPassword.Leave += new System.EventHandler(this.txtConfirmPassword_Leave);
            // 
            // btnRegister
            // 
            this.btnRegister.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(188)))), ((int)(((byte)(156)))));
            this.btnRegister.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegister.FlatAppearance.BorderSize = 0;
            this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegister.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegister.ForeColor = System.Drawing.Color.White;
            this.btnRegister.Location = new System.Drawing.Point(30, 440);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(410, 48);
            this.btnRegister.TabIndex = 6;
            this.btnRegister.Text = "CREATE ACCOUNT";
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            this.btnRegister.MouseEnter += new System.EventHandler(this.btnRegister_MouseEnter);
            this.btnRegister.MouseLeave += new System.EventHandler(this.btnRegister_MouseLeave);
            this.btnRegister.Paint += new System.Windows.Forms.PaintEventHandler(this.btnRegister_Paint);
            // 
            // pnlDivider
            // 
            this.pnlDivider.Controls.Add(this.lblOr);
            this.pnlDivider.Controls.Add(this.lblDividerRight);
            this.pnlDivider.Controls.Add(this.lblDividerLeft);
            this.pnlDivider.Location = new System.Drawing.Point(30, 500);
            this.pnlDivider.Name = "pnlDivider";
            this.pnlDivider.Size = new System.Drawing.Size(410, 20);
            this.pnlDivider.TabIndex = 7;
            // 
            // lblDividerLeft
            // 
            this.lblDividerLeft.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDividerLeft.Location = new System.Drawing.Point(0, 10);
            this.lblDividerLeft.Name = "lblDividerLeft";
            this.lblDividerLeft.Size = new System.Drawing.Size(150, 2);
            this.lblDividerLeft.TabIndex = 0;
            // 
            // lblDividerRight
            // 
            this.lblDividerRight.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDividerRight.Location = new System.Drawing.Point(260, 10);
            this.lblDividerRight.Name = "lblDividerRight";
            this.lblDividerRight.Size = new System.Drawing.Size(150, 2);
            this.lblDividerRight.TabIndex = 1;
            // 
            // lblOr
            // 
            this.lblOr.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.lblOr.Location = new System.Drawing.Point(155, 0);
            this.lblOr.Name = "lblOr";
            this.lblOr.Size = new System.Drawing.Size(100, 20);
            this.lblOr.TabIndex = 2;
            this.lblOr.Text = "OR";
            this.lblOr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(188)))), ((int)(((byte)(156)))));
            this.btnCancel.FlatAppearance.BorderSize = 2;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(188)))), ((int)(((byte)(156)))));
            this.btnCancel.Location = new System.Drawing.Point(30, 530);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(410, 48);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            this.btnCancel.MouseEnter += new System.EventHandler(this.btnCancel_MouseEnter);
            this.btnCancel.MouseLeave += new System.EventHandler(this.btnCancel_MouseLeave);
            this.btnCancel.Paint += new System.Windows.Forms.PaintEventHandler(this.btnCancel_Paint);
            // 
            // lblFooter
            // 
            this.lblFooter.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFooter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.lblFooter.Location = new System.Drawing.Point(30, 585);
            this.lblFooter.Name = "lblFooter";
            this.lblFooter.Size = new System.Drawing.Size(410, 25);
            this.lblFooter.TabIndex = 9;
            this.lblFooter.Text = "Already have an account? Sign in instead";
            this.lblFooter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1000, 700);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "RegisterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QCM Management System - Register";
            this.pnlMain.ResumeLayout(false);
            this.pnlLeft.ResumeLayout(false);
            this.pnlRight.ResumeLayout(false);
            this.pnlRegisterContainer.ResumeLayout(false);
            this.pnlUsernameContainer.ResumeLayout(false);
            this.pnlUsername.ResumeLayout(false);
            this.pnlUsername.PerformLayout();
            this.pnlFullNameContainer.ResumeLayout(false);
            this.pnlFullName.ResumeLayout(false);
            this.pnlFullName.PerformLayout();
            this.pnlPasswordContainer.ResumeLayout(false);
            this.pnlPassword.ResumeLayout(false);
            this.pnlPassword.PerformLayout();
            this.pnlConfirmPasswordContainer.ResumeLayout(false);
            this.pnlConfirmPassword.ResumeLayout(false);
            this.pnlConfirmPassword.PerformLayout();
            this.pnlDivider.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblSystemName;
        private System.Windows.Forms.Label lblQuote;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Panel pnlRegisterContainer;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Panel pnlUsernameContainer;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Panel pnlUsername;
        private System.Windows.Forms.Label lblUsernameIcon;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Panel pnlFullNameContainer;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Panel pnlFullName;
        private System.Windows.Forms.Label lblFullNameIcon;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Panel pnlPasswordContainer;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Panel pnlPassword;
        private System.Windows.Forms.Label lblPasswordIcon;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Panel pnlConfirmPasswordContainer;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.Panel pnlConfirmPassword;
        private System.Windows.Forms.Label lblConfirmPasswordIcon;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Panel pnlDivider;
        private System.Windows.Forms.Label lblOr;
        private System.Windows.Forms.Label lblDividerRight;
        private System.Windows.Forms.Label lblDividerLeft;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblFooter;
    }
}