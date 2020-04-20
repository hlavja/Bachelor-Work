using System;
using System.Security.Cryptography;

namespace ISSSC.Class
{
    /// <summary>
    /// Class for manipulation with administrator password
    /// </summary>
    public class PasswordHash
    {
        /// <summary>
        /// Endoce given password
        /// </summary>
        /// <param name="blankPassword">filled password in param form</param>
        /// <returns>Returns password hash</returns>
        public string Encode(string blankPassword)
        {
            //Create the salt value with a cryptographic PRNG
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            //Create the Rfc2898DeriveBytes and get the hash value:
            var pbkdf2 = new Rfc2898DeriveBytes(blankPassword, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);
            //Combine the salt and password bytes for later use:
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);
            //Save to DB
            string savedPasswordHash = Convert.ToBase64String(hashBytes);
            return(savedPasswordHash);
        }

        /// <summary>
        /// Decode given password and compare it with the one in database
        /// </summary>
        /// <param name="savedPasswordHash">saved password hash from database</param>
        /// <param name="password">filled password in login form</param>
        /// <returns>returns boolean value if passwords are equal</returns>
        public Boolean Decode(string savedPasswordHash, string password = "")
        {
            byte[] hashBytes = Convert.FromBase64String(savedPasswordHash);
            string savedPassword = Convert.ToBase64String(hashBytes);
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);
            //compare passwords
            for (int i = 0; i < 20; i++)
            {
                if (hashBytes[i + 16] != hash[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}