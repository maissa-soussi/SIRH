using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    }
}
