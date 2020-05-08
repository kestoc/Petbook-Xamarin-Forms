using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Petbook
{
    //Clase para establecer la conexion de la DB con la App
    public interface ISQLiteDB
    {
        SQLiteAsyncConnection GetConnection();
    }
}
