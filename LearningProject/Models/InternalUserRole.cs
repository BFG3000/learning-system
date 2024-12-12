using System.ComponentModel.DataAnnotations;
namespace LearningProject.Models
{
    public class InternalUserRole
    {
        public int Id { get; set; }
        public int InternalUserId { get; set; }
        public InternalUser? InternalUser { get; set; }

        public int RoleId { get; set; }
        public Role? Role { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}