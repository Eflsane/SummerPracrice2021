using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryThreeLayer2021.Common.Entities
{
    public class Book
    {
        public long ID { get; }

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                if (value != null) _name = value;
            }
        }
        private string _desc;
        public string Desc
        {
            get => _desc;
            set
            {
                if (value != null) _desc = value;
            }
        }

        private DateTime _publicationDate;

        public DateTime PublicationDate
        {
            get => new DateTime(_publicationDate.Ticks);
            set
            {
                if (value != null) _publicationDate = value;
            }
        }
        
        public string AddedByUsername { get; }

        public long AuthorID { get; }

        public Book(long iD, string name, string desc, DateTime publicationDate, string addedByUsername, long authorID)
        {
            ID = iD;
            Name = name;
            Desc = desc;
            PublicationDate = publicationDate;
            AddedByUsername = addedByUsername;
            AuthorID = authorID;
        }

        public Book()
        {
        }
    }
}
