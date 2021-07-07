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
    public class SqlGenreDAO : SqlDAO, IGenreDAO
    {
        public bool AddGenre(string name, string desc)
        {
            using (_connection = GetNewSqlConnection())
            {
                var proc = "Add_genre";

                var command = new SqlCommand(proc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@description", desc);

                _connection.Open();

                int rowCount = command.ExecuteNonQuery();

                return rowCount > 0;
            }
        }

        public bool DeleteGenre(long genreID)
        {
            using (_connection = GetNewSqlConnection())
            {
                var proc = "Delete_genre";

                var command = new SqlCommand(proc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@ID", genreID);

                _connection.Open();

                int rowCount = command.ExecuteNonQuery();

                return rowCount > 0;
            }
        }

        public IEnumerable<Genre> GetAllGenres()
        {
            using (_connection = GetNewSqlConnection())
            {
                var proc = "Get_all_genres";

                var command = new SqlCommand(proc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                _connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new Genre
                    (

                        iD: (long)reader["ID"],
                        name: reader["name"] as string,
                        desc: reader["description"] as string
                    );

                }

                yield break;
            }
        }

        public Genre GetGenreByID(long genreID)
        {
            using (_connection = GetNewSqlConnection())
            {
                var proc = "Get_genre_by_id";

                var command = new SqlCommand(proc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@ID", genreID);

                _connection.Open();

                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new Genre
                    (

                        iD: (long)reader["ID"],
                        name: reader["secondname"] as string,
                        desc: reader["description"] as string
                    );

                }

                throw new InvalidOperationException("Genre not found");
            }
        }

        public IEnumerable<Genre> GetGenresOfBookById(long bookID)
        {
            using (_connection = GetNewSqlConnection())
            {
                var proc = "Get_genres_of_book_by_id";

                var command = new SqlCommand(proc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@ID", bookID);

                _connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new Genre
                    (

                        iD: (long)reader["ID"],
                        name: reader["name"] as string,
                        desc: reader["description"] as string
                    );

                }

                yield break;
            }
        }

        public bool UpdateGenre(long ID, string name, string desc)
        {
            using (_connection = GetNewSqlConnection())
            {
                var proc = "Update_genre";

                var command = new SqlCommand(proc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@ID", ID);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@description", desc);

                _connection.Open();

                int rowCount = command.ExecuteNonQuery();

                return rowCount > 0;
            }
        }
    }
}
