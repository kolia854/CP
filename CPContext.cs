using System.Data.Entity;

namespace CourseProject
{
    class CPContext : DbContext
    {
        public CPContext()
            : base("DbConnection")
        {}

        public DbSet<DBComp> Competitions { get; set; }
        public DbSet<DBDistance> Distances { get; set; }
        public DbSet<DBSportsman> Sportsmen { get; set; }

    }
}
