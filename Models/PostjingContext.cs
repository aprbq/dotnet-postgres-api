using Microsoft.EntityFrameworkCore;

namespace postjing.Models
{
    public class PostjingContext : DbContext
    {
        public PostjingContext(DbContextOptions<PostjingContext> options) : base(options)
        {
        }

        public DbSet<Pokemon> Pokemon { get; set; }
    }
}
