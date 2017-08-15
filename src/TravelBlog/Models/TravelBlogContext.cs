using Microsoft.EntityFrameworkCore;


namespace TravelBlog.Models
{
    public class TravelBlogContext : DbContext
    {

        public TravelBlogContext()
        {
        }
        public virtual DbSet<Experience> Experiences { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Person> People { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=DESKTOP-6CVACGR\SQLEXPRESS;Database=TravelBlog;integrated security=True");
        }
        public TravelBlogContext(DbContextOptions<TravelBlogContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
 