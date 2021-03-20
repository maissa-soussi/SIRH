using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SIRH.Models
{
	public class CandidateDiploma
	{
		public int Id { get; set; }
		[Required]
		[StringLength(10)]
		public string Date { get; set; }


		[Required]
		[StringLength(50)]
		public string University { get; set; }
		[Required]
		[ForeignKey("Domain")]
		public int? DomainId { get; set; }
		public virtual Domain Domain { get; set; }

		[Required]
		[ForeignKey("Diploma")]
		public int? DiplomaId { get; set; }
		public virtual Diploma Diploma { get; set; }
	}
}