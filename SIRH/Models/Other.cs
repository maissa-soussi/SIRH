using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SIRH.Models
{
    public class Other
    {
        public int Id { get; set; }

        
        [Url]
        public string FacebookUrl { get; set; }

        
        [Url]
        public string LinkedinUrl { get; set; }

        [Required]
        [ForeignKey("SalaryWish")]
        public int SalaryWishId { get; set; }
        public virtual SalaryWish SalaryWish { get; set; }

        [Required]
        [ForeignKey("DrivingLicence")]
        public int DrivingLicenceId { get; set; }
        public virtual DrivingLicence DrivingLicence { get; set; }
    }
}
