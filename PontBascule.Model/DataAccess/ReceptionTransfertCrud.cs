using Microsoft.EntityFrameworkCore;
using PontBascule.Model.Models;

namespace PontBascule.Model.DataAccess
{
    public  class ReceptionTransfertCrud
    {
        private ApplicationDbContext db;

        public ReceptionTransfertCrud(ApplicationDbContext _db)
        {
            db = _db;
        }

        public  ReceptionTransfert CreateReceptionTransfertEntity(string NumBL, int ParcId, DateTime DateOp, TimeSpan HeureOP, string Transporteur, int TypeProduitId, string Mat, int PCC, int PCV, int PQR, bool Termine, string Observation,string Provenance,string TypeTransport,string TypeCamion)
        {
            ReceptionTransfert receptionTransfert = new ReceptionTransfert()
            {
                NumBL = NumBL,
                ParcId = ParcId,
                DateOp = DateOp,
                HeureOP = HeureOP,
                Transporteur = Transporteur,
                Mat = Mat,
                TypeProduitId = TypeProduitId,
                PCC = PCC,
                PCV = PCV,
                PQR = PQR,
                Termine = Termine,
                Observation = Observation,
                Provenance = Provenance

            };

            return receptionTransfert;
        }


        public  async Task<ReceptionTransfert> CreateReceptionTransfert(ReceptionTransfert receptionTransfert)
        {
            var transfert = db.ReceptionTransferts.Add(receptionTransfert);
            await db.SaveChangesAsync();
            return transfert.Entity;
        }

        public  async Task<List<ReceptionTransfert>> GetReceptionTransfertList()
        {
            return await db.ReceptionTransferts
                .Include(r => r.Parc)
                .Include(r => r.TypeProduit).ToListAsync();
        }

        public  async Task<ReceptionTransfert> GetReceptionTransfertById(int id)
        {
            return await db.ReceptionTransferts.FindAsync(id);
        }
        public  async Task<ReceptionTransfert> GetReceptionTransfertByNumBL(string NumBL)
        {
            return await db.ReceptionTransferts.FirstOrDefaultAsync(x => x.NumBL == NumBL);
        }

        public  async Task EditReceptionTransfert(ReceptionTransfert receptionTransfert)
        {
            db.Entry(receptionTransfert).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }

        public  async Task DeleteReceptionTransfert(ReceptionTransfert receptionTransfert)
        {
            db.ReceptionTransferts.Remove(receptionTransfert);
            await db.SaveChangesAsync();
        }

        public  string GetMax()
        {
            return db.ReceptionTransferts.Max(x => x.NumBL);
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
