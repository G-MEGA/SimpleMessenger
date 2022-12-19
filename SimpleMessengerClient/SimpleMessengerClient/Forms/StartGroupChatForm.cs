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
            server.SendStartChatting(false
                , new List<User>() { userList.GetUser(userList.GetMyID()) }
                , titleBox.Text);

            Close();
        }
    }
}
