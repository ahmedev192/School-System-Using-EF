using Microsoft.EntityFrameworkCore;
using SchoolSystemWeb.Models;

namespace SchoolSystemWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Family> Families { get; set; }
        public DbSet<FamilyMember> FamilyMembers { get; set; }
        public DbSet<Homework> Homeworks { get; set; }
        //public  DbSet<Human > Humans { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<ParentAddress> ParentAddresses { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentAddress> StudentAddresses { get; set; }
        public DbSet<StudentClass> StudentClasses { get; set; }
        public DbSet<StudentParent> StudentParents { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ParentAddress>()
                .HasKey(u => new { u.ParentId, u.AddressId });

            modelBuilder.Entity<StudentAddress>()
                .HasKey(u => new { u.StudentId, u.AddressId });

            modelBuilder.Entity<StudentClass>()
                .HasKey(u => new { u.StudentId, u.ClassId });

            modelBuilder.Entity<StudentParent>()
                .HasKey(u => new { u.StudentId, u.ParentId });

            modelBuilder.Entity<FamilyMember>()
                .HasOne(fm => fm.Family)
                .WithMany()
                .HasForeignKey(fm => fm.FamilyId)
                .OnDelete(DeleteBehavior.Restrict);



            modelBuilder.Entity<FamilyMember>()
                .HasOne(fm => fm.Student)
                .WithMany()
                .HasForeignKey(fm => fm.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }

    }
}
