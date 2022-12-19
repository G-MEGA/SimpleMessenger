namespace SimpleMessengerClient.Forms
{
    partial class InviteForm
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
            this.checkList = new System.Windows.Forms.CheckedListBox();
            this.confirmButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkList
            // 
            this.checkList.FormattingEnabled = true;
            this.checkList.Location = new System.Drawing.Point(12, 12);
            this.checkList.MinimumSize = new System.Drawing.Size(450, 0);
            this.checkList.Name = "checkList";
            this.checkList.Size = new System.Drawing.Size(462, 334);
            this.checkList.TabIndex = 0;
            // 
            // confirmButton
            // 
            this.confirmButton.Location = new System.Drawing.Point(12, 352);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(462, 53);
            this.confirmButton.TabIndex = 1;
            this.confirmButton.Text = "초대하기";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // InviteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 417);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.checkList);
            this.Name = "InviteForm";
            this.Text = "InviteForm";
            this.ResumeLayout(false);

        }

        #endregion

        private CheckedListBox checkList;
        private Button confirmButton;
    }
}