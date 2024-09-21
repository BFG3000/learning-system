using System.ComponentModel.DataAnnotations;
namespace LearningProject.Models
{
public class InternalUser
{
    public int Id { get; set; } 

    [Required]
    public string Username { get; set; }

    [Required]
    public string PasswordHash { get; set; }

    public int? DepartmentId { get; set; }

    // Navigation properties
    public int UserId { get; set; }
    public User User { get; set; }  // Reference to User table
    public ICollection<Role> Roles { get; set; }
}
}