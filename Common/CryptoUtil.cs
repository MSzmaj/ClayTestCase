using System.Text;

namespace Common {
    public static class CryptoUtil {
        public static string Encrypt (string data, string publicKey) {
            var bytes = Encoding.UTF8.GetBytes(data);
            //In a real world scenario this would use RSA public key encryption
            return System.Convert.ToBase64String(bytes);
        }
    }
}