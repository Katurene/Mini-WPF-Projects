using AutoMapper;
using Lab9.BusinessLayer.Interfaces;
using Lab9.BusinessLayer.Models;
using Lab9.DataLayer.Entities;
using Lab9.DataLayer.Interfaces;
using Lab9.DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Lab9.BusinessLayer.Services
{
    public class WorkService : IWorkService
    {
        IUnitOfWork dataBase;

        public WorkService(string name)
        {
            dataBase = new EntityUnitOfWork(name);
        }

        public void AddWorkerToWork(int workId, WorkerViewModel workerViewModel)
        {
            var work = dataBase.Works.Get(workId);
            
            var config = new MapperConfiguration(cfg => cfg.CreateMap<WorkerViewModel, Worker>());
            var mapper = new Mapper(config);
            
            var worker = mapper.Map<WorkerViewModel, Worker>(workerViewModel);
       
            worker.Salary = workerViewModel.HasAward == true
                                    ? work.Estimate * (decimal)1.8
                                    : work.Estimate;
           
            work.Workers.Add(worker);           
            dataBase.Save();
        }

        public void CreateWork(WorkViewModel workvm)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<WorkViewModel, Work>());
            var mapper = new Mapper(config);
            Work work = mapper.Map<WorkViewModel, Work>(workvm);
            dataBase.Works.Create(work);
            dataBase.Save();
        }

        public void DeleteWork(int workId)
        {
            dataBase.Works.Delete(workId);
            dataBase.Save();
        }

        public WorkViewModel Get(int id)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<WorkViewModel> GetAll()
        { 
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Worker, WorkerViewModel>();
                cfg.CreateMap<Work, WorkViewModel>();
            });
            var mapper = new Mapper(config);         
            var works = mapper.Map<IEnumerable<Work>, ObservableCollection<WorkViewModel>>(dataBase.Works.GetAll());
            return works;
        }

        public void RemoveWorkerFromWork(int workId, int workerId)
        {
            dataBase.Workers.Delete(workerId);
            dataBase.Save();
        }

        public void UpdateWork(WorkViewModel workvm)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<WorkerViewModel, Worker>();
                cfg.CreateMap<WorkViewModel, Work>();
            });
            var mapper = new Mapper(config);
            Work work = mapper.Map<WorkViewModel, Work>(workvm);
            dataBase.Works.Update(work);
            dataBase.Save();
        }

        public void UpdateWorker(WorkerViewModel workerViewModel)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<WorkerViewModel, Worker>();
            });
            var mapper = new Mapper(config);
            Worker worker = mapper.Map<WorkerViewModel, Worker>(workerViewModel);
            dataBase.Workers.Update(worker);
            dataBase.Save();
        }
    }
}

