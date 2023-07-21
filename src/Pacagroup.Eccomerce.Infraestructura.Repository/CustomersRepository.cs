using Pacagroup.Eccomerce.Domain.Entity;
using Pacagroup.Eccomerce.Infraestructure.Interface;
using Pacagroup.Eccomerce.Transversal.Common;
using Dapper;
using System.Data;
using System.Threading.Tasks;

namespace Pacagroup.Eccomerce.Infraestructura.Repository
{
    public class CustomersRepository : ICustomersRepository
    {
        IConnectionFactory _connectionFactory;
        public CustomersRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        #region Métodos Síncronos
        public bool Insert(Customers customer)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "CustomersInsert";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerID", customer.CustomerId);
                parameters.Add("CompanyName", customer.CompanyName);
                parameters.Add("ContactName", customer.ContactName);
                parameters.Add("ContactTitle", customer.ContactTitle);
                parameters.Add("Address", customer.Address);
                parameters.Add("City", customer.City);
                parameters.Add("Region", customer.Region);
                parameters.Add("PostalCode", customer.PostalCode);
                parameters.Add("Country", customer.Country);
                parameters.Add("Phone", customer.Phone);
                parameters.Add("Fax", customer.Fax);

                var result = connection.Execute(query, parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public bool Update(Customers customer)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "CustomersUpdate";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerID", customer.CustomerId);
                parameters.Add("CompanyName", customer.CompanyName);
                parameters.Add("ContactName", customer.ContactName);
                parameters.Add("ContactTitle", customer.ContactTitle);
                parameters.Add("Address", customer.Address);
                parameters.Add("City", customer.City);
                parameters.Add("Region", customer.Region);
                parameters.Add("PostalCode", customer.PostalCode);
                parameters.Add("Country", customer.Country);
                parameters.Add("Phone", customer.Phone);
                parameters.Add("Fax", customer.Fax);

                var result = connection.Execute(query, parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public bool Delete(string customerId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "CustomersDelete";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerID", customerId);

                var result = connection.Execute(query, parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public Customers Get(string customerId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "CustomersGetByID";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerID", customerId);
                //QuerySingle por que es consulta (Propio de Dapper)
                var customer = connection.QuerySingle<Customers>(query, parameters, commandType: CommandType.StoredProcedure);
                return customer;
            }
        }

        public IEnumerable<Customers> GetAll()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "CustomersList";
                var parameters = new DynamicParameters();

                //Query por que es consulta (Propio de Dapper)
                var customers = connection.Query<Customers>(query, commandType: CommandType.StoredProcedure);
                return customers;
            }
        }
        #endregion

        #region Métodos Asíncronos
        public async Task<bool> InsertAsync(Customers customer)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "CustomersInsert";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerID", customer.CustomerId);
                parameters.Add("CompanyName", customer.CompanyName);
                parameters.Add("ContactName", customer.ContactName);
                parameters.Add("ContactTitle", customer.ContactTitle);
                parameters.Add("Address", customer.Address);
                parameters.Add("City", customer.City);
                parameters.Add("Region", customer.Region);
                parameters.Add("PostalCode", customer.PostalCode);
                parameters.Add("Country", customer.Country);
                parameters.Add("Phone", customer.Phone);
                parameters.Add("Fax", customer.Fax);

                var result = await connection.ExecuteAsync(query, parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public async Task<bool> UpdateAsync(Customers customer)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "CustomersUpdate";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerID", customer.CustomerId);
                parameters.Add("CompanyName", customer.CompanyName);
                parameters.Add("ContactName", customer.ContactName);
                parameters.Add("ContactTitle", customer.ContactTitle);
                parameters.Add("Address", customer.Address);
                parameters.Add("City", customer.City);
                parameters.Add("Region", customer.Region);
                parameters.Add("PostalCode", customer.PostalCode);
                parameters.Add("Country", customer.Country);
                parameters.Add("Phone", customer.Phone);
                parameters.Add("Fax", customer.Fax);

                var result = await connection.ExecuteAsync(query, parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public async Task<bool> DeleteAsync(string customerId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "CustomersDelete";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerID", customerId);

                var result = await connection.ExecuteAsync(query, parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public async Task<Customers> GetAsync(string customerId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "CustomersGetByID";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerID", customerId);
                //QuerySingle por que es consulta (Propio de Dapper)
                var customer = await connection.QuerySingleAsync<Customers>(query, parameters, commandType: CommandType.StoredProcedure);
                return customer;
            }
        }

        public async Task<IEnumerable<Customers>> GetAllAsync()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "CustomersList";
                var parameters = new DynamicParameters();

                //Query por que es consulta (Propio de Dapper)
                var customers = await connection.QueryAsync<Customers>(query, commandType: CommandType.StoredProcedure);
                return customers;
            }
        }
        #endregion
    }
}