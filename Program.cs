using System;
using System.Collections.Generic;
using System.Data;
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
            dbConnect dbConnect = new dbConnect();
            string restart = null;
            do
            {
                Console.WriteLine("Enter text to database: ");
                string addstring = Console.ReadLine();
                dbConnect.InsertDB(addstring);

                Console.Write("Add more? (Y/N) ");
                restart = Console.ReadLine().ToUpper();
                while ((restart != "Y") && (restart != "N"))
                {
                    Console.WriteLine("Error");
                    Console.WriteLine("Add more? (Y/N) ");
                    restart = Console.ReadLine().ToUpper();
                }
            } while (restart == "Y");


            var result = dbConnect.ReadDB();
            
            Console.WriteLine("------------------");
            Console.WriteLine("Now in Database: ");
            Console.WriteLine(result);
            Console.ReadKey();

                                          
        }
    }
}
