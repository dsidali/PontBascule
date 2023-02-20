using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace PontBascule.Model
{
    public class DbContextMigrationFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            builder.UseSqlServer(configuration.GetConnectionString("data source=127.0.0.1;initial catalog=PontBasculeDB2;user id=sa;password=Informatik.1;Trust Server Certificate=true;MultipleActiveResultSets=True;"));

            return new ApplicationDbContext(builder.Options);
        }
    }
}
