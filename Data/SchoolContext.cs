using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using School.Models;

namespace School.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options)
            : base(options)
        {
        }

        public DbSet<Course> Course { get; set; } = default!;
        public DbSet<Student> Student { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().ToTable("Course")
                .HasIndex(c => c.CourseCode)
                .IsUnique();

            modelBuilder.Entity<Student>().ToTable("Student")
                .HasIndex(s => s.Email)
                .IsUnique();

            modelBuilder.Entity<Course>()
                .HasMany(c => c.Students)
                .WithMany(s => s.Courses)
                .UsingEntity<CourseStudent>(
                    j => j
                        .HasOne(cs => cs.Student)
                        .WithMany(s => s.CourseStudents)
                        .HasForeignKey(cs => cs.StudentId),
                    j => j
                        .HasOne(cs => cs.Course)
                        .WithMany(c => c.CourseStudents)
                        .HasForeignKey(cs => cs.CourseId),
                    j =>
                    {
                        j.ToTable("CourseStudent");
                        j.HasKey(cs => new { cs.StudentId, cs.CourseId });
                    });
        }
    }
}