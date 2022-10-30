using System.ComponentModel.DataAnnotations;
namespace TransNetwork.Models
{
    public class PassagerModel
    {
		[Key]
		public int IdPassager { get; set; }
		public int IdUtilisateur { get; set; }
		public string CodeReference { get; set; }
		public string NomPassager { get; set; }
		public string Mobile { get; set; }
	}
}
