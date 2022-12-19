namespace SimpleMessengerClient.Forms
{
    partial class ChattingForm
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
            this.messageContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.textBox = new System.Windows.Forms.TextBox();
            this.titleText = new System.Windows.Forms.Label();
            this.exitButton = new System.Windows.Forms.Button();
            this.sendButton = new System.Windows.Forms.Button();
            this.fileButton = new System.Windows.Forms.Button();
            this.usersContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.inviteButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // messageContainer
            // 
            this.messageContainer.AutoScroll = true;
            this.messageContainer.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.messageContainer.ImeMode = System.Windows.Forms.ImeMode.On;
            this.messageContainer.Location = new System.Drawing.Point(12, 70);
            this.messageContainer.Name = "messageContainer";
            this.messageContainer.Size = new System.Drawing.Size(485, 467);
            this.messageContainer.TabIndex = 0;
            this.messageContainer.WrapContents = false;
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(12, 559);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(392, 114);
            this.textBox.TabIndex = 0;
            // 
            // titleText
            // 
            this.titleText.Location = new System.Drawing.Point(105, 9);
            this.titleText.Name = "titleText";
            this.titleText.Size = new System.Drawing.Size(299, 48);
            this.titleText.TabIndex = 0;
            this.titleText.Text = "title";
            this.titleText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // exitButton
            // 
            this.exitButton.ForeColor = System.Drawing.Color.Red;
            this.exitButton.Location = new System.Drawing.Point(12, 6);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(87, 55);
            this.exitButton.TabIndex = 1;
            this.exitButton.Text = "채팅\r\n나가기";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(410, 559);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(87, 71);
            this.sendButton.TabIndex = 2;
            this.sendButton.Text = "전송";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // fileButton
            // 
            this.fileButton.Location = new System.Drawing.Point(410, 636);
            this.fileButton.Name = "fileButton";
            this.fileButton.Size = new System.Drawing.Size(87, 37);
            this.fileButton.TabIndex = 3;
            this.fileButton.Text = "파일 전송";
            this.fileButton.UseVisualStyleBackColor = true;
            this.fileButton.Click += new System.EventHandler(this.fileButton_Click);
            // 
            // usersContainer
            // 
            this.usersContainer.AutoScroll = true;
            this.usersContainer.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.usersContainer.Location = new System.Drawing.Point(522, 70);
            this.usersContainer.Name = "usersContainer";
            this.usersContainer.Size = new System.Drawing.Size(241, 467);
            this.usersContainer.TabIndex = 4;
            this.usersContainer.WrapContents = false;
            // 
            // inviteButton
            // 
            this.inviteButton.Location = new System.Drawing.Point(522, 559);
            this.inviteButton.Name = "inviteButton";
            this.inviteButton.Size = new System.Drawing.Size(241, 114);
            this.inviteButton.TabIndex = 5;
            this.inviteButton.Text = "초대하기";
            this.inviteButton.UseVisualStyleBackColor = true;
            this.inviteButton.Click += new System.EventHandler(this.inviteButton_Click);
            // 
            // ChattingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 685);
            this.Controls.Add(this.inviteButton);
            this.Controls.Add(this.usersContainer);
            this.Controls.Add(this.fileButton);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.titleText);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.messageContainer);
            this.Name = "ChattingForm";
            this.Text = "ChattingForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChattingForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FlowLayoutPanel messageContainer;
        private TextBox textBox;
        private Label titleText;
        private Button exitButton;
        private Button sendButton;
        private Button fileButton;
        private FlowLayoutPanel usersContainer;
        private Button inviteButton;
    }
}