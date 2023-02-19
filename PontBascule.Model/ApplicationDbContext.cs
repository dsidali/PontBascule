using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PontBascule.Model.Models;

namespace PontBascule.Model
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

        }

        */


        public DbSet<Parc> Parcs { get; set; }
        public DbSet<Transporteur> Transporteurs { get; set; }
        public DbSet<TypeProduit> TypeProduits { get; set; }
        public DbSet<Achat> Achats { get; set; }
        public DbSet<SortieTransfert> SortieTransferts { get; set; }
        public DbSet<ReceptionTransfert> ReceptionTransferts { get; set; }
        public DbSet<SortieRondBeton> SortieRondBetons { get; set; }
        public DbSet<Pesage> Pesages { get; set; }
        public DbSet<ReceptionRondBeton> ReceptionRondBetons { get; set; }
        public DbSet<Privilege> Privileges { get; set; }
        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<TypeDeCamion> TypeDeCamions { get; set; }
        public DbSet<TypeDeTransport> TypeDeTransports { get; set; }
    }
}
