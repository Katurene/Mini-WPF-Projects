using System;

namespace Lab9.DataLayer.Entities
{
    public class Worker
    {
        public int WorkerId { get; set; }      //ключ
        public string FullName { get; set; }   //фио рабочего ЖЭСа
        public DateTime DateOfBirth { get; set; }  //дата рождения
        public string Position { get; set; } //должность   НОВОЕ!!!
        public decimal Salary { get; set; }  //оплата  IndividualPrice
        public string FileName { get; set; } // имя файла с фото

        // Навигационные свойства
        public int WorkId { get; set; }   // ключ 
        public Work Work { get; set; } // название работы по благоустройству Group
    }
}

