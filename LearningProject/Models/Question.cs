using System.ComponentModel.DataAnnotations;

namespace LearningProject.Models
{
    public class Question
    {
        public int Id { get; set; }
        [Range(1, 100, ErrorMessage = "Marks must be between 1 and 100")]
        public int Marks { get; set; }
        public string Level { get; set; }
        public int? ActivityId { get; set; }

        public bool IsPublic { get; set; }
        public int QuestionTypeId { get; set; }

        // Navigation properties
        public QuestionType QuestionType { get; set; }

        // Navigation property for QuestionExam
        public ICollection<Answer>? Answers { get; set; }
    }
}