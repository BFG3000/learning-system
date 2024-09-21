namespace LearningProject.Models
{
    public class ExamQuestion
    {
        public int Id { get; set; }
        public int ExamVariantId { get; set; }
        public int QuestionId { get; set; }

        // Navigation properties
        public ExamVariant? ExamVariant { get; set; }
        public Question? Question { get; set; }
    }
}