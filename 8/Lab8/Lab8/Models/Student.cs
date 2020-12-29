using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8.Models
{
    public class Student
    {//по соглашению, принятому в Entity Framework свойство,название которого включает имя класса с 
     //добавлением id(до или после) или просто называется id, будет преобразовано в ключевое поле таблицы БД
        public int StudentId { get; set; } //имя класса Student + Id (StudentId или IdStudent) 
                                          //среда вычленит поле с этим названием(Id) и сделает его главным

        public String FullName { get; set; }

        public int Age { get; set; }

        public decimal Payment { get; set; }

        public int GroupId { get; set; }
    }
}
