using Microsoft.AspNetCore.Mvc;
using Pacagroup.Eccomerce.Application.DTO;
using Pacagroup.Eccomerce.Application.Interface;

namespace Pacagroup.Eccomerce.Services.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomersApplication _customersApplication;
        public CustomersController(ICustomersApplication customersApplication)
        {
            _customersApplication = customersApplication;
        }

        #region Métodos Síncronos
        [HttpPost("Insert")]
        public IActionResult Insert([FromBody]CustomersDTO customersDTO)
        {
            if (customersDTO == null)
                return BadRequest();

            var response = _customersApplication.Insert(customersDTO);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpPut("Update")]
        public IActionResult Update([FromBody] CustomersDTO customersDTO)
        {
            if (customersDTO == null)
                return BadRequest();

            var response = _customersApplication.Update(customersDTO);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpDelete("Delete/{customerId}")]
        public IActionResult Delete(string customerId)
        {
            if (String.IsNullOrEmpty(customerId))
                return BadRequest();

            var response = _customersApplication.Delete(customerId);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("Get/{customerId}")]
        public IActionResult Get(string customerId)
        {
            if (String.IsNullOrEmpty(customerId))
                return BadRequest();

            var response = _customersApplication.Get(customerId);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var response = _customersApplication.GetAll();
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }
        #endregion

        #region Métodos Asíncronos
        [HttpPost]
        public async Task<IActionResult> InsertAsync([FromBody] CustomersDTO customersDTO)
        {
            if (customersDTO == null)
                return BadRequest();

            var response = await _customersApplication.InsertAsync(customersDTO);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] CustomersDTO customersDTO)
        {
            if (customersDTO == null)
                return BadRequest();

            var response = await _customersApplication.UpdateAsync(customersDTO);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpDelete("{customerId}")]
        public async Task<IActionResult> DeleteAsync(string customerId)
        {
            if (String.IsNullOrEmpty(customerId))
                return BadRequest();

            var response = await _customersApplication.DeleteAsync(customerId);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetAsync(string customerId)
        {
            if (String.IsNullOrEmpty(customerId))
                return BadRequest();

            var response = await _customersApplication.GetAsync(customerId);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _customersApplication.GetAllAsync();
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }
        #endregion
    }
}
