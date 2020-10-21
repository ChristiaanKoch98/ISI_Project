using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementToolkit
{
    public class Validation
    {
        //Check if the user already exists in the database's Users table
        public static bool CheckIfUserExists(string username)
        {
            bool existsYN = false;

            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.ISI_DBConnectionString))
            {
                
                string selectUser = "SELECT COUNT(user_id) FROM users WHERE username = @userName";

                using (SqlCommand selectUserCommand = new SqlCommand(selectUser))
                {
                    selectUserCommand.Connection = conn;
                    selectUserCommand.Parameters.Add("@userName", SqlDbType.VarChar, 50).Value = username;

                    conn.Open();
                    int userCount = (int)selectUserCommand.ExecuteScalar();

                    if (userCount > 0)
                    {
                        existsYN = true;
                    }
                }

                conn.Close();
            }

            return existsYN;
        }

        //Check the user's login credentials
        public static bool CheckLoginCredentials(string username, string hashedPassword)
        {
            bool isCorrect = true;

            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.ISI_DBConnectionString))
            {

                string selectUser = "SELECT COUNT(user_id) FROM users WHERE username = @userName AND hashedpassword = @hashedPassword";

                using (SqlCommand selectUserCommand = new SqlCommand(selectUser))
                {
                    selectUserCommand.Connection = conn;
                    selectUserCommand.Parameters.Add("@userName", SqlDbType.VarChar, 50).Value = username;
                    selectUserCommand.Parameters.Add("@hashedPassword", SqlDbType.NChar, 20).Value = hashedPassword;

                    conn.Open();
                    int userCount = (int)selectUserCommand.ExecuteScalar();

                    if (userCount == 0)
                    {
                        isCorrect = false;
                    }
                }

                conn.Close();
            }

            return isCorrect;
        }

    }
}
