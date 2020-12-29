using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9.DataLayer.Entities
{
    public class Group
    {
        public Group()
        {
            Students = new List<Student>();//ссылка на список студентов
        }
        public int GroupId { get; set; }            // ключ
        public string CourseName { get; set; }      // название курса
        public DateTime Commence { get; set; }      // дата начала курса
        public decimal BasePrice { get; set; }      // стоимость

        // навигационное свойство
        public List<Student> Students { get; set; }//ссылка на весь список студентов, будет сюда передоваться готовый
    }
}
