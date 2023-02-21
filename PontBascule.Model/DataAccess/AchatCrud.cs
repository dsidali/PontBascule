
using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using PontBascule.Model;
using PontBascule.Model.Models;

namespace PontBascule.Model.DataAccess
{
    public  class AchatCrud : IAchatCrud
    {
        private ApplicationDbContext db;
        private IDbContextFactory<ApplicationDbContext> _dbContextFactory;
        public AchatCrud(IDbContextFactory<ApplicationDbContext> dbContextFactory)
        {
           _dbContextFactory = dbContextFactory;
           db = _dbContextFactory.CreateDbContext();
        }

        public  Achat CreateAchatEntity(string NumBonA, int ParcId, string Mat, string Transporteur, DateTime DateOP, TimeSpan HeureOP, string NumTicket, int PCC, int PCV, int PB, int PQRa, int PQS, bool Termine, string Observation,string FournisseurOuClient,string TypeTransport,string TypeCamion)
        {
            Achat achat = new Achat()
            {
                NumBonA = NumBonA,
                ParcId = ParcId,
                Mat = Mat,
             Transporteur= Transporteur,
                DateOP = DateOP,
                HeureOP = HeureOP,
                NumTicket = NumTicket,
                PCC = PCC,
                PB = PB,
                PQRa = PQRa,
                PQS = PQS,
                Termine = Termine,
                Observation = Observation,
                FournisseurOuClient = FournisseurOuClient,
                TypeTransport = TypeTransport,
                TypeCamion = TypeCamion
            };

            return achat;
        }

        public  async Task<Achat> CreateAchat(Achat achat)
        {
          



            var _achat = db.Achats.Add(achat);
            await db.SaveChangesAsync();
            return _achat.Entity;
        }


        public  async Task<List<Achat>> GetAchatsList()
        {

            return await db.Achats.ToListAsync();
        }

        public  async Task<Achat> GetAchatById(int id)
        {
            return await db.Achats.FindAsync(id);
        }

        public  async Task<Achat> GetAchatByNumBon(string NumBonA)
        {
            return await db.Achats.FirstOrDefaultAsync(x => x.NumBonA == NumBonA);
        }


        public  async Task EditAchat(Achat achat)
        {
            db.Entry(achat).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }

        public  async Task DeleteAchat(Achat achat)
        {
            db.Achats.Remove(achat);
            await db.SaveChangesAsync();
        }

        public  string GetMax()
        {
            return db.Achats.Max(x => x.NumBonA);
        }

        public  string GenerateId()
        {


            string max = GetMax();
            int inc = int.Parse(max.Substring(0, 6));
            inc++;


            return $"{inc:000000}";
        }

    }
}
