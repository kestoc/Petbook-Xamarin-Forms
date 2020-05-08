using System;
using System.Collections.Generic;
using System.Text;

namespace Petbook.ClasesAux
{
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
