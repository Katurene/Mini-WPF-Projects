using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab9.DataLayer.Entities;

namespace Lab9.DataLayer.EFContext
{
    class CoursesInitializer : CreateDatabaseIfNotExists<CoursesContext>//инициализатор БД
    {
        protected override void Seed(CoursesContext context)//метод для засевания БД исходными значениями
        {
            context.Groups.AddRange(new Group[] {               //две группы с данными
                new Group { BasePrice=100, Commence=new DateTime(2017, 01, 20),
                            CourseName ="Знакомство с Adobe Photoshop",
                            Students =new List<Student>{
                                new Student { IndividualPrice=100,
                                    DateOfBirth =new DateTime (1978, 10,23),
                                    FullName="Никита Хрущев", FileName="1.jpg" },
                                new Student { IndividualPrice=100,
                                    DateOfBirth =new DateTime (1981, 03,05),
                                    FullName ="Дарт Вэйдер", FileName="2.jpg" }
                            }
                },
                new Group { BasePrice=150, Commence=new DateTime(2017, 02, 11),
                            CourseName ="Вязание крючком",
                    Students =new List<Student>{
                                new Student { IndividualPrice=120,
                                    DateOfBirth =new DateTime (1991, 06,14),
                                    FullName ="Иван Драго", FileName="3.jpg" },
                                new Student { IndividualPrice=150,
                                    DateOfBirth =new DateTime (1989, 12,06),
                                    FullName ="Геракл Зевсович", FileName="4.jpg" },
                                new Student { IndividualPrice=150,
                                    DateOfBirth =new DateTime (1985, 09,11),
                                    FullName ="Мерлин Мэнсон", FileName="5.jpg" }
                    }
                }
            });
            context.SaveChanges();
        }
    }
}
