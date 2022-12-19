using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleMessenger.Classes
{
    public class Chatting
    {
        string id;
        string title;
        bool isOneOnOne;
        string[] userIDs;

        List<Message?> messages;

        public event Updated? InfoUpdated;
        public event ElementUpdated? MessageAdded;
        public event Updated? Removed;

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

            InfoUpdated?.Invoke();
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
                messages[messageIndex] = new Message(messageIndex, userID, time, typeCode, text);
                MessageAdded?.Invoke(messageIndex);
            }
        }
        public string GetID()
        {
            return id;
        }
        public string GetTitle()
        {
            return title;
        }
        public Message? GetMessage(int messageIndex)
        {
            return messages[messageIndex];
        }
        public int GetMessageCount()
        {
            return messages.Count;
        }
        public bool IsOneOnOne()
        {
            return isOneOnOne;
        }
        public string[] GetUserIDs()
        {
            return userIDs;
        }

        public void OnRemovedAtChattingList()
        {
            Removed?.Invoke();
        }
    }
    public delegate void ElementUpdated(int index);
}
