namespace LearningProject.Dtos
{
    public class ExamVariantDTO
    {
        public int? Id { get; set; }
        public int? ExamDefinitionId { get; set; }
        public required string VariantName { get; set; }
        public List<QuestionDto>? Questions { get; set; }
    }
}
