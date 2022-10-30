using System.ComponentModel.DataAnnotations;
namespace TransNetwork.Models
{
    public class ConducteurModel
    {
		[Key]
		public int IdConducteur { get; set; }
		public int IdUtilisateur { get; set; }
		public string CodeReference { get; set; }
		public string NomConducteur { get; set; }
		public string Mobile { get; set; }
	}
}
