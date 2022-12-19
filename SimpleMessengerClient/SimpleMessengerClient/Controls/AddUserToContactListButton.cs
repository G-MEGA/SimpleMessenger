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

namespace SimpleMessengerClient.Controls
{
    public partial class AddUserToContactListButton : UserControl
    {
        string userID;
        ServerCommunicationProcessor server;
        UserList userList;

        public AddUserToContactListButton(string id, string nickname, ServerCommunicationProcessor sc, UserList ul)
        {
            InitializeComponent();

            userID = id;
            server = sc;
            userList = ul;

            userList.ContactListUpdated += OnContactListUpdated;
            OnContactListUpdated();

            button.Text = id + '\n' + nickname;
        }

        public void OnRemove()
        {
            userList.ContactListUpdated -= OnContactListUpdated;
        }
        public void OnContactListUpdated()
        {
            if (InvokeRequired)
            {
                Invoke(() =>
                {
                    button.Enabled = !userList.IsContact(userID)
                        && !userList.GetMyID().Equals(userID);
                }
                    );
            }
            else
            {
                button.Enabled = !userList.IsContact(userID) 
                    && !userList.GetMyID().Equals(userID);
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            server.SendAddUserToContactList(userID);
        }
    }
}
