using System.ComponentModel.DataAnnotations;

namespace TransNetwork.Models
{
    public class DelegationModel
    {
        [Key]
        public int IdDelegation { get; set; }
        public int IdGouvernorat { get; set; }
        public string LibelleDelegation { get; set; }
    }
}
