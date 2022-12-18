using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMessenger.Classes
{
    internal class UserList
    {
        string myID;
        List<string> contactIDs;
        Dictionary<string, User> users;

        public UserList() 
        {
            myID = "";
            contactIDs = new List<string>();
            users = new Dictionary<string, User>();
        }

        public void SetMyID(string id)
        {
            myID = id;
            // To do gui연결
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
                // To do gui연결
            }
        }
        public void RemoveInContactList(string id)
        {
            if (contactIDs.Contains(id))
            {
                contactIDs.Remove(id);
                // To do gui연결
            }
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
