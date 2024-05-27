
using Domain.Aggreagtes.StudentAggregate;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public class ApplicationContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Student>  Students { get; set; }
}
