using System;

namespace Domain.Models
{
    public class Token
    {
        public int Id { get; set; }
        public DateTime Expiry { get; set; }
        public int OwnerId { get; set; }
    }
}
