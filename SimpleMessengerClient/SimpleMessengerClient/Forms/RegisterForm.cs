using SimpleMessenger.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleMessengerClient.Forms
{
    public partial class RegisterForm : Form
    {
        ServerCommunicationProcessor serverCommunication;

        public RegisterForm(ServerCommunicationProcessor sp)
        {
            InitializeComponent();

            serverCommunication = sp;
        }
        private void RegisterForm_Shown(object sender, EventArgs e)
        {
            serverCommunication.SetRegisterForm(this);
        }

        private void RegisterForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            serverCommunication.SetRegisterForm(null);
        }

        public void OnRegisterFail(string reason)
        {
            if (reason.Equals("idAlreadyExists"))
            {
                failText.Text = "이미 존재하는 ID입니다.";
            }
            else
            {
                failText.Text = "알 수 없는 이유로 회원가입에 실패했습니다.";
            }
            idBox.Enabled = true;
            nicknameBox.Enabled = true;
            passwordBox.Enabled = true;
            passwordConfirmBox.Enabled = true;
            registerButton.Enabled = true;
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            if (!passwordBox.Text.Equals(passwordConfirmBox.Text))
            {
                failText.Text = "비밀번호가 일치하지 않습니다.";
                return;
            }
            if (idBox.Text.Contains('/') || idBox.Text.Contains(',')
                || passwordBox.Text.Contains('/') || passwordBox.Text.Contains(',')
                || nicknameBox.Text.Contains('/') || nicknameBox.Text.Contains(','))
            {
                failText.Text = "콤마(,)와 슬래시(/)는 사용할 수 없습니다.";
                return;
            }
            if (idBox.Text.Equals(""))
            {
                failText.Text = "id를 입력하세요.";
                return;
            }
            if (passwordBox.Text.Equals(""))
            {
                failText.Text = "비밀번호를 입력하세요.";
                return;
            }
            if (nicknameBox.Text.Equals(""))
            {
                failText.Text = "닉네임을 입력하세요.";
                return;
            }

            idBox.Enabled = false;
            nicknameBox.Enabled = false;
            passwordBox.Enabled = false;
            passwordConfirmBox.Enabled = false;
            registerButton.Enabled = false;

            serverCommunication.SendRegister(idBox.Text, passwordBox.Text, nicknameBox.Text);
        }
    }
}
