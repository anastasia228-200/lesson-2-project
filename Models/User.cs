using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Lesson_2.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        
        public string Login { get; set; }
        [Required]
        [EmailAddress]
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }

        public UserRole Role { get; set; }
        public DateTimeOffset CreatedAt { get; set; }

        [JsonIgnore]
        public Student? Student { get; set; }
    }
}
