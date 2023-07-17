using Pacagroup.Eccomerce.Domain.Entity;
using Pacagroup.Eccomerce.Domain.Interface;
using Pacagroup.Eccomerce.Infraestructure.Interface;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Pacagroup.Eccomerce.Domain.Core
{
    public class CustomersDomain : ICustomersDomain
    {
        //logica y reglas de negocio.
        private readonly ICustomersRepository _customerRepository;

        public CustomersDomain(ICustomersRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        #region Síncronos

        public bool Insert(Customers customer)
        {

            return _customerRepository.Insert(customer);
        }

        public bool Update(Customers customer)
        {
            return _customerRepository.Update(customer);
        }

        public bool Delete(string customerId)
        {
            return _customerRepository.Delete(customerId);
        }

        public Customers Get(string customerId)
        {
            return _customerRepository.Get(customerId);
        }

        public IEnumerable<Customers> GetAll()
        {
            return _customerRepository.GetAll();
        }
        #endregion

        #region Asíncronos

        public async Task<Customers> GetAsync(string customerId)
        {
            return await _customerRepository.GetAsync(customerId);
        }

        public async Task<bool> DeleteAsync(string customerId)
        {
            return await _customerRepository.DeleteAsync(customerId);
        }

        public async Task<IEnumerable<Customers>> GetAllAsync()
        {
            return await _customerRepository.GetAllAsync();
        }

        public async Task<bool> InsertAsync(Customers customer)
        {
            return await _customerRepository.InsertAsync(customer);
        }

        public async Task<bool> UpdateAsync(Customers customer)
        {
            return await _customerRepository.UpdateAsync(customer);
        }
        #endregion
    }
}