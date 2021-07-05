using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryThreeLayer2021.Common.Entities
{
    public class BookGenre
    {
        public long BookID { get; }
        public long GenreID { get; }


        public BookGenre(long bookID, long genreID)
        {
            this.BookID = bookID;
            this.GenreID = genreID;
        }

        public BookGenre()
        {
        }
    }
}
