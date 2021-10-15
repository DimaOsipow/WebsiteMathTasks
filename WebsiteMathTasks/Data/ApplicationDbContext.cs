using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebsiteMathTasks.Models;

namespace WebsiteMathTasks.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<UserAnswerModel> UserAnswerModels { get; set; }

        public DbSet<IndexViewModel> indexViewModels { get; set; }
        
        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                Name = "admin",
                NormalizedName = "ADMIN"
            });
            modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                UserName = "my@email.com",
                NormalizedUserName = "MY@EMAIL.COM",
                Email = "my@email.com",
                NormalizedEmail = "MY@EMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "Zxcqwe123!"),
                SecurityStamp = string.Empty
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                UserId = "3b62472e-4f66-49fa-a20f-e7685b9565d8"
            });

            modelBuilder
               .Entity<UserAnswerModel>()
               .HasMany(c => c.Tasks)
               .WithMany(s => s.UserAnswerModels)
               .UsingEntity<IndexViewModel>(
               j => j
                   .HasOne(pt => pt.tasks)
                   .WithMany(t => t.IndexViewModels)
                   .HasForeignKey(pt => pt.TaskId),
               j => j
                   .HasOne(pt => pt.userAnswerModels)
                   .WithMany(p => p.IndexViewModels)
                   .HasForeignKey(pt => pt.UserAnswerModelId),
               j =>
               {
                   
                   j.HasKey(t => new { t.UserAnswerModelId, t.TaskId });
                   j.ToTable("IndexViewModel");
               });
        }   
    }
}
    


