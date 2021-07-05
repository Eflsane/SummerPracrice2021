using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryThreeLayer2021.Common.Entities
{
    public class Author
    {
        public long ID { get; }

        private string _secondname;
        public string Secondname
        {
            get => _secondname;
            set
            {
                if (value != null) _secondname = value;
            }
        }
        private string _firstname;
        public string Firstname
        {
            get => _firstname;
            set
            {
                if (value != null) _firstname = value;
            }
        }
        
        private DateTime _birthDate;

        public DateTime BirthDate
        {
            get => new DateTime(_birthDate.Ticks);
            set
            {
                if (value != null) _birthDate = value;
            }
        }

        public Author(long iD, string secondname, string firstname, DateTime birthDate)
        {
            ID = iD;
            Secondname = secondname;
            Firstname = firstname;
            BirthDate = birthDate;
        }

        public Author()
        {
        }
    }
}
