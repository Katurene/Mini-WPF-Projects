using System;

namespace Lab9.BusinessLayer.Models
{
    public class WorkerViewModel
    {
        public int WorkerId { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Position { get; set; } //должность
        public decimal Salary { get; set; }
        public string FileName { get; set; }
        public bool HasAward { get; set; } //получает премию
    }
}

