﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WST.Domain.Domain;

namespace WST.BusinessLogic.ModelDTO
{
    public class RejestracjaDTO
    {
        public string Email { get; set; }
        public string Haslo { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Adres { get; set; }
        public string Telefon { get; set; }
    }
}