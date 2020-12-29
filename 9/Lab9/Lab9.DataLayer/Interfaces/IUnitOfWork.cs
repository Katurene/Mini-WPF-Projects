using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab9.DataLayer.Entities;

namespace Lab9.DataLayer.Interfaces
{
    public interface IUnitOfWork : IDisposable//для отслеживания подключений к БД. Следит чтобы DbContext был один
    {                             //IDisposable - для высвобождения ресурсов Отрубает неиспользуемые подключения к БД
        IRepository<Group> Groups { get; }   //get- тк будет получать контекст для работы с группой 
        IRepository<Student> Students { get; }//и студентом
        void Save();
    }
}
