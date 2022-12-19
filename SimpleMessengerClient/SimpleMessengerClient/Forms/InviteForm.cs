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
    public partial class InviteForm : Form
    {
        ServerCommunicationProcessor server;
        UserList userList;
        Chatting chatting;

        List<string> notJoinedContacts;

        public InviteForm(ServerCommunicationProcessor sc, UserList ul, Chatting c)
        {
            InitializeComponent();

            server = sc;
            userList = ul;
            chatting = c;

            notJoinedContacts = new List<string>();

            notJoinedContacts.AddRange(userList.GetContactList());
            foreach (string joinedID in chatting.GetUserIDs())
            {
                notJoinedContacts.Remove(joinedID);
            }

            checkList.Items.Clear();
            foreach (string id in notJoinedContacts)
            {
                checkList.Items.Add(id + " / " + userList.GetUser(id).GetNickname());
            }
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            foreach (int index in checkList.CheckedIndices)
            {
                server.SendInviteChatting(notJoinedContacts[index], chatting.GetID());
            }

            Close();
        }
    }
}
