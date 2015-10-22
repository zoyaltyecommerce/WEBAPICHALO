using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace CHALO.Models
{
    public class encryptdecrypt
    {
        #region crypto  Methods to Encrypt and Decrypt

        static string myKey = "3d5900ae-111a-45be-96b3-d9e4606ca793";
        static TripleDESCryptoServiceProvider cryptDES3 = new TripleDESCryptoServiceProvider();
        static MD5CryptoServiceProvider cryptMD5Hash = new MD5CryptoServiceProvider();

        internal static string Decrypt(string myString)
        {
            cryptDES3.Key = cryptMD5Hash.ComputeHash(ASCIIEncoding.ASCII.GetBytes(myKey));
            cryptDES3.Mode = CipherMode.ECB;
            ICryptoTransform desdencrypt = cryptDES3.CreateDecryptor();
            byte[] buff = Convert.FromBase64String(myString);
            return ASCIIEncoding.ASCII.GetString(desdencrypt.TransformFinalBlock(buff, 0, buff.Length));
        }

        internal static string Encrypt(string myString)
        {
            cryptDES3.Key = cryptMD5Hash.ComputeHash(ASCIIEncoding.ASCII.GetBytes(myKey));
            cryptDES3.Mode = CipherMode.ECB;
            ICryptoTransform desdencrypt = cryptDES3.CreateEncryptor();
            object MyASCIIEncoding = new ASCIIEncoding();
            byte[] buff = ASCIIEncoding.ASCII.GetBytes(myString);
            return Convert.ToBase64String(desdencrypt.TransformFinalBlock(buff, 0, buff.Length));
        }

        #endregion
    }
}