using Microsoft.EntityFrameworkCore;
using PontBascule.Model.Models;

namespace PontBascule.Model.DataAccess
{
    public  class TypeProduitService
    {
        private ApplicationDbContext db;

        public TypeProduitService(ApplicationDbContext _db)
        {
            db = _db;
        }

        public  TypeProduit CreateTypeProduitEntity(string type)
        {

            TypeProduit typeProduit = new TypeProduit()
            {
                TypedeProduit = type
            };

            return typeProduit;
        }

        public  async Task<TypeProduit> CreateTypeProduit(TypeProduit TypeProduit)
        {
            var tr = db.TypeProduits.Add(TypeProduit);
            await db.SaveChangesAsync();

            return tr.Entity;
        }

        public  async Task<List<TypeProduit>> GetTypeProduits()
        {
            return await db.TypeProduits.ToListAsync();
        }

        public  async Task<TypeProduit> GetTypeProduitById(int id)
        {
            return await db.TypeProduits.FindAsync(id);
        }

        public  async Task EditTypeProduit(TypeProduit TypeProduit)
        {
            db.Entry(TypeProduit).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }

        public  async Task DeleteTypeProduit(TypeProduit TypeProduit)
        {
            db.TypeProduits.Remove(TypeProduit);
            await db.SaveChangesAsync();
        }
    }
}
