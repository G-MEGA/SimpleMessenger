namespace SimpleMessengerClient.Forms
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.failText = new System.Windows.Forms.Label();
            this.registerButton = new System.Windows.Forms.Button();
            this.idBox = new System.Windows.Forms.TextBox();
            this.nicknameBox = new System.Windows.Forms.TextBox();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.passwordConfirmBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nickname";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Password Confirm";
            // 
            // failText
            // 
            this.failText.ForeColor = System.Drawing.Color.Red;
            this.failText.Location = new System.Drawing.Point(29, 204);
            this.failText.Name = "failText";
            this.failText.Size = new System.Drawing.Size(407, 36);
            this.failText.TabIndex = 4;
            this.failText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // registerButton
            // 
            this.registerButton.Location = new System.Drawing.Point(29, 243);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(407, 43);
            this.registerButton.TabIndex = 5;
            this.registerButton.Text = "회원가입";
            this.registerButton.UseVisualStyleBackColor = true;
            this.registerButton.Click += new System.EventHandler(this.registerButton_Click);
            // 
            // idBox
            // 
            this.idBox.Location = new System.Drawing.Point(181, 28);
            this.idBox.Name = "idBox";
            this.idBox.Size = new System.Drawing.Size(255, 27);
            this.idBox.TabIndex = 6;
            // 
            // nicknameBox
            // 
            this.nicknameBox.Location = new System.Drawing.Point(181, 74);
            this.nicknameBox.Name = "nicknameBox";
            this.nicknameBox.Size = new System.Drawing.Size(255, 27);
            this.nicknameBox.TabIndex = 7;
            // 
            // passwordBox
            // 
            this.passwordBox.Location = new System.Drawing.Point(181, 118);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.Size = new System.Drawing.Size(255, 27);
            this.passwordBox.TabIndex = 8;
            // 
            // passwordConfirmBox
            // 
            this.passwordConfirmBox.Location = new System.Drawing.Point(181, 164);
            this.passwordConfirmBox.Name = "passwordConfirmBox";
            this.passwordConfirmBox.Size = new System.Drawing.Size(255, 27);
            this.passwordConfirmBox.TabIndex = 9;
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 298);
            this.Controls.Add(this.passwordConfirmBox);
            this.Controls.Add(this.passwordBox);
            this.Controls.Add(this.nicknameBox);
            this.Controls.Add(this.idBox);
            this.Controls.Add(this.registerButton);
            this.Controls.Add(this.failText);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "RegisterForm";
            this.Text = "RegisterForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RegisterForm_FormClosing);
            this.Shown += new System.EventHandler(this.RegisterForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label failText;
        private Button registerButton;
        private TextBox idBox;
        private TextBox nicknameBox;
        private TextBox passwordBox;
        private TextBox passwordConfirmBox;
    }
}