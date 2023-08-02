using SQLite;
using System.IO;
using ScreenTemplate.iOS.Data;
using Xamarin.Forms;
using ScreenTemplate.ViewModels;
using ScreenTemplate.Models;

[assembly: Dependency(typeof(SQLiteDbiOS))]

namespace ScreenTemplate.iOS.Data
{
    public class SQLiteDbiOS : ISQLiteDb
    {
        public SQLiteConnection GetConnection()
        {
            var dbName = "UserCredentials.db4";
            var dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "..", "Library", dbName);
            var connection = new SQLiteConnection(dbPath);
            connection.CreateTable<UserData>();

            return connection;
        }
    }
}
