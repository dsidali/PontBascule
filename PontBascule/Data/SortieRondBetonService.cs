using Microsoft.EntityFrameworkCore;
using PontBascule.Model.Models;

namespace PontBascule.Model.DataAccess
{
    public  class SortieRondBetonService
    {
        private ApplicationDbContext db;

        public SortieRondBetonService(ApplicationDbContext _db)
        {
            db = _db;
        }

        public  SortieRondBeton CreateSortieRondBetonEntity(string NumBonA, int ParcId, string Mat, string Transporteur, DateTime DateOp, TimeSpan HeureOP, string NumTicket, int PCC, int PCV, int PB, int PQRa, int PQS, bool Termine, string Observation, string FournisseurOuClient,string Destination,string TypeTransport, string TypeCamion)
        {
            SortieRondBeton sortieRb = new SortieRondBeton()
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
                Destination = Destination,
                TypeTransport = TypeTransport,
                TypeCamion = TypeCamion,

            };
            return sortieRb;
        }

        public  async Task<SortieRondBeton> CreateSortieRondBeton(SortieRondBeton sortieRondBeton)
        {
            var sortieRb = db.SortieRondBetons.Add(sortieRondBeton);
            await db.SaveChangesAsync();
            return sortieRb.Entity;
        }

        public  async Task<List<SortieRondBeton>> GetSortieRondBetonList()
        {
            return await db.SortieRondBetons.Include(s => s.Parc).ToListAsync();
        }

        public  async Task<SortieRondBeton> GetSortieRondBetonById(int id)
        {
            return await db.SortieRondBetons.FindAsync(id);
        }

        public  async Task<SortieRondBeton> GetSortieRondBetonByNumBon(string NumBonA)
        {
            return await db.SortieRondBetons.Include(s => s.Parc)
                .FirstOrDefaultAsync(x => x.NumBonA == NumBonA);
        }


        public  async Task EditSortieBeton(SortieRondBeton sortieRondBeton)
        {
            db.Entry(sortieRondBeton).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }

        public  async Task DeleteAchat(SortieRondBeton sortieRondBeton)
        {
            db.SortieRondBetons.Remove(sortieRondBeton);
            await db.SaveChangesAsync();
        }

        public  string GetMax()
        {
            return db.SortieRondBetons.Max(x => x.NumBonA);
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
