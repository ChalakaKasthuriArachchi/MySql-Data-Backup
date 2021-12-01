using MySql.Data.MySqlClient;
using System;
using System.Threading;

namespace RuhunaSupplyBackup
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 0;
            while (true)
            {
                try
                {
                    string conString = "Server = localhost; Database = dbname; user id = root; password = pass;";
                    MySqlConnection con = new MySqlConnection(conString);
                    con.Open();
                    MySqlBackup backup = new MySqlBackup(con.CreateCommand());
                    backup.ExportToFile("Backup\\" + x + ".bckp");
                    Console.WriteLine("Backup Done at {0} : {1}", 
                        DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"), x + ".bckp");
                    con.Close();
                    x = (x + 1) % LIMIT;
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Error : " + ex.Message);
                }
                //Thread.Sleep(2 * 3600 * 1000);
                Thread.Sleep(5 * 1000);
            }
        }
        const int LIMIT = 100;
    }
}
