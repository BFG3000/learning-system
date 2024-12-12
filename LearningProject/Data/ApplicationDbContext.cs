using Microsoft.EntityFrameworkCore;
using LearningProject.Models;

namespace LearningProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // DbSets for each model
        public DbSet<ExamDefinition> ExamDefinitions { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<UserExam> UserExams { get; set; }
        public DbSet<ExamQuestion> ExamQuestions { get; set; }
        public DbSet<ExamVariant> ExamVariants { get; set; }
        public DbSet<QuestionType> QuestionTypes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<ExamType> ExamTypes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<PublicUser> PublicUsers { get; set; }
        public DbSet<InternalUser> InternalUsers { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<InternalUserRole> InternalUserRoles { get; set; }
        public DbSet<AnswerResult> AnswerResults { get; set; }
        public DbSet<QuestionImage> QuestionImages { get; set; }
        public DbSet<AnswerImage> AnswerImages { get; set; }
        
        // Configure relationships using Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed initial question types
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "General" },
                new Category { Id = 2, Name = "IT" },
                new Category { Id = 3, Name = "HR" }
            );

            modelBuilder.Entity<QuestionType>().HasData(
                new QuestionType { Id = 1, Name = "Multiple Choice" },
                new QuestionType { Id = 2, Name = "True/False" },
                new QuestionType { Id = 3, Name = "Multiple Choice With Images" }
            );

            modelBuilder.Entity<Location>().HasData(
                new Location { Id = 1, Name = "Online" },
                new Location { Id = 2, Name = "Headquarters" }
            );

            modelBuilder.Entity<ExamType>().HasData(
                new ExamType { Id = 1, Name = "Private" },
                new ExamType { Id = 2, Name = "Public" },
                new ExamType { Id = 3, Name = "InviteOnly" }
            );

            modelBuilder.Entity<User>().HasData(
                new User { 
                    Id = 1, 
                    Name = "Admin",
                    Email="learn@learn.com",
                    Phone="01117005305"
                }
            );

            modelBuilder.Entity<Role>().HasData(
                new Role { 
                    Id = 1, 
                    Name = "SuperAdmin"
                }
            );

            modelBuilder.Entity<InternalUser>().HasData(
                new InternalUser { 
                    Id = 1, 
                    Username = "admin",
                    PasswordHash = "$2y$10$nFW94pFwxc2tnTvpBFCw9OP.DWyckomslKPme7uPDTdibK64/wZQ.",
                    UserId = 1
                }
            ); 

            modelBuilder.Entity<InternalUserRole>().HasData(
                new InternalUserRole { 
                    Id = 1, 
                    RoleId = 1,
                    InternalUserId = 1
                }
            );            

            // ExamDefinition and Category
            modelBuilder.Entity<ExamDefinition>()
                .HasOne(ed => ed.Category)
                .WithMany()
                .HasForeignKey(ed => ed.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            // // Exam and ExamDefinition
            // modelBuilder.Entity<Exam>()
            //     .HasOne(e => e.ExamDefinition)
            //     .WithMany()
            //     .HasForeignKey(e => e.ExamDefinitionId)
            //     .OnDelete(DeleteBehavior.Restrict);

            // Question and QuestionType
            modelBuilder.Entity<Question>()
                .HasOne(q => q.QuestionType)
                .WithMany()
                .HasForeignKey(q => q.QuestionTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            // Answer and Question
            modelBuilder.Entity<Answer>()
                .HasOne(a => a.Question)
                .WithMany(q => q.Answers)
                .HasForeignKey(a => a.QuestionId)
                .OnDelete(DeleteBehavior.Cascade);


            // Result and UserExam
            modelBuilder.Entity<Result>()
                .HasOne(r => r.UserExam)
                .WithMany()
                .HasForeignKey(r => r.UserExamId)
                .OnDelete(DeleteBehavior.Cascade);

            // Result and ExamVariant
            modelBuilder.Entity<Result>()
                .HasOne(r => r.ExamVariant)
                .WithMany(q=>q.Results)
                .HasForeignKey(r => r.ExamVariantId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure ExamQuestion many to many relationship
            modelBuilder.Entity<ExamQuestion>()
                .HasOne(qe => qe.Question)
                .WithMany(q => q.ExamQuestions)
                .HasForeignKey(qe => qe.QuestionId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ExamQuestion>()
                .HasOne(qe => qe.ExamVariant)
                .WithMany(ev => ev.ExamQuestions)
                .HasForeignKey(qe => qe.ExamVariantId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure InternalUserRole many to many relationship
            modelBuilder.Entity<InternalUserRole>()
                .HasOne(e => e.InternalUser)
                .WithMany(s => s.InternalUserRoles)
                .HasForeignKey(e => e.InternalUserId);

            modelBuilder.Entity<InternalUserRole>()
                .HasOne(e => e.Role)
                .WithMany(c => c.InternalUserRoles)
                .HasForeignKey(e => e.RoleId);

            // Configure AnswerResults many to many relationship
            modelBuilder.Entity<AnswerResult>()
                .HasOne(e => e.Answer)
                .WithMany(s => s.AnswerResults)
                .HasForeignKey(e => e.AnswerId);

            modelBuilder.Entity<AnswerResult>()
                .HasOne(e => e.Result)
                .WithMany(c => c.AnswerResults)
                .HasForeignKey(e => e.ResultId);

            // Configure UserExams many to many relationship
            modelBuilder.Entity<UserExam>()
                .HasOne(ee => ee.User)
                .WithMany(e=>e.UserExams)
                .HasForeignKey(ee => ee.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserExam>()
                .HasOne(ee => ee.Exam)
                .WithMany(e=>e.UserExams)
                .HasForeignKey(ee => ee.ExamId)
                .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
