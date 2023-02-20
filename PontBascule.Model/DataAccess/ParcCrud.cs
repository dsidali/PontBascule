using Microsoft.EntityFrameworkCore;
using PontBascule.Model.Models;

namespace PontBascule.Model.DataAccess
{
    public  class ParcCrud
    {

        private ApplicationDbContext db;

        public ParcCrud(ApplicationDbContext _db)
        {
            db = _db;
        }

        public  Parc CreateParcEntity(string Name, string Adresse, string Email, string Telephone, string Observation)
        {
            Parc parc = new Parc()
            {
                Name = Name,
                Adresse = Adresse,
                Email = Email,
                Telephone = Telephone,
                Observation = Observation

            };

            return parc;
        }

        public  async Task<Parc> CreateParc(Parc parc)
        {
            var prc = db.Parcs.Add(parc);
            await db.SaveChangesAsync();
            return prc.Entity;
        }

        public  async Task<List<Parc>> GetParcs()
        {
            return await db.Parcs.ToListAsync();
        }

        public  async Task EditParc(Parc parc)
        {
            db.Entry(parc).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }

        public  async Task DeleteParc(Parc parc)
        {
            db.Parcs.Remove(parc);
            await db.SaveChangesAsync();
        }
        public   Parc GetActualParc()
        {
         return   db.Parcs.FirstOrDefault(x => x.actuel == true);

        }
    }
}
