using ReactChat.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace ReactChat.BusinessLogicLayer.Helpers.Encryption
{
    public class HashMd5
    {
        public string GetMd5Hash(string value)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(value));
                StringBuilder stringBuilder = new StringBuilder();
                for(int i =0; i<data.Length; i++)
                {
                    stringBuilder.Append(data[i].ToString("x2"));
                }
                return stringBuilder.ToString();
            }
        }

        public bool VerifyHash(string value , string hash)
        {
            using(MD5 md5Hash = MD5.Create())
            {
                string hashOfInput = GetMd5Hash(value);
                StringComparer stringComparer = StringComparer.OrdinalIgnoreCase;
                if(0 == stringComparer.Compare(hashOfInput, hash))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
