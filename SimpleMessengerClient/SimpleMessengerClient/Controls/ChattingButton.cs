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
    public partial class ChattingButton : UserControl
    {
        Chatting chatting;
        ServerCommunicationProcessor server;
        UserList userList;
        ChattingList chattingList;

        public ChattingButton(Chatting c, ServerCommunicationProcessor sc, UserList ul, ChattingList cl)
        {
            InitializeComponent();
            chatting = c;
            server = sc;
            userList = ul;
            chattingList = cl;

            button.Text = c.GetTitle();
        }

        private void button_Click(object sender, EventArgs e)
        {
            new ChattingForm(chatting, server, userList, chattingList).Show();
        }
    }
}
