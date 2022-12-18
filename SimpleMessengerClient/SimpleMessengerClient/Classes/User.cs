using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMessenger.Classes
{
    internal class User
    {
        string id;
        string nickname;
        string selfIntroduction;

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
            // To do gui 연결
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
}
