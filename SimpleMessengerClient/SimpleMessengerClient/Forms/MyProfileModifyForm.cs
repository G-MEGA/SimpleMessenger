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
    public partial class MyProfileModifyForm : Form
    {
        ServerCommunicationProcessor server;

        public MyProfileModifyForm(ServerCommunicationProcessor sc, string currentNickname, string currentSelfIntroduction)
        {
            InitializeComponent();

            server = sc;

            nicknameBox.Text = currentNickname;
            selfIntroductionBox.Text = currentSelfIntroduction;
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {

            if (nicknameBox.Text.Contains('/') || nicknameBox.Text.Contains(','))
            {
                MessageBox.Show("닉네임에 콤마(,)와 슬래시(/)는 사용할 수 없습니다.");
                return;
            }
            if (nicknameBox.Text.Equals(""))
            {
                MessageBox.Show("닉네임을 입력하세요.");
                return;
            }

            server.SendModifyProfile(nicknameBox.Text, selfIntroductionBox.Text);
            Close();
        }
    }
}
