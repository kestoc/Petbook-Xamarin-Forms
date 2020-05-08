using System;
using System.Collections.Generic;
using System.Text;

namespace Petbook.ClasesAux
{
    //Clase auxiliar que me permite guardar los datos de una publicacion, para crearlas y usarlas en la pag principal de noticias
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
