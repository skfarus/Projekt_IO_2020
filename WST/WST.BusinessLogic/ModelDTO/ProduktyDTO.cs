using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WST.BusinessLogic.ModelDTO
{
    public class ProduktyDTO
    {
        public int Id { get; set; }
        public string Marka { get; set; }
        public string Model { get; set; }
        public string Opis { get; set; }
        public string Ilosc { get; set; }
    }
}
