using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SIRH.Models
{
    public class Candidate
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Gender { get; set; }

        [Required]
        [StringLength(100)]
        public string Street { get; set; }

        [Required]
        public int ZipCode { get; set; }

        [Required]
        [StringLength(100)]
        public string City { get; set; }

        
        [StringLength(255)]
        public string PicturePath { get; set; }

        [Required]
        [StringLength(255)]
        public string CvPath { get; set; }

        [Required]
        [StringLength(8)]
        [Phone]
        public string Phone { get; set; }

        [Required]
        [StringLength(10)]
        
        public string BirthdayDate { get; set; }

        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        [Required]
        [ForeignKey("Country")]
        public int? CountryId { get; set; }
        public virtual Country Country { get; set; }

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
