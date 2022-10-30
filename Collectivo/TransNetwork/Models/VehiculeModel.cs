using System.ComponentModel.DataAnnotations;

namespace TransNetwork.Models
{
    public class VehiculeModel
    {
        [Key]
		public int IdVehicule { get; set; }
		public int IdCategorie { get; set; }
		public int IdMarque { get; set; }
		public int IdModele { get; set; }
		public string CodeReference { get; set; }
		public string Matricule { get; set; }
		public int NbrPlaces { get; set; }
		public int Annee { get; set; }
		public int Kilometrage { get; set; }

		public string LibelleCategorie { get; set; }
		public string LibelleMarque { get; set; }
		public string LibelleModele { get; set; }

	}
}
