using System;
using System.ComponentModel.DataAnnotations;

namespace RealEstateMVC.Models
{
    public class Message
    {
        public int Id { get; set; }

        [Required]
        public string SenderName { get; set; }

        [Required, EmailAddress]
        public string SenderEmail { get; set; }

        public string Subject { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime SentAt { get; set; } = DateTime.Now;

        public bool IsRead { get; set; }
    }
}
