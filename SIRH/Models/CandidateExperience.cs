using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SIRH.Models
{
    public class CandidateExperience
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string CompanyName { get; set; }
        [Required]
        [StringLength(50)]
        public string Profession { get; set; }
        [Required]
        [StringLength(10)]
        public string StartDate { get; set; }
        [Required]
        [StringLength(10)]
        public string EndDate { get; set; }
        [Required]
        [ForeignKey("Experience")]
        public int? ExperienceId { get; set; }
        public virtual Experience Experience { get; set; }
        [Required]
        [ForeignKey("Domain")]
        public int? DomainId { get; set; }
        public virtual Domain Domain { get; set; }
        [Required]
        [ForeignKey("Candidate")]
        public int? CandidateId { get; set; }
        public virtual Candidate Candidate { get; set; }
    }
}
