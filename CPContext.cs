using System.Data.Entity;

namespace CourseProject
{
    class CPContext : DbContext
    {
        public CPContext()
            : base("DbConnection")
        { }

        public DbSet<Comp> Competitions { get; set; }
        public DbSet<Sportsman> Sportsmen { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
