using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMessengerServer.Classes
{
    internal class UserList
    {
        Dictionary<string, User> users;


        public UserList() {
            users = new Dictionary<string, User>();
        }

        public bool HasID(string id)
        {
            if (users.ContainsKey(id)) { return true; }

            return false;
        }
        public User? GetUser(string id, string password)
        {
            User? user = GetUser(id);

            if (user != null && !user.IsPassword(password)) 
            {
                user = null;
            }

            return user;
        }
        public User? GetUser(string id)
        {
            if (HasID(id))
            {
                return users[id];
            }
            return null;
        }
        public List<User> SearchUser(string keyword)
        {
            List<User> result = new List<User>();

            foreach (User user in users.Values)
            {
                if(user.GetID().Contains(keyword) || user.GetNickname().Contains(keyword))
                {
                    result.Add(user);
                }
            }

            return result;
        }

        public bool RegisterUser(string id, string password, string nickname)
        {
            if (HasID(id))
            {
                return false;
            }

            users[id] = new User(id, password, nickname);
            return true;
        }
    }
}
