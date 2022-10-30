using System.ComponentModel.DataAnnotations;
namespace TransNetwork.Models
{
    public class MarqueModel
    {
        [Key]
        public int IdMarque { get; set; }
        public string LibelleMarque { get; set; }
    }
}
