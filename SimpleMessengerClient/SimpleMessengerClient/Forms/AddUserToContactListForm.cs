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
    public partial class AddUserToContactListForm : Form
    {
        ServerCommunicationProcessor server;
        UserList userList;

        public AddUserToContactListForm(ServerCommunicationProcessor sc, UserList ul)
        {
            InitializeComponent();

            server = sc;
            userList = ul;

            server.SearchedUsers += OnSearchedUsers;
        }

        private void ContainerClear()
        {
            foreach (Control button in buttonContainer.Controls)
            {
                if (button != null && button is AddUserToContactListButton)
                {
                    AddUserToContactListButton? b = (button as AddUserToContactListButton);
                    if (b!= null)
                    {
                        if(b.InvokeRequired)
                        {
                            b.Invoke(b.OnRemove);
                        }
                        else
                        {
                            b.OnRemove();
                        }
                    }
                }
            }

            buttonContainer.Invoke(buttonContainer.Controls.Clear);
        }

        private void AddUserToContactListForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ContainerClear();
            server.SearchedUsers -= OnSearchedUsers;
        }

        public void OnSearchedUsers(Dictionary<string, string> id_nickname)
        {
            ContainerClear();
            foreach (string id in id_nickname.Keys)
            {
                if(InvokeRequired)
                {
                    Invoke(
                        buttonContainer.Controls.Add,
                        new AddUserToContactListButton(id, id_nickname[id], server, userList)
                        );
                }
                else
                {
                    buttonContainer.Controls.Add(new AddUserToContactListButton(id, id_nickname[id], server, userList));
                }
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            server.SendSearchUser(keywordBox.Text);
        }
    }
}
