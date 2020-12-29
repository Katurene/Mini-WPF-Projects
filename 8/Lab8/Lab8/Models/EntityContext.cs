using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8.Models
{
    //Для взаимодействия с базой данных через Entity Framework нужен контекст данных, поэтому добавим в 
    //папку Models еще один класс EntityContext кот будет наследником DbContext(в имени принято добавл слово Context).
    //DbContext - стандартный класс платформы Entity Framework и все его наследники могут потом связываться 
    //при его помощи с соответствующими таблицами

    class EntityContext : DbContext
    {
        public EntityContext() : base("DefaultConnection")//конструктор присоединяется к БД
        {                                                 //DefaultConnection-имя строки подключения
            Database.SetInitializer(new DataBaseInitializer());//для срабатывания DataBaseInitializer и 
            //автозаполнения БД начальными значениями в конструкторе укажем необходимость вызова инициализатора
        }
        public DbSet<Student> Students { get; set; }//свойство кот позволит нам получить данные для заполнения грида
    }
}
