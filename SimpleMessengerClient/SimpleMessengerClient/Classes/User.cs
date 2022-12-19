using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMessenger.Classes
{
    public class User
    {
        string id;
        string nickname;
        string selfIntroduction;

        public event Updated? Updated;

        public User(string initiialID, string initiialNickname, string initiialSelfIntroduction)
        {
            id = initiialID;
            nickname = initiialNickname;
            selfIntroduction = initiialSelfIntroduction;
        }
        public void Update(string newNickname, string newSelfIntroduction)
        {
            nickname = newNickname;
            selfIntroduction = newSelfIntroduction;
            Updated?.Invoke();
        }

        public string GetID()
        {
            return id;
        }
        public string GetNickname()
        {
            return nickname;
        }
        public string GetSelfIntroduction()
        {
            return selfIntroduction;
        }
    }

    public delegate void Updated();
}
