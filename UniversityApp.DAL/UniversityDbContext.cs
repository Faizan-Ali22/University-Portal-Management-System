using Microsoft.EntityFrameworkCore;
using UniversityApp.Entities;
using UniversityApp.Entities.Models;

namespace UniversityApp.DAL;

public class UniversityDbContext : DbContext
{
    public UniversityDbContext(DbContextOptions<UniversityDbContext> options) : base(options) { }

    public DbSet<Student> Students => Set<Student>();
    public DbSet<Course> Courses => Set<Course>();
    public DbSet<Faculty> Faculties => Set<Faculty>();
    public DbSet<Department> Departments => Set<Department>();
    public DbSet<Enrollment> Enrollments => Set<Enrollment>();
    public DbSet<Attendance> Attendances => Set<Attendance>();
    public DbSet<Exam> Exams => Set<Exam>();
    public DbSet<Grade> Grades => Set<Grade>();
    public DbSet<Announcement> Announcements => Set<Announcement>();
    public DbSet<Timetable> Timetables => Set<Timetable>();
    public DbSet<AppUser> AppUsers => Set<AppUser>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure relationships
        modelBuilder.Entity<Enrollment>()
            .HasOne(e => e.Student).WithMany(s => s.Enrollments).HasForeignKey(e => e.StudentId).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<Enrollment>()
            .HasOne(e => e.Course).WithMany(c => c.Enrollments).HasForeignKey(e => e.CourseId).OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Attendance>()
            .HasOne(a => a.Student).WithMany(s => s.Attendances).HasForeignKey(a => a.StudentId).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<Attendance>()
            .HasOne(a => a.Course).WithMany(c => c.Attendances).HasForeignKey(a => a.CourseId).OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Grade>()
            .HasOne(g => g.Student).WithMany(s => s.Grades).HasForeignKey(g => g.StudentId).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<Grade>()
            .HasOne(g => g.Exam).WithMany(e => e.Grades).HasForeignKey(g => g.ExamId).OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Course>()
            .HasOne(c => c.Faculty).WithMany(f => f.Courses).HasForeignKey(c => c.FacultyId).OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<Exam>()
            .HasOne(e => e.Course).WithMany(c => c.Exams).HasForeignKey(e => e.CourseId).OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Timetable>()
            .HasOne(t => t.Course).WithMany(c => c.Timetables).HasForeignKey(t => t.CourseId).OnDelete(DeleteBehavior.Cascade);

        // Indexes
        modelBuilder.Entity<Student>().HasIndex(s => s.Email).IsUnique();
        modelBuilder.Entity<Course>().HasIndex(c => c.Code).IsUnique();
        modelBuilder.Entity<AppUser>().HasIndex(u => u.Email).IsUnique();
        modelBuilder.Entity<Department>().HasIndex(d => d.Code).IsUnique();
    }
}
