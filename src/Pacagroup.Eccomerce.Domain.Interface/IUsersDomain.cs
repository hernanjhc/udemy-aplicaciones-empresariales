using Pacagroup.Eccomerce.Domain.Entity;

namespace Pacagroup.Eccomerce.Domain.Interface
{
    public interface IUsersDomain
    {
        Users Authenticate(string username, string password);
    }
}
