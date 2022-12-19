using SimpleMessenger.Classes;
using SimpleMessengerClient.Controls;
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

namespace SimpleMessenger
{
    public partial class MainForm : Form
    {
        ServerCommunicationProcessor server;
        UserList userList;
        ChattingList chattingList;

        User? myUser;

        bool logout;

        public MainForm(ServerCommunicationProcessor sc, UserList ul, ChattingList cl)
        {
            InitializeComponent();

            server = sc;
            logout = false;
            userList = ul;
            chattingList = cl;

            userList.MyIDUpdated += OnMyIDUpdated;
            userList.ContactListUpdated += OnContactListUpdated;

            chattingList.ChattingsUpdated += OnChattingsUpdated;
        }
        private void MainForm_Shown(object sender, EventArgs e)
        {
            OnMyIDUpdated();
            OnContactListUpdated();

            OnChattingsUpdated();

            server.SetMainForm(this);
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            server.SetMainForm(null);

            if (!logout)
            {
                Program.SetTerminatingFlag();
            }
        }


        private void logoutButton_Click(object sender, EventArgs e)
        {
            //server.Logout(); 어차피 Program측에서 Disconnect해주니까 여기서 할 필요 없음
            logout = true;
            Close();
        }
        private void modifyProfileButton_Click(object sender, EventArgs e)
        {
            new MyProfileModifyForm(
                server, 
                myUser.GetNickname(), 
                myUser.GetSelfIntroduction()).ShowDialog();
        }

        private void addToContactListButton_Click(object sender, EventArgs e)
        {
            new AddUserToContactListForm(server, userList).ShowDialog();
        }
        private void startGroupChatButton_Click(object sender, EventArgs e)
        {
            new StartGroupChatForm(server, userList).ShowDialog();
        }


        public void OnFileDownloadFail()
        {
            MessageBox.Show("파일 다운로드에 실패했습니다.");
        }
        public void OnMyIDUpdated()
        {
            if (myUser != null)
            {
                myUser.Updated -= OnMyUserUpdated;
            }

            myUser = userList.GetUser(userList.GetMyID());

            if (myUser != null)
            {
                myUser.Updated += OnMyUserUpdated;
                OnMyUserUpdated();
            }
        }
        public void OnContactListUpdated()
        {
            foreach(Control control in contactsContainer.Controls)
            {
                if (control != null && control is UserProfileButton)
                {
                    (control as UserProfileButton).SetUser(null);
                }
            }

            if(InvokeRequired)
            {
                Invoke(contactsContainer.Controls.Clear);
                foreach (string id in userList.GetContactList())
                {
                    UserProfileButton userProfileButton = new(server, userList, chattingList);
                    contactsContainer
                        .Invoke(contactsContainer.Controls.Add, userProfileButton);
                    userProfileButton.SetUser(userList.GetUser(id));
                }
            }
            else
            {
                contactsContainer.Controls.Clear();
                foreach (string id in userList.GetContactList())
                {
                    UserProfileButton userProfileButton = new(server, userList, chattingList);
                    contactsContainer.Controls.Add(userProfileButton);
                    userProfileButton.SetUser(userList.GetUser(id));
                }
            }
        }
        public void OnMyUserUpdated()
        {
            if (InvokeRequired)
            {
                Invoke(() =>
                {
                    myIDText.Text = myUser.GetID();
                    myNicknameText.Text = myUser.GetNickname();
                    mySelfIntroductionText.Text = myUser.GetSelfIntroduction();
                });
            }
            else
            {
                myIDText.Text = myUser.GetID();
                myNicknameText.Text = myUser.GetNickname();
                mySelfIntroductionText.Text = myUser.GetSelfIntroduction();
            }
        }
        public void OnChattingsUpdated()
        {
            if (InvokeRequired)
            {
                Invoke(() =>
                {
                    chattingsContainer.Controls.Clear();

                    foreach (Chatting chat in chattingList.GetAllChattings().Values)
                    {
                        chattingsContainer.Controls.Add(
                            new ChattingButton(chat, server, userList, chattingList)
                            );
                    }
                });
            }
            else
            {
                chattingsContainer.Controls.Clear();

                foreach (Chatting chat in chattingList.GetAllChattings().Values)
                {
                    chattingsContainer.Controls.Add(
                        new ChattingButton(chat, server, userList, chattingList)
                        );
                }
            }
        }
    }
}
