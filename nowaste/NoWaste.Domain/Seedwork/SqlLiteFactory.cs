using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using NoWaste.Domain.Models.Aggregates;
using System.Linq;

namespace NoWaste.Domain.Seedwork
{
    public class SqlLiteFactory
    {
        public static string dbName = "NoWaste.db";
        static string _dbPath;

        public static string DbPath { get => _dbPath; }

       

        public static bool Seed(string dbPath)
        {
            try
            {
                _dbPath = dbPath;
                using (var con = new SQLite.SQLiteConnection(dbPath))
                {
                    
                    con.CreateTable<Item>();
                    con.CreateTable<Category>();
                    con.CreateTable<Setting>();
                }
                return true;
            }
            catch (SQLite.SQLiteException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }



    }
}

