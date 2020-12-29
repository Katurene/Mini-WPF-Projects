using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    public class Payer
    {
        static SqlConnection connection;

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Hol { get; set; }
        public decimal Gor { get; set; }

        public static void newConnection()
        {
            var connString = ConfigurationManager
            .ConnectionStrings["DefaultConnection"]
            .ConnectionString;
            connection = new SqlConnection(connString);
        }

        public static IEnumerable<Payer> GetAllPayers()
        {
            newConnection();
            connection.Open();
            var commandString = "SELECT Id, Name, Hol, Gor FROM Payer";
            SqlCommand getAllCommand = new SqlCommand(commandString, connection);

            var reader = getAllCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var id = reader.GetInt32(0);
                    var name = reader.GetString(1);
                    var hol = reader.GetDecimal(2);
                    var gor = reader.GetDecimal(3);
                    var payer = new Payer
                    {
                        Id = id,
                        Name = name,
                        Hol = hol,
                        Gor = gor
                    };
                    yield return payer;
                }
            };
            connection.Close();
        }

        public void Insert()
        {
            newConnection();
            connection.Open();
            var commandString = "INSERT INTO Payer (Name, Hol, Gor) VALUES (@name, @hol, @gor)";
            SqlCommand insertCommand = new SqlCommand(commandString, connection);
            insertCommand.Parameters.AddRange(new SqlParameter[] {
                                      new SqlParameter("name", Name),
                                      new SqlParameter("hol", Hol),
                                      new SqlParameter("gor", Gor),});
            insertCommand.ExecuteNonQuery();
            connection.Close();
        }

        public static void Delete(int id)
        {
            newConnection();
            connection.Open();
            var commandString = "DELETE FROM Payer WHERE(Id=@id)";
            SqlCommand deleteCommand = new SqlCommand(commandString, connection);
            deleteCommand.Parameters.AddWithValue("id", id);
            deleteCommand.ExecuteNonQuery();
            connection.Close();
        }

        public static Payer Find(string name)
        {
            foreach (var payer in GetAllPayers())
            {
                if (payer.Name == name)
                    return payer;
            }
            return null;
        }

        public void Update()
        {
            newConnection();
            connection.Open();
            var commandString = "UPDATE Payer SET Name=@name, Hol=@hol, Gor=@gor WHERE(Id=@id)";
            SqlCommand updateCommand = new SqlCommand(commandString, connection);
            updateCommand.Parameters.AddRange(new SqlParameter[] {
                             new SqlParameter("name", Name),
                             new SqlParameter("hol", Hol),
                             new SqlParameter("gor", Gor),
                             new SqlParameter("id", Id),});
            updateCommand.ExecuteNonQuery();
            connection.Close();
        }
        
        public override string ToString()
        {
            return $"№ {Id} Плательщик: {Name}, Показания счетчика: хол.: {Hol:0.00} гор.: {Gor:0.00}";
        }

    }
}
