using WST.BusinessLogic.ModelDTO;
using WST.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WST.BusinessLogic.Extensions
{
    public static class ProduktyExtensions
    {
        public static Produkty ToProdukty(this ProduktyDTO dTO)
        {
            if (dTO == null)
                return null;

            return new Produkty
            {
                Id = dTO.Id,
                Marka = dTO.Marka,
                Model = dTO.Model,
                Opis = dTO.Opis,
                Ilosc = dTO.Ilosc
            };
        }
    }
}
