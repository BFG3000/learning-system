
namespace LearningProject.Models
{
public class AnswerImage
{
    public int Id { get; set; }
    public int AnswerId { get; set; }
    public string Image { get; set; }
    public Answer Answer { get; set; }
}
}