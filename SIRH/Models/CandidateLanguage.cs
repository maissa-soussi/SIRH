using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SIRH.Models
{
    public class CandidateLanguage
    {
        public int Id { get; set; }

        [Required]
        [ForeignKey("Candidate")]
        public int? CandidateId { get; set; }
        public virtual Candidate Candidate { get; set; }

        [Required]
        [ForeignKey("Language")]
        public int? LanguageId { get; set; }
        public virtual Language Language { get; set; }

        [Required]
        [ForeignKey("LanguageLevel")]
        public int? LanguageLevelId { get; set; }
        public virtual LanguageLevel LanguageLevel { get; set; }
    }
}
