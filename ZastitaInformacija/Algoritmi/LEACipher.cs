using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZastitaInformacija.Algoritmi
{
    internal class LEACipher : ICipherBehavior
    {
        private int keySize = 128;
        private int blockSize = 16; //128b, 16B;
        protected uint[,] roundKeys;
        private readonly uint[] delta = { unchecked((uint)0xc3efe9db), 0x44626b02, 0x79e27c8a, 0x78df30ec, 0x715ea49e, unchecked((uint)0xc785da0a), unchecked((uint)0xe04ef22a), unchecked((uint)0xe5c40957) };
        private uint[] iv;  
        public LEACipher(string key) {
            byte[] bytekey = Binary.HexStringToByteArray(key);
            this.keySize = bytekey.Length * 8;

            try
            {
                GenerateRoundKeys(bytekey);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }



        public string Encrypt(string plaintext)
        {
            try
            {
                byte[] paddedText = AddPKCS7Padding(plaintext);

                int blockCount = paddedText.Length / this.blockSize;
                uint[] plainUint = Binary.ByteArrayToUintArray(paddedText);

                uint[] ciphertext = new uint[plainUint.Length];

                iv = GenerateIV();

                //0. element
                uint[] xorResult = new uint[4];

                uint[] currentBlock = new uint[4];

                Array.Copy(plainUint, 0, currentBlock, 0, 4);

                xorResult = Binary.XOR(currentBlock, iv);

                uint[] encryptedBlock = EncryptBlock(xorResult);
                Array.Copy(encryptedBlock, 0, ciphertext, 0, 4);

                //
                for (int i = 4; i < plainUint.Length - 4; i += 4)
                {
                    Array.Copy(plainUint, i, currentBlock, 0, 4);

                    uint[] previousCipher = new uint[4];
                    uint[] previousPlain = new uint[4];
                    Array.Copy(plainUint, i - 4, previousPlain, 0, 4);

                    uint[] xorResult1 = new uint[4];
                    Array.Copy(ciphertext, i - 4, previousCipher, 0, 4);

                    xorResult1 = Binary.XOR(previousCipher, previousPlain);

                    xorResult = Binary.XOR(currentBlock, xorResult1);

                    encryptedBlock = EncryptBlock(xorResult);

                    Array.Copy(encryptedBlock, 0, ciphertext, i, 4);
                }

                string cipherString = Binary.UintArrayToString(ciphertext);

                return cipherString;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return plaintext;
            }
        }


        public uint[] EncryptBlock(uint[] plaintext)
        {

            int numOfRounds = keySize == 128 ? 24 : keySize == 192 ? 28 : 32;

            uint[,] X = new uint[numOfRounds + 1, plaintext.Length];
            uint[] cipherText = new uint[plaintext.Length];

            for (int i = 0; i < plaintext.Length; i++)
            {
                X[0, i] = plaintext[i];
            }

            for (int i = 0; i < numOfRounds; i++)
            {
                X[i + 1, 0] = Binary.ROL(X[i, 0] ^ this.roundKeys[i, 0] + X[i, 1] ^ this.roundKeys[i, 1], 9);
                X[i + 1, 1] = Binary.ROR(X[i, 1] ^ this.roundKeys[i, 2] + X[i, 2] ^ this.roundKeys[i, 3], 5);
                X[i + 1, 2] = Binary.ROR(X[i, 2] ^ this.roundKeys[i, 4] + X[i, 3] ^ this.roundKeys[i, 5], 3);
                X[i + 1, 3] = X[i, 0];
            }

            for (int i = 0; i < plaintext.Length; i++)
            {
                cipherText[i] = X[numOfRounds, i];
            }

            return cipherText;
        }

        public string Decrypt(string ciphertext)
        {
            byte[] cipherByte = Encoding.UTF8.GetBytes(ciphertext);

            uint[] cipherUint = Binary.ByteArrayToUintArray(cipherByte);

            uint[] plaintext = new uint[cipherUint.Length];

            uint[] xorResult = new uint[4];

            uint[] currentBlock = new uint[4];

            //0. element
            Array.Copy(cipherUint, 0, currentBlock, 0, 4);

            uint[] decryptedBlock = DecryptBlock(currentBlock);

            xorResult = Binary.XOR(decryptedBlock, iv);

            Array.Copy(xorResult, 0, plaintext, 0, 4);

            //
            for (int i = 4; i < cipherUint.Length - 4; i += 4)
            {
                Array.Copy(cipherUint, i, currentBlock, 0, 4);
                decryptedBlock = DecryptBlock(currentBlock);

                uint[] previousPlain = new uint[4];
                Array.Copy(plaintext, i - 4, previousPlain, 0, 4);

                uint[] previousCipher = new uint[4];
                Array.Copy(cipherUint, i - 4, previousCipher, 0, 4);

                uint[] xorResult1 = new uint[4];
                xorResult1 = Binary.XOR(previousPlain, previousCipher);

                xorResult = Binary.XOR(xorResult1, decryptedBlock);

                Array.Copy(xorResult, 0, plaintext, i, 4);
            }

            string plainString = Binary.UintArrayToString(plaintext);

            return plainString;
        }

        public uint[] DecryptBlock(uint[] ciphertext)
        {

            int numOfRounds = keySize == 128 ? 24 : keySize == 192 ? 28 : 32;

            uint[,] X = new uint[numOfRounds + 1, ciphertext.Length];
            uint[] plainext = new uint[ciphertext.Length];


            for (int i = 0; i < ciphertext.Length; i++)
            {
                X[numOfRounds, i] = ciphertext[i];
            }


            for (int i = numOfRounds - 1; i >= 0; i--)
            {
                X[i, 0] = X[i + 1, 3];
                X[i, 1] = (byte)(Binary.ROR(X[i + 1, 0], 9) - ((X[i, 0] ^ this.roundKeys[i, 0]) ^ this.roundKeys[i, 1]));
                X[i, 2] = (byte)(Binary.ROL(X[i + 1, 1], 5) - ((X[i, 1] ^ this.roundKeys[i, 2]) ^ this.roundKeys[i, 3]));
                X[i, 3] = (byte)(Binary.ROL(X[i + 1, 2], 3) - ((X[i, 2] ^ this.roundKeys[i, 4]) ^ this.roundKeys[i, 5]));
            }

            for (int i = 0; i < ciphertext.Length; i++)
            {
                plainext[i] = X[0, i];
            }

            return plainext;
        }


        public byte[] AddPKCS7Padding(string input)
        {
            if (string.IsNullOrEmpty(input))
                throw new ArgumentException("Input string cannot be null or empty");

            int paddingSize = this.blockSize - (input.Length % this.blockSize);
            if (paddingSize == 0)
                paddingSize = this.blockSize;

            string paddedInput = input + new string((char)paddingSize, paddingSize);
            return Encoding.UTF8.GetBytes(paddedInput);
        }

        public uint[] GenerateIV()
        {
            if (blockSize <= 0 || blockSize % 8 != 0)
            {
                throw new ArgumentException("Block size must be a positive multiple of 8.");
            }

            int ivSize = blockSize / 4;
            uint[] iv = new uint[ivSize];

            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                byte[] randomBytes = new byte[ivSize * sizeof(uint)];
                rng.GetBytes(randomBytes);

                Buffer.BlockCopy(randomBytes, 0, iv, 0, randomBytes.Length);
            }

            return iv;
        }
        

        public byte[] EncryptBytes(byte[] fileBytes)
        {
            // Konvertujemo fajl u string (ovo radi za tekstualne podatke)
            string plaintext = Encoding.UTF8.GetString(fileBytes);
            string encryptedText = Encrypt(plaintext);

            // Pretpostavimo da Binary.UintArrayToByteArray radi konverziju
            byte[] cipherBytes = Encoding.UTF8.GetBytes(encryptedText);

            // Pretvorimo IV (uint[]) u byte[] (morate implementirati odgovarajuću metodu ako već ne postoji)
            byte[] ivBytes = Binary.UintArrayToByteArray(iv);

            // Kombinujemo IV i ciphertext (prepend-ujemo IV)
            byte[] result = new byte[ivBytes.Length + cipherBytes.Length];
            Buffer.BlockCopy(ivBytes, 0, result, 0, ivBytes.Length);
            Buffer.BlockCopy(cipherBytes, 0, result, ivBytes.Length, cipherBytes.Length);

            return result;
        }
     


        public byte[] DecryptBytes(byte[] fileBytes)
        {
            // Pretpostavimo da znate veličinu IV-a (u bajtovima)
            int ivSize = blockSize; // Pošto je blockSize u bajtovima (16 bajtova)

            // Izdvajamo IV
            byte[] ivBytes = new byte[ivSize];
            Buffer.BlockCopy(fileBytes, 0, ivBytes, 0, ivSize);
            // Konvertujemo IV u uint[] (morate imati odgovarajuću metodu, npr. Binary.ByteArrayToUintArray)
            iv = Binary.ByteArrayToUintArray(ivBytes);

            // Izdvajamo ciphertext (ostatak niza)
            int cipherTextLength = fileBytes.Length - ivSize;
            byte[] cipherBytes = new byte[cipherTextLength];
            Buffer.BlockCopy(fileBytes, ivSize, cipherBytes, 0, cipherTextLength);

            // Pretvaramo ciphertext u string
            string ciphertext = Encoding.UTF8.GetString(cipherBytes);
            string decryptedText = Decrypt(ciphertext);

            return Encoding.UTF8.GetBytes(decryptedText);
        }


        public void GenerateRoundKeys(byte[] keyByte)
        {
            if (this.keySize != 128 && this.keySize != 192 && this.keySize != 256)
                throw new ArgumentException("Invalid key size");

            int numOfRounds = this.keySize == 128 ? 24 : this.keySize == 192 ? 28 : 32;
            this.roundKeys = new uint[numOfRounds, 6]; //generise niz kljuceva od 192b

            uint[] key = Binary.ByteArrayToUintArray(keyByte);

            uint[] T = new uint[8];

            for (int i = 0; i < keyByte.Length / 4; i++)
            {
                T[i] = key[i];
            }

            if (this.keySize == 128)
            {
                for (int i = 0; i < numOfRounds; i++)
                {
                    T[0] = Binary.ROL(T[0] + Binary.ROL(this.delta[i % 4], i), 1);
                    T[1] = Binary.ROL(T[1] + Binary.ROL(this.delta[i % 4], i + 1), 3);
                    T[2] = Binary.ROL(T[2] + Binary.ROL(this.delta[i % 4], i + 2), 6);
                    T[3] = Binary.ROL(T[3] + Binary.ROL(this.delta[i % 4], i + 3), 11);

                    this.roundKeys[i, 0] = T[0];
                    this.roundKeys[i, 1] = T[1];
                    this.roundKeys[i, 2] = T[2];
                    this.roundKeys[i, 3] = T[1];
                    this.roundKeys[i, 4] = T[3];
                    this.roundKeys[i, 5] = T[1];
                }
            }
            else if (this.keySize == 192)
            {
                for (int i = 0; i < numOfRounds; i++)
                {
                    T[0] = Binary.ROL(T[0] + Binary.ROL(this.delta[i % 6], i), 1);
                    T[1] = Binary.ROL(T[1] + Binary.ROL(this.delta[i % 6], i + 1), 3);
                    T[2] = Binary.ROL(T[2] + Binary.ROL(this.delta[i % 6], i + 2), 6);
                    T[3] = Binary.ROL(T[3] + Binary.ROL(this.delta[i % 6], i + 3), 11);
                    T[4] = Binary.ROL(T[4] + Binary.ROL(this.delta[i % 6], i + 4), 13);
                    T[5] = Binary.ROL(T[5] + Binary.ROL(this.delta[i % 6], i + 5), 17);

                    this.roundKeys[i, 0] = T[0];
                    this.roundKeys[i, 1] = T[1];
                    this.roundKeys[i, 2] = T[2];
                    this.roundKeys[i, 3] = T[3];
                    this.roundKeys[i, 4] = T[4];
                    this.roundKeys[i, 5] = T[5];
                }
            }
            else
            {
                for (int i = 0; i < numOfRounds; i++)
                {
                    T[(6 * i) % 8] = Binary.ROL(T[(6 * i) % 8] + Binary.ROL(this.delta[i % 8], i), 1);
                    T[(6 * i + 1) % 8] = Binary.ROL(T[(6 * i + 1) % 8] + Binary.ROL(this.delta[i % 8], i + 1), 3);
                    T[(6 * i + 2) % 8] = Binary.ROL(T[(6 * i + 2) % 8] + Binary.ROL(this.delta[i % 8], i + 2), 6);
                    T[(6 * i + 3) % 8] = Binary.ROL(T[(6 * i + 3) % 8] + Binary.ROL(this.delta[i % 8], i + 3), 11);
                    T[(6 * i + 4) % 8] = Binary.ROL(T[(6 * i + 4) % 8] + Binary.ROL(this.delta[i % 8], i + 4), 13);
                    T[(6 * i + 5) % 8] = Binary.ROL(T[(6 * i + 5) % 8] + Binary.ROL(this.delta[i % 8], i + 5), 17);

                    this.roundKeys[i, 0] = T[(6 * i) % 8];
                    this.roundKeys[i, 1] = T[(6 * i + 1) % 8];
                    this.roundKeys[i, 2] = T[(6 * i + 2) % 8];
                    this.roundKeys[i, 3] = T[(6 * i + 3) % 8];
                    this.roundKeys[i, 4] = T[(6 * i + 4) % 8];
                    this.roundKeys[i, 5] = T[(6 * i + 5) % 8];
                }
            }
        }

       
    }
}
