using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace StoreWithDataSources.Data
{
    public class HashEncryption
    {
        public string GetHashPassword(string password)
        {
            MD5 mD5 = MD5.Create();
            byte[] byteMass = Encoding.ASCII.GetBytes(password);
            byte[] hashPassword = mD5.ComputeHash(byteMass);
            StringBuilder stringBuilder = new StringBuilder();
            foreach(var item in hashPassword)
            {
                stringBuilder.Append(item.ToString("X2"));
            }
            return Convert.ToString(stringBuilder);
        }
    }
}
