using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polizia
{
    public class DBManager : IManager
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ProvaAgenti;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
       
        public bool Add(Agente item)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "insert into dbo.Agente values(@nome, @cognome, @codiceFiscale, @areaGeografica, @annoInizio)";
                command.Parameters.AddWithValue("@nome", item.Nome);
                command.Parameters.AddWithValue("@cognome", item.Cognome);
                command.Parameters.AddWithValue("@codiceFiscale", item.CodiceFiscale);
                command.Parameters.AddWithValue("@areaGeografica", item.AreaGeografica);
                command.Parameters.AddWithValue("@annoInizio", item.AnnoInizio);

                int numRighe = command.ExecuteNonQuery();
                if (numRighe == 1)
                {
                    connection.Close();
                    return true;
                }
                connection.Close();
                return false;
            }
        }

        public List<Agente> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from dbo.Agente";

                SqlDataReader reader = command.ExecuteReader();

                List<Agente> agenti = new List<Agente>();

                while (reader.Read())
                {
                    string Nome = (string)reader["Nome"];
                    string Cognome = (string)reader["Cognome"];
                    string CodiceFiscale = (string)reader["CodiceFiscale"];
                    string AreaGeografica = (string)reader["AreaGeografica"];
                    int AnnoInizio = (int)reader["AnnoInizio"];

                    Agente ag = new Agente(Nome, Cognome, CodiceFiscale, AreaGeografica, AnnoInizio);
                    agenti.Add(ag);
                }
                connection.Close();

                return agenti;
            }
        }

       

        public List<Agente> GetByAnniServizio(int anniServizio)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from Agente where ((DATEPART(YEAR,SYSDATETIME())-AnnoInizio)>=@anniServizio)";
                command.Parameters.AddWithValue("@AnniServizio", anniServizio);

                SqlDataReader reader = command.ExecuteReader();
                List<Agente> agentiArea = new List<Agente>();
                Agente agente = null;

                while (reader.Read())
                {
                    string nome = (string)reader["Nome"];
                    string cognome = (string)reader["Cognome"];
                    string codiceFiscale = (string)reader["CodiceFiscale"];
                    string areaGeogr = (string)reader["AreaGeografica"];
                    int annoInizio = (int)reader["AnnoInizio"];

                    agente = new Agente(nome, cognome, codiceFiscale, areaGeogr, annoInizio);
                    agentiArea.Add(agente);
                }
                connection.Close();
                return agentiArea;
            }
        }

        public List<Agente> GetByAreaGeografica(string areaGeografica)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from Agente where AreaGeografica = @AreaGeografica";
                command.Parameters.AddWithValue("@AreaGeografica", areaGeografica);

                SqlDataReader reader = command.ExecuteReader();
                List<Agente> agentiArea = new List<Agente>();
                Agente agente = null;

                while (reader.Read())
                {
                    string nome = (string)reader["Nome"];
                    string cognome = (string)reader["Cognome"];
                    string codiceFiscale = (string)reader["CodiceFiscale"];
                    string areaGeogr = (string)reader["AreaGeografica"];
                    int annoInizio = (int)reader["AnnoInizio"];

                    agente = new Agente(nome,cognome,codiceFiscale,areaGeogr,annoInizio);
                    agentiArea.Add(agente);
                }
                connection.Close();
                return agentiArea;
            }
        }

        public Agente GetByCodiceFiscale(string codiceFiscale)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from Agente where CodiceFiscale = @codiceFiscale";
                command.Parameters.AddWithValue("@codiceFiscale", codiceFiscale);

                SqlDataReader reader = command.ExecuteReader();

                Agente agente = null;

                while (reader.Read())
                {
                    string nome = (string)reader["Nome"];
                    string cognome = (string)reader["Cognome"];
                    string codiFiscale = (string)reader["CodiceFiscale"];
                    string areaGeogr = (string)reader["AreaGeografica"];
                    int annoInizio = (int)reader["AnnoInizio"];

                    agente = new Agente(nome,cognome,codiFiscale,areaGeogr,annoInizio);
                }
                connection.Close();
                return agente;
            }
        }
    }
}

