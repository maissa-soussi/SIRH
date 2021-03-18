using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        /*[Required]
        [StringLength(255)]
        public string CvPath { get; set; }

        [Required]
        [StringLength(255)]
        public string CoverLetterPath { get; set; }*/

        [Required]
        [StringLength(8)]
        [Phone]
        public int Phone { get; set; }

        [Required]
        [StringLength(10)]
        
        public string BirthdayDate { get; set; }
    }
}
