using gigadr3w.benchmark.dataaccess.Models;
using Microsoft.EntityFrameworkCore;

namespace gigadr3w.benchmark.dataaccess.Handlers
{
    public class MyDbContext : DbContext
    {
        public DbSet<CustomerModel> Customers { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
        
    }

    public sealed class EFHandler
    {
        private readonly DbContextOptions<MyDbContext> _myDbContextOptions;
        public EFHandler(string connectionString)
            => _myDbContextOptions = new DbContextOptionsBuilder<MyDbContext>().UseSqlServer(connectionString).Options;
        

        public void HandleCustomerList(string query)
        {
            using (MyDbContext context = new MyDbContext(_myDbContextOptions))
            {
                try
                {
                    List<CustomerModel> customers = context.Customers.FromSqlRaw(query).ToList();
                }
                catch 
                {   
                }
            }
        }
    }
}
