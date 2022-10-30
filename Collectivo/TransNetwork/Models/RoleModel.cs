using System.ComponentModel.DataAnnotations;

namespace TransNetwork.Models
{
    public class RoleModel
    {
        [Key]
        public int IdRole { get; set; }
        public string LibelleRole { get; set; }
    }
}
