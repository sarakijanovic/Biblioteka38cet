using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka38cet
{
    internal class Knjiga
    {

        public string NazivKnjige { get; set; }
        public string NazivAutora { get; set; }

        public DateTime DatumUpisa { get; set; }

        public Knjiga (string naziv, string autor, DateTime datum)
        {
            NazivKnjige = naziv;
            NazivAutora = autor;
            DatumUpisa = datum;

        }
    }
}
