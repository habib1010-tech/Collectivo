using System.ComponentModel.DataAnnotations;
namespace TransNetwork.Models
{
    public class CategorieModel
    {
        [Key]
        public int IdCategorie { get; set; }
        public string LibelleCategorie { get; set; }
    }
}
