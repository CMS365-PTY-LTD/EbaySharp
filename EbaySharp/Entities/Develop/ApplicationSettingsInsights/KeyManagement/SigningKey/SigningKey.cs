namespace EbaySharp.Entities.Develop.KeyManagement.SigningKey
{
    public class SigningKey
    {
        public string SigningKeyId { get; set; }
        public SigningKeyCipher SigningKeyCipher { get; set; }
        public string PublicKey { get; set; }

        public string PrivateKey { get; set; }
        public string JWE { get; set; }
        public int CreationTime { get; set; }
        public int ExpirationTime { get; set; }
    }
}
