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
    public partial class StartGroupChatForm : Form
    {
        ServerCommunicationProcessor server;
        UserList userList;

        public StartGroupChatForm(ServerCommunicationProcessor sc, UserList ul)
        {
            InitializeComponent();

            server = sc;
            userList = ul;
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            if (titleBox.Text.Equals(""))
            {
                MessageBox.Show("그룹 채팅의 이름을 입력하세요.");
                return;
            }
            if (titleBox.Text.Contains(',') || titleBox.Text.Contains('/'))
            {
                MessageBox.Show("콤마(,)나 슬래시(/)는 사용할 수 없습니다.");
                return;
            }
            server.SendStartChatting(false
                , new List<User>() { userList.GetUser(userList.GetMyID()) }
                , titleBox.Text);

            Close();
        }
    }
}
