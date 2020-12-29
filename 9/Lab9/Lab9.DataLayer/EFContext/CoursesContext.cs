using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab9.DataLayer.Entities;

namespace Lab9.DataLayer.EFContext
{
    class CoursesContext : DbContext //Context спец класс для связки с БД
    {
        public CoursesContext(string name) : base(name)
        {
            Database.SetInitializer(new CoursesInitializer());//засевание БД
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }
    }
}
