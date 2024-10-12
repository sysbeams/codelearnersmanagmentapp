
using Domain.Aggreagtes.ApplicantAggregate;
using Domain.Aggreagtes.CourseAggregate;
using Domain.Aggreagtes.EnrollmentAggregate;
using Domain.Aggreagtes.LectureAggregate;
using Domain.Aggreagtes.ResultAggregate;
using Domain.Aggreagtes.RoleAggregate;
using Domain.Aggreagtes.StaffAggregate;
using Domain.Aggreagtes.StudentAggregate;
using Domain.Aggreagtes.UserAggregate;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Infrastructure.Persistence.Context;

public class ApplicationContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Student> Students { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Applicant> Applicants { get; set; }
    public DbSet<ApplicantEnrollment> ApplicantEnrollments { get; set; }
    public DbSet<Assessment> Assessments { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Enrollment> Enrollments { get; set; }
    public DbSet<Lecture> Lectures { get; set; }
   // public DbSet<Result> Results { get; set; }
    public DbSet<Staff> Staff { get; set; }
    public DbSet<Role> Roles { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Applicant>()
        .HasKey(a => a.Id);
        modelBuilder.Entity<Role>()
        .HasKey(a => a.Id);
        modelBuilder.Entity<User>()
        .HasKey(a => a.Id);
        modelBuilder.Entity<Enrollment>()
        .HasKey(a => a.Id);
        modelBuilder.Entity<Lecture>()
        .HasKey(a => a.Id);
        modelBuilder.Entity<Staff>()
       .HasKey(a => a.Id);
        modelBuilder.Entity<ApplicantEnrollment>()
        .HasKey(p => p.Id);
        modelBuilder.Entity<Assessment>()
        .HasKey(p => p.Id);
        modelBuilder.Entity<Course>()
        .HasKey(p => p.Id);
        modelBuilder.Entity<Student>()
        .HasKey(p => p.Id);

    }
}
