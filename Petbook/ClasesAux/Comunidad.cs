using System;
using System.Collections.Generic;
using System.Text;

namespace Petbook.ClasesAux
{
    //Clase para almacenar los datos de las comunidades que se creen
   public class Comunidad
    {
        public string Nombre { get; set; }
        public string Miembros { get; set; }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
