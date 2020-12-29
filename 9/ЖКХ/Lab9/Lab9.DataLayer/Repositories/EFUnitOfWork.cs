using Lab9.DataLayer.EFContext;
using Lab9.DataLayer.Entities;
using Lab9.DataLayer.Interfaces;
using System;

namespace Lab9.DataLayer.Repositories
{
    public class EntityUnitOfWork : IUnitOfWork
    {
        CoursesContext context;
        WorksRepository worksRepository;
        WorkersRepository workersRepository;

        public EntityUnitOfWork(string name)
        {
            context = new CoursesContext(name);
        }

        public IRepository<Work> Works
        {
            get
            {
                if (worksRepository == null)
                    worksRepository = new WorksRepository(context);
                return worksRepository;
            }
        }

        public IRepository<Worker> Workers
        {
            get
            {
                if (workersRepository == null)
                    workersRepository =
                    new WorkersRepository(context);
                return workersRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

