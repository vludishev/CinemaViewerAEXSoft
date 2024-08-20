using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CV.Infrastructure.Persistence
{
    public interface IApplicationDbContext
    {
        DbSet<TodoList> TodoLists { get; }

        DbSet<TodoItem> TodoItems { get; }
    }

    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {

        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options
            )
            : base(options)
        {

        }

        //public DbSet<TodoList> TodoLists => Set<TodoList>();

        //public DbSet<TodoItem> TodoItems => Set<TodoItem>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
