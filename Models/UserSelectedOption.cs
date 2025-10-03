using System.ComponentModel.DataAnnotations;

namespace Lesson_2.Models
{
    public class UserSelectedOption
    {
        public int Id { get; set; }
        [Required]
        public int UserAttemptAnswerId { get; set; }
        [Required]
        public int AnswerId { get; set; }
        public UserAttemptsAnswer UserAttemptAnswer { get; set; }
        public Answer Answer { get; set; }
    }
}