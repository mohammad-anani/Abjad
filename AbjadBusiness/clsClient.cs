using AbjadData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Configuration;
using System.Data;

namespace AbjadBusiness
{
    public class clsClient
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string CreditCardNumber { get; set; }
        public string ImagePath { get; set; }
        public bool IsActive { get; set; }

        public clsClient()
        {
            this.ID = -1;
            this.FullName = "FullName";
            this.Username = "Username";
            this.Password = "Password";
            this.CreditCardNumber = "CreditCardNumber";
            this.ImagePath = "ImagePath";
            this.IsActive = false;
            this.Address = "Address";
        }


        public clsClient(int iD, string fullName, string address, string username, string password, string creditCardNumber, string imagePath, bool isActive)
        {
            this.ID = iD;
            this.FullName = fullName;
            this.Address = address;
            this.Username = username;
            this.Password = password;
            this.CreditCardNumber = creditCardNumber;
            this.ImagePath = imagePath;
            this.IsActive = isActive;
        }

        public bool AddClient()
        {
            this.ID = clsClientData.AddClient(this.FullName, this.Address, this.Username, ComputeHash(this.Password), SymmetricEncryption(this.CreditCardNumber), this.ImagePath);
            return this.ID != -1;
        }

        public bool UpdateClient()
        {
            return clsClientData.UpdateClient(this.ID, this.FullName, this.Address, this.Username, this.Password,this.CreditCardNumber, this.ImagePath,this.IsActive);

        }

        public bool ChangePassword()
        {
            return clsClientData.UpdateClient(this.ID, this.FullName, this.Address, this.Username, ComputeHash(this.Password), this.CreditCardNumber, this.ImagePath,this.IsActive);

        }

        public bool ChangeCreditCardNumber()
        {
            return clsClientData.UpdateClient(this.ID, this.FullName, this.Address, this.Username, this.Password, SymmetricEncryption(this.CreditCardNumber), this.ImagePath,this.IsActive);

        }

        public static bool UsernameExists(string username)
        {
            return clsClientData.UsernameExists(username);
        }
        public static string ComputeHash(string stringtohash)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(stringtohash));
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }

        public static string SymmetricEncryption(string stringtoencrypt)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(ConfigurationManager.AppSettings["Key"]);
                aesAlg.IV = new byte[aesAlg.BlockSize / 8];



                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);



                using (var msEncrypt = new System.IO.MemoryStream())
                {
                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    using (var swEncrypt = new System.IO.StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(stringtoencrypt);
                    }


                    return Convert.ToBase64String(msEncrypt.ToArray());
                }

            }
        }

        public static string SymmetricDecryption(string stringtodecrypt)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(ConfigurationManager.AppSettings["Key"]);
                aesAlg.IV = new byte[aesAlg.BlockSize / 8];


                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);


                using (var msDecrypt = new System.IO.MemoryStream(Convert.FromBase64String(stringtodecrypt)))
                using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                using (var srDecrypt = new System.IO.StreamReader(csDecrypt))
                {
                   
                    return srDecrypt.ReadToEnd();
                }
            }
        }

        public static clsClient FindClientByID(int ClientID)
        {
           string FullName = "FullName";
           string Username = "Username";
          string  Password = "Password";
           string CreditCardNumber = "CreditCardNumber";
            string ImagePath = "ImagePath";
           bool IsActive = false;
           string Address = "Address";

            if(clsClientData.FindClientByID(ClientID,ref FullName,ref Address,ref Username,ref Password,ref CreditCardNumber,ref ImagePath,ref IsActive))
            {
                return new clsClient(ClientID, FullName,Address, Username,Password,CreditCardNumber,ImagePath,IsActive);
            }
            return new clsClient();
        }

        public static clsClient FindClientByUsernameAndPassword(string Username,string Password)
        {
            int ClientID = -1;
            string FullName = "FullName";
            string CreditCardNumber = "CreditCardNumber";
            string ImagePath = "ImagePath";
            bool IsActive = false;
            string Address = "Address";

            if (clsClientData.FindClientByUsernameAndPassword(ref ClientID, ref FullName, ref Address, Username, Password, ref CreditCardNumber, ref ImagePath, ref IsActive))
            {
                return new clsClient(ClientID, FullName, Address, Username, Password, CreditCardNumber, ImagePath, IsActive);
            }
            return new clsClient();
        }
    
        public static DataTable ListClients(int pagenumber)
        {
            return clsClientData.ListClients(pagenumber);
        }

        public static int GetClientsTotal()
        {
            return clsClientData.GetClientsTotal();
        }

        public static bool DeleteClient(int ClientID)
        {
            return clsClientData.DeleteClient(ClientID);
        }
    
    }
}