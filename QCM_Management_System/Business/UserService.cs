using QCM_Management_System.Models;
using QCM_ManagementSystem.DataAccess;
using System;
using System.Data.SqlClient;

namespace QCM_Management_System.Business
{
    public class UserService
    {
        // Authentifier un utilisateur
        public User AuthenticateUser(string username, string password)
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT IdUser, Username, FullName, Role, CreatedAt 
                                   FROM Users 
                                   WHERE Username = @Username AND PasswordHash = @Password";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new User
                                {
                                    IdUser = (int)reader["IdUser"],
                                    Username = reader["Username"].ToString(),
                                    FullName = reader["FullName"].ToString(),
                                    Role = reader["Role"].ToString(),
                                    CreatedAt = (DateTime)reader["CreatedAt"]
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Authentication error: " + ex.Message);
            }

            return null;
        }

        // Vérifier si un username existe déjà
        public bool UsernameExists(string username)
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        int count = (int)cmd.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        // Créer un nouvel utilisateur (pour registration future)
        public bool CreateUser(string username, string password, string fullName, string role = "User")
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"INSERT INTO Users (Username, PasswordHash, FullName, Role) 
                                   VALUES (@Username, @Password, @FullName, @Role)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password);
                        cmd.Parameters.AddWithValue("@FullName", fullName);
                        cmd.Parameters.AddWithValue("@Role", role);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch
            {
                return false;
            }
        }
    }
}