using System;
using System.Collections.Generic;
using System.Text;

namespace Petbook.ClasesAux
{
    //Clase auxiliar que me permite almacenar las opciones que se crearan y se mostraran en la seccion del menu
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
