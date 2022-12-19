using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMessenger.Classes
{
    public class UserList
    {
        string myID;
        List<string> contactIDs;
        Dictionary<string, User> users;

        public event Updated? MyIDUpdated;
        public event Updated? ContactListUpdated;

        public UserList() 
        {
            myID = "";
            contactIDs = new List<string>();
            users = new Dictionary<string, User>();
        }

        public void SetMyID(string id)
        {
            myID = id;
            MyIDUpdated?.Invoke();
        }
        public string GetMyID()
        {
            return myID;
        }

        public void SetUserProfile(string id, string nickname, string selfIntroduction)
        {
            if (!users.ContainsKey(id))
            {
                users[id] = new(id, nickname, selfIntroduction);
            }
            else
            {
                users[id].Update(nickname, selfIntroduction);
            }
        }
        public void AddToContactList(string id)
        {
            if (!contactIDs.Contains(id))
            {
                contactIDs.Add(id);
                ContactListUpdated?.Invoke();
            }
        }
        public void RemoveInContactList(string id)
        {
            if (contactIDs.Contains(id))
            {
                contactIDs.Remove(id);
                ContactListUpdated?.Invoke();
            }
        }
        public List<string> GetContactList()
        {
            return contactIDs;
        }
        public bool IsContact(string id)
        {
            return contactIDs.Contains(id);
        }

        public User GetUser(string id)
        {
            if (!users.ContainsKey(id))
            {
                users[id] = new(id, "", "");
            }
            return users[id];
        }
    }
}
