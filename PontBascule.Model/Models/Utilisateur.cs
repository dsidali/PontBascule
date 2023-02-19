namespace PontBascule.Model.Models
{
    public class Utilisateur
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int ParcId { get; set; }
        public Parc Parc { get; set; }

        public int PrivilegeId { get; set; }
        public Privilege Privilege { get; set; }


    }
}
