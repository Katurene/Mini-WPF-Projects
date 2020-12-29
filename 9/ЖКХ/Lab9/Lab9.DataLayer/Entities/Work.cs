using System;
using System.Collections.Generic;

namespace Lab9.DataLayer.Entities
{
    public class Work
    {
        public Work()
        {
            Workers = new List<Worker>();
        }
        public int WorkId { get; set; }   // ключ
        public string TypeOfWork { get; set; }  // наименование работы
        public DateTime Begin { get; set; } // дата начала Commence
        public decimal Estimate { get; set; } // смета стоимость BasePrice

        // навигационное свойство
        public List<Worker> Workers { get; set; }
    }
}

