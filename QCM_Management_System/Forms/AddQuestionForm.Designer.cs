namespace QCM_Management_System.Forms
{
    partial class AddQuestionForm
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
            this.grpQuestion = new System.Windows.Forms.GroupBox();
            this.txtQuestion = new System.Windows.Forms.TextBox();
            this.grpAnswers = new System.Windows.Forms.GroupBox();
            this.radioAnswer4 = new System.Windows.Forms.RadioButton();
            this.radioAnswer3 = new System.Windows.Forms.RadioButton();
            this.radioAnswer2 = new System.Windows.Forms.RadioButton();
            this.radioAnswer1 = new System.Windows.Forms.RadioButton();
            this.txtAnswer4 = new System.Windows.Forms.TextBox();
            this.txtAnswer3 = new System.Windows.Forms.TextBox();
            this.txtAnswer2 = new System.Windows.Forms.TextBox();
            this.txtAnswer1 = new System.Windows.Forms.TextBox();
            this.lblAnswer4 = new System.Windows.Forms.Label();
            this.lblAnswer3 = new System.Windows.Forms.Label();
            this.lblAnswer2 = new System.Windows.Forms.Label();
            this.lblAnswer1 = new System.Windows.Forms.Label();
            this.lblInstruction = new System.Windows.Forms.Label();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.grpQuestion.SuspendLayout();
            this.grpAnswers.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(650, 70);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(650, 70);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "➕ Add Question";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpQuestion
            // 
            this.grpQuestion.BackColor = System.Drawing.Color.White;
            this.grpQuestion.Controls.Add(this.txtQuestion);
            this.grpQuestion.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.grpQuestion.Location = new System.Drawing.Point(20, 90);
            this.grpQuestion.Name = "grpQuestion";
            this.grpQuestion.Size = new System.Drawing.Size(610, 120);
            this.grpQuestion.TabIndex = 1;
            this.grpQuestion.TabStop = false;
            this.grpQuestion.Text = "Question Text";
            // 
            // txtQuestion
            // 
            this.txtQuestion.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtQuestion.Location = new System.Drawing.Point(20, 30);
            this.txtQuestion.Multiline = true;
            this.txtQuestion.Name = "txtQuestion";
            this.txtQuestion.Size = new System.Drawing.Size(570, 70);
            this.txtQuestion.TabIndex = 0;
            // 
            // grpAnswers
            // 
            this.grpAnswers.BackColor = System.Drawing.Color.White;
            this.grpAnswers.Controls.Add(this.radioAnswer4);
            this.grpAnswers.Controls.Add(this.radioAnswer3);
            this.grpAnswers.Controls.Add(this.radioAnswer2);
            this.grpAnswers.Controls.Add(this.radioAnswer1);
            this.grpAnswers.Controls.Add(this.txtAnswer4);
            this.grpAnswers.Controls.Add(this.txtAnswer3);
            this.grpAnswers.Controls.Add(this.txtAnswer2);
            this.grpAnswers.Controls.Add(this.txtAnswer1);
            this.grpAnswers.Controls.Add(this.lblAnswer4);
            this.grpAnswers.Controls.Add(this.lblAnswer3);
            this.grpAnswers.Controls.Add(this.lblAnswer2);
            this.grpAnswers.Controls.Add(this.lblAnswer1);
            this.grpAnswers.Controls.Add(this.lblInstruction);
            this.grpAnswers.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.grpAnswers.Location = new System.Drawing.Point(20, 230);
            this.grpAnswers.Name = "grpAnswers";
            this.grpAnswers.Size = new System.Drawing.Size(610, 300);
            this.grpAnswers.TabIndex = 2;
            this.grpAnswers.TabStop = false;
            this.grpAnswers.Text = "Answers (Select the correct one)";
            // 
            // radioAnswer4
            // 
            this.radioAnswer4.AutoSize = true;
            this.radioAnswer4.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.radioAnswer4.Location = new System.Drawing.Point(550, 250);
            this.radioAnswer4.Name = "radioAnswer4";
            this.radioAnswer4.Size = new System.Drawing.Size(14, 13);
            this.radioAnswer4.TabIndex = 12;
            this.radioAnswer4.TabStop = true;
            this.radioAnswer4.UseVisualStyleBackColor = true;
            // 
            // radioAnswer3
            // 
            this.radioAnswer3.AutoSize = true;
            this.radioAnswer3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.radioAnswer3.Location = new System.Drawing.Point(550, 195);
            this.radioAnswer3.Name = "radioAnswer3";
            this.radioAnswer3.Size = new System.Drawing.Size(14, 13);
            this.radioAnswer3.TabIndex = 11;
            this.radioAnswer3.TabStop = true;
            this.radioAnswer3.UseVisualStyleBackColor = true;
            // 
            // radioAnswer2
            // 
            this.radioAnswer2.AutoSize = true;
            this.radioAnswer2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.radioAnswer2.Location = new System.Drawing.Point(550, 140);
            this.radioAnswer2.Name = "radioAnswer2";
            this.radioAnswer2.Size = new System.Drawing.Size(14, 13);
            this.radioAnswer2.TabIndex = 10;
            this.radioAnswer2.TabStop = true;
            this.radioAnswer2.UseVisualStyleBackColor = true;
            // 
            // radioAnswer1
            // 
            this.radioAnswer1.AutoSize = true;
            this.radioAnswer1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.radioAnswer1.Location = new System.Drawing.Point(550, 85);
            this.radioAnswer1.Name = "radioAnswer1";
            this.radioAnswer1.Size = new System.Drawing.Size(14, 13);
            this.radioAnswer1.TabIndex = 9;
            this.radioAnswer1.TabStop = true;
            this.radioAnswer1.UseVisualStyleBackColor = true;
            // 
            // txtAnswer4
            // 
            this.txtAnswer4.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtAnswer4.Location = new System.Drawing.Point(120, 245);
            this.txtAnswer4.Name = "txtAnswer4";
            this.txtAnswer4.Size = new System.Drawing.Size(410, 25);
            this.txtAnswer4.TabIndex = 8;
            // 
            // txtAnswer3
            // 
            this.txtAnswer3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtAnswer3.Location = new System.Drawing.Point(120, 190);
            this.txtAnswer3.Name = "txtAnswer3";
            this.txtAnswer3.Size = new System.Drawing.Size(410, 25);
            this.txtAnswer3.TabIndex = 7;
            // 
            // txtAnswer2
            // 
            this.txtAnswer2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtAnswer2.Location = new System.Drawing.Point(120, 135);
            this.txtAnswer2.Name = "txtAnswer2";
            this.txtAnswer2.Size = new System.Drawing.Size(410, 25);
            this.txtAnswer2.TabIndex = 6;
            // 
            // txtAnswer1
            // 
            this.txtAnswer1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtAnswer1.Location = new System.Drawing.Point(120, 80);
            this.txtAnswer1.Name = "txtAnswer1";
            this.txtAnswer1.Size = new System.Drawing.Size(410, 25);
            this.txtAnswer1.TabIndex = 5;
            // 
            // lblAnswer4
            // 
            this.lblAnswer4.AutoSize = true;
            this.lblAnswer4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblAnswer4.Location = new System.Drawing.Point(20, 248);
            this.lblAnswer4.Name = "lblAnswer4";
            this.lblAnswer4.Size = new System.Drawing.Size(82, 19);
            this.lblAnswer4.TabIndex = 4;
            this.lblAnswer4.Text = "Answer 4:";
            // 
            // lblAnswer3
            // 
            this.lblAnswer3.AutoSize = true;
            this.lblAnswer3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblAnswer3.Location = new System.Drawing.Point(20, 193);
            this.lblAnswer3.Name = "lblAnswer3";
            this.lblAnswer3.Size = new System.Drawing.Size(82, 19);
            this.lblAnswer3.TabIndex = 3;
            this.lblAnswer3.Text = "Answer 3:";
            // 
            // lblAnswer2
            // 
            this.lblAnswer2.AutoSize = true;
            this.lblAnswer2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblAnswer2.Location = new System.Drawing.Point(20, 138);
            this.lblAnswer2.Name = "lblAnswer2";
            this.lblAnswer2.Size = new System.Drawing.Size(82, 19);
            this.lblAnswer2.TabIndex = 2;
            this.lblAnswer2.Text = "Answer 2:";
            // 
            // lblAnswer1
            // 
            this.lblAnswer1.AutoSize = true;
            this.lblAnswer1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblAnswer1.Location = new System.Drawing.Point(20, 83);
            this.lblAnswer1.Name = "lblAnswer1";
            this.lblAnswer1.Size = new System.Drawing.Size(82, 19);
            this.lblAnswer1.TabIndex = 1;
            this.lblAnswer1.Text = "Answer 1:";
            // 
            // lblInstruction
            // 
            this.lblInstruction.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblInstruction.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblInstruction.Location = new System.Drawing.Point(20, 30);
            this.lblInstruction.Name = "lblInstruction";
            this.lblInstruction.Size = new System.Drawing.Size(570, 30);
            this.lblInstruction.TabIndex = 0;
            this.lblInstruction.Text = "Enter all four answers and select the radio button next to the correct answer. Al" +
    "l fields are required.";
            // 
            // pnlButtons
            // 
            this.pnlButtons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.pnlButtons.Controls.Add(this.btnCancel);
            this.pnlButtons.Controls.Add(this.btnAdd);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(0, 550);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(650, 70);
            this.pnlButtons.TabIndex = 3;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(355, 15);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(150, 40);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "✖ Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(145, 15);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(150, 40);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "✔ Add Question";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // AddQuestionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(650, 620);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.grpAnswers);
            this.Controls.Add(this.grpQuestion);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddQuestionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Question";
            this.pnlHeader.ResumeLayout(false);
            this.grpQuestion.ResumeLayout(false);
            this.grpQuestion.PerformLayout();
            this.grpAnswers.ResumeLayout(false);
            this.grpAnswers.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpQuestion;
        private System.Windows.Forms.TextBox txtQuestion;
        private System.Windows.Forms.GroupBox grpAnswers;
        private System.Windows.Forms.RadioButton radioAnswer4;
        private System.Windows.Forms.RadioButton radioAnswer3;
        private System.Windows.Forms.RadioButton radioAnswer2;
        private System.Windows.Forms.RadioButton radioAnswer1;
        private System.Windows.Forms.TextBox txtAnswer4;
        private System.Windows.Forms.TextBox txtAnswer3;
        private System.Windows.Forms.TextBox txtAnswer2;
        private System.Windows.Forms.TextBox txtAnswer1;
        private System.Windows.Forms.Label lblAnswer4;
        private System.Windows.Forms.Label lblAnswer3;
        private System.Windows.Forms.Label lblAnswer2;
        private System.Windows.Forms.Label lblAnswer1;
        private System.Windows.Forms.Label lblInstruction;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAdd;
    }
}