using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Petbook
{
    public interface ISQLiteDB
    {
        SQLiteAsyncConnection GetConnection();
    }
}
