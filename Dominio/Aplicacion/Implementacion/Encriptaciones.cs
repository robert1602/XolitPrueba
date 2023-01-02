using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using Dominio.Enumeradores;

namespace Dominio.Aplicacion.Implementacion
{
    public class Encriptaciones
    {
        public static string Sha256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public static byte[] EncriptarStringABytesAes(string plainText, byte[] Key, byte[] IV)
        {
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encriptado;
            using (Aes aesAlgoritmo = Aes.Create())
            {
                aesAlgoritmo.Key = Key;
                aesAlgoritmo.IV = IV;
                ICryptoTransform encryptor = aesAlgoritmo.CreateEncryptor(aesAlgoritmo.Key, aesAlgoritmo.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                        encriptado = msEncrypt.ToArray();
                    }
                }
            }
            return encriptado;
        }

        static string DesencriptarDeBytesAstringAes(byte[] cipherText, byte[] Key, byte[] IV)
        {
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            string plaintext = null;
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }

            return plaintext;
        }
        public static string CodificarBase64(string Texto)
        {
            byte[] encbuff = System.Text.Encoding.UTF8.GetBytes(Texto);
            return Convert.ToBase64String(encbuff);
        }

        public static string Base64_Decode(string str)
        {
            string ValidacionTexto = ValidarTextoBase64(str);
            if (ValidacionTexto == string.Empty)
            {
                byte[] decbuff = Convert.FromBase64String(str);
                return System.Text.Encoding.UTF8.GetString(decbuff);
            }
            return string.Empty;
               
        }

        public static string ValidarTextoBase64(string TextoBase64)
        {
            string expresionRegular = EnumValor.GetStringValue(ExpresionesRegulares.ValidacionesTipoTexto.Base64);
            Regex FuncionExpresionRegular = new Regex(expresionRegular);
            bool EstextoBase64 = FuncionExpresionRegular.IsMatch(TextoBase64);
            string mensajeCorreoElectronico = EstextoBase64 ? string.Empty : EnumValor.GetStringValue(MensajesValidaciones.MensajesCampos.FormatoBase64Invalido);
            return mensajeCorreoElectronico;
        }


    }
}
