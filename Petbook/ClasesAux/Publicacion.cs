using System;
using System.Collections.Generic;
using System.Text;

namespace Petbook.ClasesAux
{
    //Clase para guardar las publicaciones que se crean
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
