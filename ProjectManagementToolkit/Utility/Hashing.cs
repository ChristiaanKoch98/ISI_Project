using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementToolkit
{
    public class Hashing
    {
        static public string HashPassword(string password)
        {
            /*
            Dirk probably won't be concerned about someone trying to hack into his accounts.
            I'm using a fast but outdated form of hashing.

            NB: Please note that if the hash type is changed, the length of the password field 
                has to be adjusted in the Users table. SHA1 only requires 20 characters.
            */

            byte[] data = Encoding.ASCII.GetBytes(password);
            var sha1_Hasher = new SHA1CryptoServiceProvider();
            byte[] hashedPasswordBytes = sha1_Hasher.ComputeHash(data);
            string hashedPassword = Encoding.ASCII.GetString(hashedPasswordBytes);

            return hashedPassword;
        }
    }
}
