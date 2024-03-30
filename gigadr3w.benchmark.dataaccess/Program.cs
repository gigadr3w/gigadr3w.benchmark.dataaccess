using gigadr3w.benchmark.dataaccess.Benchmarks;
using BenchmarkDotNet.Running;
using gigadr3w.benchmark.dataaccess.Handlers;

namespace gigadr3w.benchmark.dataaccess
{
    class Program
    {
        static void Main(string[] args)
        {
            //var diagnostic = BenchmarkRunner.Run<DataAccessBenchmark>();
            string query = string.Format("SELECT TOP {0} * FROM Customers;", 100000);
            new ADOHandler("Server=localhost;Database=MyDb;User Id=sa;Password=!MySQL1nst4nc3_2024;").HandleCustomerList(query);
        }         
    }
}
