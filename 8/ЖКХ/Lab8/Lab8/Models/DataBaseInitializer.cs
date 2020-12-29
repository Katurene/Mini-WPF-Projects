using System.Data.Entity;

namespace Lab8.Models
{
    class DataBaseInitializer : DropCreateDatabaseIfModelChanges<EntityContext>
    {
        protected override void Seed(EntityContext context)
        {
            context.Payers.AddRange(new Payer[] {
                new Payer { FullName="Иванов Павел Сергеевич", Street="Пушкина", House=23, Flat=11, Payment=300 },
                new Payer { FullName="Ветров Евгений Петрович", Street="Притыцкого", House=56, Flat=19, Payment=500 },
                new Payer { FullName="Ларина Елена Викторовна", Street="Пушкина", House=44, Flat=8, Payment=250 },
            });
        }
    }
}
