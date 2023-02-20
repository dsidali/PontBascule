using Microsoft.EntityFrameworkCore;
using PontBascule.Model.Models;

namespace PontBascule.Model.DataAccess
{
    public  class ReceptionRondBetonCrud
    {

        private ApplicationDbContext db;

        public ReceptionRondBetonCrud(ApplicationDbContext _db)
        {
            db = _db;
        }

        public  ReceptionRondBeton CreateReceptionRondBetonEntity(string NumBonA, int ParcId, string Mat, string Transporteur, DateTime DateOp, TimeSpan HeureOP, string NumTicket, int PCC, int PCV, int PB, int PQRa, int PQS, bool Termine, string Observation,string FournisseurOuClient,string TypeTransport,string TypeCamion)
        {
            ReceptionRondBeton sortieRb = new ReceptionRondBeton()
            {
                NumBonA = NumBonA,
                ParcId = ParcId,
                Mat = Mat,
                Transporteur = Transporteur,
                DateOp = DateOp,
                HeureOP = HeureOP,
                NumTicket = NumTicket,
                PCC = PCC,
                PCV = PCV,
                PB = PB,
                PQRa = PQRa,
                PQS = PQS,
                Termine = Termine,
                Observation = Observation,
                FournisseurOuClient = FournisseurOuClient,
                TypeTransport = TypeTransport,
                TypeCamion = TypeCamion


            };
            return sortieRb;
        }

        public  async Task<ReceptionRondBeton> CreateReceptionRondBeton(ReceptionRondBeton ReceptionRondBeton)
        {
            var sortieRb = db.ReceptionRondBetons.Add(ReceptionRondBeton);
            await db.SaveChangesAsync();
            return sortieRb.Entity;
        }

        public  async Task<List<ReceptionRondBeton>> GetReceptionRondBetonList()
        {
            return await db.ReceptionRondBetons.Include(s => s.Parc).ToListAsync();
        }

        public  async Task<ReceptionRondBeton> GetReceptionRondBetonById(int id)
        {
            return await db.ReceptionRondBetons.FindAsync(id);
        }

        public  async Task<ReceptionRondBeton> GetReceptionRondBetonByNumBon(string NumBonA)
        {
            return await db.ReceptionRondBetons.Include(s => s.Parc).FirstOrDefaultAsync(x => x.NumBonA == NumBonA);
        }


        public  async Task EditReceptionBeton(ReceptionRondBeton ReceptionRondBeton)
        {
            db.Entry(ReceptionRondBeton).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }

        public  async Task DeleteAchat(ReceptionRondBeton ReceptionRondBeton)
        {
            db.ReceptionRondBetons.Remove(ReceptionRondBeton);
            await db.SaveChangesAsync();
        }


        public  string GetMax()
        {
            return db.ReceptionRondBetons.Max(x => x.NumBonA);
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
