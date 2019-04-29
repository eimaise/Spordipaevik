using Core.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Data
{
    public class PeSportsTrackingContext : IdentityDbContext<ApplicationUser>
    {
        public PeSportsTrackingContext(DbContextOptions<PeSportsTrackingContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<SchoolClass> Classes { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<ApplicationUser> Persons { get; set; }
        
        public DbSet<Invite> Invites{ get;   set; }
        public DbSet<TeacherRegistration> Registrations{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<SchoolClass>()
                .HasMany(x => x.Students);
            modelBuilder.Entity<Exercise>()
                .HasOne(x => x.Unit);
            modelBuilder.Entity<Invite>()
                .Property(x => x.Token).IsRequired();
            modelBuilder.Entity<Student>()
                .HasOne(x => x.Invite);
            modelBuilder.ApplyConfiguration(new Invite.InviteConfiguration());
            modelBuilder.Entity<Student>()
                .HasMany(x => x.Results)
                .WithOne(x => x.Student)
                .HasForeignKey(x => x.StudentId);
            modelBuilder.Entity<Student>()
                .HasIndex(x => x.StudentCardNumber).IsUnique();
            modelBuilder.Entity<Result>().OwnsOne(o => o.ResultValue);
        }
    }
}