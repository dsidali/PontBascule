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
    public class AchatService
    {
        private IDbContextFactory<ApplicationDbContext> _dbContextFactory;

        public AchatService(IDbContextFactory<ApplicationDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }


        public List<Achat> GetAchats()
        {
          var db =   _dbContextFactory.CreateDbContext();
          return db.Achats.ToList();
        }
    }
}
