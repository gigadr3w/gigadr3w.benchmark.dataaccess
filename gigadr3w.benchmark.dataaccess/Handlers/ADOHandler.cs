using System.Data.SqlClient;
using System.Data;
using gigadr3w.benchmark.dataaccess.Models;

namespace gigadr3w.benchmark.dataaccess.Handlers
{
    public class ADOHandler
    {
        private readonly string _connectionString;

        public ADOHandler(string connectionString)
            =>_connectionString = connectionString;

        public void HandleCustomerList(string query)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand(query, connection);
                    
                    SqlDataReader reader = cmd.ExecuteReader();

                    List<CustomerModel> customers = new();

                    while (reader.Read())
                    {
                        customers.Add(new CustomerModel
                        {
                            Id = (int)reader["Id"],
                            Name = reader["Name"].ToString() ?? string.Empty,
                            Address = reader["Address"].ToString() ?? string.Empty,
                            City = reader["City"].ToString() ?? string.Empty,
                            ZipCode = reader["ZipCode"].ToString() ?? string.Empty,
                            Country = reader["Country"].ToString() ?? string.Empty,
                            Description = reader["Description"].ToString() ?? string.Empty,
                            Code = reader["Code"].ToString() ?? string.Empty,
                            CreationDate = Convert.ToDateTime(reader["CreationDate"].ToString()),
                            IsEnable = Convert.ToBoolean(reader["IsEnable"].ToString()),
                        });
                    }
                    reader.Close();
                }
                catch 
                {   
                }
            }
        }
    }
}
