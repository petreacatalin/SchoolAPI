using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using School.Data.Configuration;
using School.Data.Configuration.Entities;
using School.Data.Entities;
using School.Repositories.Implementation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace School.Repositories
{
    public class SchoolDbContext : IdentityDbContext<ApiUser>
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options)
        {

        }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentClass> StudentClasses { get; set; }
        public DbSet<ApiUser> ApiUsers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>()
            .HasOne<Card>(c => c.Card)
            .WithOne(st => st.Student)
            .HasForeignKey<Card>(cd => cd.StudentId)
            .HasConstraintName("FK_StudentId_Cards")
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<StudentClass>().HasKey(sc => new { sc.StudentId, sc.ClassId });

            modelBuilder.Entity<StudentClass>()
            .HasOne<Student>(st => st.Student)
            .WithMany(stc => stc.StudentClasses)
            .HasForeignKey(sc => sc.StudentId)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("FK_StudentId_StudentClasses");

            modelBuilder.Entity<StudentClass>()
            .HasOne<Class>(c => c.Class)
            .WithMany(stc => stc.StudentClasses)
            .HasForeignKey(sc => sc.ClassId)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("FK_ClassId_StudentClasses");

            modelBuilder.Entity<Professor>()
            .HasOne<Office>(o => o.Office)
            .WithMany(p => p.Professors)
            .HasForeignKey(o => o.OfficeId)
            .HasConstraintName("FK_OfficeId_Professors")
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Professor>()
            .HasOne<Class>(p => p.Class)
            .WithMany(g => g.Professors)
            .HasForeignKey(d => d.ClassId)
            .HasConstraintName("FK_ClassId_Professor")
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Grade>()
            .HasOne<Professor>(p => p.Professor)
            .WithMany(g => g.Grades)
            .HasForeignKey(p => p.ProfessorId)
            .HasConstraintName("FK_ProfessorId_Grades")
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Grade>()
           .HasOne<Student>(st => st.Student)
           .WithMany(g => g.Grades)
           .HasForeignKey(d => d.StudentId)
           .HasConstraintName("FK_StudentId_Grades")
           .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ApiUser>()
            .HasOne<Student>(st => st.Student)
            .WithOne(ai => ai.ApiUser)
            .HasForeignKey<Student>(cd => cd.ApiUserId)
            .HasConstraintName("FK_Student_ApiUser")
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ApiUser>()
            .HasOne<Professor>(x => x.Professor)
            .WithOne(st => st.ApiUser)
            .HasForeignKey<Professor>(cd => cd.ApiUserId)
            .HasConstraintName("FK_Professor_ApiUser")
            .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new ClassConfiguration());
        }
    }
}
