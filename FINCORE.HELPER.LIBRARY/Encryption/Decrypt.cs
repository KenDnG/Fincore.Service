using System.Security.Cryptography;

namespace FINCORE.HELPER.LIBRARY.Encryption
{
    public class Decrypt
    {
        public static string DecryptAES(string encryptedStr)
        {
            string DecryptKey = Configuration.GetKey();
            encryptedStr = encryptedStr.Replace(" ", "+");
            byte[] byKey = { };
            byte[] IV = { 18, 52, 86, 120, 144, 171, 205, 239 };
            byte[] inputByteArray = new byte[encryptedStr.Length];

            byKey = System.Text.Encoding.UTF8.GetBytes(DecryptKey.Substring(0, 8));
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            inputByteArray = Convert.FromBase64String(encryptedStr.Replace(" ", "+"));

            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(byKey, IV), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            System.Text.Encoding encoding = System.Text.Encoding.UTF8;

            return encoding.GetString(ms.ToArray());
        }
    }
}