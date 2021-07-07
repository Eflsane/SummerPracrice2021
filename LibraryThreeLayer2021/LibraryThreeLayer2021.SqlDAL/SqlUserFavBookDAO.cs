using LibraryThreeLayer2021.Common.Entities;
using LibraryThreeLayer2021.DAL.InterfaceDAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryThreeLayer2021.DAL.SqlDAL
{
    public class SqlUserFavBookDAO : SqlDAO, IUserFavBookDAO
    {
        public bool AddBookToFavorite(string username, long bookID)
        {
            using (_connection = GetNewSqlConnection())
            {
                var proc = "Add_book_to_favorite";

                var command = new SqlCommand(proc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@bookID", bookID);

                _connection.Open();

                int rowCount = command.ExecuteNonQuery();

                return rowCount > 0;
            }
        }

        public bool DeleteAllFavBooksFromUser(string username)
        {
            using (_connection = GetNewSqlConnection())
            {
                var proc = "Delete_all_fav_book_from_user";

                var command = new SqlCommand(proc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@username", username);

                _connection.Open();

                int rowCount = command.ExecuteNonQuery();

                return rowCount > 0;
            }
        }

        public bool DeleteConnectionFavBookWithUsers(long bookID)
        {
            using (_connection = GetNewSqlConnection())
            {
                var proc = "Delete_connection_fav_book_with_users";

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

        public bool DeleteFavBookFromUser(string username, long bookID)
        {
            using (_connection = GetNewSqlConnection())
            {
                var proc = "Delete_fav_book_from_user";

                var command = new SqlCommand(proc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@bookID", bookID);

                _connection.Open();

                int rowCount = command.ExecuteNonQuery();

                return rowCount > 0;
            }
        }

        public IEnumerable<Book> GetFavBooksOfUser(string username)
        {
            using (_connection = GetNewSqlConnection())
            {
                var proc = "Get_favorite_books_of_user";

                var command = new SqlCommand(proc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@username", username);

                _connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new Book
                    (

                        iD: (long)reader["ID"],
                        name: reader["name"] as string,
                        desc: reader["description"] as string,
                        publicationDate: (DateTime)reader["publication_date"],
                        addedByUsername: reader["added_by_username"] as string,
                        authorID: (long)reader["authorID"]
                    );
                }

                yield break;
                throw new InvalidOperationException("No favorite books this user has");
            }
        }
    }
}
