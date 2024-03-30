using BenchmarkDotNet.Attributes;
using gigadr3w.benchmark.dataaccess.Handlers;

namespace gigadr3w.benchmark.dataaccess.Benchmarks
{
    [MemoryDiagnoser]
    public class DataAccessBenchmark
    {
        private string _connectionString;
        private readonly string queryTemplate = "SELECT TOP {0} * FROM Customers;";

        [Params(10, 100, 500, 1000, 5000)]
        public int RecordCount { get; set; }

        [GlobalSetup]
        public void Setup()
            => _connectionString = "Server=localhost;Database=MyDb;User Id=sa;Password=!MySQL1nst4nc3_2024;";

        [Benchmark]
        public void QueryWith_ADO()
        {
            string query = string.Format(queryTemplate, RecordCount);
            new ADOHandler(_connectionString).HandleCustomerList(query);
        }

        //[Benchmark]
        //public void CallStoreProcedureWith_ADO()
        //{
        //    using (SqlConnection connection = new SqlConnection(_connectionString))
        //    {
        //        try
        //        {
        //            connection.Open();

        //            SqlCommand cmd = new SqlCommand("sp_get_customers", connection);
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            SqlDataReader reader = cmd.ExecuteReader();

        //            while (reader.Read())
        //            {
        //                string firstName = reader["FirstName"].ToString();
        //                string lastName = reader["LastName"].ToString();
        //                string department = reader["Department"].ToString();


        //            }
        //            reader.Close();
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine("Errore: " + ex.Message);
        //        }
        //    }
        //}

        [Benchmark]
        public void QueryWith_EF()
        {
            string query = string.Format(queryTemplate, RecordCount);
            new EFHandler(_connectionString).HandleCustomerList(query);
        }

        [Benchmark]
        public void QueryWith_DAPPER()
        {
            string query = string.Format(queryTemplate, RecordCount);
            new DapperHandler(_connectionString).HandleCustomerList(query);
        }
    }
}
