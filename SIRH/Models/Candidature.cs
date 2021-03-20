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
        [StringLength(10)]
        public String JobInterviewDate { get; set; }
        [Required]
        [StringLength(10)]
        public String CandidatureDate { get; set; }
        [Required]
        [StringLength(255)]
        public string CoverLetterPath { get; set; }
        [ForeignKey("JobOffer")]
        public int? JobOfferId { get; set; }
        public virtual JobOffer JobOffer { get; set; }
        [Required]
        [ForeignKey("Candidate")]
        public int? CandidateId { get; set; }
        public virtual Candidate Candidate { get; set; }


        

    }
}
