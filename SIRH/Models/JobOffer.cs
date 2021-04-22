using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SIRH.Models
{
    public class JobOffer
    {
        public int Id { get; set; }
        public string Reference { get; set; }
        [Required]
        [ForeignKey("Country")]
        public int? CountryId { get; set; }
        public virtual Country Country { get; set; }
        [ForeignKey("Diploma")]
        public int? DiplomaId { get; set; }
        public virtual Diploma Diploma { get; set; }
        [ForeignKey("Experience")]
        public int? ExperienceId { get; set; }
        public virtual Experience Experience { get; set; }
        [Required]
        [ForeignKey("ContratType")]
        public int? ContratTypeId { get; set; }
        public virtual ContratType ContratType { get; set; }
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
        [Required]
        [ForeignKey("Domain")]
        public int? DomainId { get; set; }
        public virtual Domain Domain { get; set; }

    }
}
