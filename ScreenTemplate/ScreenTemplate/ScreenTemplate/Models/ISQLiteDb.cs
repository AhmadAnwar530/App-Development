using System;
using System.Collections.Generic;
using System.Text;

namespace ScreenTemplate.Models
{
    using SQLite;

    namespace ScreenTemplate.Data
    {
        public interface ISQLiteDb
        {
            SQLiteConnection GetConnection();
        }
    }

}
