using System.ComponentModel.DataAnnotations;
namespace LearningProject.Models
{
public class InternalUser
{
    public int Id { get; set; } 

    [Required]
    public required string Username { get; set; }

    public string? PasswordHash { get; set; }

    public int? DepartmentId { get; set; }
    public Department? Department { get; set; }    

    public int UserId { get; set; }
    public User? User { get; set; }
    public ICollection<InternalUserRole>? InternalUserRoles { get; set; }
}
}