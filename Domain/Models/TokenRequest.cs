using System;

namespace Domain.Models
{
    public class TokenRequest
    {
        public int Id { get; set; }
        public int LockId { get; set; }
        public string PublicKey { get; set; }
        public DateTime Expiry { get; set; }
    }
}
