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
{
    class GroupsRepository : IRepository<Group>//работает с группами Все также как и в студенте
    {//Если в классе репозитория не реализовать к-л метод описанный в интерфейсе то будет выдана ошибка
        CoursesContext context;

        public GroupsRepository(CoursesContext context)
        {
            this.context = context;
        }

        public void Create(Group t)
        {
            context.Groups.Add(t);
        }

        public void Delete(int id)
        {
            var group = context.Groups.Find(id);
            context.Groups.Remove(group);
        }

        public IEnumerable<Group> Find(Func<Group, bool> predicate)
        {
            return context
            .Groups
            .Include(g => g.Students)//отличие предиката - Группа включает студентов
            .Where(predicate)
            .ToList();
        }

        public Group Get(int id)
        {
            return context.Groups.Find(id);
        }

        public IEnumerable<Group> GetAll()//если извлекаем группы то извлекаются и все студенты кот там лежат
        {
            return context.Groups.Include(g => g.Students);
        }

        public void Update(Group t)
        {
            // context.Entry(t).State = EntityState.Modified;
            var group = context.Groups.Find(t.GroupId);
            group.BasePrice = t.BasePrice;
            group.CourseName = t.CourseName;
            group.Commence = t.Commence;
        }
    }
}
