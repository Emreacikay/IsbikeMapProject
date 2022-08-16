using System.ComponentModel.DataAnnotations;

namespace JsonWebTokenAPI.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; } 
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime TokenCreated { get; set; }
        public DateTime TokenExpires { get; set; } 
        public string Token { get; set; }
    }
}
