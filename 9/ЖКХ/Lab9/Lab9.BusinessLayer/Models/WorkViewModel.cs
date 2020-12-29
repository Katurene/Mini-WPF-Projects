using System;
using System.Collections.ObjectModel;

namespace Lab9.BusinessLayer.Models
{
    public class WorkViewModel
    {
        public int WorkId { get; set; }
        public string TypeOfWork { get; set; }
        public DateTime Begin { get; set; } // дата начала
        public decimal Estimate { get; set; } // смета
        public ObservableCollection<WorkerViewModel> Workers { get; set; }
    }
}

