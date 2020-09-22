using WST.BusinessLogic.Communication;
using WST.BusinessLogic.ModelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WST.BusinessLogic.Api.Interface
{
    public interface IWSTApi
    {
        ///<summary>
        /// Pobranie spisu ubrań
        /// </summary>
        /// <returns>Zwraca ubrania</returns>
        ProduktyServiceResponse GetProdukty();
        ///<summary>
        /// Usuwa ubranie
        /// </summary>
        /// <returns>Zwraca status operacji</returns>
        ProduktyServiceResponse DelProdukty(int id);
    }
}
