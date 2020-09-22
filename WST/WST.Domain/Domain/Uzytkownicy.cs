using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WST.Domain.Domain
{
    public class Uzytkownicy
    {
        public virtual int Id { get; set; }
        public virtual string Email { get; set; }
        public virtual string Haslo { get; set; }
        public virtual string Imie { get; set; }
        public virtual string Nazwisko { get; set; }
        public virtual string Adres { get; set; }
        public virtual string Telefon { get; set; }
        public virtual string Admin { get; set; }
    }
}
