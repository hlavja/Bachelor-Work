using ISSSC.Models;
using Microsoft.AspNetCore.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Web;

namespace ISSSC.Class
{
    /// <summary>
    /// Class for rendering timetable component
    /// </summary>
    public class PasswordHash
    {
        /// <summary>
        /// Renders timetable component
        /// </summary>
        /// <param name="events">List of events to display</param>
        /// <param name="showState">Show state of event</param>
        /// <returns>rendered component</returns>
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
        /// Renders public event timetable component
        /// </summary>
        /// <param name="db">Database context</param>
        /// <param name="weeks">Weeks</param>
        /// <returns>Html component</returns>
        public Boolean Decode(string savedPasswordHash, string password = "")
        {
            /* Extract the bytes */
            byte[] hashBytes = Convert.FromBase64String(savedPasswordHash);
            string savedPassword = Convert.ToBase64String(hashBytes);
            /* Get the salt */
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);

            /* Compare the results */
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