using Pacagroup.Eccomerce.Application.DTO;
using Pacagroup.Eccomerce.Transversal.Common;

namespace Pacagroup.Eccomerce.Application.Interface
{
    public interface IUsersApplication
    {
        Response<UsersDto> Authenticate(string username, string password);
    }
}
