using Microsoft.EntityFrameworkCore;
using NetCoreApiEgitim2.Models;

namespace NetCoreApiEgitim2.Entities
{
    public class Context2 : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

            string? con1 = configuration.GetConnectionString("con2");

            optionsBuilder.UseSqlServer(con1);

            //optionsBuilder.UseSqlServer("Data Source=RAMBO3;Initial Catalog=POSDB;User ID=sa;Password=19830126;TrustServerCertificate=True");
        }
        public DbSet<Kategoriler> Kategoriler { get; set; }

    }
}
