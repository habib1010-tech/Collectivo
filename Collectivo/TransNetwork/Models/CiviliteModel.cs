using System.ComponentModel.DataAnnotations;

namespace TransNetwork.Models
{
    public class CiviliteModel
    {
        [Key]
        public int IdCivilite { get; set; }
        public string LibelleCivilite { get; set; }
    }
}
