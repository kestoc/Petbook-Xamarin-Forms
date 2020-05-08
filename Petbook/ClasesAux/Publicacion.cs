using System;
using System.Collections.Generic;
using System.Text;

namespace Petbook.ClasesAux
{
    public class Publicacion
    {
        public string Autor { get; set; }
        public string Texto { get; set; }
        public string Imagen { get; set; }
        public int Megusta { get; set; }

        public override string ToString()
        {
            return Autor;
        }
    }
}
