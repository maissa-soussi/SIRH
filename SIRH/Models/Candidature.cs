using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SIRH.Models
{
    public class Candidature
    {
        public int Id { get; set; }
        [Required]
        public String JobInterviewDate { get; set; }

        [Required]
        public String CandidatureDate { get; set; }

        [Required]
        [ForeignKey("JobOffer")]
        public int? JobOfferId { get; set; }
        public virtual JobOffer JobOffer { get; set; }

        [Required]
        [ForeignKey("Candidate")]
        public int? CandidateId { get; set; }
        public virtual Candidate Candidate { get; set; }


    }
}
