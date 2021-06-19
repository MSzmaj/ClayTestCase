using System;

namespace Domain.Models
{
    public class Token
    {
        public string Id { get; set; }
        public DateTime Expiry { get; set; }
        public string OwnerId { get; set; }
    }
}
