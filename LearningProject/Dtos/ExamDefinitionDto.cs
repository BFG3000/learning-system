namespace LearningProject.Dtos
{
    public class ExamDefinitionDto
    {
        public int Id { get; set; }

        public required string ExamDefinitionName { get; set; }
        public string? Category { get; set; }
        public string? ExamType { get; set; }
        public int? Duration { get; set; }

        public List<ExamVariantDTO>? ExamVariants { get; set; }
        public List<ExamDto>? Exams { get; set; }
    }
}

