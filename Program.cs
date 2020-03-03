using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;

namespace learning
{

    class Program
    {

             static void Main(string[] args)
        {


            string connStr = "server=35.233.55.137;user=root;database=learning;password=qwerty_1;";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();



            string restart = null;
            do
            {
                Console.WriteLine("Enter text to database: ");
                string addstring;
                addstring = Console.ReadLine();

                string query = "INSERT INTO learning (content) VALUES ('" + addstring + "')";
                MySqlCommand dbInsert = new MySqlCommand(query, conn);
                dbInsert.ExecuteNonQuery();

                Console.Write("Add more? (Y/N) ");                          //от сих
                restart = Console.ReadLine().ToUpper();
                while ((restart != "Y") && (restart != "N"))   
                {
                    Console.WriteLine("Error");
                    Console.WriteLine("Add more? (Y/N) ");
                    restart = Console.ReadLine().ToUpper();
                }
            } while (restart == "Y");                                        //до сих, ниибу как работает



                Console.WriteLine("------------------");
                Console.WriteLine("Now in Database: ");
                string sqlRead = "SELECT id,content FROM learning";
                MySqlCommand dbRead = new MySqlCommand(sqlRead, conn);
                MySqlDataReader reader = dbRead.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine(reader[0].ToString() + " " + reader[1].ToString());
                }
                reader.Close();
                
                

            conn.Close();
            Console.ReadKey();
        }
    }
}
