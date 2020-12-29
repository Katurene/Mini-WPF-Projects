using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9.BusinessLayer.Models
{
    public class StudentViewModel//класс похож на класс студента но добавлена бизнес логика
    {                            //здесь нет полей для связи с группой 
        public int StudentId { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal IndividualPrice { get; set; }
        public string FileName { get; set; }
        public bool HasDiscount { get; set; }
    }
}
