
using Domain.Aggreagtes.ApplicantAggregate;
using Domain.Aggreagtes.StudentAggregate;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Context;

public class ApplicationContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Applicant> Applicants { get; set; }
}
