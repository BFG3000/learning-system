using System.ComponentModel.DataAnnotations;

namespace LearningProject.Models
{
    public class Exam
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Exam name is required")]
        [MaxLength(100, ErrorMessage = "Exam name can't exceed 100 characters")]
        public required string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int LocationId { get; set; }
        public int ExamDefinitionId { get; set; }
        public ExamDefinition? ExamDefinition { get; set; }  // Reference to ExamDefinition
        public Location? Location { get; set; }  // Reference to Location


    }
}