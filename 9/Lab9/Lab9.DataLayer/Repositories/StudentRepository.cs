using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab9.DataLayer.EFContext;
using Lab9.DataLayer.Entities;
using Lab9.DataLayer.Interfaces;

namespace Lab9.DataLayer.Repositories
{//Если в классе репозитория не реализовать к-л метод описанный в интерфейсе то будет выдана ошибка
    class StudentRepository : IRepository<Student>//работает со студентом
    {
        CoursesContext context;

        public StudentRepository(CoursesContext context)//CoursesContext-строка подключ к БД Приходит из App.config
        {
            this.context = context;
        }

        public void Create(Student t)
        {
            context.Students.Add(t);//создаем и добавляем студента
        }

        public void Delete(int id)
        {
            var student = context.Students.Find(id);
            context.Students.Remove(student);
        }

        public IEnumerable<Student> Find(Func<Student, bool> predicate)
        {
            return context.Students
                          .Where(predicate)//находим по предикату(к-л правило) делегат
                          .ToList();
        }

        public Student Get(int id)
        {
            return context.Students.Find(id);//получим по идентификатору
        }

        public IEnumerable<Student> GetAll()//получим всех студентов используя цикл foreach
        {
            return context.Students;
        }
        
        public void Update(Student t)
        {
            //context.Entry<Student>(t).State = EntityState.Modified;
            var student = context.Students.Find(t.StudentId);
            student.FullName = t.FullName;
            student.DateOfBirth = t.DateOfBirth;
            student.FileName = t.FileName;
            student.IndividualPrice = t.IndividualPrice;
        }
    }
}
