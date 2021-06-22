using System;

namespace Domain.Models
{
    public class Log
    {
        public int Id { get; set; }
        public int LockId { get; set; }
        public int UserId { get; set; }
        public int TokenId { get; set; }
        public bool Success { get; set; }
        public DateTime EntryDate { get; set; }
    }
}
