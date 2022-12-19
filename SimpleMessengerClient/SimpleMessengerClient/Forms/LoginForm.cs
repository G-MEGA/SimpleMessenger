using SimpleMessenger.Classes;
using SimpleMessengerClient.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleMessenger
{
    public partial class LoginForm : Form
    {
        ServerCommunicationProcessor serverCommunication;

        public LoginForm(ServerCommunicationProcessor sp)
        {
            InitializeComponent();

            serverCommunication = sp;
        }

        private void LoginForm_Shown(object sender, EventArgs e)
        {
            serverCommunication.SetLoginForm(this);
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!serverCommunication.IsSuccessedLogin())
            {
                Program.SetTerminatingFlag();
            }
            serverCommunication.SetLoginForm(null);
        }

        public void OnLoginFail()
        {
            idBox.Enabled = true;
            passwordBox.Enabled = true;
            loginButton.Enabled = true;
            registerButton.Enabled = true;

            failText.Text = "ID 또는 Password가 유효하지 않습니다.";
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            idBox.Enabled = false;
            passwordBox.Enabled = false;
            loginButton.Enabled = false;
            registerButton.Enabled = false;

            serverCommunication.SendLogin(idBox.Text, passwordBox.Text);
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new(serverCommunication);
            registerForm.ShowDialog();
        }
    }
}
