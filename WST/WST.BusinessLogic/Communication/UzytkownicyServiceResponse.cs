using WST.BusinessLogic.ModelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WST.BusinessLogic.Communication
{
    public class UzytkownicyServiceResponse : ServiceResponse
    {
        public List<UzytkownicyDTO> Data { get; set; }
    }
}
