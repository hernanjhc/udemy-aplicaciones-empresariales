using Pacagroup.Eccomerce.Domain.Entity;
using Pacagroup.Eccomerce.Domain.Interface;
using Pacagroup.Eccomerce.Infraestructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacagroup.Eccomerce.Domain.Core
{
    public class UsersDomain : IUsersDomain
    {
        private readonly IUsersRepository _usersRepository;
        public UsersDomain(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public Users Authenticate(string username, string password)
        {
            return _usersRepository.Authenticate(username, password);
        }
    }
}
