namespace SimpleMessenger
{
    partial class MainForm
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
            this.logoutButton = new System.Windows.Forms.Button();
            this.myIDText = new System.Windows.Forms.Label();
            this.myProfileGroup = new System.Windows.Forms.GroupBox();
            this.mySelfIntroductionText = new System.Windows.Forms.Label();
            this.myNicknameText = new System.Windows.Forms.Label();
            this.modifyProfileButton = new System.Windows.Forms.Button();
            this.contactsContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.chattingsContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.addToContactListButton = new System.Windows.Forms.Button();
            this.startGroupChatButton = new System.Windows.Forms.Button();
            this.myProfileGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // logoutButton
            // 
            this.logoutButton.Location = new System.Drawing.Point(12, 16);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(94, 29);
            this.logoutButton.TabIndex = 0;
            this.logoutButton.Text = "로그아웃";
            this.logoutButton.UseVisualStyleBackColor = true;
            this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
            // 
            // myIDText
            // 
            this.myIDText.Location = new System.Drawing.Point(6, 23);
            this.myIDText.Name = "myIDText";
            this.myIDText.Size = new System.Drawing.Size(219, 37);
            this.myIDText.TabIndex = 1;
            this.myIDText.Text = "myIDText";
            // 
            // myProfileGroup
            // 
            this.myProfileGroup.Controls.Add(this.mySelfIntroductionText);
            this.myProfileGroup.Controls.Add(this.myNicknameText);
            this.myProfileGroup.Controls.Add(this.myIDText);
            this.myProfileGroup.Location = new System.Drawing.Point(12, 51);
            this.myProfileGroup.Name = "myProfileGroup";
            this.myProfileGroup.Size = new System.Drawing.Size(231, 387);
            this.myProfileGroup.TabIndex = 2;
            this.myProfileGroup.TabStop = false;
            this.myProfileGroup.Text = "내 프로필";
            // 
            // mySelfIntroductionText
            // 
            this.mySelfIntroductionText.Location = new System.Drawing.Point(6, 104);
            this.mySelfIntroductionText.Name = "mySelfIntroductionText";
            this.mySelfIntroductionText.Size = new System.Drawing.Size(219, 280);
            this.mySelfIntroductionText.TabIndex = 3;
            this.mySelfIntroductionText.Text = "mySelfIntroduction";
            // 
            // myNicknameText
            // 
            this.myNicknameText.Location = new System.Drawing.Point(6, 60);
            this.myNicknameText.Name = "myNicknameText";
            this.myNicknameText.Size = new System.Drawing.Size(219, 44);
            this.myNicknameText.TabIndex = 3;
            this.myNicknameText.Text = "myNicknameText";
            // 
            // modifyProfileButton
            // 
            this.modifyProfileButton.Location = new System.Drawing.Point(126, 16);
            this.modifyProfileButton.Name = "modifyProfileButton";
            this.modifyProfileButton.Size = new System.Drawing.Size(117, 29);
            this.modifyProfileButton.TabIndex = 3;
            this.modifyProfileButton.Text = "프로필 수정";
            this.modifyProfileButton.UseVisualStyleBackColor = true;
            this.modifyProfileButton.Click += new System.EventHandler(this.modifyProfileButton_Click);
            // 
            // contactsContainer
            // 
            this.contactsContainer.AutoScroll = true;
            this.contactsContainer.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.contactsContainer.Location = new System.Drawing.Point(547, 51);
            this.contactsContainer.Name = "contactsContainer";
            this.contactsContainer.Size = new System.Drawing.Size(241, 387);
            this.contactsContainer.TabIndex = 4;
            this.contactsContainer.WrapContents = false;
            // 
            // chattingsContainer
            // 
            this.chattingsContainer.AutoScroll = true;
            this.chattingsContainer.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.chattingsContainer.Location = new System.Drawing.Point(268, 51);
            this.chattingsContainer.Name = "chattingsContainer";
            this.chattingsContainer.Size = new System.Drawing.Size(251, 387);
            this.chattingsContainer.TabIndex = 5;
            this.chattingsContainer.WrapContents = false;
            // 
            // addToContactListButton
            // 
            this.addToContactListButton.Location = new System.Drawing.Point(547, 12);
            this.addToContactListButton.Name = "addToContactListButton";
            this.addToContactListButton.Size = new System.Drawing.Size(241, 29);
            this.addToContactListButton.TabIndex = 6;
            this.addToContactListButton.Text = "연락처 추가";
            this.addToContactListButton.UseVisualStyleBackColor = true;
            this.addToContactListButton.Click += new System.EventHandler(this.addToContactListButton_Click);
            // 
            // startGroupChatButton
            // 
            this.startGroupChatButton.Location = new System.Drawing.Point(268, 12);
            this.startGroupChatButton.Name = "startGroupChatButton";
            this.startGroupChatButton.Size = new System.Drawing.Size(251, 29);
            this.startGroupChatButton.TabIndex = 7;
            this.startGroupChatButton.Text = "새 그룹 채팅 만들기";
            this.startGroupChatButton.UseVisualStyleBackColor = true;
            this.startGroupChatButton.Click += new System.EventHandler(this.startGroupChatButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.startGroupChatButton);
            this.Controls.Add(this.addToContactListButton);
            this.Controls.Add(this.chattingsContainer);
            this.Controls.Add(this.contactsContainer);
            this.Controls.Add(this.modifyProfileButton);
            this.Controls.Add(this.myProfileGroup);
            this.Controls.Add(this.logoutButton);
            this.Name = "MainForm";
            this.Text = "Main";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.myProfileGroup.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Button logoutButton;
        private Label myIDText;
        private GroupBox myProfileGroup;
        private Label mySelfIntroductionText;
        private Label myNicknameText;
        private Button modifyProfileButton;
        private FlowLayoutPanel contactsContainer;
        private FlowLayoutPanel chattingsContainer;
        private Button addToContactListButton;
        private Button startGroupChatButton;
    }
}