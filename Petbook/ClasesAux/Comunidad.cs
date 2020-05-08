using System;
using System.Collections.Generic;
using System.Text;

namespace Petbook.ClasesAux
{
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
