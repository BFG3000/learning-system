using LearningProject.Models;

namespace LearningProject.Dtos
{
    public class ExamDefinitionDto
    {
        public int? Id { get; set; }

        public required string ExamDefinitionName { get; set; }
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        public ExamType? ExamType { get; set; }
        public int? Duration { get; set; }

        public List<ExamVariantDTO>? ExamVariants { get; set; }
        public List<ExamDto>? Exams { get; set; }
    }
}

