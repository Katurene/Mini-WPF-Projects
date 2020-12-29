using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab9.DataLayer.EFContext;
using Lab9.DataLayer.Entities;
using Lab9.DataLayer.Interfaces;

namespace Lab9.DataLayer.Repositories
{
    public class EntityUnitOfWork : IUnitOfWork
    {
        CoursesContext context;
        GroupsRepository groupsRepository;
        StudentRepository studentsRepository;

        public EntityUnitOfWork(string name)
        {
            context = new CoursesContext(name);//создается сам контекст
        }

        public IRepository<Group> Groups
        {
            get
            {                   //возвращает контекст для работы с группой
                if (groupsRepository == null)
                    groupsRepository = new GroupsRepository(context);
                return groupsRepository;
            }
        }

        public IRepository<Student> Students
        {
            get
            {                 //возвращает контекст для работы со студентами
                if (studentsRepository == null)
                    studentsRepository =
                    new StudentRepository(context);
                return studentsRepository;
            }
        }//эти контексты будут одинаковыми но если проект большой и работает с разными БД то контекст может быть разным

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;
                                                //реализовано высвобождение ресурсов
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
