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
    public class SqlUserDAO : SqlDAO, IUserDAO
    {
        public bool AddUser(string username, string password, bool sex, string customName = null, bool isAdmin = false)
        {
            using (_connection = GetNewSqlConnection())
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
            using (_connection = GetNewSqlConnection())
            {
                var proc = "Check_admin_pass";

                var command = new SqlCommand(proc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@password", password);

                _connection.Open();

                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return true;
                }

                return false;
            }
        }

        public bool DeleteUser(string username)
        {
            using (_connection = GetNewSqlConnection())
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

        public IEnumerable<User> GetAllUsers()
        {
            using (_connection = GetNewSqlConnection())
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

        public User GetUserByName(string username)
        {
            using (_connection = GetNewSqlConnection())
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
            using (_connection = GetNewSqlConnection())
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

        public bool UpdateUser(string username, bool sex, string customName = null)
        {
            using (_connection = GetNewSqlConnection())
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
            using (_connection = GetNewSqlConnection())
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
