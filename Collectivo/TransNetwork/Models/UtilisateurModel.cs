using System.ComponentModel.DataAnnotations;
namespace TransNetwork.Models
{
    public class UtilisateurModel
    {
		[Key]
		public int IdUtilisateur { get; set; }
		public string NomUtilisateur { get; set; }
		public string Email { get; set; }
		public string MotDePasse { get; set; }
		public int IdRole { get; set; }
		public string Mobile { get; set; }
		public string Nom { get; set; }
		public string Prenom { get; set; }
		public bool CompteActif { get; set; }
		public int? IdCivilite { get; set; }
		public DateTime DateNaissance { get; set; }
		public int? IdGouvernorat { get; set; }
		public string CodePostal { get; set; }
		public int? IdPays { get; set; }
		public int? IdDelegation { get; set; }
		public string Ville { get; set; }
		public string Adresse { get; set; }

		public string CodeReference { get; set; }
		public string LibelleRole { get; set; }
		public string LibellePays { get; set; }
		public string LibelleGouvrnorat { get; set; }
		public string LibelleCivilite { get; set; }
		public string LibelleDelegation { get; set; }
	}
}
