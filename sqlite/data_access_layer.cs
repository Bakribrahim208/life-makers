using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
namespace sqlite
{
     class data_access_layer
    {
    public     SQLiteConnection m_dbConnection;

         public data_access_layer()
         {
             m_dbConnection = new SQLiteConnection("Data Source=D:\\hussien embaby\\database1.sqlite;Version=3;");
             m_dbConnection.Open();
              
         }
         public void Execuate_quary(String sql)
         {

             SQLiteCommand command = new SQLiteCommand(sql,m_dbConnection);
             command.ExecuteNonQuery();
         }
         public void se()
         {
             SQLiteDataAdapter d = new SQLiteDataAdapter();
             DataTable dt = new DataTable();
             d.Fill(dt);
            
         }
         public DataTable select(string sql )  // Read data from database 
         {
            //// SQLiteDataReader reader;
             SQLiteCommand command = m_dbConnection.CreateCommand();
             command.CommandText = sql;

            // reader = command.ExecuteReader();
          //   int count = 0;
           //  while (reader.Read()) // Read() returns true if there is still a result line to read
           //  {
             //    count++;
            // }

             // We are ready, now lets cleanup and close our connection:

             SQLiteDataAdapter da = new SQLiteDataAdapter(command);
             DataTable dt = new DataTable();
             da.Fill(dt);
             
             m_dbConnection.Close();
             return dt;  
         }


    }
}
