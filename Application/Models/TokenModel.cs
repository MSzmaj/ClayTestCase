using System;
namespace Application.Models
{
    public class TokenModel
    {
        public string Id { get; set; }
        public DateTime Expiry { get; set; }
        public string OwnerId { get; set; }
    }
}
