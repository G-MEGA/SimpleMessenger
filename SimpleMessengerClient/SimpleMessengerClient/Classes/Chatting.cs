using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleMessenger.Classes
{
    internal class Chatting
    {
        string id;
        string title;
        bool isOneOnOne;
        string[] userIDs;

        List<Message?> messages;

        public Chatting(string initialID, string initialTitle, bool initialIsOneOnOne, string[] initialUserIDs)
        {
            id = initialID;
            title = initialTitle;
            isOneOnOne = initialIsOneOnOne;
            userIDs = initialUserIDs;

            messages = new List<Message?>();
        }

        public void Update(string newID, string newTitle, bool newIsOneOnOne, string[] newUserIDs)
        {
            id = newID;
            title = newTitle;
            isOneOnOne = newIsOneOnOne;
            userIDs = newUserIDs;

            // To do gui와 연결
        }
        public void SetMessage(int messageIndex, string userID, long time, string typeCode, string text)
        {
            if (messages.Count <= messageIndex) {

                int cnt = messageIndex + 1 - messages.Count;

                for(int i = 0; i < cnt;i++)
                {
                    messages.Add(null);
                }
            }

            if (messages[messageIndex] == null)
            {
                messages[messageIndex] = new Message(userID, time, typeCode, text);
            }
            // To do gui와 연결
        }

        public void OnRemovedAtChattingList()
        {
            // To do gui와 연결
        }
    }
}
