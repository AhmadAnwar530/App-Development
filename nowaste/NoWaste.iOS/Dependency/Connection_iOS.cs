using System;
using System.IO;
using NoWaste.Domain.Models.Contracts;
using NoWaste.Domain.Seedwork;
using NoWaste.iOS.Dependency;
using Xamarin.Forms;

[assembly: Dependency(typeof(Connection_iOS))]
namespace NoWaste.iOS.Dependency
{
    public class Connection_iOS : ISqlLiteConnection
    {
        public string GetDatabasePath()
        {
            var docs = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var db = Path.Combine(docs, "..", "Library", SqlLiteFactory.dbName);
            return db;
            //return System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData), Domain.Seedwork.SqlLiteFactory.dbName);


        }
        public string GetFolderPath()
        {

            var docs = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var folderPath = Path.Combine(docs, "..", "Library");
            return folderPath;
        }
    }
}
