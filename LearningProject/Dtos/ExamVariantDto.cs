namespace LearningProject.Dtos
{
    public class ExamVariantDTO
    {
        public required string VariantName { get; set; }
        public required List<QuestionDTO> Questions { get; set; }
    }
}
