namespace LearningProject.Models
{
    public class Role
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public ICollection<InternalUserRole>? InternalUserRoles { get; set; }
    }
}