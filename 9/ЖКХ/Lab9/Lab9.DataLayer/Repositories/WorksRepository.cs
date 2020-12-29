using Lab9.DataLayer.EFContext;
using Lab9.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Lab9.DataLayer.Interfaces;

namespace Lab9.DataLayer.Repositories
{
    class WorksRepository : IRepository<Work>
    {
        CoursesContext context;

        public WorksRepository(CoursesContext context)
        {
            this.context = context;
        }

        public void Create(Work t)
        {
            context.Works.Add(t);
        }

        public void Delete(int id)
        {
            var work = context.Works.Find(id);
            context.Works.Remove(work);
        }

        public IEnumerable<Work> Find(Func<Work, bool> predicate)
        {
            return context
            .Works
            .Include(g => g.Workers)
            .Where(predicate)
            .ToList();
        }

        public Work Get(int id)
        {
            return context.Works.Find(id);
        }

        public IEnumerable<Work> GetAll()
        {
            return context.Works.Include(g => g.Workers);
        }

        public void Update(Work t)
        {
            var work = context.Works.Find(t.WorkId);
            work.Estimate = t.Estimate;
            work.TypeOfWork = t.TypeOfWork;
            work.Begin = t.Begin;
        }
    }
}

