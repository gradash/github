using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learning
{
    class dbConnect
    {
        private readonly string connStr = "server=35.233.55.137;user=root;database=learning;password=qwerty_1;";


        public void InsertDB(string addstring)
        {


            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();

            string query = "INSERT INTO learning (content) VALUES (@content);";
            MySqlCommand dbInsert = new MySqlCommand(query, conn);
            dbInsert.Parameters.AddWithValue("@content", addstring);
            dbInsert.ExecuteNonQuery();

            conn.Close();

        }

        public string ReadDB()
        {
            MySqlConnection conn = new MySqlConnection(connStr);

            conn.Open();


            string sqlRead = "SELECT id,content FROM learning";
            MySqlCommand dbRead = new MySqlCommand(sqlRead, conn);
            MySqlDataReader reader = dbRead.ExecuteReader();

            string result = string.Empty;
            while (reader.Read())
            {
                result = result + (reader[0].ToString() + " " + reader[1].ToString()) + "\n";
            }
            reader.Close();

            conn.Close();
            return result;
        }


    }


}




    

