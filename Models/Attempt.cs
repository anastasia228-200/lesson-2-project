using System.ComponentModel.DataAnnotations;

namespace Lesson_2.Models
{
    public class Attempt
    {
        public int Id { get; set; }
        public DateTimeOffset StartedAt { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset? SubmittedAt { get; set; }
        public int? Score { get; set; }
        [Required]
        public int TestId { get; set; }
        [Required]
        public int StudentId { get; set; }

        public Test Test { get; set; }
        public Student Student { get; set; }
        public List<UserAttemptsAnswer> UserAttemptAnswers { get; set; }
    }
}
