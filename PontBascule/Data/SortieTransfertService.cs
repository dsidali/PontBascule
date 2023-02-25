using Microsoft.EntityFrameworkCore;
using PontBascule.Model.Models;

namespace PontBascule.Model.DataAccess
{
    public  class SortieTransfertService
    {
        private ApplicationDbContext db;

        public SortieTransfertService(ApplicationDbContext _db)
        {
            db = _db;
        }

        public  SortieTransfert CreateSortieTransfertEntity(string NumBL, int ParcId, DateTime DateOp, TimeSpan HeureOP, string Transporteur, string Mat, int TypeProduitId, int PCC, int PCV, int PQS, bool Termine,string Observation,string Destination,string TypeTransport, string TypeCamion)
        {
            SortieTransfert sortie = new SortieTransfert()
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
                PQS = PQS,
                Termine = Termine,
                Observation = Observation,
                Destination = Destination,
                TypeTransport = TypeTransport,
                TypeCamion = TypeCamion



            };

            return sortie;
        }

        public  async Task<SortieTransfert> CreateSortieTransfert(SortieTransfert sortieTransfert)
        {
            var sortie = db.SortieTransferts.Add(sortieTransfert);
            await db.SaveChangesAsync();
            return sortie.Entity;
        }

        public  async Task<List<SortieTransfert>> GetSortieTransfertList()
        {
            return await db.SortieTransferts.Include(s => s.Parc)
                .Include(o=>o.TypeProduit).ToListAsync();
        }

        public  async Task<SortieTransfert> GetSortieTransfertById(int id)
        {
            return await db.SortieTransferts.FindAsync(id);
        }


        public  async Task<SortieTransfert> GetSortieTransfertByNumBL(string NumBL)
        {
            return await db.SortieTransferts.FirstOrDefaultAsync(x => x.NumBL == NumBL);
        }

        public  async Task EditSortieTransfert(SortieTransfert sortieTransfert)
        {
            db.Entry(sortieTransfert).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }

        public  async Task DeleteSortieTransfert(SortieTransfert sortieTransfert)
        {
            db.SortieTransferts.Remove(sortieTransfert);
            await db.SaveChangesAsync();
        }

        public  string GetMax()
        {
            return db.SortieTransferts.Max(x => x.NumBL);
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
