using System.Security.Cryptography;

byte[] GetSHA1(byte[] data)
{
    using (var sha1 = SHA1.Create())
    {
        return sha1.ComputeHash(data);
    }
}
