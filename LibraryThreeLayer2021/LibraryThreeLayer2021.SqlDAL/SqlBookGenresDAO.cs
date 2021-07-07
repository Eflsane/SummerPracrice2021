using LibraryThreeLayer2021.DAL.InterfaceDAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryThreeLayer2021.DAL.SqlDAL
{
    public class SqlBookGenresDAO : SqlDAO, IBookGenresDAO
    {
        public bool AddGenreToBook(long bookID, long genreID)
        {
            using (_connection = GetNewSqlConnection())
            {
                var proc = "Add_genre_to_book";

                var command = new SqlCommand(proc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@bookID", bookID);
                command.Parameters.AddWithValue("@genreID", genreID);

                _connection.Open();

                int rowCount = command.ExecuteNonQuery();

                return rowCount > 0;
            }
        }

        public bool DeleteAllGenresFromBook(long bookID)
        {
            using (_connection = GetNewSqlConnection())
            {
                var proc = "Delete_all_genres_from_book";

                var command = new SqlCommand(proc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@bookID", bookID);

                _connection.Open();

                int rowCount = command.ExecuteNonQuery();

                return rowCount > 0;
            }
        }

        public bool DeleteConnectionOfGenreWithBooks(long genreID)
        {
            using (_connection = GetNewSqlConnection())
            {
                var proc = "Delete_connection_of_genre_with_books";

                var command = new SqlCommand(proc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@genreID", genreID);

                _connection.Open();

                int rowCount = command.ExecuteNonQuery();

                return rowCount > 0;
            }
        }

        public bool DeleteGenreFromBook(long bookID, long genreID)
        {
            using (_connection = GetNewSqlConnection())
            {
                var proc = "Delete_genre_from_book";

                var command = new SqlCommand(proc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@bookID", bookID);
                command.Parameters.AddWithValue("@genreID", genreID);

                _connection.Open();

                int rowCount = command.ExecuteNonQuery();

                return rowCount > 0;
            }
        }
    }
}
