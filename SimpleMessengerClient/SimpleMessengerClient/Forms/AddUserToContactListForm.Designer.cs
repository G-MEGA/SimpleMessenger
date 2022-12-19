namespace SimpleMessengerClient.Forms
{
    partial class AddUserToContactListForm
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
            this.buttonContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.keywordBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonContainer
            // 
            this.buttonContainer.AutoScroll = true;
            this.buttonContainer.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.buttonContainer.Location = new System.Drawing.Point(24, 83);
            this.buttonContainer.Name = "buttonContainer";
            this.buttonContainer.Size = new System.Drawing.Size(251, 379);
            this.buttonContainer.TabIndex = 0;
            this.buttonContainer.WrapContents = false;
            // 
            // keywordBox
            // 
            this.keywordBox.Location = new System.Drawing.Point(24, 37);
            this.keywordBox.Name = "keywordBox";
            this.keywordBox.Size = new System.Drawing.Size(195, 27);
            this.keywordBox.TabIndex = 0;
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(225, 35);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(50, 29);
            this.searchButton.TabIndex = 1;
            this.searchButton.Text = "검색";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "아이디 또는 닉네임으로 검색";
            // 
            // AddUserToContactListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 474);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.keywordBox);
            this.Controls.Add(this.buttonContainer);
            this.Controls.Add(this.searchButton);
            this.Name = "AddUserToContactListForm";
            this.Text = "AddUserToContactListForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddUserToContactListForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FlowLayoutPanel buttonContainer;
        private TextBox keywordBox;
        private Button searchButton;
        private Label label1;
    }
}