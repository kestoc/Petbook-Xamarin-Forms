using System;
using System.Collections.Generic;
using System.Text;

namespace Petbook.ClasesAux
{
    //Clase para almacenar las opciones que se crean para el menu
    public class Options
    {
        public string Texto { get; set; }
        public string Imagen { get; set; }

        public override string ToString()
        {
            return Texto;
        }
    }
}
