using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Petbook
{
    //Clase auxiliar para hacer la conexion de la DB entre la App y la DB local
    public interface ISQLiteDB
    {
        SQLiteAsyncConnection GetConnection();
    }
}
