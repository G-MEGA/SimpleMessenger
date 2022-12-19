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

        private void MyProfileModifyForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            server.SendModifyProfile(nicknameBox.Text, selfIntroductionBox.Text);
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
