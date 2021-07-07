using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryThreeLayer2021.Common.Entities;
using LibraryThreeLayer2021.DAL.InterfaceDAL;

namespace LibraryThreeLayer2021.DAL.SqlDAL
{
    public class SqlAuthorDAO : SqlDAO, IAuthorDAO
    {
        public bool AddAuthor(string secondname, string firstname, DateTime birthDate)
        {
            using (_connection = GetNewSqlConnection())
            {
                var proc = "Add_author";

                var command = new SqlCommand(proc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@secondname", secondname);
                command.Parameters.AddWithValue("@firstname", firstname);
                command.Parameters.AddWithValue("@birth_date", birthDate);

                _connection.Open();

                int rowCount = command.ExecuteNonQuery();

                return rowCount > 0;
            }
        }

        public bool DeleteAuthor(long authorID)
        {
            using (_connection = GetNewSqlConnection())
            {
                var proc = "Delete_author";

                var command = new SqlCommand(proc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@ID", authorID);

                _connection.Open();

                int rowCount = command.ExecuteNonQuery();

                return rowCount > 0;
            }
        }

        public IEnumerable<Author> FindAuthors(string author)
        {
            using (_connection = GetNewSqlConnection())
            {
                var proc = "Find_authors";

                var command = new SqlCommand(proc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@author", author);

                _connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new Author
                    (

                        iD: (long)reader["ID"],
                        secondname: reader["secondname"] as string,
                        firstname: reader["firstname"] as string,
                        birthDate: (DateTime)reader["birth_date"]
                    );

                }

                yield break;
            }
        }

        public IEnumerable<Author> GetAllAuthors()
        {
            using (_connection = GetNewSqlConnection())
            {
                var proc = "Get_all_authors";

                var command = new SqlCommand(proc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                _connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new Author
                    (

                        iD: (long)reader["ID"],
                        secondname: reader["secondname"] as string,
                        firstname: reader["firstname"] as string,
                        birthDate: (DateTime)reader["birth_date"]
                    );

                }

                yield break;
            }
        }

        public Author GetAuthorByID(long authorID)
        {
            using (_connection = GetNewSqlConnection())
            {
                var proc = "Get_author_by_id";

                var command = new SqlCommand(proc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@ID", authorID);

                _connection.Open();

                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new Author
                    (

                        iD: (long)reader["ID"],
                        secondname: reader["secondname"] as string,
                        firstname: reader["firstname"] as string,
                        birthDate: (DateTime)reader["birth_date"]
                    );
                }

                throw new InvalidOperationException("Author not found");
            }
        }

        public bool UpdateAuthor(long ID, string secondname, string firstname, DateTime birthDate)
        {
            using (_connection = GetNewSqlConnection())
            {
                var proc = "Update_author";

                var command = new SqlCommand(proc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@ID", ID);
                command.Parameters.AddWithValue("@secondname", secondname);
                command.Parameters.AddWithValue("@firstname", firstname);
                command.Parameters.AddWithValue("@birth_date", birthDate);

                _connection.Open();

                int rowCount = command.ExecuteNonQuery();

                return rowCount > 0;
            }
        }



    }
}
