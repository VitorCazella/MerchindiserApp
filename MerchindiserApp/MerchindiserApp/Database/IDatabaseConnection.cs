﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MerchindiserApp.Database
{
    interface IDatabaseConnection
    {
        SQLite.SQLiteConnection DbConnection();
    }
}
