using System.Data.Entity;

namespace Lab8.Models
{
    class EntityContext : DbContext
    {
        public EntityContext() : base("DefaultConnection")
        {
            Database.SetInitializer(new DataBaseInitializer());
        }
        public DbSet<Payer> Payers { get; set; }
    }
}
