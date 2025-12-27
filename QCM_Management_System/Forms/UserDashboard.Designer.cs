namespace QCM_Management_System.Forms
{
    partial class UserDashboard
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblAvailableQCMs = new System.Windows.Forms.Label();
            this.dgvQCMs = new System.Windows.Forms.DataGridView();
            this.btnTakeQCM = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lblMyResults = new System.Windows.Forms.Label();
            this.dgvResults = new System.Windows.Forms.DataGridView();
            this.btnViewDetails = new System.Windows.Forms.Button();
            this.btnDeleteResult = new System.Windows.Forms.Button(); 
            ((System.ComponentModel.ISupportInitialize)(this.dgvQCMs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.SuspendLayout();
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.lblWelcome.Location = new System.Drawing.Point(30, 20);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(250, 37);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Welcome, User!";
            // 
            // lblAvailableQCMs
            // 
            this.lblAvailableQCMs.AutoSize = true;
            this.lblAvailableQCMs.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblAvailableQCMs.Location = new System.Drawing.Point(30, 80);
            this.lblAvailableQCMs.Name = "lblAvailableQCMs";
            this.lblAvailableQCMs.Size = new System.Drawing.Size(160, 28);
            this.lblAvailableQCMs.TabIndex = 1;
            this.lblAvailableQCMs.Text = "Available QCMs";
            // 
            // dgvQCMs
            // 
            this.dgvQCMs.AllowUserToAddRows = false;
            this.dgvQCMs.AllowUserToDeleteRows = false;
            this.dgvQCMs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvQCMs.BackgroundColor = System.Drawing.Color.White;
            this.dgvQCMs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQCMs.Location = new System.Drawing.Point(30, 120);
            this.dgvQCMs.Name = "dgvQCMs";
            this.dgvQCMs.ReadOnly = true;
            this.dgvQCMs.RowHeadersWidth = 51;
            this.dgvQCMs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvQCMs.Size = new System.Drawing.Size(1100, 200);
            this.dgvQCMs.TabIndex = 2;
            // 
            // btnTakeQCM
            // 
            this.btnTakeQCM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnTakeQCM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTakeQCM.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnTakeQCM.ForeColor = System.Drawing.Color.White;
            this.btnTakeQCM.Location = new System.Drawing.Point(980, 340);
            this.btnTakeQCM.Name = "btnTakeQCM";
            this.btnTakeQCM.Size = new System.Drawing.Size(150, 40);
            this.btnTakeQCM.TabIndex = 3;
            this.btnTakeQCM.Text = "Take QCM";
            this.btnTakeQCM.UseVisualStyleBackColor = false;
            this.btnTakeQCM.Click += new System.EventHandler(this.btnTakeQCM_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(980, 20);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(150, 40);
            this.btnLogout.TabIndex = 4;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // lblMyResults
            // 
            this.lblMyResults.AutoSize = true;
            this.lblMyResults.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblMyResults.Location = new System.Drawing.Point(30, 400);
            this.lblMyResults.Name = "lblMyResults";
            this.lblMyResults.Size = new System.Drawing.Size(114, 28);
            this.lblMyResults.TabIndex = 5;
            this.lblMyResults.Text = "My Results";
            // 
            // dgvResults
            // 
            this.dgvResults.AllowUserToAddRows = false;
            this.dgvResults.AllowUserToDeleteRows = false;
            this.dgvResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvResults.BackgroundColor = System.Drawing.Color.White;
            this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResults.Location = new System.Drawing.Point(30, 440);
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.ReadOnly = true;
            this.dgvResults.RowHeadersWidth = 51;
            this.dgvResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResults.Size = new System.Drawing.Size(1100, 220);
            this.dgvResults.TabIndex = 6;
            // 
            // btnDeleteResult
            // 
            this.btnDeleteResult.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnDeleteResult.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteResult.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDeleteResult.ForeColor = System.Drawing.Color.White;
            this.btnDeleteResult.Location = new System.Drawing.Point(810, 680);
            this.btnDeleteResult.Name = "btnDeleteResult";
            this.btnDeleteResult.Size = new System.Drawing.Size(150, 40);
            this.btnDeleteResult.TabIndex = 8;
            this.btnDeleteResult.Text = "Delete";
            this.btnDeleteResult.UseVisualStyleBackColor = false;
            this.btnDeleteResult.Click += new System.EventHandler(this.btnDeleteResult_Click);
            // 
            // btnViewDetails
            // 
            this.btnViewDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnViewDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewDetails.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnViewDetails.ForeColor = System.Drawing.Color.White;
            this.btnViewDetails.Location = new System.Drawing.Point(980, 680);
            this.btnViewDetails.Name = "btnViewDetails";
            this.btnViewDetails.Size = new System.Drawing.Size(150, 40);
            this.btnViewDetails.TabIndex = 7;
            this.btnViewDetails.Text = "View Details";
            this.btnViewDetails.UseVisualStyleBackColor = false;
            this.btnViewDetails.Click += new System.EventHandler(this.btnViewDetails_Click);
            // 
            // UserDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1160, 740);
            this.Controls.Add(this.btnDeleteResult); 
            this.Controls.Add(this.btnViewDetails);
            this.Controls.Add(this.dgvResults);
            this.Controls.Add(this.lblMyResults);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnTakeQCM);
            this.Controls.Add(this.dgvQCMs);
            this.Controls.Add(this.lblAvailableQCMs);
            this.Controls.Add(this.lblWelcome);
            this.Name = "UserDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Dashboard";
            this.Load += new System.EventHandler(this.UserDashboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvQCMs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblAvailableQCMs;
        private System.Windows.Forms.DataGridView dgvQCMs;
        private System.Windows.Forms.Button btnTakeQCM;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lblMyResults;
        private System.Windows.Forms.DataGridView dgvResults;
        private System.Windows.Forms.Button btnViewDetails;
        private System.Windows.Forms.Button btnDeleteResult;
    }
}