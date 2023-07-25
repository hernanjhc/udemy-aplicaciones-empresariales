using Dapper;
using Pacagroup.Eccomerce.Domain.Entity;
using Pacagroup.Eccomerce.Infraestructure.Interface;
using Pacagroup.Eccomerce.Transversal.Common;

namespace Pacagroup.Eccomerce.Infraestructure.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public UsersRepository(IConnectionFactory connectionFactory)
        {
                _connectionFactory = connectionFactory;
        }

        public Users Authenticate(string username, string password)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UsersGetByUserAndPassword";
                var parameters = new DynamicParameters();
                parameters.Add("UserName", username);
                parameters.Add("Password", password);

                var user = connection.QuerySingle<Users>(query, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
                return user;
            }
        }
    }
}
