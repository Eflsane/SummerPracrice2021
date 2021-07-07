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
    public class SqlBookDAO : SqlDAO, IBookDAO
    {
        public bool AddBook(string name, string desc, DateTime publicationDate, string addedByUsername, long authorID, string text = null, byte[] bookItself = null, string fileName = null)
        {
            using (_connection = GetNewSqlConnection())
            {
                var proc = "Add_book";

                var command = new SqlCommand(proc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@description", desc);
                command.Parameters.AddWithValue("@publication_date", publicationDate);
                command.Parameters.AddWithValue("@added_by_username", addedByUsername);
                command.Parameters.AddWithValue("@authorID", authorID);
                command.Parameters.AddWithValue("@text", text);
                command.Parameters.AddWithValue("@book", bookItself);
                command.Parameters.AddWithValue("@file_name", fileName);

                _connection.Open();

                int rowCount = command.ExecuteNonQuery();

                return rowCount > 0;
            }
        }

        public bool DeleteBookByID(long bookID)
        {
            using (_connection = GetNewSqlConnection())
            {
                var proc = "Delete_book_by_id";

                var command = new SqlCommand(proc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@ID", bookID);

                _connection.Open();

                int rowCount = command.ExecuteNonQuery();

                return rowCount > 0;
            }
        }

        public IEnumerable<Book> FindBooksByAuthor(string author)
        {
            using (_connection = GetNewSqlConnection())
            {
                var proc = "Find_books_by_author";

                var command = new SqlCommand(proc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@author", author);

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
            }
        }

        public IEnumerable<Book> FindBooksByGenre(string genre)
        {
            using (_connection = GetNewSqlConnection())
            {
                var proc = "Find_books_by_genre";

                var command = new SqlCommand(proc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@genre", genre);

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
            }
        }

        public IEnumerable<Book> FindBooksByName(string name)
        {
            using (_connection = GetNewSqlConnection())
            {
                var proc = "Find_books_by_name";

                var command = new SqlCommand(proc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@name", name);

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
            }
        }

        public IEnumerable<Book> FindBooksByYear(long year)
        {
            using (_connection = GetNewSqlConnection())
            {
                var proc = "Find_books_by_year";

                var command = new SqlCommand(proc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@year", year);

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
            }
        }

        public IEnumerable<Book> FindBooksByYearMultiple(long year1, long year2)
        {
            using (_connection = GetNewSqlConnection())
            {
                var proc = "Find_books_by_year_multiple";

                var command = new SqlCommand(proc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@year1", year1);
                command.Parameters.AddWithValue("@year2", year2);

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
            }
        }

        public IEnumerable<Book> GetAllBooks()
        {
            using (_connection = GetNewSqlConnection())
            {
                var proc = "Get_all_books";

                var command = new SqlCommand(proc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

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
            }
        }

        public Book GetBookByID(long bookID)
        {
            using (_connection = GetNewSqlConnection())
            {
                var proc = "Get_book_by_id";

                var command = new SqlCommand(proc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@ID", bookID);

                _connection.Open();

                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new Book
                    (

                        iD: (long)reader["ID"],
                        name: reader["name"] as string,
                        desc: reader["description"] as string,
                        publicationDate: (DateTime)reader["publication_date"],
                        addedByUsername: reader["added_by_username"] as string,
                        authorID: (long)reader["authorID"]
                    );
                }

                throw new InvalidOperationException("Book not found");
            }
        }

        public BookFileContainer GetBookFile(long bookID)
        {
            using (_connection = GetNewSqlConnection())
            {
                var proc = "Get_bookFile_of_book";

                var command = new SqlCommand(proc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@bookID", bookID);

                _connection.Open();

                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    if (reader["File_name"] == null || reader["Book_itself"] == null)
                    {
                        throw new InvalidOperationException("There is no file attached to this book");
                    }

                    return new BookFileContainer
                    (
                        fileName: reader["File_name"] as string,
                        bookFile: (byte[])reader["Book_itself"]
                    );
                }

                throw new InvalidOperationException("Book not found");
            }
        }

        public IEnumerable<Book> GetBooksByAuthorID(long authorID)
        {
            using (_connection = GetNewSqlConnection())
            {
                var proc = "Get_books_by_author_id";

                var command = new SqlCommand(proc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@ID", authorID);

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
            }
        }

        public IEnumerable<Book> GetBooksByGenreID(long genreID)
        {
            using (_connection = GetNewSqlConnection())
            {
                var proc = "Get_books_by_genre_id";

                var command = new SqlCommand(proc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@ID", genreID);

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
            }
        }

        public string GetTextOfBook(long bookID)
        {
            using (_connection = GetNewSqlConnection())
            {
                var proc = "Get_text_of_book";

                var command = new SqlCommand(proc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@bookID", bookID);

                _connection.Open();

                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    if (reader["Text"] == null)
                    {
                        throw new InvalidOperationException("There is not text attached to this book");
                    }

                    return reader["Text"] as string;
                }

                throw new InvalidOperationException("Book not found");
            }
        }

        public bool UpdateBook(long ID, string name, string desc, DateTime publicationDate, long authorID)
        {
            using (_connection = GetNewSqlConnection())
            {
                var proc = "Update_book";

                var command = new SqlCommand(proc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@ID", ID);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@description", desc);
                command.Parameters.AddWithValue("@publication_date", publicationDate);
                command.Parameters.AddWithValue("@authorID", authorID);

                _connection.Open();

                int rowCount = command.ExecuteNonQuery();

                return rowCount > 0;
            }
        }

        public bool UpdateBookFie(long ID, byte[] bookItself, string fileName)
        {
            using (_connection = GetNewSqlConnection())
            {
                var proc = "Update_Book_file";

                var command = new SqlCommand(proc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@ID", ID);
                command.Parameters.AddWithValue("@file_name", fileName);
                command.Parameters.AddWithValue("@book", bookItself);

                _connection.Open();

                int rowCount = command.ExecuteNonQuery();

                return rowCount > 0;
            }
        }

        public bool UpdateBookText(long ID, string text)
        {
            using (_connection = GetNewSqlConnection())
            {
                var proc = "Update_Book_text";

                var command = new SqlCommand(proc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@ID", ID);
                command.Parameters.AddWithValue("@text", text);

                _connection.Open();

                int rowCount = command.ExecuteNonQuery();

                return rowCount > 0;
            }
        }
    }
}
