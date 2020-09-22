using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WST.Domain.Domain
{
    public class Produkty
    {
        public virtual int Id { get; set; }
        public virtual string Marka { get; set; }
        public virtual string Model { get; set; }
        public virtual string Opis { get; set; }
        public virtual string Ilosc { get; set; }
    }
}
