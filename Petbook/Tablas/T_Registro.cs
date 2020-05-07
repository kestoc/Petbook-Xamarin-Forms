using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Petbook.Tablas
{
    public class T_Registro
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string user { get; set; }
        [MaxLength(100)]
        public string correo { get; set; }
        public string password { get; set; }
        [MaxLength(200)]
        public DateTime fecha { get; set; }
    }
}
