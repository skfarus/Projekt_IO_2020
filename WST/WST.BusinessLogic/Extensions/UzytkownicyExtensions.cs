using WST.BusinessLogic.ModelDTO;
using WST.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WST.BusinessLogic.Extensions
{
    public static class UzytkownicyExtensions
    {
        public static Uzytkownicy ToUzytkownicy(this UzytkownicyDTO dTO)
        {
            if (dTO == null)
                return null;

            return new Uzytkownicy
            {
                Id = dTO.Id,
                Imie = dTO.Imie,
                Nazwisko = dTO.Nazwisko,
                Haslo = dTO.Haslo,
                Email = dTO.Email,
                Adres = dTO.Adres,
                Telefon = dTO.Telefon,
                Admin = dTO.Admin
            };
        }
    }
}
