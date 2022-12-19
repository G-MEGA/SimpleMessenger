using SimpleMessenger.Classes;
using SimpleMessengerClient.Controls;
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
    public partial class ChattingForm : Form
    {
        Chatting chatting;
        ServerCommunicationProcessor server;
        UserList userList;
        ChattingList chattingList;

        List<MessageDisplay> messageDisplays;

        public ChattingForm(Chatting c, ServerCommunicationProcessor sc,UserList ul, ChattingList cl)
        {
            InitializeComponent();

            chatting = c;
            server = sc;
            userList = ul;
            chattingList = cl;

            messageDisplays = new List<MessageDisplay>();

            chatting.InfoUpdated += OnChattingInfoUpdated;
            chatting.Removed += OnRemoved;
            OnChattingInfoUpdated();

            chatting.MessageAdded += OnMessageAdded;
            for(int i = chatting.GetMessageCount() - 1; i >= 0; i--)
            {
                OnMessageAdded(i);
            }
        }
        private void ChattingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            chatting.InfoUpdated -= OnChattingInfoUpdated;
            chatting.Removed -= OnRemoved;
            UsersContainerClear();

            chatting.MessageAdded -= OnMessageAdded;
            MessageDisplaysClear();
        }

        public void OnChattingInfoUpdated()
        {
            if(InvokeRequired)
            {
                Invoke(() =>
                {
                    titleText.Text = chatting.GetTitle();
                    inviteButton.Enabled = !chatting.IsOneOnOne();

                    UsersContainerClear();

                    foreach (string userID in chatting.GetUserIDs())
                    {
                        UserProfileButton b = new(server, userList, chattingList);
                        b.SetUser(userList.GetUser(userID));
                        usersContainer.Controls.Add(b);
                    }
                });
            }
            else
            {
                titleText.Text = chatting.GetTitle();
                inviteButton.Enabled = !chatting.IsOneOnOne();

                UsersContainerClear();

                foreach (string userID in chatting.GetUserIDs())
                {
                    UserProfileButton b = new(server, userList, chattingList);
                    b.SetUser(userList.GetUser(userID));
                    usersContainer.Controls.Add(b);
                }
            }
        }
        public void OnRemoved()
        {
            if(InvokeRequired) {
                Invoke(() =>
                {
                    Close();
                });
            }
            else
            {
                Close();
            }
        }
        public void OnMessageAdded(int index)
        {
            if (InvokeRequired)
            {
                Invoke(() =>
                {
                    //MessageDisplay가 부족한 만큼 생성
                    if (messageDisplays.Count <= index)
                    {
                        int count = index + 1 - messageDisplays.Count;
                        for (int i = 0; i < count; i++)
                        {
                            MessageDisplay md = new MessageDisplay(server, chatting, userList, chattingList);
                            messageDisplays.Add(md);
                            messageContainer.Controls.Add(md);

                            md.SetMessage(null);
                        }
                    }

                    messageDisplays[index].SetMessage(chatting.GetMessage(index));
                    messageContainer.AutoScrollOffset = new Point(100, -100);
                    messageContainer.ScrollControlIntoView(messageDisplays.Last());
                });
            }
            else
            {
                //MessageDisplay가 부족한 만큼 생성
                if (messageDisplays.Count <= index)
                {
                    int count = index + 1 - messageDisplays.Count;
                    for (int i = 0; i < count; i++)
                    {
                        MessageDisplay md = new MessageDisplay(server, chatting, userList, chattingList);
                        messageDisplays.Add(md);
                        messageContainer.Controls.Add(md);

                        md.SetMessage(null);
                    }
                }

                messageDisplays[index].SetMessage(chatting.GetMessage(index));
                messageContainer.AutoScrollOffset = new Point(100, -100);
                messageContainer.ScrollControlIntoView(messageDisplays.Last());
            }
        }

        private void UsersContainerClear()
        {
            if (InvokeRequired)
            {
                Invoke(() =>
                {
                    foreach (Control control in usersContainer.Controls)
                    {
                        if (control is UserProfileButton)
                        {
                            UserProfileButton b = (UserProfileButton)control;

                            b.SetUser(null);
                        }
                    }

                    usersContainer.Controls.Clear();
                });
            }
            else
            {
                foreach (Control control in usersContainer.Controls)
                {
                    if (control is UserProfileButton)
                    {
                        UserProfileButton b = (UserProfileButton)control;

                        b.SetUser(null);
                    }
                }

                usersContainer.Controls.Clear();
            }
        }
        private void MessageDisplaysClear()
        {
            if (InvokeRequired)
            {
                Invoke(() =>
                {
                    foreach (MessageDisplay md in messageDisplays)
                    {
                        md.SetMessage(null);
                    }
                    messageDisplays.Clear();
                    messageContainer.Controls.Clear();
                });
            }
            else
            {
                foreach (MessageDisplay md in messageDisplays)
                {
                    md.SetMessage(null);
                }
                messageDisplays.Clear();
                messageContainer.Controls.Clear();

                //foreach (Control control in messageContainer.Controls)
                //{
                //    if (control is MessageDisplay)
                //    {
                //        MessageDisplay d = (MessageDisplay)control;

                //        d.SetMessage(null);
                //    }
                //}

                //messageContainer.Controls.Clear();
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            server.SendExitFromChatting(chatting.GetID());
        }
        private void sendButton_Click(object sender, EventArgs e)
        {
            if (!textBox.Text.Equals(""))
            {
                server.SendMakeTextMessage(chatting.GetID(), textBox.Text);

                textBox.Text = "";
            }
        }
        private void fileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new();
            open.FileName = "";
            open.Title = "전송할 파일 선택";

            if(open.ShowDialog() == DialogResult.OK)
            {
                byte[] bytes = File.ReadAllBytes(open.FileName);

                string fileName = open.FileName.Split('\\').Last();

                server.SendMakeFileMessage(
                    chatting.GetID(), fileName, bytes);
            }
        }

        private void inviteButton_Click(object sender, EventArgs e)
        {
            new InviteForm(server, userList, chatting).ShowDialog();
        }
    }
}
