using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WST.BusinessLogic.ModelDTO
{
    public class WypozyczeniaDTO
    {
        public int Id { get; set; }
        public string Produkt_id { get; set; }
        public string Uzytkownik_id { get; set; }
        public string Ilosc { get; set; }
        public DateTime Data_od { get; set; }
        public string Ilosc_dni { get; set; }
        public DateTime? Data_do { get; set; }
    }
}
