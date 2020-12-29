using Lab9.DataLayer.Entities;
using System.Data.Entity;

namespace Lab9.DataLayer.EFContext
{
    class CoursesContext : DbContext
    {
        public CoursesContext(string name) : base(name)
        {
            Database.SetInitializer(new CoursesInitializer());
        }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Work> Works { get; set; }
    }
}

