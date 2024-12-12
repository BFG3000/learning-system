namespace LearningProject.Models
{
    public class UserExam
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ExamId { get; set; }

        // Navigation properties
        public User User { get; set; }
        public Exam Exam { get; set; }
    }
}