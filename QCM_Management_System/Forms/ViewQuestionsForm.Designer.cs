namespace QCM_Management_System.Forms
{
    partial class ViewQuestionsForm
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.dgvQuestions = new System.Windows.Forms.DataGridView();
            this.lblQuestionsList = new System.Windows.Forms.Label();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.grpAnswers = new System.Windows.Forms.GroupBox();
            this.dgvAnswers = new System.Windows.Forms.DataGridView();
            this.grpQuestionDetail = new System.Windows.Forms.GroupBox();
            this.txtQuestionDetail = new System.Windows.Forms.TextBox();
            this.lblAnswerDetails = new System.Windows.Forms.Label();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDeleteQuestion = new System.Windows.Forms.Button();
            this.btnEditQuestion = new System.Windows.Forms.Button();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblTotalQuestions = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuestions)).BeginInit();
            this.pnlRight.SuspendLayout();
            this.grpAnswers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnswers)).BeginInit();
            this.grpQuestionDetail.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(4);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1600, 86);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1600, 86);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "📋 Questions for: [QCM Title]";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 86);
            this.splitContainer.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.pnlLeft);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.pnlRight);
            this.splitContainer.Size = new System.Drawing.Size(1600, 505);
            this.splitContainer.SplitterDistance = 733;
            this.splitContainer.SplitterWidth = 5;
            this.splitContainer.TabIndex = 1;
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = System.Drawing.Color.White;
            this.pnlLeft.Controls.Add(this.dgvQuestions);
            this.pnlLeft.Controls.Add(this.lblQuestionsList);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Margin = new System.Windows.Forms.Padding(4);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(733, 505);
            this.pnlLeft.TabIndex = 0;
            // 
            // dgvQuestions
            // 
            this.dgvQuestions.AllowUserToAddRows = false;
            this.dgvQuestions.AllowUserToDeleteRows = false;
            this.dgvQuestions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvQuestions.BackgroundColor = System.Drawing.Color.White;
            this.dgvQuestions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQuestions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvQuestions.Location = new System.Drawing.Point(0, 49);
            this.dgvQuestions.Margin = new System.Windows.Forms.Padding(4);
            this.dgvQuestions.MultiSelect = false;
            this.dgvQuestions.Name = "dgvQuestions";
            this.dgvQuestions.ReadOnly = true;
            this.dgvQuestions.RowHeadersWidth = 51;
            this.dgvQuestions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvQuestions.Size = new System.Drawing.Size(733, 456);
            this.dgvQuestions.TabIndex = 1;
            this.dgvQuestions.SelectionChanged += new System.EventHandler(this.dgvQuestions_SelectionChanged);
            // 
            // lblQuestionsList
            // 
            this.lblQuestionsList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblQuestionsList.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblQuestionsList.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblQuestionsList.ForeColor = System.Drawing.Color.White;
            this.lblQuestionsList.Location = new System.Drawing.Point(0, 0);
            this.lblQuestionsList.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblQuestionsList.Name = "lblQuestionsList";
            this.lblQuestionsList.Size = new System.Drawing.Size(733, 49);
            this.lblQuestionsList.TabIndex = 0;
            this.lblQuestionsList.Text = "📝 Questions List";
            this.lblQuestionsList.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlRight
            // 
            this.pnlRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.pnlRight.Controls.Add(this.grpAnswers);
            this.pnlRight.Controls.Add(this.grpQuestionDetail);
            this.pnlRight.Controls.Add(this.lblAnswerDetails);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(0, 0);
            this.pnlRight.Margin = new System.Windows.Forms.Padding(4);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(862, 505);
            this.pnlRight.TabIndex = 0;
            // 
            // grpAnswers
            // 
            this.grpAnswers.Controls.Add(this.dgvAnswers);
            this.grpAnswers.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpAnswers.Location = new System.Drawing.Point(20, 222);
            this.grpAnswers.Margin = new System.Windows.Forms.Padding(4);
            this.grpAnswers.Name = "grpAnswers";
            this.grpAnswers.Padding = new System.Windows.Forms.Padding(4);
            this.grpAnswers.Size = new System.Drawing.Size(820, 271);
            this.grpAnswers.TabIndex = 2;
            this.grpAnswers.TabStop = false;
            this.grpAnswers.Text = "Answer Options";
            // 
            // dgvAnswers
            // 
            this.dgvAnswers.AllowUserToAddRows = false;
            this.dgvAnswers.AllowUserToDeleteRows = false;
            this.dgvAnswers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAnswers.BackgroundColor = System.Drawing.Color.White;
            this.dgvAnswers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAnswers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAnswers.Location = new System.Drawing.Point(4, 27);
            this.dgvAnswers.Margin = new System.Windows.Forms.Padding(4);
            this.dgvAnswers.MultiSelect = false;
            this.dgvAnswers.Name = "dgvAnswers";
            this.dgvAnswers.ReadOnly = true;
            this.dgvAnswers.RowHeadersWidth = 51;
            this.dgvAnswers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAnswers.Size = new System.Drawing.Size(812, 240);
            this.dgvAnswers.TabIndex = 0;
            // 
            // grpQuestionDetail
            // 
            this.grpQuestionDetail.Controls.Add(this.txtQuestionDetail);
            this.grpQuestionDetail.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpQuestionDetail.Location = new System.Drawing.Point(20, 62);
            this.grpQuestionDetail.Margin = new System.Windows.Forms.Padding(4);
            this.grpQuestionDetail.Name = "grpQuestionDetail";
            this.grpQuestionDetail.Padding = new System.Windows.Forms.Padding(4);
            this.grpQuestionDetail.Size = new System.Drawing.Size(820, 148);
            this.grpQuestionDetail.TabIndex = 1;
            this.grpQuestionDetail.TabStop = false;
            this.grpQuestionDetail.Text = "Question Text";
            // 
            // txtQuestionDetail
            // 
            this.txtQuestionDetail.BackColor = System.Drawing.Color.White;
            this.txtQuestionDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtQuestionDetail.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtQuestionDetail.Location = new System.Drawing.Point(4, 27);
            this.txtQuestionDetail.Margin = new System.Windows.Forms.Padding(4);
            this.txtQuestionDetail.Multiline = true;
            this.txtQuestionDetail.Name = "txtQuestionDetail";
            this.txtQuestionDetail.ReadOnly = true;
            this.txtQuestionDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtQuestionDetail.Size = new System.Drawing.Size(812, 117);
            this.txtQuestionDetail.TabIndex = 0;
            // 
            // lblAnswerDetails
            // 
            this.lblAnswerDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblAnswerDetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAnswerDetails.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblAnswerDetails.ForeColor = System.Drawing.Color.White;
            this.lblAnswerDetails.Location = new System.Drawing.Point(0, 0);
            this.lblAnswerDetails.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAnswerDetails.Name = "lblAnswerDetails";
            this.lblAnswerDetails.Size = new System.Drawing.Size(862, 49);
            this.lblAnswerDetails.TabIndex = 0;
            this.lblAnswerDetails.Text = "📄 Question Details";
            this.lblAnswerDetails.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlButtons
            // 
            this.pnlButtons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.pnlButtons.Controls.Add(this.btnClose);
            this.pnlButtons.Controls.Add(this.btnDeleteQuestion);
            this.pnlButtons.Controls.Add(this.btnEditQuestion);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(0, 591);
            this.pnlButtons.Margin = new System.Windows.Forms.Padding(4);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(1600, 86);
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
            this.btnClose.Location = new System.Drawing.Point(660, 15);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(150, 40);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "✖ Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDeleteQuestion
            // 
            this.btnDeleteQuestion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnDeleteQuestion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteQuestion.FlatAppearance.BorderSize = 0;
            this.btnDeleteQuestion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteQuestion.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnDeleteQuestion.ForeColor = System.Drawing.Color.White;
            this.btnDeleteQuestion.Location = new System.Drawing.Point(490, 15);
            this.btnDeleteQuestion.Name = "btnDeleteQuestion";
            this.btnDeleteQuestion.Size = new System.Drawing.Size(150, 40);
            this.btnDeleteQuestion.TabIndex = 1;
            this.btnDeleteQuestion.Text = "🗑 Delete Question";
            this.btnDeleteQuestion.UseVisualStyleBackColor = false;
            this.btnDeleteQuestion.Click += new System.EventHandler(this.btnDeleteQuestion_Click);
            // 
            // btnEditQuestion
            // 
            this.btnEditQuestion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnEditQuestion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditQuestion.FlatAppearance.BorderSize = 0;
            this.btnEditQuestion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditQuestion.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnEditQuestion.ForeColor = System.Drawing.Color.White;
            this.btnEditQuestion.Location = new System.Drawing.Point(320, 15);
            this.btnEditQuestion.Name = "btnEditQuestion";
            this.btnEditQuestion.Size = new System.Drawing.Size(150, 40);
            this.btnEditQuestion.TabIndex = 0;
            this.btnEditQuestion.Text = "✏ Edit Question";
            this.btnEditQuestion.UseVisualStyleBackColor = false;
            this.btnEditQuestion.Click += new System.EventHandler(this.btnEditQuestion_Click);
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.pnlFooter.Controls.Add(this.lblTotalQuestions);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 677);
            this.pnlFooter.Margin = new System.Windows.Forms.Padding(4);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1600, 49);
            this.pnlFooter.TabIndex = 3;
            // 
            // lblTotalQuestions
            // 
            this.lblTotalQuestions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTotalQuestions.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalQuestions.ForeColor = System.Drawing.Color.White;
            this.lblTotalQuestions.Location = new System.Drawing.Point(0, 0);
            this.lblTotalQuestions.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalQuestions.Name = "lblTotalQuestions";
            this.lblTotalQuestions.Size = new System.Drawing.Size(1600, 49);
            this.lblTotalQuestions.TabIndex = 0;
            this.lblTotalQuestions.Text = "Total Questions: 0 | Select a question to view details";
            this.lblTotalQuestions.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ViewQuestionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1600, 726);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "ViewQuestionsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "View Questions & Answers";
            this.pnlHeader.ResumeLayout(false);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.pnlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuestions)).EndInit();
            this.pnlRight.ResumeLayout(false);
            this.grpAnswers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnswers)).EndInit();
            this.grpQuestionDetail.ResumeLayout(false);
            this.grpQuestionDetail.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            this.pnlFooter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.DataGridView dgvQuestions;
        private System.Windows.Forms.Label lblQuestionsList;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.GroupBox grpAnswers;
        private System.Windows.Forms.DataGridView dgvAnswers;
        private System.Windows.Forms.GroupBox grpQuestionDetail;
        private System.Windows.Forms.TextBox txtQuestionDetail;
        private System.Windows.Forms.Label lblAnswerDetails;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDeleteQuestion;
        private System.Windows.Forms.Button btnEditQuestion;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label lblTotalQuestions;
    }
}