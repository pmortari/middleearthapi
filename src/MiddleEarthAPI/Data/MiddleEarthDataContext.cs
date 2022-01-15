using Microsoft.EntityFrameworkCore;

namespace MiddleEarthAPI.Data
{
    public class MiddleEarthDataContext : DbContext
    {
        public MiddleEarthDataContext(DbContextOptions<MiddleEarthDataContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Book> Book { get; set; }

        public DbSet<Models.BookChapter> BookChapter { get; set; }

        public DbSet<Models.BookAuthor> BookAuthor { get; set; }

        public DbSet<Models.Character> Character { get; set; }

        public DbSet<Models.Movie> Movie { get; set; }

        public DbSet<Models.Publisher> Publisher { get; set; }

        public DbSet<Models.Author> Author { get; set; }

        public DbSet<Models.Role> Role { get; set; }
    }
}