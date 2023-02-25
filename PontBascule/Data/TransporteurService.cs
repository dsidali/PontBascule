using Microsoft.EntityFrameworkCore;
using PontBascule.Model.Models;

namespace PontBascule.Model.DataAccess
{
    public  class TransporteurService
    {
        private ApplicationDbContext db;

        public TransporteurService(ApplicationDbContext _db)
        {
            db = _db;
        }

        public  Transporteur CreateTransporteurEntity(string Nom, string Prenom, bool Interne)
        {

            Transporteur transporteur = new Transporteur()
            {
                Nom = Nom,
                Prenom = Prenom,
                Interne = Interne
            };

            return transporteur;
        }

        public  async Task<Transporteur> CreateTransporteur(Transporteur transporteur)
        {
            var tr = db.Transporteurs.Add(transporteur);
            await db.SaveChangesAsync();

            return tr.Entity;
        }

        public  async Task<List<Transporteur>> GetTransporteurs()
        {
            return await db.Transporteurs.ToListAsync();
        }

        public  async Task<Transporteur> GetTransporteurById(int id)
        {
            return await db.Transporteurs.FindAsync(id);
        }

        public  async Task EditTransporteur(Transporteur transporteur)
        {
            db.Entry(transporteur).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }

        public  async Task DeleteTransporteur(Transporteur transporteur)
        {
            db.Transporteurs.Remove(transporteur);
            await db.SaveChangesAsync();
        }
    }
}
