using Lab9.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Lab9.DataLayer.EFContext
{
    class CoursesInitializer : CreateDatabaseIfNotExists<CoursesContext>
    {
        protected override void Seed(CoursesContext context)
        {
            context.Works.AddRange(new Work[] {
                new Work { Estimate=1000, Begin = new DateTime(2020, 09, 20),
                            TypeOfWork ="Ремонт скамеек",
                            Workers = new List<Worker>{
                                new Worker { Salary=200,
                                    DateOfBirth = new DateTime (1978, 10,23),
                                    Position = "плотник",
                                    FullName="Петров Сергей", FileName="1.jpg" },
                                new Worker { Salary=150,
                                    DateOfBirth = new DateTime (1981, 03,05),
                                    Position = "столяр",
                                    FullName ="Иванов Андрей", FileName="2.jpg" }
                            }
                },
                new Work { Estimate=780, Begin = new DateTime(2020, 08, 20),
                            TypeOfWork ="Покраска перил",
                    Workers =new List<Worker>{
                                new Worker { Salary=120,
                                    DateOfBirth =new DateTime (1991, 06,14),
                                    Position = "маляр",
                                    FullName ="Ларина Ольга", FileName="3.jpg" },
                                new Worker { Salary=150,
                                    DateOfBirth =new DateTime (1989, 12,06),
                                    Position = "маляр",
                                    FullName ="Васильев Евгений", FileName="4.jpg" },
                                new Worker { Salary=150,
                                    DateOfBirth =new DateTime (1985, 09,11),
                                    Position = "маляр",
                                    FullName ="Сидоров Олег", FileName="5.jpg" }
                    }
                }
            });
            context.SaveChanges();
        }
    }
}

