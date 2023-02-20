using PontBascule.Model.Models;

namespace PontBascule.Model.DataAccess;

public interface IAchatCrud
{
    Achat CreateAchatEntity(string NumBonA, int ParcId, string Mat, string Transporteur, DateTime DateOP, TimeSpan HeureOP, string NumTicket, int PCC, int PCV, int PB, int PQRa, int PQS, bool Termine, string Observation,string FournisseurOuClient,string TypeTransport,string TypeCamion);
    Task<Achat> CreateAchat(Achat achat);
    Task<List<Achat>> GetAchatsList();
    Task<Achat> GetAchatById(int id);
    Task<Achat> GetAchatByNumBon(string NumBonA);
    Task EditAchat(Achat achat);
    Task DeleteAchat(Achat achat);
    string GetMax();
    string GenerateId();
}