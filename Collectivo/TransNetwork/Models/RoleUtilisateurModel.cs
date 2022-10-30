using System.ComponentModel.DataAnnotations;

namespace TransNetwork.Models
{
    public class RoleUtilisateurModel
    {
        [Key]
        public int IdRole { get; set; }
        [Key]
        public int IdUtilisateur { get; set; }

        public string NomUtilisateur { get; set; }
        public string LibelleRole { get; set; }
    }
}
