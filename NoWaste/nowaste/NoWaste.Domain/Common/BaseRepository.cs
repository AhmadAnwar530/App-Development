using NoWaste.Domain.Seedwork;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoWaste.Domain.Common
{
    public abstract class BaseRepository
    {
        protected virtual SQLiteConnection GetConnection()
        {
            try
            {
                return new SQLiteConnection(SqlLiteFactory.DbPath);
            }
            catch (SQLiteException ex)
            {
                throw;
            }
        }

        protected virtual void Insert<T>(T value)
        {
            using (var con = GetConnection())
            {
                con.Insert(value);
            }
        }
        protected IEnumerable<T> Query<T>(string query) where T : new()
        {
            using (var con = GetConnection())
            {
                return con.Query<T>(query).ToArray();
            }
        }
        protected virtual void Update<T>(T value)
        {
            using (var con = GetConnection())
            {
                con.Update(value);
            }
        }

        protected virtual void Delete<T>(T value)
        {
            using (var con = GetConnection())
            {
                con.Delete(value);
            }
        }

    }
}
