using System;
using NoWaste.Droid.Dependency;
using Xamarin.Forms;

[assembly: Dependency(typeof(Connection_Android))]
namespace NoWaste.Droid.Dependency
{
    public class Connection_Android : Domain.Models.Contracts.ISqlLiteConnection
    {
        public string GetDatabasePath()
        {
            return System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData), Domain.Seedwork.SqlLiteFactory.dbName);
        }

        public string GetFolderPath()
        {
            return System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
        }
    }
}
