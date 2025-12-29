namespace QCM_Management_System.Forms
{
    partial class ManageQCMForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnEditQCM;

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
            this.components = new System.ComponentModel.Container();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.dgvQCMs = new System.Windows.Forms.DataGridView();
            this.cmsQcmRow = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsiToggleActive = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnCreateNew = new System.Windows.Forms.Button();
            this.btnEditQCM = new System.Windows.Forms.Button();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblTotalQCMs = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQCMs)).BeginInit();
            this.cmsQcmRow.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1333, 86);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1333, 86);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "📝 Manage QCM";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvQCMs
            // 
            this.dgvQCMs.AllowUserToAddRows = false;
            this.dgvQCMs.AllowUserToDeleteRows = false;
            this.dgvQCMs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvQCMs.BackgroundColor = System.Drawing.Color.White;
            this.dgvQCMs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQCMs.ContextMenuStrip = this.cmsQcmRow;
            this.dgvQCMs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvQCMs.Location = new System.Drawing.Point(0, 86);
            this.dgvQCMs.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvQCMs.MultiSelect = false;
            this.dgvQCMs.Name = "dgvQCMs";
            this.dgvQCMs.ReadOnly = true;
            this.dgvQCMs.RowHeadersWidth = 51;
            this.dgvQCMs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvQCMs.Size = new System.Drawing.Size(1333, 444);
            this.dgvQCMs.TabIndex = 1;
            // 
            // cmsQcmRow
            // 
            this.cmsQcmRow.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsQcmRow.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsiToggleActive});
            this.cmsQcmRow.Name = "cmsQcmRow";
            this.cmsQcmRow.Size = new System.Drawing.Size(227, 28);
            // 
            // tsiToggleActive
            // 
            this.tsiToggleActive.Name = "tsiToggleActive";
            this.tsiToggleActive.Size = new System.Drawing.Size(226, 24);
            this.tsiToggleActive.Text = "Toggle Active/Inactive";
            this.tsiToggleActive.Click += new System.EventHandler(this.tsiToggleActive_Click);
            // 
            // pnlButtons
            // 
            this.pnlButtons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.pnlButtons.Controls.Add(this.btnClose);
            this.pnlButtons.Controls.Add(this.btnRefresh);
            this.pnlButtons.Controls.Add(this.btnDelete);
            this.pnlButtons.Controls.Add(this.btnEdit);
            this.pnlButtons.Controls.Add(this.btnCreateNew);
            this.pnlButtons.Controls.Add(this.btnEditQCM);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(0, 530);
            this.pnlButtons.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(1333, 98);
            this.pnlButtons.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(1105, 21);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(200, 55);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "✖ Close";
            this.btnClose.UseCompatibleTextRendering = true;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(897, 21);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(200, 55);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "🔄 Refresh";
            this.btnRefresh.UseCompatibleTextRendering = true;
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(689, 21);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(200, 55);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "🗑 Delete";
            this.btnDelete.UseCompatibleTextRendering = true;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(454, 21);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(227, 55);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "✏ View Questions";
            this.btnEdit.UseCompatibleTextRendering = true;
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnCreateNew
            // 
            this.btnCreateNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnCreateNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCreateNew.FlatAppearance.BorderSize = 0;
            this.btnCreateNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateNew.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnCreateNew.ForeColor = System.Drawing.Color.White;
            this.btnCreateNew.Location = new System.Drawing.Point(25, 21);
            this.btnCreateNew.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCreateNew.Name = "btnCreateNew";
            this.btnCreateNew.Size = new System.Drawing.Size(213, 55);
            this.btnCreateNew.TabIndex = 0;
            this.btnCreateNew.Text = "➕ Create New QCM";
            this.btnCreateNew.UseCompatibleTextRendering = true;
            this.btnCreateNew.UseVisualStyleBackColor = false;
            this.btnCreateNew.Click += new System.EventHandler(this.btnCreateNew_Click);
            // 
            // btnEditQCM
            // 
            this.btnEditQCM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(18)))));
            this.btnEditQCM.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditQCM.FlatAppearance.BorderSize = 0;
            this.btnEditQCM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditQCM.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnEditQCM.ForeColor = System.Drawing.Color.White;
            this.btnEditQCM.Location = new System.Drawing.Point(246, 21);
            this.btnEditQCM.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEditQCM.Name = "btnEditQCM";
            this.btnEditQCM.Size = new System.Drawing.Size(200, 55);
            this.btnEditQCM.TabIndex = 4;
            this.btnEditQCM.Text = "✏ Edit QCM";
            this.btnEditQCM.UseVisualStyleBackColor = false;
            this.btnEditQCM.Click += new System.EventHandler(this.btnEditQCM_Click);
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.pnlFooter.Controls.Add(this.lblTotalQCMs);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 628);
            this.pnlFooter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1333, 49);
            this.pnlFooter.TabIndex = 3;
            // 
            // lblTotalQCMs
            // 
            this.lblTotalQCMs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTotalQCMs.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalQCMs.ForeColor = System.Drawing.Color.White;
            this.lblTotalQCMs.Location = new System.Drawing.Point(0, 0);
            this.lblTotalQCMs.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalQCMs.Name = "lblTotalQCMs";
            this.lblTotalQCMs.Size = new System.Drawing.Size(1333, 49);
            this.lblTotalQCMs.TabIndex = 0;
            this.lblTotalQCMs.Text = "Total QCMs: 0";
            this.lblTotalQCMs.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ManageQCMForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1333, 677);
            this.Controls.Add(this.dgvQCMs);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "ManageQCMForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage QCM";
            this.pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvQCMs)).EndInit();
            this.cmsQcmRow.ResumeLayout(false);
            this.pnlButtons.ResumeLayout(false);
            this.pnlFooter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgvQCMs;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnCreateNew;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label lblTotalQCMs;
        private System.Windows.Forms.ContextMenuStrip cmsQcmRow;
        private System.Windows.Forms.ToolStripMenuItem tsiToggleActive;
    }
}