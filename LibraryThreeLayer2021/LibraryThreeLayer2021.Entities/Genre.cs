using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryThreeLayer2021.Common.Entities
{
    public class Genre
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
            set => _desc = value;
        }

        public Genre(long iD, string name, string desc)
        {
            ID = iD;
            Name = name;
            Desc = desc;
        }

        public Genre()
        {
        }
    }
}
