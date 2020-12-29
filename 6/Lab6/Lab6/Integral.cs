using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    public class Integral : IDataErrorInfo//наследует интерфейс IDataErrorInfo-чтобы добавить свою логику обработки ошибок
    {
        double a, b;//границы интегрирования
        int n;//количество точек разбиения

        public Integral()
        {
        }

        public Integral(double a, double b, int n)
        {
            A = a;
            B = b;
            N = n;
        }

        public double A { get => a; set => a = value; }
        public double B { get => b; set => b = value; }
        public int N { get => n; set => n = value; }

        public string this[string columnName]//валидация данных в полях columnName
        {
            get
            {
                string error = String.Empty;//изначально пустой - ошибки нет
                switch (columnName)
                {
                    case "A":
                        if (A < 0 || A > 1)
                        {
                            error = "Начало диапазона должно быть [0;1]";
                        }
                        break;
                    case "B":
                        if (B < 0 || B > 10)
                        {
                            error = "Конец диапазона должен быть [0;10]";
                        }
                        break;
                    case "N":
                        if (N < 100)
                        {
                            error = "К-во точек разбиения должно быть >= 100";
                        }
                        break;
                }
                return error;
            }
        }

        public string Error//спец метод Error кот делает выброс исключения
        {
            get { throw new NotImplementedException(); }
        }
    }
}
