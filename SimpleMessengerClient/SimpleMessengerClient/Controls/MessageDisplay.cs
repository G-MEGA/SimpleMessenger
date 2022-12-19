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
using static System.Net.Mime.MediaTypeNames;

namespace SimpleMessengerClient.Controls
{
    public partial class MessageDisplay : UserControl
    {
        ServerCommunicationProcessor server;
        Chatting chatting;
        UserList userList;
        ChattingList chattingList;

        UserProfileButton profileButton;
        Label text;
        Button downloadButton;
        Label timeText;

        SimpleMessenger.Classes.Message? message;

        public MessageDisplay(ServerCommunicationProcessor sc, Chatting c, UserList ul, ChattingList cl)
        {
            InitializeComponent();

            server = sc;
            chatting = c;
            userList = ul;
            chattingList = cl;

            profileButton = new(server, userList, chattingList);
            container.Controls.Add(profileButton);

            text = new();
            text.AutoSize = true;
            container.Controls.Add(text);

            downloadButton = new();
            downloadButton.Text = "다운로드";
            downloadButton.Visible = false;
            downloadButton.Click += OnDownloadButtonClicked;
            container.Controls.Add(downloadButton);

            timeText = new();
            timeText.AutoSize = true;
            timeText.ForeColor = Color.DarkGray;
            container.Controls.Add(timeText);
        }
        public void SetMessage(SimpleMessenger.Classes.Message? msg)
        {
            //if (message != null)
            //{

            //}

            message = msg;

            if(message != null)
            {
                text.Text = message.GetText();
                downloadButton.Visible = message.GetTypeCode().Equals("File");
                timeText.Text = DateTimeOffset.FromUnixTimeSeconds(message.GetTime())
                    .ToString();

                profileButton.SetUser(userList.GetUser(message.GetUserID()));
            }
            else
            {
                downloadButton.Visible = false;

                profileButton.SetUser(null);
            }
        }
        public void OnDownloadButtonClicked(object? sender, EventArgs e)
        {
            if (message != null && message.GetTypeCode().Equals("File"))
            {
                server.SendFileMessageDownload(chatting.GetID(), message.GetIndex());
            }
        }
    }
}
