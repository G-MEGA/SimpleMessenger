namespace SimpleMessengerClient.Forms
{
    partial class MyProfileModifyForm
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
            this.confirmButton = new System.Windows.Forms.Button();
            this.nicknameBox = new System.Windows.Forms.TextBox();
            this.selfIntroductionBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // confirmButton
            // 
            this.confirmButton.Location = new System.Drawing.Point(174, 409);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(94, 29);
            this.confirmButton.TabIndex = 0;
            this.confirmButton.Text = "확인";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // nicknameBox
            // 
            this.nicknameBox.Location = new System.Drawing.Point(32, 41);
            this.nicknameBox.Name = "nicknameBox";
            this.nicknameBox.Size = new System.Drawing.Size(396, 27);
            this.nicknameBox.TabIndex = 1;
            // 
            // selfIntroductionBox
            // 
            this.selfIntroductionBox.Location = new System.Drawing.Point(32, 111);
            this.selfIntroductionBox.Multiline = true;
            this.selfIntroductionBox.Name = "selfIntroductionBox";
            this.selfIntroductionBox.Size = new System.Drawing.Size(396, 253);
            this.selfIntroductionBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "닉네임";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "자기소개";
            // 
            // MyProfileModifyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.selfIntroductionBox);
            this.Controls.Add(this.nicknameBox);
            this.Controls.Add(this.confirmButton);
            this.Name = "MyProfileModifyForm";
            this.Text = "MyProfileModifyForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MyProfileModifyForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button confirmButton;
        private TextBox nicknameBox;
        private TextBox selfIntroductionBox;
        private Label label1;
        private Label label2;
    }
}