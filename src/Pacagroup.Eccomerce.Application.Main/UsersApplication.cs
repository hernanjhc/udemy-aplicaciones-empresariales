using AutoMapper;
using Pacagroup.Eccomerce.Application.DTO;
using Pacagroup.Eccomerce.Application.Interface;
using Pacagroup.Eccomerce.Domain.Interface;
using Pacagroup.Eccomerce.Transversal.Common;
using Pacagroup.Ecommerce.Application.Validator;

namespace Pacagroup.Eccomerce.Application.Main
{
    public class UsersApplication : IUsersApplication
    {
        private readonly IUsersDomain _usersDomain;
        private readonly IMapper _mapper;
        private readonly UsersDtoValidator _usersDtosValidator;

        public UsersApplication(IUsersDomain usersDomain, IMapper mapper, UsersDtoValidator usersDtosValidator)
        {
            _mapper = mapper;
            _usersDomain = usersDomain;
            _usersDtosValidator = usersDtosValidator;
        }

        public Response<UsersDto> Authenticate(string username, string password)
        {
            var response = new Response<UsersDto>();
            var validation = _usersDtosValidator.Validate(new UsersDto() { UserName = username, Password = password });

            //if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            if (!validation.IsValid)
            {
                //response.Message = "Parámetros no pueden ser vacios.";
                response.Message = "Errores de Validación.";
                response.Errors = validation.Errors;
                    return response;
            }
            try
            {
                var user = _usersDomain.Authenticate(username, password);
                response.Data = _mapper.Map<UsersDto>(user);
                response.IsSuccess = true;
                response.Message = "Autenticación exitosa!";
            }
            catch(InvalidOperationException)    //user o pass que no existan
            {
                response.IsSuccess = true;
                response.Message = "Usuario no existe.";
                return response; 
            }
            catch (Exception e)
            {
                response.Message = e.Message; 
            }
                return response;
        }
    }
}
