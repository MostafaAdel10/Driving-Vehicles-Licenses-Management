using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public class clsDataHelper
    {
        /// <summary>
        /// To hash data on 256 bits
        /// </summary>
        /// <typeparam name="T">any data type</typeparam>
        /// <param name="Input"></param>
        /// <returns>hashed data</returns>
        public static string ComputHash<T>(T Input)
        {
            //SHA is Secutred Hash Algorithm.
            // Create an instance of the SHA-256 algorithm
            using (SHA256 sha256 = SHA256.Create())
            {
                // Compute the hash value from the UTF-8 encoded input string
                Byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(Input.ToString()));

                // Convert the byte array to a lowercase hexadecimal string
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
            
        }
        /// <summary>
        /// compare between two hashed values  
        /// </summary>
        /// <typeparam name="T">any data type</typeparam>
        /// <param name="value1">first value to be compared</param>
        /// <param name="value2">second value to be compared</param>
        /// <returns>is equle</returns>
        public static bool IsTheSame(string value1, string value2)
        {
            return value1 == value2;
        }
    }
}
