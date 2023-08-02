using NoWaste.Domain.Seedwork;
using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            catch (SQLiteException)
            {
                throw;
            }
        }

        protected virtual void Insert<T>(T value)
        {
            using (var con = GetConnection())
            {
                try
                {
                    con.Insert(value);
                }
                catch (SQLite.SQLiteException ex)
                {
                    if (ex.Message.Contains("no such column"))
                    {
                        
                        Debug.WriteLine("Update failed: " + ex.Message);
                    }
                    else
                    {
                        throw;
                    }
                }
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
                try
                {
                    con.Update(value);
                }
                catch (SQLite.SQLiteException ex)
                {
                    if (ex.Message.Contains("no such column: PurchaseAmount"))
                    {
                       
                        Debug.WriteLine("Update failed: " + ex.Message);
                    }
                    else
                    {
                       
                        throw;
                    }
                }
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
