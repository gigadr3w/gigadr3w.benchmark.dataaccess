using gigadr3w.benchmark.dataaccess.Models;
using Dapper;
using System.Data.SqlClient;

namespace gigadr3w.benchmark.dataaccess.Handlers
{
    public class DapperHandler
    {
        private readonly string _connectionString;
        public DapperHandler(string connectionString)
            => _connectionString = connectionString;
        

        public void HandleCustomerList(string query)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    List<CustomerModel> customers = connection.Query<CustomerModel>(query).ToList();
                }
                catch 
                {   
                }
            }
        }
    }
}
