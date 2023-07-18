using SQLite;
using System.IO;
using ScreenTemplate.Droid.Data;
using Xamarin.Forms;
using ScreenTemplate.ViewModels;
using ScreenTemplate.Models;

[assembly: Dependency(typeof(SQLiteDbAndroid))]

namespace ScreenTemplate.Droid.Data
{
    public class SQLiteDbAndroid : ISQLiteDb
    {
        public SQLiteConnection GetConnection()
        {
            var dbName = "UserCredentials.db3";
            var dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), dbName);
            var connection = new SQLiteConnection(dbPath);
            connection.CreateTable<User>();

            return connection;

            //return new SQLiteConnection(dbPath);
            
        }
    }
}
