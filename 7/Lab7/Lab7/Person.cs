using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    public class Person//класс уровня модели
    {
        static SqlConnection connection;//Работа с БД осуществляется на уровне модели-person. static-виден всем
                                        //в этой ссылке хранится вся инф о подключении к БД
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Sum { get; set; }

        public static void newConnection()//метод для связи с БД при необходимости, тк постоянно связь с БД не держим
        {                                  //и связь потребуется вызывать много раз
            var connString = ConfigurationManager
            .ConnectionStrings["DefaultConnection"]//DefaultConnection-имя строки подключения
            .ConnectionString;//саму строку подключения кладем в файл конфигурации
            connection = new SqlConnection(connString);//тут созд подключение к БД 
        }

        public static IEnumerable<Person> GetAllPersons()//нумератор-позволяет получать записи по одной
        {
            newConnection();//настраиваем связь 
            connection.Open();//открываем подключение
            var commandString = "SELECT Id, Name, Sum FROM Person";//запрос к БД
            SqlCommand getAllCommand = new SqlCommand(commandString, connection);//выбираем из таблицы

            var reader = getAllCommand.ExecuteReader();//ридер позволяет сделать запрос который вернет результат
            if (reader.HasRows)//есть строки или нет
            {
                while (reader.Read())//если что то есть то проходим циклом по ридеру
                {
                    var id = reader.GetInt32(0);//и каждый раз заполняем переменные
                    var name = reader.GetString(1);
                    var sum = reader.GetDecimal(2);
                    var person = new Person//и создаем новую персону
                    {
                        Id = id,
                        Name = name,
                        Sum = sum
                    };
                    yield return person;//подает по одной персоне но считывает все
                }
            };
            connection.Close();//после каждого запроса соединение разрывается
        }

        public void Insert()//метод для записи текущего объекта(персон) в БД (чтобы не сразу по клику работал)
        {
            newConnection();
            connection.Open();
            var commandString = "INSERT INTO Person (Name, Sum) VALUES (@name, @sum)";
            SqlCommand insertCommand = new SqlCommand(commandString, connection);
            insertCommand.Parameters.AddRange(new SqlParameter[] {
                                      new SqlParameter("name", Name),
                                      new SqlParameter("sum", Sum),});
            insertCommand.ExecuteNonQuery();
            connection.Close();
        }

        //метод insert экземплярный,а delete статический тк когда мы удаляем то самого объекта нет, а есть  
        //только запись в бд(номер -(int id)),а когда вставляем то подаем объект и от него делаем инсерт
        public static void Delete(int id)//статический - вызываем от всего класса person
        {
            newConnection();
            connection.Open();
            var commandString = "DELETE FROM Person WHERE(Id=@id)";
            SqlCommand deleteCommand = new SqlCommand(commandString, connection);
            deleteCommand.Parameters.AddWithValue("id", id);//id подаем из main
            deleteCommand.ExecuteNonQuery();
            connection.Close();
        }

        //здесь метод нестатический, т.е объект должен содержать в себе всю информацию об обновлении и прежде всего-id
        public void Update()//обновляет имя и сумму по идентификатору,те выделяется определ запись и ей подается
        {                   //новое имя и сумма или что то одно
            newConnection();
            connection.Open();//устанавливается соединение с базой
            var commandString = "UPDATE Person SET Name=@name, Sum=@sum WHERE(Id=@id)";
            SqlCommand updateCommand = new SqlCommand(commandString, connection);
            updateCommand.Parameters.AddRange(new SqlParameter[] {//AddRange позволяет исп параметр через @(переменная 
                             new SqlParameter("name", Name),    //которую можно будет в это место подставить, 
                             new SqlParameter("sum", Sum),      //те подменить все параметры)
                             new SqlParameter("id", Id),});
            updateCommand.ExecuteNonQuery();//запуск запроса (ExecuteNonQuery-запрос без ответа)
            connection.Close();
        }

        //Будем искать запись по имени
        public static Person Find(string name)//получает имя и возвращает объект
        {
            foreach (var person in GetAllPersons())//если это имя найдено
            {                                //обращается к нумератору-проходит коллекцию используя готовый нумератор
                if (person.Name == name)//и сравнивает-если нашел имя 
                    return person;      //то вернет персону
            }
            return null;
        }

        public override string ToString()
        {
            return $"№ {Id} Имя: {Name}, Сумма: {Sum:0.000}";
        }

    }
}
