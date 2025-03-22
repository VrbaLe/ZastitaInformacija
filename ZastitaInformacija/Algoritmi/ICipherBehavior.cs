using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZastitaInformacija.Algoritmi
{
    internal interface ICipherBehavior
    {
            public string Encrypt(string plaintext)
            {
                return plaintext;
            }

            public string Decrypt(string ciphertext)
            {
                return ciphertext;
            }

            public byte[] EncryptBytes(byte[] plaintext)
            {
                return plaintext;
            }

            public byte[] DecryptBytes(byte[] ciphertext)
            {
                return ciphertext;
            }
    }
}
