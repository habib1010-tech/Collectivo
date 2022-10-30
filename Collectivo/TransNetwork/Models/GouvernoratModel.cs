using System.ComponentModel.DataAnnotations;

namespace TransNetwork.Models
{
    public class GouvernoratModel
    {
        [Key]
        public int IdGouvernorat { get; set; }
        public int IdPays { get; set; }
        public string LibelleGouvernorat { get; set; }
    }
}
