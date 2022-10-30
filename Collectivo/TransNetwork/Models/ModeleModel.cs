using System.ComponentModel.DataAnnotations;
namespace TransNetwork.Models
{
    public class ModeleModel
    {
        [Key]
        public int IdModele { get; set; }
        public int IdMarque { get; set; }
        public string LibelleModele { get; set; }
    }
}
