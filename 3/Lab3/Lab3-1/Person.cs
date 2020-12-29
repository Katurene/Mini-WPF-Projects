using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Lab3_1
{
    class Person: IDataErrorInfo//спец интерфейс для обработки Error
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public string this[string columnName]//индексатор-позв получ по индексу значение
        {                               //columnName-имя поля
            get
            {
                string error = String.Empty;
                switch (columnName)
                {
                    case "Age":
                        if ((Age < 0) || (Age > 100))
                        {
                            error = "Возраст должен быть больше 0 и меньше 100";
                        }
                        break;
                    case "Name":
                        //Обработка ошибок для свойства Name
                        break;

                }
                return error;
            }
        }
        public string Error
        {
            get { throw new NotImplementedException(); }
        }

    }
}
