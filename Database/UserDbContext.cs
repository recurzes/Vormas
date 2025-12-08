using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Vormas.Interfaces;
using Vormas.Models;

namespace Vormas.Database
{
    public class UserDbContext : IUserManager
    {
        private string _connStr = Helpers.MySqlHelper.GetConnectionString();

        public void Create(User e)
        {
            DbCommandHelper.ExecuteNonQuery(_connStr, "prcAddUser", cmd =>
            {
                cmd.Parameters.AddWithValue("pFname", e.FirstName);
                cmd.Parameters.AddWithValue("pLname", e.LastName);
                cmd.Parameters.AddWithValue("pUsername", e.UserName);
                cmd.Parameters.AddWithValue("pPasswordHash", e.PasswordHash);
                cmd.Parameters.AddWithValue("pEmail", e.Email);
                cmd.Parameters.AddWithValue("pPhone", e.Phone);
                cmd.Parameters.AddWithValue("pRoleId", e.RoleId);
                cmd.Parameters.AddWithValue("pIsActive", e.IsActive);
            });
        }

        public List<User> GetAllUsers()
        {
            
            return DbCommandHelper.ExecuteReader(_connStr, "prcGetAllUsers", cmd =>
            {

            }, reader =>
            {
                List<User> users = new List<User>();
                while (reader.Read())
                {
                    User user = new User
                    {
                        UserId = reader.GetInt32("UserId"),
                        FirstName = reader.GetString("FirstName"),
                        LastName = reader.GetString("LastName"),
                        UserName = reader.GetString("Username"),
                        Email = reader.GetString("Email"),
                        Phone = reader.GetString("Phone"),
                        RoleId = reader.GetInt32("RoleId"),
                        IsActive = reader.GetBoolean("IsActive"),
                        CreatedAt = reader.GetDateTime("CreatedAt")
                    };

                    users.Add(user);
                }
                return users;
            });
        }

        public User GetUserById(int userId)
        {
            return DbCommandHelper.ExecuteReader(_connStr, "prcGetUserById", command =>
            {
                command.Parameters.AddWithValue("pUserId", userId);
            }, reader =>
            {
                if (reader.Read())
                {
                    return new User
                    {
                        UserId = reader.GetInt32("UserId"),
                        FirstName = reader.GetString("FirstName"),
                        LastName = reader.GetString("LastName"),
                        UserName = reader.GetString("UserName"),
                        PasswordHash = reader.GetString("PasswordHash"),
                        Email = reader.GetString("Email"),
                        Phone = reader.GetString("Phone"),
                        Address = reader.IsDBNull(reader.GetOrdinal("Address"))
                            ? null
                            : reader.GetString("Address"),
                        RoleId = reader.GetInt32("RoleId"),
                        IsActive = reader.GetBoolean("IsActive"),
                        CreatedAt = reader.GetDateTime("CreatedAt"),
                        UpdatedAt = reader.GetDateTime("UpdatedAt")
                    };
                }

                return null;
            });
        }

        public User GetUserByUsername(string username)
        {
            return DbCommandHelper.ExecuteReader(_connStr, "prcGetUserByUsername", cmd =>
            {
                cmd.Parameters.AddWithValue("pUsername", username);
            }, reader =>
            {
                if (reader.Read())
                {
                    return new User
                    {
                        UserId = reader.GetInt32("UserId"),
                        FirstName = reader.GetString("FirstName"),
                        LastName = reader.GetString("LastName"),
                        UserName = reader.GetString("Username"),
                        PasswordHash = reader.GetString("PasswordHash"),
                        Email = reader.GetString("Email"),
                        Phone = reader.GetString("Phone"),
                        RoleId = reader.GetInt32("RoleId"),
                        IsActive = reader.GetBoolean("IsActive")
                    };
                }

                return null;
            });
        }

        public int UpdateUser(User e)
        {
            int rowsAffected = DbCommandHelper.ExecuteNonQuery(_connStr, "prcUpdateUser", command =>
            {
                command.Parameters.AddWithValue("pUserId", e.UserId);
                command.Parameters.AddWithValue("pFname", e.FirstName);
                command.Parameters.AddWithValue("pLname", e.LastName);
                command.Parameters.AddWithValue("pUsername", e.UserName);
                command.Parameters.AddWithValue("pEmail", e.Email);
                command.Parameters.AddWithValue("pPhone", e.Phone);
                command.Parameters.AddWithValue("pAddress", e.Address);
                command.Parameters.AddWithValue("pRoleId", e.RoleId);
                command.Parameters.AddWithValue("pIsActive", e.IsActive);
            });

            return rowsAffected;
        }

        public int UpdatePassword(int userId, string newPasswordHash)
        {
            int rowsAffected = DbCommandHelper.ExecuteNonQuery(_connStr, "prcUpdateUserPassword", command =>
            {
                command.Parameters.AddWithValue("pUserId", userId);
                command.Parameters.AddWithValue("pPasswordHash", newPasswordHash);
            });

            return rowsAffected;
        }

        public int DeleteUser(int userId)
        {
            int rowsAffected = DbCommandHelper.ExecuteNonQuery(_connStr, "prcDeleteUser", command =>
            {
                command.Parameters.AddWithValue("pUserId", userId);
            });

            return rowsAffected;
        }
    }
}