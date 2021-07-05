using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryThreeLayer2021.DAL.InterfaceDAL;
using LibraryThreeLayer2021.Common.Entities;
using System.Configuration;
using System.Data.SqlClient;

namespace LibraryThreeLayer2021.DAL.SqlDAL
{
    public class SqlDAO : ILibDAO
    {
        private static string _connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;

        private static SqlConnection _connection;

        public bool AddAuthor(string secondname, string firstname, DateTime birthDate)
        {
            using (_connection = new SqlConnection(_connectionString))
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

        public bool AddBook(string name, string desc, DateTime publicationDate, string addedByUsername, long authorID, string text = null, byte[] bookItself = null, string fileName = null)
        {
            using (_connection = new SqlConnection(_connectionString))
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

        public bool AddBookToFavorite(string username, long bookID)
        {
            using (_connection = new SqlConnection(_connectionString))
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

        public bool AddGenre(string name, string desc)
        {
            using (_connection = new SqlConnection(_connectionString))
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

        public bool AddGenreToBook(long bookID, long genreID)
        {
            using (_connection = new SqlConnection(_connectionString))
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

        public bool AddUser(string username, string password, bool sex, string customName = null, bool isAdmin = false)
        {
            using (_connection = new SqlConnection(_connectionString))
            {
                var proc = "Add_user";

                var command = new SqlCommand(proc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);
                command.Parameters.AddWithValue("@sex", sex);
                command.Parameters.AddWithValue("@Is_admin", isAdmin);
                command.Parameters.AddWithValue("@custom_name", customName);

                _connection.Open();

                int rowCount = command.ExecuteNonQuery();

                return rowCount > 0;
            }
        }

        public bool CheckAdminPass(string password)
        {
            using (_connection = new SqlConnection(_connectionString))
            {
                var proc = "Check_admin_pass";

                var command = new SqlCommand(proc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@password", password);

                _connection.Open();

                var reader = command.ExecuteReader();

                if(reader.Read())
                {
                    return true;
                }

                return false;
            }
        }

        public bool DeleteAllFavBooksFromUser(string username)
        {
            using (_connection = new SqlConnection(_connectionString))
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

        public bool DeleteAllGenresFromBook(long bookID)
        {
            using (_connection = new SqlConnection(_connectionString))
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

        public bool DeleteAuthor(long authorID)
        {
            using (_connection = new SqlConnection(_connectionString))
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

        public bool DeleteBookByID(long bookID)
        {
            using (_connection = new SqlConnection(_connectionString))
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

        public bool DeleteConnectionFavBookWithUsers(long bookID)
        {
            using (_connection = new SqlConnection(_connectionString))
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

        public bool DeleteConnectionOfGenreWithBooks(long genreID)
        {
            using (_connection = new SqlConnection(_connectionString))
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

        public bool DeleteFavBookFromUser(string username, long bookID)
        {
            using (_connection = new SqlConnection(_connectionString))
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

        public bool DeleteGenre(long genreID)
        {
            using (_connection = new SqlConnection(_connectionString))
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

        public bool DeleteGenreFromBook(long bookID, long genreID)
        {
            using (_connection = new SqlConnection(_connectionString))
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

        public bool DeleteUser(string username)
        {
            using (_connection = new SqlConnection(_connectionString))
            {
                var proc = "Delete_user";

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

        public IEnumerable<Author> FindAuthors(string author)
        {
            using (_connection = new SqlConnection(_connectionString))
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

        public IEnumerable<Book> FindBooksByAuthor(string author)
        {
            using (_connection = new SqlConnection(_connectionString))
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
            using (_connection = new SqlConnection(_connectionString))
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
            using (_connection = new SqlConnection(_connectionString))
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
            using (_connection = new SqlConnection(_connectionString))
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
            using (_connection = new SqlConnection(_connectionString))
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

        public IEnumerable<Author> GetAllAuthors()
        {
            using (_connection = new SqlConnection(_connectionString))
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

        public IEnumerable<Book> GetAllBooks()
        {
            using (_connection = new SqlConnection(_connectionString))
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

        public IEnumerable<Genre> GetAllGenres()
        {
            using (_connection = new SqlConnection(_connectionString))
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
                        name: reader["secondname"] as string,
                        desc: reader["description"] as string
                    );

                }

                yield break;
            }
        }

        public IEnumerable<User> GetAllUsers()
        {
            using (_connection = new SqlConnection(_connectionString))
            {
                var proc = "Get_all_users";

                var command = new SqlCommand(proc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                _connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new User
                    (
                        username: reader["Username"] as string,
                        customName: reader["Custom_name"] as string,
                        sex: (Boolean)reader["sex"],
                        regDate: (DateTime)reader["Register_date"],
                        isAdmin: (Boolean)reader["Is_Admin"]

                    );

                }

                yield break;
            }
        }

        public Author GetAuthorByID(long authorID)
        {
            using (_connection = new SqlConnection(_connectionString))
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

        public Book GetBookByID(long bookID)
        {
            using (_connection = new SqlConnection(_connectionString))
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
            using (_connection = new SqlConnection(_connectionString))
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
                    if(reader["File_name"] == null || reader["Book_itself"] == null)
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
            using (_connection = new SqlConnection(_connectionString))
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
            using (_connection = new SqlConnection(_connectionString))
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

        public IEnumerable<Book> GetFavBooksOfUser(string username)
        {
            using (_connection = new SqlConnection(_connectionString))
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

        public Genre GetGenreByID(long genreID)
        {
            using (_connection = new SqlConnection(_connectionString))
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
            using (_connection = new SqlConnection(_connectionString))
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
                        name: reader["secondname"] as string,
                        desc: reader["description"] as string
                    );

                }

                yield break;
            }
        }

        public string GetTextOfBook(long bookID)
        {
            using (_connection = new SqlConnection(_connectionString))
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

        public User GetUserByName(string username)
        {
            using (_connection = new SqlConnection(_connectionString))
            {
                var proc = "Get_user_by_name";

                var command = new SqlCommand(proc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@username", username);

                _connection.Open();

                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new User
                    (
                            username: reader["Username"] as string,
                            customName: reader["Custom_name"] as string,
                            sex: (Boolean)reader["sex"],
                            regDate: (DateTime)reader["Register_date"],
                            isAdmin: (Boolean)reader["Is_Admin"]

                    );

                }

                throw new InvalidOperationException("There is no such user");
            }
        }

        public bool GetUserByNameAndPass(string username, string pass)
        {
            using (_connection = new SqlConnection(_connectionString))
            {
                var proc = "Get_user_by_name_with_pass";

                var command = new SqlCommand(proc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", pass);

                _connection.Open();

                return command.ExecuteReader().HasRows;
            }
        }

        public bool UpdateAuthor(long ID, string secondname, string firstname, DateTime birthDate)
        {
            using (_connection = new SqlConnection(_connectionString))
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

        public bool UpdateBook(long ID, string name, string desc, DateTime publicationDate, long authorID)
        {
            using (_connection = new SqlConnection(_connectionString))
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
            using (_connection = new SqlConnection(_connectionString))
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
            using (_connection = new SqlConnection(_connectionString))
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

        public bool UpdateGenre(long ID, string name, string desc)
        {
            using (_connection = new SqlConnection(_connectionString))
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

        public bool UpdateUser(string username, bool sex, string customName = null)
        {
            using (_connection = new SqlConnection(_connectionString))
            {
                var proc = "Update_user";

                var command = new SqlCommand(proc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@sex", sex);
                command.Parameters.AddWithValue("@custom_name", customName);

                _connection.Open();

                int rowCount = command.ExecuteNonQuery();

                return rowCount > 0;
            }
        }

        public bool UpdateUserPass(string username, string newPass)
        {
            using (_connection = new SqlConnection(_connectionString))
            {
                var proc = "Update_user_password";

                var command = new SqlCommand(proc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", newPass);

                _connection.Open();

                int rowCount = command.ExecuteNonQuery();

                return rowCount > 0;
            }
        }
    }
}
