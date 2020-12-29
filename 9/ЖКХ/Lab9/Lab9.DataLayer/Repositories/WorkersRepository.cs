using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Lab9.DataLayer.EFContext;
using Lab9.DataLayer.Entities;
using Lab9.DataLayer.Interfaces;

namespace Lab9.DataLayer.Repositories
{
    class WorkersRepository : IRepository<Worker>
    {
        CoursesContext context;

        public WorkersRepository(CoursesContext context)
        {
            this.context = context;
        }

        public void Create(Worker t)
        {
            context.Workers.Add(t);
        }

        public void Delete(int id)
        {
            var worker = context.Workers.Find(id);
            context.Workers.Remove(worker);
        }

        public IEnumerable<Worker> Find(Func<Worker, bool> predicate)
        {
            return context.Workers
                          .Where(predicate)
                          .ToList();
        }

        public Worker Get(int id)
        {
            return context.Workers.Find(id);
        }

        public IEnumerable<Worker> GetAll()
        {
            return context.Workers;
        }

        public void Update(Worker t)
        {
            var worker = context.Workers.Find(t.WorkerId);
            worker.FullName = t.FullName;
            worker.DateOfBirth = t.DateOfBirth;
            worker.Position = t.Position; 
            worker.Salary = t.Salary;
            worker.FileName = t.FileName;            
        }
    }
}

