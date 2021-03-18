using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SIRH.Models
{
    public class Candidature
    {
        public int Id { get; set; }
        [Required]
        public DateTime JobInterviewDate { get; set; }

        [Required]
        public DateTime CandidatureDate { get; set; }

    }
}
