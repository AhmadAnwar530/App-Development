using System;
namespace NoWaste.Domain.Models.Contracts
{
    public interface ISqlLiteConnection
    {
        string GetDatabasePath();
        string GetFolderPath();
    }
}
