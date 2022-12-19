using SimpleMessenger.Classes;
using SimpleMessengerClient.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleMessengerClient.Controls
{
    public partial class UserProfileButton : UserControl
    {
        ServerCommunicationProcessor server;
        UserList userList;
        ChattingList chattingList;

        User? user;

        public UserProfileButton(ServerCommunicationProcessor sc, UserList ul, ChattingList cl)
        {
            InitializeComponent();

            server = sc;
            userList = ul;
            chattingList = cl;
        }

        public void SetUser(User? u)
        {
            if (user != null)
            {
                user.Updated -= UserInfoUpdated;
            }

            user = u;

            if (user != null)
            {
                user.Updated += UserInfoUpdated;
                UserInfoUpdated();
            }
        }

        private void UserInfoUpdated()
        {
            if (InvokeRequired)
            {
                Invoke(() => button.Text = user.GetNickname());
            }
            else
            {
                button.Text = user.GetNickname();
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            if (user != null)
            {
                UserProfileForm form = new UserProfileForm(server, userList, chattingList);
                form.SetUser(user);
                form.ShowDialog();
            }
        }
    }
}
