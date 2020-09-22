using WST.BusinessLogic.ModelDTO;
using WST.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WST.BusinessLogic.Extensions
{
    public static class WypozyczeniaExtensions
    {
        public static Wypozyczenia ToWypozyczenia(this WypozyczeniaDTO dTO)
        {
            if (dTO == null)
                return null;

            return new Wypozyczenia
            {
                Id = dTO.Id,
                Produkt_id = dTO.Produkt_id,
                Uzytkownik_id = dTO.Uzytkownik_id,
                Ilosc = dTO.Ilosc,
                Data_od = dTO.Data_od,
                Ilosc_dni = dTO.Ilosc_dni,
                Data_do = dTO.Data_do
            };
        }
    }
}
