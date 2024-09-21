using System.ComponentModel.DataAnnotations;

namespace LearningProject.Models
{
public class Answer
    {
        public int Id { get; set; }
        public Question Question { get; set; }

        [Required(ErrorMessage = "Question ID is required")]
        public int QuestionId { get; set; }
        public string Name { get; set; }
        public bool IsCorrect { get; set; }
    }
}