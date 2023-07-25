using AutoMapper;
using Pacagroup.Eccomerce.Application.DTO;
using Pacagroup.Eccomerce.Application.Interface;
using Pacagroup.Eccomerce.Domain.Interface;
using Pacagroup.Eccomerce.Transversal.Common;

namespace Pacagroup.Eccomerce.Application.Main
{
    public class UsersApplication : IUsersApplication
    {
        private readonly IUsersDomain _usersDomain;
        private readonly IMapper _mapper;

        public UsersApplication(IUsersDomain usersDomain, IMapper mapper)
        {
            _mapper = mapper;
            _usersDomain = usersDomain;
        }

        public Response<UsersDto> Authenticate(string username, string password)
        {
            var response = new Response<UsersDto>();
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                response.Message = "Parámetros no pueden ser vacios.";
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
