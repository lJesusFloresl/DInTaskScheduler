using System;
using System.Security.Cryptography;

namespace DInTaskSchedulerApi.Tools
{
    /// <summary>
    /// Enable secure passwords to users
    /// </summary>
    public sealed class PasswordHash
    {
        private const int SALT_SIZE = 16;
        private const int HASH_SIZE = 20;
        private const int ITERATIONS = 1000;
        private readonly byte[] salt;
        private readonly byte[] hash;
        public byte[] Salt { get { return (byte[])salt.Clone(); } }
        public byte[] Hash { get { return (byte[])hash.Clone(); } }

        public PasswordHash(string password)
        {
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[SALT_SIZE]);
            hash = new Rfc2898DeriveBytes(password, salt, ITERATIONS).GetBytes(HASH_SIZE);
        }

        public PasswordHash(byte[] hashBytes)
        {
            Array.Copy(hashBytes, 0, salt = new byte[SALT_SIZE], 0, SALT_SIZE);
            Array.Copy(hashBytes, SALT_SIZE, hash = new byte[HASH_SIZE], 0, HASH_SIZE);
        }

        public PasswordHash(byte[] salt, byte[] hash)
        {
            Array.Copy(salt, 0, this.salt = new byte[SALT_SIZE], 0, SALT_SIZE);
            Array.Copy(hash, 0, this.hash = new byte[HASH_SIZE], 0, HASH_SIZE);
        }

        public byte[] ToArray()
        {
            byte[] hashBytes = new byte[SALT_SIZE + HASH_SIZE];
            Array.Copy(salt, 0, hashBytes, 0, SALT_SIZE);
            Array.Copy(hash, 0, hashBytes, SALT_SIZE, HASH_SIZE);
            return hashBytes;
        }

        public bool Verify(string password)
        {
            byte[] test = new Rfc2898DeriveBytes(password, salt, ITERATIONS).GetBytes(HASH_SIZE);
            for (int i = 0; i < HASH_SIZE; i++)
                if (test[i] != hash[i])
                    return false;
            return true;
        }
    }
}
