using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8.Models
{//DataBaseInitializer - отдельный класс кот вынесен отдельно и кот сразу инициализирует БД 
    //До его создания VS не запускать!!!!
    class DataBaseInitializer : DropCreateDatabaseIfModelChanges<EntityContext>
    //DropCreateDatabaseIfModelChanges<EntityContext> станд класс энтити. Должен быть параметризован EntityContext
    {
        protected override void Seed(EntityContext context)//метод инициализирующий базу
        {
            context.Students.AddRange(new Student[] {
                new Student { FullName="John Smith", Age=23, Payment=234, GroupId=2 },//StudentId не задаем, тк
                new Student { FullName="Uncle Benz", Age=80, Payment=231, GroupId=2 },//он присв автоматически
                new Student { FullName="Papa Johns", Age=36, Payment=532, GroupId=1 },
            });
        }
    }
}
