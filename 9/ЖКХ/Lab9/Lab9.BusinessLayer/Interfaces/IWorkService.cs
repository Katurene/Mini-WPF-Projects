using Lab9.BusinessLayer.Models;
using System.Collections.ObjectModel;

namespace Lab9.BusinessLayer.Interfaces
{
    public interface IWorkService
    {
        ObservableCollection<WorkViewModel> GetAll();
        WorkViewModel Get(int id);
        void AddWorkerToWork(int workId, WorkerViewModel worker);
        void RemoveWorkerFromWork(int workId, int workerId);
        void CreateWork(WorkViewModel work);
        void DeleteWork(int workId);
        void UpdateWork(WorkViewModel work);
        void UpdateWorker(WorkerViewModel workerViewModel);
    }
}

