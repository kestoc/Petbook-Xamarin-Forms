using System;
using System.Collections.Generic;
using System.Text;

namespace Petbook.ClasesAux
{
    //Clase auxiliar almacenar y poder crear las comunidades en dicha seccion 
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
