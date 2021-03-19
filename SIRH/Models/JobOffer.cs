using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SIRH.Models
{
    public class JobOffer
    {
        public int Id { get; set; }
        public string Reference { get; set; }
        public string Description { get; set; }
        [Required]
        public int MinSalary { get; set; }
        [Required]
        public int MaxSalary { get; set; }
        [Required]
        [StringLength(10)]
        public string PublicationDate { get; set; }
        [Required]
        [StringLength(10)]
        public string ExpirationDate { get; set; }
    }
}
