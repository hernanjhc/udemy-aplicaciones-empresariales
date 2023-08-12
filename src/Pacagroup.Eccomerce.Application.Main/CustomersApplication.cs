using AutoMapper;
using Pacagroup.Eccomerce.Application.DTO;
using Pacagroup.Eccomerce.Application.Interface;
using Pacagroup.Eccomerce.Domain.Entity;
using Pacagroup.Eccomerce.Domain.Interface;
using Pacagroup.Eccomerce.Transversal.Common;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Pacagroup.Eccomerce.Application.Main
{
    public class CustomersApplication : ICustomersApplication
    {
        private readonly ICustomersDomain _customersDomain;
        private readonly IMapper _mapper;
        private readonly IAppLogger<CustomersApplication> _logger;

        public CustomersApplication(ICustomersDomain customersDomain, IMapper mapper, IAppLogger<CustomersApplication> logger)
        {
            _customersDomain = customersDomain;
            _mapper = mapper;
            _logger = logger;
        }

        #region Síncronos

        public Response<bool> Insert(CustomersDTO customersDTO)
        {
            var response = new Response<bool>();
            try
            {
                var customers = _mapper.Map<Customers>(customersDTO);
                response.Data = _customersDomain.Insert(customers);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro exitoso!";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        public Response<bool> Update(CustomersDTO customersDTO)
        {
            var response = new Response<bool>();
            try
            {
                var customers = _mapper.Map<Customers>(customersDTO);
                response.Data = _customersDomain.Update(customers);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Actualización exitosa!";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
        public Response<bool> Delete(string customerId)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = _customersDomain.Delete(customerId);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Eliminación exitosa!";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        public Response<CustomersDTO> Get(string customerId)
        {
            var response = new Response<CustomersDTO>();
            try
            {
                var customer = _customersDomain.Get(customerId);
                response.Data = _mapper.Map<CustomersDTO>(customer);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta exitosa!";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        public Response<IEnumerable<CustomersDTO>> GetAll()
        {
            var response = new Response<IEnumerable<CustomersDTO>>();
            try
            {
                var customers = _customersDomain.GetAll();
                response.Data = _mapper.Map<IEnumerable<CustomersDTO>>(customers);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta exitosa!";
                    _logger.LogInformation("Consulta exitosa!");
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(ex.Message);
            }
            return response;
        }
        #endregion

        #region Asíncronos

        public async Task<Response<bool>> DeleteAsync(string customerId)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = await _customersDomain.DeleteAsync(customerId);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Eliminación exitosa!";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<IEnumerable<CustomersDTO>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<CustomersDTO>>();
            try
            {
                var customers = await _customersDomain.GetAllAsync();
                response.Data = _mapper.Map<IEnumerable<CustomersDTO>>(customers);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta exitosa!";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<CustomersDTO>> GetAsync(string customerId)
        {
            var response = new Response<CustomersDTO>();
            try
            {
                var customer = await _customersDomain.GetAsync(customerId);
                response.Data = _mapper.Map<CustomersDTO>(customer);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta exitosa!";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<bool>> InsertAsync(CustomersDTO customersDTO)
        {
            var response = new Response<bool>();
            try
            {
                var customers = _mapper.Map<Customers>(customersDTO);
                response.Data = await _customersDomain.InsertAsync(customers);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro exitoso!";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<bool>> UpdateAsync(CustomersDTO customersDTO)
        {
            var response = new Response<bool>();
            try
            {
                var customers = _mapper.Map<Customers>(customersDTO);
                response.Data = await _customersDomain.UpdateAsync(customers);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Actualización exitosa!";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
        #endregion
    }
}