using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PontBascule.Model;
using PontBascule.Model.Models;

namespace PontBascule.Data
{
    public class AchatsService
    {
        private IDbContextFactory<ApplicationDbContext> _dbContextFactory;
        private ApplicationDbContext db;

        public AchatsService(IDbContextFactory<ApplicationDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
            db = _dbContextFactory.CreateDbContext();
        }


        public List<Achat> GetAchats()
        {
       
          return db.Achats.ToList();
        }
    }
}
