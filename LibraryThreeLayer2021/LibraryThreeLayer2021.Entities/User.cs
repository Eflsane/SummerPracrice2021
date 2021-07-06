using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryThreeLayer2021.Common.Entities
{
    public class User
    {
        private string _username;

        public string Username
        {
            get => _username;
            set
            {
                if (value != null) _username = value;
            }
        }

        public string CustomName { get; set; }

        public bool Sex { get; set; }

        private DateTime _regDate;

        public DateTime RegDate
        {
            get => _regDate;
            set
            {
                if (value != null) _regDate = value;
            }
        }

        public bool IsAdmin { get; }

        public User(string username, string customName, bool sex, DateTime regDate, bool isAdmin)
        {
            Username = username;
            CustomName = customName;
            Sex = sex;
            RegDate = regDate;
            IsAdmin = isAdmin;
        }

        public User()
        {
        }

        public override string ToString()
        {
            return ((CustomName != null? CustomName: Username) + (IsAdmin ? " Admin": ""));
        }
    }
}
