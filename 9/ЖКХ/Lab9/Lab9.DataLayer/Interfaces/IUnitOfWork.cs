using Lab9.DataLayer.Entities;
using System;

namespace Lab9.DataLayer.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Work> Works { get; }
        IRepository<Worker> Workers { get; }
        void Save();
    }
}

