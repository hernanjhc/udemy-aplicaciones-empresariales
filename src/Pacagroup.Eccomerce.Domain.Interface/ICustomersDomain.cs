using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pacagroup.Eccomerce.Domain.Entity;

namespace Pacagroup.Eccomerce.Domain.Interface
{
    public interface ICustomersDomain
    {
        //Son las operaciones que vamos a realizar sobre nuestra entidad de dominio customers
        #region Métodos Síncronos
        bool Insert(Customers customer);
        bool Update(Customers customer);
        bool Delete(string customerId);

        Customers Get(string customerId);
        IEnumerable<Customers> GetAll();
        #endregion

        #region Métodos Asíncronos
        Task<bool> InsertAsync(Customers customer);
        Task<bool> UpdateAsync(Customers customer);
        Task<bool> DeleteAsync(string customerId);

        Task<Customers> GetAsync(string customerId);
        Task<IEnumerable<Customers>> GetAllAsync();
        #endregion
    }
}
