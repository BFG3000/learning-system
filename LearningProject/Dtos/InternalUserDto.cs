using LearningProject.Models;

namespace LearningProject.Dtos
{
    public class InternalUserDto
    {
        public int? Id { get; set; }

        public string Username { get; set; }

        public string PasswordHash { get; set; }

        // Navigation properties
        public int UserId { get; set; }
        public ICollection<Role> Roles { get; set; }
        

    }
}