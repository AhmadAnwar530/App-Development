﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ScreenTemplate.Models
{
    using SQLite;

        public interface ISQLiteDb
        {
            SQLiteConnection GetConnection();
        }
    }

//this code defines an interface (ISQLiteDb) that provides a method (GetConnection())
//to obtain an SQLite connection. This interface can be implemented by platform-specifi
//c code to establish a connection to an SQLite database.