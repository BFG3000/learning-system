namespace LearningProject.Dtos
{
    public class AnswerDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public bool IsCorrect { get; set; }
    }
}
