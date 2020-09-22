using WST.BusinessLogic.ModelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WST.BusinessLogic.Communication
{
    public class ProduktyServiceResponse : ServiceResponse
    {
        public List<ProduktyDTO> Data { get; set; }
    }
}
