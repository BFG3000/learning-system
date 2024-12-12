namespace LearningProject.Models
{
    public class Result
    {
        public int Id { get; set; }
        public int UserExamId { get; set; }
        public int ExamVariantId { get; set; }
        public int Score { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        // Navigation properties
        public UserExam? UserExam { get; set; }
        public ExamVariant? ExamVariant { get; set; }
        public ICollection<AnswerResult>? AnswerResults { get; set; }
    }
}