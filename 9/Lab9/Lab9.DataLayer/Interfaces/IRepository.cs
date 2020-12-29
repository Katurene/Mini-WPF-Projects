using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9.DataLayer.Interfaces
{//интерфейс нужен чтобы не забыть реализовать в классе все перечисленные методы
    public interface IRepository<T>//интерфейс неизвестно от какого типа, т.е. дженерик Параметризованный 
    {                              //будет работать с любым классом
        IEnumerable<T> GetAll();//возвращает всю коллекцию
        T Get(int id);//возвр по идентификатору
        IEnumerable<T> Find(Func<T, bool> predicate);
        void Create(T t);
        void Update(T t);
        void Delete(int id);
    }
}
