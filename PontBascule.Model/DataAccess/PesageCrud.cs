using Microsoft.EntityFrameworkCore;
using PontBascule.Model.Models;

namespace PontBascule.Model.DataAccess
{
    public  class PesageCrud
    {
        private ApplicationDbContext db;

        public PesageCrud(ApplicationDbContext _db)
        {
            db = _db;
        }

        public  Pesage CreatePesageEntity(string NumBonA, int ParcId, string Mat, string Transporteur, DateTime DateOP, TimeSpan HeureOP, string NumTicket, int PCC, int PCV, int QP, bool Termine, string Observation,string TypeTransport, string TypeCamion)
        {
            Pesage pesage = new Pesage()
            {
                NumBonA = NumBonA,
                ParcId = ParcId,
                Mat = Mat,
                Transporteur = Transporteur,
                DateOP = DateOP,
                HeureOP = HeureOP,
                NumTicket = NumTicket,
                PCC = PCC,
                PCV = PCV,
                QP = QP,
                Termine = Termine,
                Observation = Observation,
                TypeTransport = TypeTransport,
                TypeCamion = TypeCamion

            };

            return pesage;
        }

        public  async Task<Pesage> CreatePesage(Pesage pesage)
        {
            var pese = db.Pesages.Add(pesage);
            await db.SaveChangesAsync();
            return pese.Entity;
        }

        public  async Task<List<Pesage>> GetPesageList()
        {
            return await db.Pesages.Include(p => p.Parc).ToListAsync();

        }

        public  async Task<Pesage> GetPesageById(string id)
        {
            Pesage pesage = await db.Pesages.FindAsync(id);
            return pesage;
        }

        public  async Task<Pesage> GetPesageByNum(string NumBonA)
        {
            Pesage pesage = await db.Pesages.FirstOrDefaultAsync(x => x.NumBonA == NumBonA);
            return pesage;
        }

        public  async Task EditPesage(Pesage pesage)
        {
            db.Entry(pesage).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }

        public  async Task DeletePesage(Pesage pesage)
        {
            db.Pesages.Remove(pesage);
            await db.SaveChangesAsync();
        }

        public  string GetMax()
        {
            return db.Pesages.Max(x => x.NumBonA);
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
