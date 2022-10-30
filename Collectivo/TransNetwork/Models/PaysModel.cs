using System.ComponentModel.DataAnnotations;

namespace TransNetwork.Models
{
    public class PaysModel
    {
        [Key]
        public int IdPays { get; set; }
        public string LibellePays { get; set; }
    }
}
