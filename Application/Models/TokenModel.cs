using System;
namespace Application.Models
{
    public class TokenModel
    {
        public int Id { get; set; }
        public DateTime Expiry { get; set; }
        public int OwnerId { get; set; }
    }
}
