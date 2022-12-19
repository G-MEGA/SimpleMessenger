namespace SimpleMessengerClient.Forms
{
    partial class UserProfileForm
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
            this.idText = new System.Windows.Forms.Label();
            this.nicknameText = new System.Windows.Forms.Label();
            this.selfIntroductionText = new System.Windows.Forms.Label();
            this.addToContactsButton = new System.Windows.Forms.Button();
            this.removeInContactsButton = new System.Windows.Forms.Button();
            this.startChattingButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // idText
            // 
            this.idText.Location = new System.Drawing.Point(12, 9);
            this.idText.Name = "idText";
            this.idText.Size = new System.Drawing.Size(523, 41);
            this.idText.TabIndex = 0;
            this.idText.Text = "ID";
            // 
            // nicknameText
            // 
            this.nicknameText.Location = new System.Drawing.Point(12, 50);
            this.nicknameText.Name = "nicknameText";
            this.nicknameText.Size = new System.Drawing.Size(523, 41);
            this.nicknameText.TabIndex = 1;
            this.nicknameText.Text = "Nickname";
            // 
            // selfIntroductionText
            // 
            this.selfIntroductionText.Location = new System.Drawing.Point(12, 91);
            this.selfIntroductionText.Name = "selfIntroductionText";
            this.selfIntroductionText.Size = new System.Drawing.Size(523, 190);
            this.selfIntroductionText.TabIndex = 2;
            this.selfIntroductionText.Text = "Self Introduction";
            // 
            // addToContactsButton
            // 
            this.addToContactsButton.Location = new System.Drawing.Point(12, 331);
            this.addToContactsButton.Name = "addToContactsButton";
            this.addToContactsButton.Size = new System.Drawing.Size(151, 40);
            this.addToContactsButton.TabIndex = 3;
            this.addToContactsButton.Text = "연락처에 추가";
            this.addToContactsButton.UseVisualStyleBackColor = true;
            this.addToContactsButton.Click += new System.EventHandler(this.addToContactsButton_Click);
            // 
            // removeInContactsButton
            // 
            this.removeInContactsButton.Location = new System.Drawing.Point(384, 331);
            this.removeInContactsButton.Name = "removeInContactsButton";
            this.removeInContactsButton.Size = new System.Drawing.Size(151, 40);
            this.removeInContactsButton.TabIndex = 4;
            this.removeInContactsButton.Text = "연락처에서 제외";
            this.removeInContactsButton.UseVisualStyleBackColor = true;
            this.removeInContactsButton.Click += new System.EventHandler(this.removeInContactsButton_Click);
            // 
            // startChattingButton
            // 
            this.startChattingButton.Location = new System.Drawing.Point(169, 331);
            this.startChattingButton.Name = "startChattingButton";
            this.startChattingButton.Size = new System.Drawing.Size(209, 40);
            this.startChattingButton.TabIndex = 5;
            this.startChattingButton.Text = "1대1 채팅 시작";
            this.startChattingButton.UseVisualStyleBackColor = true;
            this.startChattingButton.Click += new System.EventHandler(this.startChattingButton_Click);
            // 
            // UserProfileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 389);
            this.Controls.Add(this.startChattingButton);
            this.Controls.Add(this.removeInContactsButton);
            this.Controls.Add(this.addToContactsButton);
            this.Controls.Add(this.selfIntroductionText);
            this.Controls.Add(this.nicknameText);
            this.Controls.Add(this.idText);
            this.Name = "UserProfileForm";
            this.Text = "UserProfileForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UserProfileForm_FormClosing);
            this.Shown += new System.EventHandler(this.UserProfileForm_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private Label idText;
        private Label nicknameText;
        private Label selfIntroductionText;
        private Button addToContactsButton;
        private Button removeInContactsButton;
        private Button startChattingButton;
    }
}