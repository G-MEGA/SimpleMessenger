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
    public partial class UserProfileForm : Form
    {
        ServerCommunicationProcessor server;
        UserList userList;
        ChattingList chattingList;

        User? user;

        public UserProfileForm(ServerCommunicationProcessor sc, UserList ul, ChattingList cl)
        {
            InitializeComponent();

            server = sc;
            userList = ul;
            chattingList = cl;

            userList.ContactListUpdated += OnContactListUpdated;
            chattingList.ChattingsUpdated += OnChattingsUpdated;
        }

        private void UserProfileForm_Shown(object sender, EventArgs e)
        {
            OnContactListUpdated();
            OnChattingsUpdated();
        }
        private void UserProfileForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            userList.ContactListUpdated -= OnContactListUpdated;
            chattingList.ChattingsUpdated -= OnChattingsUpdated;

            SetUser(null);
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

                OnChattingsUpdated();
                OnContactListUpdated();
            }
        }

        private void UserInfoUpdated()
        {
            if (InvokeRequired)
            {
                idText.Invoke(new Action(() =>
                {
                    idText.Text = user.GetID();
                    nicknameText.Text = user.GetNickname();
                    selfIntroductionText.Text = user.GetSelfIntroduction();
                }));
            }
            else
            {
                idText.Text = user.GetID();
                nicknameText.Text = user.GetNickname();
                selfIntroductionText.Text = user.GetSelfIntroduction();
            }
        }

        private void addToContactsButton_Click(object sender, EventArgs e)
        {
            if (user != null)
            {
                server.SendAddUserToContactList(user.GetID());
            }
        }

        private void removeInContactsButton_Click(object sender, EventArgs e)
        {
            if (user != null)
            {
                server.SendRemoveUserInContactList(user.GetID());
            }
        }

        private void startChattingButton_Click(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(() =>
                {
                    startChattingButton.Enabled = false;
                });
            }
            else
            {
                startChattingButton.Enabled = false;
            }

            List<User> users = new List<User>();
            users.Add(userList.GetUser(userList.GetMyID()));
            users.Add(user);
            string title = users[0].GetNickname() + " - " + users[1].GetNickname();
            server.SendStartChatting(true, users, title);
        }

        public void OnContactListUpdated()
        {
            if (InvokeRequired)
            {
                addToContactsButton.Invoke(() =>
                {
                    if (user != null)
                    {
                        bool isContact = userList.IsContact(user.GetID());
                        bool isMe = userList.GetMyID().Equals(user.GetID());

                        addToContactsButton.Enabled = !isContact && !isMe;
                        removeInContactsButton.Enabled = isContact && !isMe;
                    }
                }
                );
            }
            else
            {
                if (user != null)
                {
                    bool isContact = userList.IsContact(user.GetID());
                    bool isMe = userList.GetMyID().Equals(user.GetID());

                    addToContactsButton.Enabled = !isContact && !isMe;
                    removeInContactsButton.Enabled = isContact && !isMe;
                }
            }
        }
        public void OnChattingsUpdated()
        {
            if (user != null)
            {
                if (InvokeRequired)
                {
                    Invoke(() =>
                    {
                        startChattingButton.Enabled
                            = !chattingList.IsThereOneOnOneWith(user.GetID());
                    });
                }
                else
                {
                    startChattingButton.Enabled 
                        = !chattingList.IsThereOneOnOneWith(user.GetID());
                }
            }
        }
    }
}
