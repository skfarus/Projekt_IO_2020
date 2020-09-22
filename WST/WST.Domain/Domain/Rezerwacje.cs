using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WST.Domain.Domain
{
    public class Rezerwacje
    {
        public virtual int Id { get; set; }
        public virtual string Produkt_id { get; set; }
        public virtual string Uzytkownik_id { get; set; }
        public virtual string Ilosc { get; set; }
        public virtual DateTime Data_od { get; set; }
        public virtual string Ilosc_dni { get; set; }
    }
}
