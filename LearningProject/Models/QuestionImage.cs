namespace LearningProject.Models
{
    public class QuestionImage
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string Image { get; set; }
        public Question Question { get; set; }
    }
}