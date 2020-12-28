
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testTreeConsole.Dao
{
    public class ConnexionBase: Singleton<ConnexionBase>
    {
        public Test test { get; set;  }
        public List<Test> tests { get; set; }

        public int total { get; set; }

        public Synthese synthese { get; set; }
        public List<Synthese> syntheses { get; set; }
        private MySqlConnection connexion;
        public  void TestConnection()
        {
            try
            {
                string connectionString = "SERVER=localhost ; DATABASE=test_bd; UID=root; PASSWORD=";
                this.connexion = new MySqlConnection(connectionString);
                if(this.connexion == null)
                {
                    Console.WriteLine("impossible de se connecter");
                }
                Console.WriteLine("la connexion à la base de donnée a réussi !! " );
                Console.WriteLine("détails de la connexion: " + connectionString);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void AddTest(Test test)
        {
            try
            {
                this.connexion.Open();
                MySqlCommand cmd = this.connexion.CreateCommand();
                cmd.CommandText = "INSERT INTO test(categorie) VALUES(@categorie)";
                cmd.Parameters.AddWithValue("@categorie", test.Categorie);
                cmd.ExecuteNonQuery();

                this.connexion.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public List<Synthese> GetSynthese()
        {
            syntheses = new List<Synthese>();
            this.connexion.Open();
            string query = "SELECT categorie, COUNT(categorie) AS nombre, (SELECT  COUNT(*) FROM test) as total FROM test GROUP BY categorie";
            MySqlCommand cmd = new MySqlCommand(query, this.connexion);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                synthese = new Synthese()
                {
                    Categorie = reader.GetString(0),
                    Nombre = reader.GetInt32(1),
                    Pourcentage = (reader.GetInt32(1) * 100 / reader.GetInt32(2))
                };
                syntheses.Add(synthese);
            }

            reader.Close();
            this.connexion.Close();

            return syntheses;
        }
    }
  
}
