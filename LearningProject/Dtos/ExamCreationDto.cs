namespace LearningProject.Dtos
{
    public class ExamCreationDto
    {
        public int? Id { get; set; }

        public required string ExamDefinitionName { get; set; }
        public int CategoryId { get; set; }
        public int ExamTypeId { get; set; }
        public int Duration { get; set; }

        public required List<ExamVariantDTO> ExamVariants { get; set; }
        public required List<ExamDto> Exams { get; set; }
    }
}

