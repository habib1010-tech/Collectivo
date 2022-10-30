using System.ComponentModel.DataAnnotations;

namespace TransNetwork.Models
{
    public class ActiviteModel
    {
        [Key]
        public int IdActivite { get; set; }
        public int IdConducteur { get; set; }
        public int IdVehicule { get; set; }
        public bool ActivitePrincipale { get; set; }

        public DateTime? DateDebutActivite { get; set; }
        public DateTime? DateFinActivite { get; set; }
        public bool Active { get; set; }
        public string NomConducteur { get; set; }
        public string NomVehicule { get; set; }
    }
}
