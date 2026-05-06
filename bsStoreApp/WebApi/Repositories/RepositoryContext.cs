using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using WebApi.Models;

namespace WebApi.Repositories
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Book> Books { get; set; }
    }
}
                       