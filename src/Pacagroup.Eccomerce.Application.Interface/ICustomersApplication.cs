using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pacagroup.Eccomerce.Application.DTO;
using Pacagroup.Eccomerce.Transversal.Common;

namespace Pacagroup.Eccomerce.Application.Interface
{
    //todos los metodos van a devolver una entidad generica del tipo response
    //recibe dto
    public interface ICustomersApplication
    {
        #region Métodos Síncronos
        Response<bool> Insert(CustomersDTO customersDTO);
        Response<bool> Update(CustomersDTO customersDTO);
        Response<bool> Delete(string customerId);
        Response<CustomersDTO> Get(string customerId);
        Response<IEnumerable<CustomersDTO>> GetAll();
        #endregion

        #region Métodos Asíncronos
        Task<Response<bool>> InsertAsync(CustomersDTO customersDTO);
        Task<Response<bool>> UpdateAsync(CustomersDTO customersDTO);
        Task<Response<bool>> DeleteAsync(string customerId);
        Task<Response<CustomersDTO>> GetAsync(string customerId);
        Task<Response<IEnumerable<CustomersDTO>>> GetAllAsync();
        #endregion
    }
}
