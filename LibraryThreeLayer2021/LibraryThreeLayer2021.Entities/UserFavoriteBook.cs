using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryThreeLayer2021.Common.Entities
{
    public class UserFavoriteBook
    {
        public string username { get; }

        public long bookID { get; }

        public UserFavoriteBook(string username, long bookID)
        {
            this.username = username;
            this.bookID = bookID;
        }

        public UserFavoriteBook()
        {
        }
    }
}
