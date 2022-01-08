
using Microsoft.EntityFrameworkCore;

namespace ExampleAppNet6.Models {

    public class ProductDbContext : DbContext {

        public ProductDbContext() { }
        
        public ProductDbContext(DbContextOptions<ProductDbContext> options)
            : base(options) {
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder options) 
        {
            var envs = Environment.GetEnvironmentVariables();

            options.UseMySql(MySqlEfConfigurationHelper.ConstructConnectionString(envs),
                MySqlEfConfigurationHelper.MySqlServerVersion);
        }

        public DbSet<Product> Products { get; set; }
    }
}
